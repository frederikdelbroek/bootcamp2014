using System;
using System.IO;

namespace MailService
{
    public class MailService
        : IMailService
    {
        public void SendMail(string emailAddress)
        {
            System.Threading.Thread.Sleep(3000);

            var filename = String.Format("{0} - {1} - {2}", GetType().Name, emailAddress, Guid.NewGuid());
            File.Create(Path.Combine(@"C:\Temp\OrderProcessing", filename));
        }
    }
}