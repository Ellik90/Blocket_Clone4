namespace LOGIK;
public class UserService
{
    //här i är funktioner mellan anv och db, tex makenewuser(string name, string email) eller makenewuser(User user)samt kontrollerare osv;

    IUserHandeler _userHandele;

    IIdentifier _identifier;

    UserService(IIdentifier identifier, IUserHandeler userHandeler)
    {
        _identifier = identifier;
        _userHandele = userHandeler;
    }

    public void MakeUser(string email, string passWord)
    {
        // Console.WriteLine("name: ");
        // string? name = Console.ReadLine();
        // Console.WriteLine("social security number: ");
        // string? socialSecurityNumber = Console.ReadLine();
        // Console.WriteLine("adress: ");
        // string? adress = Console.ReadLine();
        // bool check = true;
        // User user1 = new(name, socialSecurityNumber, adress, email, 1234);
        // _userHandele.BecomeNewUser(user1);  // hämta id till user så det även finns i programmet här
        Console.WriteLine("name: ");
        string? name = Console.ReadLine();
        Console.WriteLine("social security number: ");
        string? socialSecurityNumber = Console.ReadLine();
        Console.WriteLine("adress: ");
        string? adress = Console.ReadLine();
        bool check = true;
        User user1 = new(name, socialSecurityNumber, adress, email, 1234);
        _userHandele.BecomeNewUser(user1);

    }

    // // i metoden bli user så har det redan kommit in personnr, mail, lösen
    // User newUser = new();
    // MessagePage messagePage = new();
    // UserHandeler userHandeler = new();

    // public UserPage(User user)
    // {
    //     newUser = user;
    // }
    // public int ShowUserPage()
    // {
    //     Console.WriteLine($"Lägg in annons [1]  Sök annons [2]  Dina meddelanden [3]");

    //     Console.WriteLine($"{newUser.Name}");
    //     Console.WriteLine($"Redigera profil [4]");
    //     Console.WriteLine();
    //     Console.WriteLine("Mina annonser [5]  Sparade annonser [6] Sålda objekt [7]");

    //     string answer = Console.ReadLine();
    //     int goToPage = 0;
    //     switch (answer)
    //     {

    //         case "3":
    //             goToPage = 3;
    //             // om man väljer tex 1
    //             // så visaas medde med nr 1
    //             break;
    //         case "4":


    //             string anAnswer = ConsoleInput.GetString($" [1]Delete my account  [2]Update my Email  [3]Update my adress  ");

    //             switch (anAnswer)
    //             {
    //                 case "1":

    //                 break;
    //             }
    //             break;
    //             case "5":
    //             goToPage = 4;
    //             break;

    //     }
    //     return goToPage;

    // }
}