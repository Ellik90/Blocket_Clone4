using TYPES;
using DATABASE;
namespace LOGIK;
public interface ILogInService
{
    public User MakeNewLogIn(User user);

    public Admin MakeNewLogIn(Admin admin);

    public User UserLogIn(User user);

    public Admin AdminLogIn(Admin admin);

    public int UserLogInIsValid(User user);

    public int AdminLogInIsValid(Admin admin);


}