using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using API;

namespace SampleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var caller = new ApiCaller("http://apitesting.leankitkanban.com");
            caller.Authenticate("paulstack@hotmail.com", "qwerty");
            var x = caller.GetBoardIdentifiers("13835201");
            //var boardIdeitifies = 
        }
    }
}
