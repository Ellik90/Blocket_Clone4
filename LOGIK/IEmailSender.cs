using System.Net.Mail;
namespace LOGIK;

public interface IEmailSender
{
    public SmtpClient SetUpSmtpClient();
    public int SendCodeViaEmail(string email);
    public int GenerateUniqueCode();
}