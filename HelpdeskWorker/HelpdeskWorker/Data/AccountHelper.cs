using HelpdeskWorker.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpdeskWorker.Data
{
    public class AccountHelper
    {
        private HelpDeskSystemContext dbContext;
        public List<Account> GetByIdCompany(int IdCompany)
        {
            using (dbContext = new HelpDeskSystemContext())
            {
                try
                {
                    List<Account> account = dbContext.Accounts.Where(r => r.IdCompany == IdCompany).ToList();

                    return account;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
