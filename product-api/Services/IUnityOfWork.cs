namespace product_api.Services
{
    public interface IUnityOfWork
    {
        Task SaveChangesAsync();
    }
}