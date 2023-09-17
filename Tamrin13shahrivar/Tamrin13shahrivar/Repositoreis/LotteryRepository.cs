using Microsoft.AspNetCore.Http.HttpResults;
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
        public Lottery Update(int id,Lottery item)
        {
            var result = db.Lottery.FirstOrDefault(y => y.Id == id);
            if (result == null)
            {
                return null;
            }
            result.TitleLottery = item.TitleLottery;
            db.SaveChanges();
            return result;
        }

        public Lottery Delete(int id)
        {
            var result= db.Lottery.FirstOrDefault(x => x.Id == id);
           var find= db.LotteryMembers.Where(x => x.lotteryId == id).ToList();
            if (find.Count == 0 && result != null)
            {
                db.Lottery.Remove(result);
                db.SaveChanges();
                return result;
            }
            return null;

        }
        

    }
}
