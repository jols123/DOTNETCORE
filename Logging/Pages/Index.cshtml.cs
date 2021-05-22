using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logging.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        //Standard way of capturing category
        //public IndexModel(ILogger<IndexModel> logger)
        //{
        //    _logger = logger;
        //}

        public IndexModel(ILoggerFactory factory)
        {
            _logger = (ILogger<IndexModel>)factory.CreateLogger("Category");
        }

        public void OnGet()
        {
            //logging levels
            //_logger.LogTrace("This is a trace log");
            //_logger.LogDebug("This is a debug log");
            //_logger.LogInformation(LoggingId.DemoCode,"This is a information log");
            //_logger.LogWarning("This is a warning log");
            //_logger.LogError("This is a error log");
            //_logger.LogCritical("This is a crtitical log");

            _logger.LogError("The server went down temporarily at {Time}", DateTime.UtcNow);
            try
            {
                throw new Exception("You forgot to catch me");
            }
            catch (Exception ex)
            {

                _logger.LogInformation(ex,"There was a bad exception at {Time}",DateTime.UtcNow);
            }
        }
    }
    public class LoggingId
    {
        public const int DemoCode = 1001;   //o/p = Logging.Pages.IndexModel[1001]
    }
}
