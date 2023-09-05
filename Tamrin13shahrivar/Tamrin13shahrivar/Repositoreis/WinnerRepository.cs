
using Tamrin13shahrivar.Date;
using Tamrin13shahrivar.Model;

namespace Tamrin13shahrivar.Repositoreis
{
    public class WinnerRepository
    {
        private readonly WinnerDbContext db;
        public WinnerRepository(WinnerDbContext _db)
        {
            db = _db;
        }
        public Winner Create(Winner item)
        {

                db.Winners.Add(item);
                db.SaveChanges();

 
            return item;
        }
    }
}
