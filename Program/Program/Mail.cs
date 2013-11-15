using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace Model
{
    class Mail
    {
        #region Fields
        //private string _senderMail;
        #endregion

        #region Properties
        public string senderMail 
        {
            get { return "VoluntaryMail@gmail.com"; }
            //set { _senderMail = value; }
        }
        private string receiverMail { get; set; }
        private string subject { get; set; }
        private string body { get; set; }

        private string mailCredentials { get { return "nrkfeBD6gTVybBWmJB9dF6DD"; } }
        #endregion

        #region Constructors
        public Mail(string receiverMail, string subject, string body)
        {
            this.receiverMail = receiverMail;
            this.subject = subject;
            this.body = body;
        }
        #endregion

        #region Methods
        public void SendMail()
        {
            // inspiration fra: http://tutplusplus.blogspot.dk/2010/09/c-tutorial-mail-sender-send-e-mails.html
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com");
                client.Port = 587;
                client.Credentials = new System.Net.NetworkCredential(senderMail, mailCredentials);
                client.EnableSsl = true;
                MailMessage hej = new MailMessage(this.senderMail, this.receiverMail, this.subject, this.body);
                client.Send(hej);
            }
        }
#endregion
    }
}
