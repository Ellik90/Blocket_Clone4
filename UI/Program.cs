using LOGIK;
using TYPES;
using DATABASE;

internal class Program
{
    private static void Main(string[] args)
    {
        int loginOption = 0;
        string answer = string.Empty;
        bool loggedInAsUser = false;
        int LoggedInOptions = 0;
        bool loginPage = true;
        bool loggedInAsAdmin = true;
        int adminOptions = 0;

        User user = new();
        Admin admin = new();
        UserDB userdb = new();
        AdminDB admindb = new();
        LogInService logInService = new(userdb, admindb, new Validator(), new EmailSender());
        UserService userservise = new(userdb, userdb);
        AddvertiseDb addvertiseDb = new();
        AdvertiseService advertiseService = new(addvertiseDb);
        advertiseoperator advertiseoperator = new(advertiseService);
        MessageDB messageDB = new();
        MessageService messageService = new(messageDB, messageDB);
        AdminService adminService = new(userdb, userdb, admindb, admindb, addvertiseDb);
        UserOperator userOperator = new(logInService, userservise, new Validator());
        AdminOperator adminOperator = new(logInService, adminService, userservise, admindb, new Validator());
        MessageOperator messageOperator = new(messageService);

        //While loop hör ihop med swith för skapa och logga in funktioner
        Console.Clear();
        while (loginPage)
        {
            System.Console.WriteLine("Välkommen till Scam_Blocket");
            System.Console.WriteLine("");
            System.Console.WriteLine("[1] Skapa konto");
            System.Console.WriteLine("[2] Logga in");
            System.Console.WriteLine("[3] Logga in som admin");
            loginOption = ConsoleInput.GetInt("Go to userpage");
            switch (loginOption)
            {
                case 1:
                    //1. SKAPAKONTO
                    user = userOperator.CreateUser(user, logInService, userdb);
                    break;
                case 2:
                    int id = userOperator.UserLogIn();
                    if (id == 0)
                    {
                        Console.WriteLine("Wrong email or password.");
                        loginPage = true;
                    }
                    else
                    {
                        loggedInAsUser = true;
                        user.Id = id;
                        loginPage = false;
                    }
                    break;
                case 3:
                    int adminId = adminOperator.AdminLogin();
                    if (adminId == 0)
                    {
                        Console.WriteLine("Wrong email or password.");
                        loginPage = true;
                    }
                    else
                    {
                        loggedInAsAdmin = true;
                        admin.Id = adminId;
                        loginPage = false;
                    }
                    break;
            }
        }
        //While och switch för användare som är inloggade
        while (loggedInAsUser)
        {
            user = userOperator.GetUser(user);
            System.Console.WriteLine(user.Name.ToUpper() + "'s Account");
            System.Console.WriteLine("-------------------------------");
            System.Console.WriteLine("[1] Create Ad ");
            System.Console.WriteLine("[2] Show My Ads");
            System.Console.WriteLine("[3] Search For Ads");
            System.Console.WriteLine("[4] My Messages");
            System.Console.WriteLine("[5] Edit profile");
            System.Console.WriteLine("[6] Contact us");
            System.Console.WriteLine("[7] Log Out");
            LoggedInOptions = ConsoleInput.GetInt("Go to page: ");

            switch (LoggedInOptions)
            {
                case 1:
                    advertiseoperator.CreateAd(user);
                    break;
                case 2:
                    System.Console.WriteLine("Active ads: ");
                    advertiseoperator.Showmyads(user.Id);
                    int choices = ConsoleInput.GetInt("[1] Delete ad   [2] Return");
                    int advertiseID = 0;
                    if (choices == 1)
                    {
                        advertiseID = ConsoleInput.GetInt("Ad to delete: ");
                        advertiseService.RemoveOneAd(advertiseID);
                    }
                    else
                    {
                        break;
                    }
                    break;
                case 3:
                    advertiseService = new(new AddvertiseDb());
                    string search = ConsoleInput.GetString("Search Ad: ");
                    List<Advertise> foundad = advertiseService.SearchAd(search);

                    foreach (Advertise item in foundad)
                    {
                        System.Console.WriteLine(item.ToString());
                    }
                    int choice = ConsoleInput.GetInt("[1] New Search   [2] Write message to advertise   [3] Return");
                    {
                        if (choice == 1)
                        {
                            LoggedInOptions = 3; // funkar ej?
                        }
                        else if (choice == 2)
                        {
                            advertiseID = ConsoleInput.GetInt("Advertise Number: ");
                            int adUserID = userdb.GetUserIdFromAdvertise(advertiseID);
                            //     UserMakesMessage(toUserId, user, messageService); GAMLA STATISKA METODEN, TA BORT NÄR DEN NEDAN ÄR TESTAD
                            //     HÄR GÖR OBJEKT AV KLASSEN MESSAGEOPERATION OCH ANROPAR WRITEMESSAGETOAD METODEN HÄR
                            //    cd ui
                            messageOperator.WriteMessageToAd(adUserID, user);
                        }
                        else if (choice == 3)
                        {
                            LoggedInOptions = 1;
                        }
                    }
                    break;
                case 4:
                    messageOperator.ShowAllMessages(user);
                    int messageId = ConsoleInput.GetInt("Enter message to read: ");
                    // hämta det meddealndet via detta id!   så stoppar vi in touser och from user här under
                    int participantId = messageOperator.GetSender(messageId);
                    // // VISA HELA KONVERSATIONEN PÅ VALT MESSAGE ID
                    messageOperator.ShowMessageConversation(messageId, participantId, user);
                    int chocie = ConsoleInput.GetInt("[1] Reply    [2] Delete conversation    [3] Return");
                    if (chocie == 1)
                    {
                        messageOperator.ReplyToMessage(participantId, user);
                    }
                    else if (chocie == 2)
                    {
                        messageOperator.DeleteConversation(user, participantId);
                    }
                    break;
                case 5:
                    string anAnswer = ConsoleInput.GetString($" [1]Delete my account  [2]Update my Email   [3]Update my nickname  [4]Update description  [5]Update password ");
                    switch (anAnswer)
                    {
                        case "1":
                            string delete = ConsoleInput.GetString("Delete account [Yes]  [No] ");
                            if (delete.ToLower() == "yes")
                            {
                                userOperator.DeleteUser(user);
                            }
                            break;
                        case "2":
                            userOperator.UpdateEmail(user);
                            break;
                        case "3":
                            userOperator.UpdateNickName(user);
                            break;
                        case "4":
                            userOperator.UpdateDescription(user);
                            break;
                        case "5":
                            userOperator.UpdatePasswordUser(user);
                            break;
                    }
                    break;
                    case 6:
                    choice = ConsoleInput.GetInt("[1] Write Message to Admin  [2] Return");
                    if(choice == 1)
                    {
                        messageOperator.WriteMessageToAdmin(user);
                        Console.WriteLine("You will recieve a reply in your inbox here at blocket-scam.");
                    }
                    break;
                    case 7:
                    loginPage = true;
                    loggedInAsUser = false;
                    break;
            }
        }
        while (loggedInAsAdmin)
        {
            admin = adminService.GetTheAdmin(admin);
            adminOptions = ConsoleInput.GetInt("[1] Add new admin-account   [2] Check advertises   [3] User-handeler   [4] Advertise-handeler [5] Update email [6] Delete admin account");
            switch (adminOptions)
            {
                case 1:
                    admin = adminOperator.CreateAdmin(admindb);
                    break;
                case 2:
                    adminOperator.GetNonCheckedAds();
                    int advertiseID = ConsoleInput.GetInt("Enter advertise id to check: ");
                    advertiseoperator.CheckAd(advertiseID);
                    break;
                case 3:
                    
                    // För vidare utveckling
                    break;
                case 4:
                    // För vidare utveckling
                    break;
                case 5:
                    adminOperator.UpdateEmail(admin);
                    break;
                case 6:
                    string delete = ConsoleInput.GetString("Delete account [Yes]  [No] ");
                    if (delete.ToLower() == "yes")
                    {
                       adminOperator.DeleteAdmin(admin);
                    }
                    break;
            }
        }

    }
}
