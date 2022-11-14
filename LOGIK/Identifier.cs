using System.Net;
using System.Net.Mail; //för att använda mailadress klassen och validera mailadressser samt använda klassen smtpclient och skicka mail
//using Outlook = Microsoft.Office.Interop.Outlook;
namespace LOGIK;
public class Identifier : IIdentifier
{
    SmtpClient _smtpClient = new SmtpClient("smtp-mail.outlook.com");
    public SmtpClient SmtpClient
    {
        get{return _smtpClient;}
        set{_smtpClient = value;}
    }
      public bool ValidateEmail(string emailAdress)
    {
        bool isValid = true;
        try
        {
            // om mailadressen som kommer in känns igen som en mailadress så returneras true
            MailAddress mailAdress = new MailAddress(emailAdress);
        }
        catch
        {
            //annars returneras falsk, den är då inte validerad som riktig mailadress
            isValid = false;
        }
        return isValid;
    }

   //FUNKAR EJ ATT SKICKA MAIL GENOM ATT SÄTTA DENNA SMTPCLIENT TILL PROPERTYN och sedan skicka mail via smtpclient??
    // public SmtpClient SetUpSmtpClient()
    // {
    //     //mailadressen är servern för utgående epost
    //     SmtpClient smtpClient = new SmtpClient("smtp-mail.outlook.com");
    //     smtpClient.Port = 587;// port 587 för utgående epost 
    //     smtpClient.Host = "smtp-mail.outlook.com";
    //     smtpClient.EnableSsl = true;
    //     smtpClient.Credentials = new System.Net.NetworkCredential("testing_sendpwd_123@outlook.com", "Testing123321");
    //     //System.Net.NetworkCredential credential = new System.Net.NetworkCredential("testing_sendpwd_123@outlook.com", "Test123321");
       
    //     return SmtpClient = smtpClient;
    // }
    public int SendEmailWithCode(string mail)
    {
        int code = 1010;
         SmtpClient smtpClient = new SmtpClient("smtp-mail.outlook.com");
        smtpClient.Port = 587;// port 587 för utgående epost 
        smtpClient.Host = "smtp-mail.outlook.com";
        smtpClient.EnableSsl = true;
        smtpClient.Credentials = new System.Net.NetworkCredential("testing_sendpwd_123@outlook.com", "Testing123321");
        
        var message = new MailMessage()
        {
            From = new MailAddress("testing_sendpwd_123@outlook.com"),
            Subject = $"Validation Email. Blocket-Klon.Com",
            Body =  $"Here is your unique code to login at Blocket-Klon.com: {1010}"
        };
        message.To.Add(mail);
        smtpClient.Send(message);
        return code;
    }
    public bool ValidateSocialSecurityNumber(string socialSecurityNumber)
    {   
        bool isValid = false;
        //måste ha 12 siffror
        int socialSecurityNumberCount = 12;
        if(socialSecurityNumber.Count() == socialSecurityNumberCount && socialSecurityNumber.All(char.IsDigit) == true)
        {
            isValid = true;
        }
        //måste endast innehålla siffror 

        return isValid;
    }

    public bool CheckIfUserExists(IUserHandeler userHandeler, User user)
    {
        int id = userHandeler.UserLogInExists(user);
        if(id == 0)
        {
            return false;
        }
        else
        {
            return true;   // den ska flyttas
        }
    }
}

