using Tamrin13shahrivar.Date;
using Tamrin13shahrivar.Model;

namespace Tamrin13shahrivar.Repositoreis
{
    public class LotteryRepository
    {
        private readonly WinnerDbContext db;
        public LotteryRepository(WinnerDbContext _db)
        {
            db = _db;
        }
        public Lottery Create(Lottery item)
        {
            try
            {

                db.Lottery.Add(item);
                db.SaveChanges();
            }
            catch (Exception ex)
            {

            }
            return item;
        }
        public Lottery Get(int id)
        {
 
            return db.Lottery.FirstOrDefault(x => x.Id == id)!;
        }

    }
}
