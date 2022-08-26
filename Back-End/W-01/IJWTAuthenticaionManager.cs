namespace CarFactory
{
    //Middleware da authentication islemlerini yonetecek classin implemente edecegi interface   
    public interface IJWTAuthenticaionManager
    {
        string Authentication(string username, string password);
    }

}
