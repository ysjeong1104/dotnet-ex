using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvcMovie.Models
{
    public class AppModel
    {
        public AppModel(string message) 
        {
            this.Message = message;
   
        }
        public string Message {get;set;}


    }
}