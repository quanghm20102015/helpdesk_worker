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

        public EmailInfo GetEmailInfoByMessageId(string MessageId)
        {
            using (dbContext = new HelpDeskSystemContext())
            {
                try
                {
                    var result = dbContext.EmailInfos.Where(x => x.MessageId == MessageId && x.MainConversation == true).FirstOrDefault();
                    return result;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }
        public bool CheckConversationResolve(string IdReference)
        {
            using (dbContext = new HelpDeskSystemContext())
            {
                try
                {
                    var result = dbContext.EmailInfos.Where(x => x.IdReference == IdReference && x.MainConversation == true).FirstOrDefault();
                    if(result.Status == 2)
                    {
                        return true;
                    }

                    return false;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
    }
}
