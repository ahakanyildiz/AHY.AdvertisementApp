using AHY.AdvertisementApp.DataAccess.Abstract;
using AHY.AdvertisementApp.Entities;
using System.Threading.Tasks;

namespace AHY.AdvertisementApp.DataAccess.UnitOfWork
{
    public interface IUow
    {
        Task SaveChangesAsync();
        IRepository<T> GetRepository<T>() where T : BaseEntity;
    }
}
