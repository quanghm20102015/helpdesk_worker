using HelpdeskWorker.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpdeskWorker.Data
{
    public class ContactHelper
    {
        private HelpDeskSystemContext dbContext;
        public Contact GetByEmail(string Email, int IdCompany)
        {
            using (dbContext = new HelpDeskSystemContext())
            {
                try
                {
                    var result = dbContext.Contacts.Where(x=> x.Email == Email && x.IdCompany == IdCompany).FirstOrDefault();
                    return result;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }
        public void Insert(Contact obj)
        {
            using (dbContext = new HelpDeskSystemContext())
            {
                try
                {
                    var result = dbContext.Contacts.Add(obj);
                    dbContext.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
