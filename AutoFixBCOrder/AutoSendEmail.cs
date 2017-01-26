using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace AutoFixBCOrder
{
    public partial class AutoSendEmail : Form
    {
        public AutoSendEmail()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress("chunglaithanh@gmail.com");
                mail.To.Add("chunglaithanh@tamayoshi.co.jp");
                mail.Subject = "Test Mail - 1";
                mail.Body = "mail with attachment the meo nao nhanh vl";

                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("chunglaithanh@gmail.com", "laichunga@");
                SmtpServer.EnableSsl = false;
                //client.UseDefaultCredentials = true;
                SmtpServer.Send(mail);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
