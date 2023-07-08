using AutoMapper;
using MediatR;
using SurveyApp.Application.DTOs.Response;
using SurveyApp.Application.Interfaces;
using SurveyApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Application.Features.Survey.Queries.GetResults
{
    public class GetSurveyResultsQueryHandler : IRequestHandler<GetSurveyResultsQuery, SurveyResult>
    {
        private readonly ISurveyRepository _surveyRepository;
        private readonly IMapper _mapper;

        public GetSurveyResultsQueryHandler(ISurveyRepository surveyRepository, IMapper mapper)
        {
            _surveyRepository = surveyRepository;
            _mapper = mapper;
        }

        public async Task<SurveyResult> Handle(GetSurveyResultsQuery request, CancellationToken cancellationToken)
        {
            var survey = await _surveyRepository.GetSurveyByTokenForResult(request.Token);
            if (survey == null)
            {
                return null;
            }

            var surveyResult = new SurveyResult
            {
                QuestionResults = new List<QuestionResult>()
            };

            foreach (var question in survey.Questions)
            {
                var questionResult = new QuestionResult
                {
                    QuestionText = question.Text,
                    AnswerOptionResults = new List<AnswerOptionResult>(),
                    TextAnswers = new List<string>()
                };

                if (question.Type == QuestionType.MultipleChoice)
                {
                    var answerCounts = question.AnswerOptions
                        .Select(answerOption => question.Answers
                            .Count(answer => answer.QuestionId == question.Id && answer.AnswerOptionId == answerOption.Id))
                        .ToList();

                    var totalAnswers = answerCounts.Sum();

                    for (int i = 0; i < question.AnswerOptions.Count; i++)
                    {
                        var answerOption = question.AnswerOptions?.ElementAtOrDefault(i);
                        var percentage = totalAnswers == 0 ? 0 : (decimal)answerCounts[i] / totalAnswers * 100;

                        questionResult.AnswerOptionResults.Add(new AnswerOptionResult
                        {
                            AnswerOptionText = answerOption.Text,
                            Percentage = percentage
                        });
                    }
                }
                else if (question.Type == QuestionType.ShortOpenEnded || question.Type == QuestionType.LongOpenEnded)
                {
                    var textAnswers = question.Answers
                        .Where(answer => answer.QuestionId == question.Id && !string.IsNullOrEmpty(answer.Text))
                        .Select(answer => answer.Text)
                        .ToList();

                    questionResult.TextAnswers = textAnswers;
                }
                else if (question.Type == QuestionType.Rating)
                {
                    var ratings = question.Answers
                        .Where(answer => answer.QuestionId == question.Id && answer.Rating != null)
                        .Select(answer => answer.Rating.Value).ToList();

                    if (ratings.Any())
                    {
                        questionResult.RatingAverage = (decimal?)ratings.Average(x => (double)x);
                    }
                }

                surveyResult.QuestionResults.Add(questionResult);
            }

            return surveyResult;
        }
    }
}
