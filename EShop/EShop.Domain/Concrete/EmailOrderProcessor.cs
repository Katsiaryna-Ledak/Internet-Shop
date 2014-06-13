using System.Net.Mail;
using System.Text;
using EShop.Domain.Abstract;
using EShop.Domain.Entities;
using System.Net;

namespace EShop.Domain.Concrete
{
    public class EmailSettings
    {
        public string MailToAddress = "ekaterina.ledak@gmail.com";
        public string MailFromAddress = "ekaterina.ledak@gmail.com";
        public bool UseSsl = true;
        public string Username = "ekaterina.ledak@gmail.com";
        public string Password = "ekaterina.ledak@gmail.com";
        public string ServerName = "pop.gmail.com";
        public int ServerPort = 995;
        public bool WriteAsFile = true;
        public string FileLocation = @"c:\eshop_emails";
    }

    public class EmailOrderProcessor : IOrderProcessor
    {
        private EmailSettings emailSettings;
        public EmailOrderProcessor(EmailSettings settings)
        {
            emailSettings = settings;
        }

        public void ProcessOrder(Cart cart, ShippingDetails shippingInfo)
        {
            StringBuilder body = new StringBuilder()
              .AppendLine("A new order has been submitted")
              .AppendLine("---")
              .AppendLine("Items:");

            foreach (var line in cart.Lines)
            {
                var subtotal = line.Product.Price * line.Quantity;
                body.AppendFormat("{0} x {1} (subtotal: {2:c}", line.Quantity, line.Product.Name, subtotal);
            }

            body.AppendFormat("Total order value: {0:c}", cart.ComputeTotalValue())
              .AppendLine("---")
              .AppendLine("Ship to:")
              .AppendLine(shippingInfo.Name)
              .AppendLine(shippingInfo.Line1)
              .AppendLine(shippingInfo.City)
              .AppendLine(shippingInfo.State ?? "")
              .AppendLine(shippingInfo.Country)
              .AppendLine(shippingInfo.Zip)
              .AppendLine("---")
              .AppendFormat("Gift wrap: {0}", shippingInfo.GiftWrap ? "Yes" : "No");

            MailMessage mailMessage = new MailMessage(
              emailSettings.MailFromAddress, // From
              emailSettings.MailToAddress, // To
              "New order submitted!", // Subject
              body.ToString()); // Body

            if (emailSettings.WriteAsFile)
            {
                mailMessage.BodyEncoding = Encoding.ASCII;
            }
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;
            MailAddress from = new MailAddress("ekaterina.ledak@gmail.com", "Katsiaryna");
            MailAddress to = new MailAddress("ekaterina.ledak@gmail.com", "Katsiaryna");
            MailMessage message = new MailMessage(from, to);
            message.Body = body.ToString();
            message.Subject = "Gmail test email with SSL and Credentials";
            NetworkCredential myCreds = new NetworkCredential("ekaterina.ledak@gmail.com", "labirint2177", "");
            client.Credentials = myCreds;
            client.Send(message);

        }
    }
}