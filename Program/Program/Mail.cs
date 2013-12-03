using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace Model
{
    public class Mail
    {
        #region Fields
        //private string _senderMail;
        #endregion

        #region Properties
        private SmtpClient Client;
        public string senderMail 
        {
            get { return "VoluntaryMail@gmail.com"; }
            //set { _senderMail = value; }
        }
        private string mailCredentials { get { return "nrkfeBD6gTVybBWmJB9dF6DD"; } }

        #endregion

        #region Constructors
        public Mail()
        {
            // inspiration from: http://tutplusplus.blogspot.dk/2010/09/c-tutorial-mail-sender-send-e-mails.html
            this.Client = new SmtpClient("smtp.gmail.com");
            this.Client.Port = 587;
            this.Client.Credentials = new System.Net.NetworkCredential(senderMail, mailCredentials);
            this.Client.EnableSsl = true;
        }
        #endregion

        #region Methods
        public void SendMail(string receiverMail, string subject, string body)
        {
            {
                if (!ValidateEmail(receiverMail))
                    throw new ArgumentException("Not a valid email!");
                MailMessage message = new MailMessage(this.senderMail, receiverMail, subject, body);
                this.Client.Send(message);
            }
        }
        #endregion

        #region Helpers
        //From Cogwheel at http://stackoverflow.com/questions/1365407/c-sharp-code-to-validate-email-address
        private bool ValidateEmail(string email)
        {
            try
            {
                var addr = new MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion
    }
}
