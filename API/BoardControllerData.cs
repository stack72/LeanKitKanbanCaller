using API.Interfaces;

namespace API
{
    public class BoardControllerData: IBoardControllerData
    {
        //private static void ()
        //{
        //    return new BoardControllerData
        //                {
        //                    Address = "http://apitesting.leankitkanban.com",
        //                    Username = "paulstack@hotmail.com",
        //                    Password = "qwerty",
        //                    BoardId = 13835201,
        //                    LaneId = 13838102,
        //                    Position = 0,
        //                    OverrideComment = "Some override comment"
        //                };
        //}

        public string Address { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
