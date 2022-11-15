using LOGIK;
internal class Program
{
    private static void Main(string[] args)
    {
        bool start = true;
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
        Identifier identifier = new();
        LogInService logInService = new(identifier, userdb, admindb);
        UserService userservise = new(identifier, userdb, userdb);
        AddvertiseDb addvertiseDb = new();
        AdvertiseService advertiseService = new(addvertiseDb);
        advertiseoperator advertiseoperator = new(advertiseService);
        MessageDB messageDB = new();
        MessageService messageService = new(messageDB, messageDB);
        AdminService adminService = new(identifier, userdb, userdb, admindb, admindb, addvertiseDb);
        UserOperator userOperator = new(logInService, user, userservise);
        AdminOperator adminOperator = new(logInService, adminService, userservise, admindb, identifier);
        MessageOperator messageOperator = new(messageService);

        //admin = CreateAdmin(admin, adminDB, logInService, identifier);
        //adminService.MakeAdmin(admin);

        //While loop hör ihop med swith för skapa och logga in funktioner
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
                    user = userOperator.CreateUser(user, logInService, userdb, identifier);
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
                    // string delete = ConsoleInput.GetString("Admin email: ");
                    // if (adminDB.AdminEmailExists(admin.Email) > 0)
                    // {
                    //     adminService.DeleteAdmin(admin);
                    //     Console.WriteLine("admin deleted ");
                    // }
                    break;
            }
        }
        //While och switch för användare som är inloggade
        while (loggedInAsUser)
        {
            user = userOperator.GetUser(user);
            System.Console.WriteLine(user.Name.ToUpper() + " Konto");
            System.Console.WriteLine("-------------------------------");
            System.Console.WriteLine("[1] Skapa annons ");
            System.Console.WriteLine("[2] Visa mina annonser");
            System.Console.WriteLine("[3] Sök annons");
            System.Console.WriteLine("[4] Mina Meddelanden");
            System.Console.WriteLine("[5] Redigera profil");
            LoggedInOptions = ConsoleInput.GetInt("Go to page");
            switch (LoggedInOptions)
            {
                case 1:
                advertiseoperator.CreateAd(user);
                    break;
                case 2:
                // EN METOD BEHÖVS SOM HÄMTAR ANNONSER PÅ MITT ID GETMYADDS(INT USERID) OCH TILL ADVERTISESERVICE EN GETMYADDS OCH TILL 
                // ADVERTISEOPERATOR LIST<ADVERTISE> SHOWMYADS() SOM GENOM FOREACH SKRIVER UT ALLA MINA ANNONSER
                    break;
                case 3:
                    advertiseService = new(new AddvertiseDb());
                    string search = ConsoleInput.GetString("Search Ad: ");

                    // // NÄR DU HÄMTAR ALLA ANNONSER I DATABASEN, LÄGG ÄVEN TILL ANNONSEN OCH USERNS ID!!
                    List<Advertise> foundad = advertiseService.SearchAd(search);

                    foreach (Advertise item in foundad)
                    {
                        System.Console.WriteLine(item.ToString());
                    }
                    int choice = ConsoleInput.GetInt("[1] New Search   [2] Write message to advertise   [3] Return");
                    {
                        if (choice == 1)
                        {
                            LoggedInOptions = 3;
                        }
                        else if (choice == 2)
                        {
                            int advertiseID = ConsoleInput.GetInt("Advertise Number: ");
                            int adUserID = userdb.GetUserIdFromAdvertise(advertiseID);
                            // UserMakesMessage(toUserId, user, messageService); GAMLA STATISKA METODEN, TA BORT NÄR DEN NEDAN ÄR TESTAD
                            // HÄR GÖR OBJEKT AV KLASSEN MESSAGEOPERATION OCH ANROPAR WRITEMESSAGETOAD METODEN HÄR
                            messageOperator.WriteMessageToAd(adUserID, user);
                        }
                        else if(choice == 3)
                        {
                            LoggedInOptions = 1;
                        }
                    }
                    break;
                case 4:

                    // VISA ALLA MEDDELANDEN 
                    // =======================================
                    messageOperator.ShowAllMessages(user);

                    // VÄLJ MEDDELANDE ATT LÄSA  
                    // =========================================
                    int messageId = ConsoleInput.GetInt("Enter message to read: ");
                    // hämta det meddealndet via detta id!   så stoppar vi in touser och from user här under
                    int participantId = messageOperator.GetSender(messageId);
                    // VISA HELA KONVERSATIONEN PÅ VALT MESSAGE ID
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
                    string anAnswer = ConsoleInput.GetString($" [1]Delete my account  [2]Update my Email  [3]Update my nickname  [4]Update description ");
                    switch (anAnswer)
                    {
                        case "1":
                            //Raderar användare om användare finns
                            string delete = ConsoleInput.GetString("Delete account [yes]  [no] ");
                            if (delete == "yes")
                            {
                                userOperator.DeleteUser(user);
                            }
                            else if (delete == "no")
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Something went wrong.");
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
                    }
                    break;
            }
        }
        while (loggedInAsAdmin)
        { 
            admin = adminService.GetTheAdmin(admin); //
            adminOptions = ConsoleInput.GetInt("[1] Add new admin-account   [2] Check advertises   [3] User-handeler   [4] Advertise-handeler [5] Update email");
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

                    break;
                case 4:

                    break;
                    case 5:
                    adminOperator.UpdateEmail(admin);
                    break;
            }
        }

    }
}
