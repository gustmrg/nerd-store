namespace NSE.WebApp.MVC.Models;

public class LoginUserResponse
{
    public string AccessToken { get; set; }
    public double ExpiresIn { get; set; }
    public UserToken UserToken { get; set; }
}