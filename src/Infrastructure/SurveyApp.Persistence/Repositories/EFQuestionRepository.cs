﻿using SurveyApp.Application.Interfaces;
using SurveyApp.Domain.Entities;
using SurveyApp.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Persistence.Repositories
{
    public class EFQuestionRepository : EFGenericRepository<Question>, IQuestionRepository
    {
        public EFQuestionRepository(AppDbContext context) : base(context)
        {
        }
    }
}
