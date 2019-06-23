namespace SysPedidos.Model.IRepository
{
    public interface ILoginRepository
    {
        bool SignIn(Login User);
        void SignOut();
    }
}
