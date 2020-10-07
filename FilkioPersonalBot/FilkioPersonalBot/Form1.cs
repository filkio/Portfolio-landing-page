using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;

namespace FilkioPersonalBot
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            List<SubResponceDb> mylist = new List<SubResponceDb>();
            using (MyDbContext cont = new MyDbContext())
            {
                mylist = cont.SubResponces.ToList();
                foreach (var item in mylist)
                {
                    richTextBox1.Text += $"{item.Id}. {item.EMail}\n";
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<SubResponceDb> mylist = new List<SubResponceDb>();
            using (MyDbContext cont = new MyDbContext())
            {
                mylist = cont.SubResponces.ToList();
            }


            MailAddress from = new MailAddress("filkiopage@mail.ru","filkiopage");
            foreach (var item in mylist)
            {
                MailAddress to = new MailAddress($"{item.EMail}");
                MailMessage m = new MailMessage(from, to);
                m.Subject = "С подписки на filkio page";
                m.Body = richTextBox2.Text;
                m.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient("smpt.mail.ru", 587);
                smtp.Credentials = new NetworkCredential("mail", "pass"); //- add your email and pass.
                smtp.EnableSsl = true;
                smtp.Send(m);
                label1.Text = "Сообщения успешно отправлены";
            }
        }
    }
}
