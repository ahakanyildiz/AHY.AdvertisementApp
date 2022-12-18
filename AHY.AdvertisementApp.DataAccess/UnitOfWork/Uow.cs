using AHY.AdvertisementApp.DataAccess.Abstract;
using AHY.AdvertisementApp.DataAccess.Concrete;
using AHY.AdvertisementApp.DataAccess.Contexts;
using AHY.AdvertisementApp.Entities;
using System.Threading.Tasks;

namespace AHY.AdvertisementApp.DataAccess.UnitOfWork
{
    public class Uow : IUow
    {
        private readonly AdvertisementContext _context;

        public Uow(AdvertisementContext context)
        {
            _context = context;
        }

        public IRepository<T> GetRepository<T>() where T: BaseEntity
        {
            return new Repository<T>(_context);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
