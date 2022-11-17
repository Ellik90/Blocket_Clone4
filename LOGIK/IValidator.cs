using TYPES;
namespace LOGIK;

public interface IValidator
{
    public bool ValidateSocialSecurityNumber(string socNo);
    public bool ValidateEmail(string email);
}