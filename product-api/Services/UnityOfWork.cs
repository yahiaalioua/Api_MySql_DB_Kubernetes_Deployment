using Microsoft.EntityFrameworkCore;
using product_api.Brokers;
using product_api.Models;

namespace product_api.Services
{
    public class UnityOfWork : IUnityOfWork
    {
        private StorageBroker _storageBroker;

        public UnityOfWork(StorageBroker storageBroker)=>
            _storageBroker = storageBroker;

        public async Task SaveChangesAsync()
        {
            await _storageBroker.SaveChangesAsync();
        }

    }
}
