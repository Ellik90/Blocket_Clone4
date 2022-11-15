namespace LOGIK;
interface ILogInService
{
    public User MakeNewLogIn(User user);

    public Admin MakeNewLogIn(Admin admin);

    public User UserLogIn(User user);

    public Type AdminLogIn(Type t);

    public int UserLogInIsValid(User user);

    public int AdminLogInIsValid(Admin admin);


}