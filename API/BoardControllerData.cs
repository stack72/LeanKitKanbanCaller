using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using API.Interfaces;

namespace API
{
    public class BoardControllerData: IBoardControllerData
    {
        public static BoardControllerData GetDataExamples()
        {
            return new BoardControllerData
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
