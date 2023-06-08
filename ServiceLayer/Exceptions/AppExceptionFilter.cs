using Serilog;
using Serilog.Events;
using Serilog.Exceptions;
using Serilog.Sinks.Elasticsearch;
using ServiceLayer.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ServiceLayer.Exceptions
{
    public class AppExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var elasticUri = Environment.GetEnvironmentVariable("ElasticConfigurationUri");

            var errorConfig = Environment.GetEnvironmentVariable("errorConfig");

            LogEventLevel logEventLevel = LogHelper.GetLoggingType(errorConfig);

            Serilog.ILogger logger = new LoggerConfiguration()
                               .Enrich.FromLogContext()
                               .Enrich.WithExceptionDetails()
                               .Enrich.WithMachineName()
                               .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(elasticUri))
                               {
                                   AutoRegisterTemplate = true,
                                   MinimumLogEventLevel = logEventLevel
                               })
                            .CreateLogger();

            logger.Error(context.Exception.ToString());

        }
    }
}
