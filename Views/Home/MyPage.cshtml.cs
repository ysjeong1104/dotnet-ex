using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace mvcMovie.Views.Home
{
    public class MyPage : PageModel
    {
        private readonly ILogger<MyPage> _logger;

        public MyPage(ILogger<MyPage> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}