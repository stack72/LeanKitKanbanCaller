using API.Interfaces;

namespace API
{
    public class BoardAuthenticator: IBoardAuthenticator
    {
        public string Address { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
