/*
 * 13-10-2021
 * - включение лога операторов SQL
 * - работа с неотслеживаемыми сущностями
 */

using EFTemplates.Logging.Context;
using System.Linq;

namespace EFTemplates.Logging
{
    class Program
    {
        static void Main(string[] args)
        {
            #region CreateData

            //var ctx = new EFTemplatesLoggingContextNoTrack();
            //ctx.Accounts.Add(new Account() { AccountNumber = "123", Comment = "comment 1"});
            //ctx.Accounts.Add(new Account() { AccountNumber = "124", Comment = "comment 2"});
            //ctx.Accounts.Add(new Account() { AccountNumber = "125", Comment = "comment 3"});
            //ctx.Accounts.Add(new Account() { AccountNumber = "126", Comment = "comment 4"});

            #endregion

            #region Tracking
            var ctx = new EFTemplatesLoggingContext();
            var Account = ctx.Accounts.Where(i => i.AccountNumber == "124").FirstOrDefault();
            Account.Comment = "new comment 1";
            ctx.SaveChanges();

            //SQL code:
            //SET NOCOUNT ON;
            //UPDATE[Accounts] SET[Comment] = @p0
            //WHERE[Id] = @p1;
            //SELECT @@ROWCOUNT;

            #endregion

            #region NoTracking
            var ctxNoTrack = new EFTemplatesLoggingContextNoTrack();
            var AccountNoTrack = ctxNoTrack.Accounts.Where(i => i.AccountNumber == "125").FirstOrDefault();
            AccountNoTrack.Comment = "new comment 3";
            ctxNoTrack.Accounts.Update(AccountNoTrack);
            ctxNoTrack.SaveChanges();

            //SQL code:
            //SET NOCOUNT ON;
            //UPDATE[Accounts] SET[AccountNumber] = @p0, [Comment] = @p1
            //WHERE[Id] = @p2;
            //SELECT @@ROWCOUNT;

            #endregion
        }
    }
}
