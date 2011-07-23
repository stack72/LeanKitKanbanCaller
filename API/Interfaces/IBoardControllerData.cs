using System;

namespace API.Interfaces
{
    public interface IBoardControllerData
    {
        string Address { get; }
        string Username { get; }
        string Password { get; }
        Int64 BoardId { get; set; }
        Int64 BoardVersion { get; set; }
        Int64 CardId { get; set; }
        Int64 LaneId { get; set; }
        int Position { get; set; }
        string OverrideComment { get; set; }
    }
}
