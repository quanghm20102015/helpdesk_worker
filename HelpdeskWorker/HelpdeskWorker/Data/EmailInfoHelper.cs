using HelpdeskWorker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpdeskWorker.Data
{
    public class EmailInfoHelper
    {
        private HelpDeskSystemContext dbContext;
        public void Insert(EmailInfo obj)
        {
            using (dbContext = new HelpDeskSystemContext())
            {
                try
                {
                    var result = dbContext.EmailInfos.Add(obj);
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
