using ECommerceApp.Domain.Entities;
using ECommerceApp.Domain.Repository;
using ECommerceApp.Infrastructure.DataBase.EntityFramework.EFContext;

namespace ECommerceApp.Infrastructure.DataBase.EntityFramework.EFRepository
{
    public class AnnouncementDal : RepositoryBase<Announcement>, IAnnouncementDal
    {
        public AnnouncementDal(EFIdentityContext context) : base(context)
        {
        }

        public void FindByIdForVaqif(int Id)
        {
            throw new System.NotImplementedException();
        }
    }
}