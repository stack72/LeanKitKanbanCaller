
using System;
using API.Interfaces;

namespace API.IntegrationTests
{
    public class BoardControllerTestData : IBoardControllerData
    {
        public static BoardControllerTestData GetDataExamples()
        {
            return new BoardControllerTestData
                   {
                       Address = "http://apitesting.leankitkanban.com",
                       Username = "paulstack@hotmail.com",
                       Password = "qwerty",
                       BoardId = 13835201,
                       LaneId = 13838102,
                       Position = 0,
                       OverrideComment = "Some override comment"
                   };
        }

        public string Address { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public Int64 BoardId { get; set; }
        public Int64 BoardVersion { get; set; }
        public Int64 CardId { get; set; }
        public Int64 LaneId { get; set; }
        public int Position { get; set; }
        public string OverrideComment { get; set; }
    }
}
