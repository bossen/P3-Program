using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class Mail
    {
        #region Properties
        #endregion

        #region Constructors
        #endregion

        #region Methods
        private void SendMail(/*object sender, EventArgs e*/)
        {
            throw new NotImplementedException();

            /*// inspiration fra: http://tutplusplus.blogspot.dk/2010/09/c-tutorial-mail-sender-send-e-mails.html
            try
            {
                string senderMail = "kostplantjekliste@gmail.com";
                string recieverMail = txtMailTjekRecieverMail.Text;
                
                MailMessage mail = new MailMessage(
                    senderMail,    //sender
                    recieverMail,  //modtager
                    CurrentUser.Name + (CurrentUser.Name.EndsWith("s") ? "' tjekliste" : "s tjekliste"),   //emne (Navn's tjekliste)
                    txtTjeklisteOutput.Text); //tekst

                SmtpClient client = new SmtpClient("smtp.gmail.com");
                client.Port = 587;
                client.Credentials = new System.Net.NetworkCredential(senderMail, "SW2A219AAU");
                client.EnableSsl = true;
                client.Send(mail);
                MessageBox.Show("Mailen blev sendt.", "Succes!", MessageBoxButtons.OK);
                txtMailTjekRecieverMail.Text = "";
            }
            catch (System.Net.Mail.SmtpException)
            {
                MessageBox.Show("Ugyldige informationer. Prøv igen.");
            }
            catch (Exception)
            {
                MessageBox.Show("Der skete en fejl; mailen blev ikke sendt.");
            }*/
        }
#endregion
    }
}
