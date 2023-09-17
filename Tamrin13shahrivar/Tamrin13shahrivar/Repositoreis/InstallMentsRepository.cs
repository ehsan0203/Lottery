using Tamrin13shahrivar.Date;
using Tamrin13shahrivar.Model;

namespace Tamrin13shahrivar.Repositoreis
{
    public class InstallMentsRepository
    {
        private readonly WinnerDbContext db;
        public InstallMentsRepository(WinnerDbContext _db)
        {
            db = _db;
        }
        public InstallMents Create(InstallMents item)
        {
            try
            {
                db.InstallMents.Add(item);
                db.SaveChanges();
            }
            catch (Exception ex)
            {

            }
            return item;
        }

        public InstallMents Delete(int id)
        {
            var result =db.InstallMents.FirstOrDefault(x => x.LotteryMemberId == id);
            db.InstallMents.Remove(result);
            db.SaveChanges() ;
            return result;
        }
    }
}
