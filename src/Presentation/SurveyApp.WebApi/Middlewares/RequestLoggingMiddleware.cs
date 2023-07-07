using Serilog.Context;

namespace SurveyApp.WebApi.Middlewares
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLoggingMiddleware> _logger;

        public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            using (LogContext.PushProperty("RequestId", Guid.NewGuid()))
            {
                context.Request.EnableBuffering();

                var request = await FormatRequest(context.Request);
                _logger.LogInformation("Incoming Request:\n{Request}", request);

                var originalBodyStream = context.Response.Body;

                using (var responseBody = new MemoryStream())
                {
                    context.Response.Body = responseBody;

                    await _next(context);

                    var response = await FormatResponse(context.Response);
                    _logger.LogInformation("Outgoing Response:\n{Response}", response);

                    await responseBody.CopyToAsync(originalBodyStream);
                }
            }
        }

        private static async Task<string> FormatRequest(HttpRequest request)
        {
            request.Body.Seek(0, SeekOrigin.Begin);
            var bodyText = await new StreamReader(request.Body).ReadToEndAsync();
            request.Body.Seek(0, SeekOrigin.Begin);

            return $"{request.Method} {request.Path}{request.QueryString}\n{bodyText}";
        }

        private static async Task<string> FormatResponse(HttpResponse response)
        {
            response.Body.Seek(0, SeekOrigin.Begin);
            var bodyText = await new StreamReader(response.Body).ReadToEndAsync();
            response.Body.Seek(0, SeekOrigin.Begin);

            return $"{response.StatusCode}\n{bodyText}";
        }
    }
}
