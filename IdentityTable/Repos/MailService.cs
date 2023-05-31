using IdentityTable.MailModels;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityTable.Repos
{
    public class MailService : IMailService
    {
        private readonly MailSettings _mailSettings;
        public MailService(IOptions<MailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }
        public async Task SendEmailAsync(MailRequest mailRequest)
        {
            try
            {
                var email = new MimeMessage();
                email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
                email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
                email.Subject = mailRequest.Subject;
                var builder = new BodyBuilder();
                if (mailRequest.Attachments != null)
                {
                    byte[] fileBytes;
                    foreach (var file in mailRequest.Attachments)
                    {
                        if (file.Length > 0)
                        {
                            using (var ms = new MemoryStream())
                            {
                                file.CopyTo(ms);
                                fileBytes = ms.ToArray();
                            }
                            builder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
                        }
                    }
                }
                builder.HtmlBody = mailRequest.Body;
                email.Body = builder.ToMessageBody();
                using var smtp = new SmtpClient();
                smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
                smtp.Authenticate(_mailSettings.Mail, _mailSettings.Password);
                await smtp.SendAsync(email);
                smtp.Disconnect(true);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        public string GetIndirectHTMLMailBody()
        {
            try
            {
                string body = "";


                body += " <html><body><div style='width:60%'> Dear Team <span style='color:#a92727'> </span>,<br/></div> <br/>";

                body += " <div style=''>Please find below grievance details and take immediate action on it for resolution</div>";

                body += "     <div> <h4 style='color:#417bd0'>Grievance Registration details</h4>";
                body += "    ***************************************************************************************************************************";
                body += "      <table>";
                body += "          <tr>";
                body += "              <td>Grievance Received By </td>";
                body += "              <td>   :</td>";
                body += "              <td style='color:#a92727'><b>   </b></td>";

                body += "              <td>Grievance Received Date </td>";
                body += "              <td>   :</td>";
                body += "              <td style='color:#a92727'><b>   </b></td>";

                body += "              <td>Mode of Receipt </td>";
                body += "              <td>   :</td>";
                body += "              <td style='color:#a92727'><b>   </b></td>";
                body += "          </tr>";
                body += "          <tr>";
                body += "          <tr>";


                body += "          <tr>";
                body += "              <td>Policy Type </td>";
                body += "              <td>   :</td>";
                body += "              <td style='color:#a92727'><b>   </b></td>";

                body += "              <td>Client Name </td>";
                body += "              <td>   :</td>";
                body += "              <td style='color:#a92727'><b>  </b></td>";

                body += "              <td>Grievance Type ( Level 1) </td>";
                body += "              <td>   :</td>";
                body += "              <td style='color:#a92727'><b>   </b></td>";
                body += "          </tr>";
                body += "          <tr>";
                body += "          <tr>";


                body += "          <tr>";
                body += "              <td>Complainent Name </td>";
                body += "              <td>   :</td>";
                body += "              <td style='color:#a92727'><b>   </b></td>";

                body += "              <td>Mobile Number </td>";
                body += "              <td>   :</td>";
                body += "              <td style='color:#a92727'><b>   </b></td>";

                body += "              <td>Complainent E mail ID </td>";
                body += "              <td>   :</td>";
                body += "              <td style='color:#a92727'><b>   </b></td>";
                body += "          </tr>";
                body += "          <tr>";
                body += "          <tr>";



                body += "          <tr>";
                body += "              <td>Intimation Email Subject Line </td>";
                body += "              <td>   :</td>";
                body += "              <td style='color:#a92727'; colspan='7'; text-align:justify;><b> </b></td>";


                body += "          </tr>";
                body += "          <tr>";
                body += "          <tr>";

                body += "          <tr>";
                body += "              <td>Detailed description of Issue </td>";
                body += "              <td>   :</td>";
                body += "              <td style='color:#a92727'; colspan='7'; text-align:justify;><b>   </b></td>";


                body += "          </tr>";
                body += "          <tr>";
                body += "          <tr>";



                body += "           </table>";
                body += "    ***************************************************************************************************************************";
                body += "</div><br />";



                body += " <br/>Regards<br />";
                body += "Anand rathi insurance brokers ltd</div></body></html>";






                return body;
            }
            catch (Exception ex)
            {

                return ex.Message.ToString();
            }

        }

    }
}
