using HelpdeskWorker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpdeskWorker.Data
{
    public class DBHelper
    {
        private HelpDeskSystemContext dbContext;
        public List<ConfigMail> GetAllConfigMail()
        {
            using (dbContext = new HelpDeskSystemContext())
            {
                try
                {
                    var users = dbContext.ConfigMails.ToList();
                    if (users != null)
                        return users;
                    else
                        return new List<ConfigMail>();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
