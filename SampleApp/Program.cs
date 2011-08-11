using API;

namespace SampleApp
{
    class Program
    {
        static void Main()
        {
            var caller = new ApiCaller("http://apitesting.leankitkanban.com");
            caller.Authenticate("paulstack@hotmail.com", "qwerty");

            //var x = caller.GetBoardIdentifiers("13835201");
            var y = caller.GetBoardAttributes("13835201");
            //var z = caller.GetListOfItemsInBackLog("13835201");
        }
    }
}
