using Tamrin13shahrivar.Date;
using Tamrin13shahrivar.Model;

namespace Tamrin13shahrivar.Repositoreis
{
    public class LotteryMemberRepository
    {
        private readonly WinnerDbContext db;
        public LotteryMemberRepository(WinnerDbContext _db)
        {
            db = _db;
        }
        public LotteryMember Create(LotteryMember item)
        {
            try
            {
               
                db.LotteryMembers.Add(item);
                db.SaveChanges();
                
            }
            catch (Exception ex)
            {

            }
            return item;
        }

        public LotteryMember SumShares(LotteryMember item,int id)
        {

            var sumshares = db.LotteryMembers.Where(x=>x.lotteryId==id).Sum(x => x.NumberMemberShares);
            var result = new LotteryMember()
            {
                Id = item.Id,
                NumberMemberShares = sumshares
            };

            return result;
        }
        public LotteryMember Delete(int id)
        {
            var result = db.LotteryMembers.FirstOrDefault(x => x.Id==id);
            if (result == null)
            {
                return null;
            }
            db.LotteryMembers.Remove(result);
            db.SaveChanges();
            return result;
        }
        public int RandomsCode(int selectmember)
        {
            return new Random().Next(0, (int)selectmember);
        }
        //public List<Winner> winner(int lotteryId)
        //{
        //    List<Winner> winners = new List<Winner>();
        //    List<LotteryMember> Candid = new List<LotteryMember>();
        //    var lotorymember = db.LotteryMembers.Where(x => x.lotteryId == lotteryId).ToList();
        //    var winnerMember = db.Winners.Where(x => x.LotteryMemberid == lotteryId).ToList();
        //    foreach (var item in lotorymember)
        //    {
        //        for (int j = 1; j <= item.NumberMemberShares; j++)
        //        {
        //            Candid.Add(item);
        //        }
        //    }
        //    foreach (var item in winnerMember)
        //    {
        //        var removeitem = Candid.FirstOrDefault(x => x.Id == item.Id);
        //        Candid.Remove(removeitem);
        //    }
        //    DateTime data = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        //    for (int j = 1;j<=db.LotteryMembers.Where(x=> x.lotteryId== lotteryId).Sum(x => x.NumberMemberShares); j++)
        //    {
        //        int random = RandomsCode(Candid.Count);
        //        if (Candid.Count == 0)
        //        {
        //            // اگر اعضا به پایان رسیده باشد، از حلقه خارج شویم
        //            break;
        //        }

        //        // انتخاب عضو تصادفی از Candid
        //        LotteryMember selectedMember = Candid[random];
        //        var result = db.LotteryMembers.FirstOrDefault(x => x.Id == selectedMember.Id);
        //        // برگرداندن اطلاعات برنده به عنوان خروجی
        //        var domain = new LotteryMember
        //        {
        //            Id = result.Id,
        //            MemberFullName = result.MemberFullName,
        //            CodeMelli = result.CodeMelli,
        //            NumberMemberShares = result.NumberMemberShares,
        //            lotteryId = selectedMember.lotteryId,

        //        };
        //        data = data.AddMonths(1);
        //        var memWin = new Winner
        //        {
        //            LotteryMemberid = domain.Id,
        //            MemberWinner = domain.MemberFullName,
        //            MonthWin =data
        //        };
        //        return winners;
        //    }


        //}

public List<Winner> RunMonthlyLottery(int lotteryId)
        {
            List<Winner> winners = new List<Winner>();

            // پیدا کردن تمام ماه‌های دوره قرعه‌کشی
            var monthsToDraw = db.InstallMents
                .Where(x => x.NumLottery == lotteryId)
                .Select(x => x.DateLottery)
                .Distinct()
                .OrderBy(x => x)
                .ToList();

            foreach (var month in monthsToDraw)
            {
                // چک کردن اگر برای این ماه قبلاً برنده انتخاب شده است
                if (db.Winners.Any(x => x.LotteryMember.lotteryId == lotteryId && x.MonthWin == month))
                {
                    continue; // این ماه قرعه‌کشی شده است، به ماه بعدی بروید
                }
                var winnermember = db.Winners.Where(x => x.NumLottery ==  lotteryId ).Select(x => x.LotteryMemberid).ToList();
                // ایجاد لیست Candid برای این ماه
                List<LotteryMember> Candid = new List<LotteryMember>();
                var lotteryMembers = db.LotteryMembers
                    .Where(x => x.lotteryId == lotteryId)
                    .ToList();

                // ایجاد لیست Candid با تکرار اعضا بر اساس تعداد سهام هر عضو
                foreach (var item in lotteryMembers)
                {
                    for (int j = 1; j <= item.NumberMemberShares; j++)
                    {
                        Candid.Add(item);
                    }
                }
                foreach (var item in winnermember)
                {
                    var removeItem = Candid.FirstOrDefault(x => x.Id == item);
                        Candid.Remove(removeItem);

                }

                // انتخاب برنده برای این ماه
                if (Candid.Count > 0)
                {
                    int randomIndex = RandomsCode(Candid.Count);
                    LotteryMember selectedMember = Candid[randomIndex];

                    // ثبت برنده در دیتابیس
                    Winner winner = new Winner
                    {
                        NumLottery=selectedMember.lotteryId,
                        LotteryMemberid = selectedMember.Id,
                        MemberWinner = selectedMember.MemberFullName,
                        MonthWin = month
                    };

                    db.Winners.Add(winner);
                    db.SaveChanges();

                    // حذف انتخاب شده از Candid بر اساس تعداد سهام
                    for (int j = 0; j < selectedMember.NumberMemberShares; j++)
                    {
                        Candid.Remove(selectedMember);
                    }

                    // افزودن برنده به لیست برندگان
                    winners.Add(winner);
                }
            }

            return winners;
        }


    }
}
