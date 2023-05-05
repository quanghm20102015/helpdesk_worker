using MailKit.Net.Imap;
using MailKit;
using Microsoft.Extensions.Configuration;
using HelpdeskWorker.Data;
using HelpdeskWorker.Models;
using MailKit.Search;
using System.ComponentModel.DataAnnotations;

namespace HelpdeskWorker
{
    public class WorkerGetMail : BackgroundService
    {
        private readonly ILogger<WorkerGetMail> _logger;
        DBHelper db = new DBHelper();
        EmailInfoHelper dbEmailInfo = new EmailInfoHelper();
        AccountHelper dbAccountInfo = new AccountHelper();

        public WorkerGetMail(ILogger<WorkerGetMail> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                List<ConfigMail> listMail = db.GetAllConfigMail();

                foreach (ConfigMail mail in listMail)
                {
                    string Email = "";
                    string YourName = "";
                    string Password = "";
                    string Incoming = "";
                    int IncomingPort = 0;
                    string Outgoing = "";
                    int OutgoingPort = 0;
                    int IdConfigEmail = 0;
                    using (var client = new ImapClient())
                    {
                        if (listMail.Count != 0)
                        {
                            IdConfigEmail = mail.Id;
                            Email = mail.Email;
                            YourName = mail.YourName;
                            Password = mail.Password;
                            Incoming = mail.Incoming;
                            IncomingPort = mail.IncomingPort.Value;
                            Outgoing = mail.Outgoing;
                            OutgoingPort = mail.OutgoingPort.Value;
                        }
                        else
                        {
                            var configuration = new ConfigurationBuilder().AddJsonFile($"appsettings.json");
                            var config = configuration.Build();
                            Email = config["MailSettings:Mail"];
                            YourName = config["MailSettings:DisplayName"];
                            Password = config["MailSettings:Password"];
                            Incoming = config["MailSettings:Incoming"];
                            IncomingPort = int.Parse(config["MailSettings:IncomingPort"]);
                            Outgoing = config["MailSettings:Outgoing"];
                            OutgoingPort = int.Parse(config["MailSettings:OutgoingPort"]);
                        }

                        client.Connect(Incoming, IncomingPort, true);

                        client.Authenticate(Email, Password);

                        var inbox = client.Inbox;
                        inbox.Open(FolderAccess.ReadWrite);

                        var results = inbox.Search(SearchOptions.All, SearchQuery.Not(SearchQuery.Seen));

                        if(results.UniqueIds.Count != 0)
                        {
                            List<Account> listAccountAll = dbAccountInfo.GetByIdCompany(mail.IdCompany);

                            List<Account> listAccountOnline = listAccountAll.FindAll(r => r.Login == true);

                            List<Account> listAccount = new List<Account>();
                            if (listAccountOnline.Count == 0)
                            {
                                listAccount = listAccountAll;
                            }
                            else
                            {
                                listAccount = listAccountOnline;
                            }

                            int k = 0;
                            int assignIndex = 0;
                            foreach (var uniqueId in results.UniqueIds)
                            {
                                assignIndex = listAccount.Count == 0 ? 0 : k % listAccount.Count;
                                EmailInfo emailInfo = new EmailInfo();

                                var message = client.Inbox.GetMessage(uniqueId);

                                emailInfo.IdConfigEmail = IdConfigEmail;
                                emailInfo.MessageId = message.MessageId.ToString();
                                emailInfo.Date = message.Date.DateTime.ToUniversalTime();
                                emailInfo.From = message.From.ToString().Split('<')[1].Replace(">", "");
                                emailInfo.FromName = message.From.ToString().Split('<')[0];
                                emailInfo.To = message.To.ToString();
                                emailInfo.Cc = message.Cc.ToString();
                                emailInfo.Bcc = message.Bcc.ToString();
                                emailInfo.Subject = message.Subject.ToString();
                                emailInfo.TextBody = message.HtmlBody.ToString();
                                emailInfo.IdCompany = mail.IdCompany;
                                emailInfo.Status = 1;
                                emailInfo.Assign = listAccountOnline[assignIndex].Id;
                                k++;
                                dbEmailInfo.Insert(emailInfo);

                                inbox.AddFlags(uniqueId, MessageFlags.Seen, true);
                            }

                        }  

                        client.Disconnect(true);
                    }
                }

                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(60000, stoppingToken);
            }
            //List<ConfigMail> listMail = db.GetAllConfigMail();
            //foreach(ConfigMail obj in listMail)
            //{

            //}

            
        }

        //protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        //{
        //    List<ConfigMail>  listMail = db.GetAllConfigMail();
        //    //foreach(ConfigMail obj in listMail)
        //    //{

        //    //}

        //    string Email = "";
        //    string YourName = "";
        //    string Password = "";
        //    string Incoming = "";
        //    int IncomingPort = 0;
        //    string Outgoing = "";
        //    int OutgoingPort = 0;
        //    int IdConfigEmail = 0;
        //    using (var client = new ImapClient())
        //    {
        //        if (listMail.Count != 0)
        //        {
        //            IdConfigEmail = listMail[0].Id;
        //            Email = listMail[0].Email;
        //            YourName = listMail[0].YourName;
        //            Password = listMail[0].Password;
        //            Incoming = listMail[0].Incoming;
        //            IncomingPort = listMail[0].IncomingPort.Value;
        //            Outgoing = listMail[0].Outgoing;
        //            OutgoingPort = listMail[0].OutgoingPort.Value;
        //        }
        //        else
        //        {
        //            var configuration = new ConfigurationBuilder().AddJsonFile($"appsettings.json");
        //            var config = configuration.Build();
        //            Email = config["MailSettings:Mail"];
        //            YourName = config["MailSettings:DisplayName"];
        //            Password = config["MailSettings:Password"];
        //            Incoming = config["MailSettings:Incoming"];
        //            IncomingPort = int.Parse(config["MailSettings:IncomingPort"]);
        //            Outgoing = config["MailSettings:Outgoing"];
        //            OutgoingPort = int.Parse(config["MailSettings:OutgoingPort"]);
        //        }

        //        client.Connect(Incoming, IncomingPort, true);

        //        client.Authenticate(Email, Password);

        //        while (!stoppingToken.IsCancellationRequested)
        //        {
        //            var inbox = client.Inbox;
        //            inbox.Open(FolderAccess.ReadWrite);

        //            var results = inbox.Search(SearchOptions.All, SearchQuery.Not(SearchQuery.Seen));

        //            foreach (var uniqueId in results.UniqueIds)
        //            {
        //                EmailInfo emailInfo = new EmailInfo();

        //                var message = client.Inbox.GetMessage(uniqueId);

        //                emailInfo.IdConfigEmail = IdConfigEmail;
        //                emailInfo.MessageId = message.MessageId.ToString();
        //                emailInfo.Date = message.Date.DateTime.ToUniversalTime().AddHours(7);
        //                emailInfo.From = message.From.ToString().Split('<')[1].Replace(">", "");
        //                emailInfo.FromName = message.From.ToString().Split('<')[0];
        //                emailInfo.To = message.To.ToString();
        //                emailInfo.Cc = message.Cc.ToString();
        //                emailInfo.Bcc = message.Bcc.ToString();
        //                emailInfo.Subject = message.Subject.ToString();
        //                emailInfo.TextBody = message.HtmlBody.ToString();

        //                dbEmailInfo.Insert(emailInfo);

        //                inbox.AddFlags(uniqueId, MessageFlags.Seen, true);
        //            }

        //            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
        //            await Task.Delay(10000, stoppingToken);
        //        }
        //    }
        //}

    }
}