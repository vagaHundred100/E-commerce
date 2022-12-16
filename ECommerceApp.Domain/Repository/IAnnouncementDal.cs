using ECommerceApp.Domain.Entities;

namespace ECommerceApp.Domain.Repository
{
    public interface IAnnouncementDal : IRepositoryBase<Announcement>
    {
        void FindByIdForVaqif(int Id);
    }
}