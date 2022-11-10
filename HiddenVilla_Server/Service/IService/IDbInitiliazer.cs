namespace HiddenVilla_Server.Service.IService
{
    //bude slouzit jako database seed - k automatickemu vytvoreni defaultniho usera
    public interface IDbInitiliazer
    {
        void Initialize();
    }
}
