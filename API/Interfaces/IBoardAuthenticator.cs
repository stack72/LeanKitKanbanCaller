namespace API.Interfaces
{
    public interface IBoardAuthenticator
    {
        string Address { get; set; }
        string Username { get; set; }
        string Password { get; set; }
    }
}
