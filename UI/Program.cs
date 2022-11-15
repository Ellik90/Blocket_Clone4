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
        bool loggedInAsAdmin = false;

        User user = new();
        UserDB userdb = new();
        AdminDB admindb = new();
        Identifier identifier = new();
        LogInService logInService = new(identifier, userdb, admindb);
        UserService userservise = new(identifier, userdb, userdb);
        MessageDB messageDB = new();
        MessageService messageService = new(messageDB, messageDB);
        AdminService adminService = new(identifier, userdb, userdb, admindb, admindb);
        UserOperator userOperator = new(logInService, user, userservise);
        AdminOperator adminOperator = new(logInService, adminService, userservise);
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
                    userservise.MakeUser(user);
                    break;
                case 2:
                    //Logga in 
                    user = new();
                    user.Email = ConsoleInput.GetString("Enter your Email");
                    user.Password = ConsoleInput.GetInt("Enter your Password");
                    user = logInService.UserLogIn(user); //user skriver bara i sin mail och kod
                    user.Id = logInService.UserLogInIsValid(user); //andvänder userhandler och ser om user finns
                    if (user.Id == 0) //<- tex om user är inloggad då så kommer man till user page?
                    {
                        Console.WriteLine("Fel lösen eller mail");
                        Environment.Exit(0);
                    }
                    else
                    {
                        loggedInAsUser = true;
                        loginPage = false;
                    }
                    break;
                case 3:
                    Admin admin = new();
                    admin.Email = ConsoleInput.GetString("Enter your Email");
                    admin.PassWord = ConsoleInput.GetInt("Enter your Password");
                    admin = logInService.AdminLogIn(admin); //user skriver bara i sin mail och kod
                    admin.Id = logInService.AdminLogInIsValid(admin); //andvänder userhandler och ser om user finns
                    if (admin.Id == 0) //<- tex om user är inloggad då så kommer man till user page?
                    {
                        Console.WriteLine("Fel lösen eller mail");
                        Environment.Exit(0);
                    }
                    else
                    {
                        admin = adminService.GetTheAdmin(admin);
                        loggedInAsAdmin = true;
                        break;
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
            user = userservise.GetTheUser(user);
            System.Console.WriteLine(user.Name.ToUpper() + "Konto");
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
                    AddvertiseDb dbManager = new();
                    AdvertiseService advertiseService = new(dbManager);

                    Advertise bil = new("KLÄDER", "10 klänningar", 20121, "borås", "borås kommun", 50764, user.Id);
                    int advertiseId1 = advertiseService.MakeNewAd(bil);
                    Advertise kaka = new("SOFFGRUPP", "mockasoffa", 2021, "borås", "borås kommun", 50764, user.Id);
                    int advertiseId2 = advertiseService.MakeNewAd(kaka);
                    break;
                case 2:
                    //6. VISA MINA ANNONSER
                    // metod anropas från advertiseservice, som returnar en lista med alla annonsen där user_id = dennas id

                    //7. MINA SÅLDA OBJEKT?)
                    // bool isSold? eller det tas sen
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
                    Console.WriteLine("[1] Write to user about advertise  [2] Search [3] Quit search");
                    int choice = ConsoleInput.GetInt("[1] Go back       [2] Message to advertise");
                    {
                        if (choice == 1)
                        {
                            loginOption = 1;
                        }
                        else if (choice == 2)
                        {
                            int advertiseID = ConsoleInput.GetInt("Advertise Number: ");
                            int adUserID = userdb.GetUserIdFromAdvertise(advertiseID);
                            // UserMakesMessage(toUserId, user, messageService); GAMLA STATISKA METODEN, TA BORT NÄR DEN NEDAN ÄR TESTAD
                            // HÄR GÖR OBJEKT AV KLASSEN MESSAGEOPERATION OCH ANROPAR WRITEMESSAGETOAD METODEN HÄR

                            messageOperator.WriteMessageToAd(adUserID, user);
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
                    int chocie = ConsoleInput.GetInt("1 för att svara, 2 för att radera, 3 för tillbaka");
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

        static Advertise AddAdvertise() // Metod för att skapa annons//D
        {
            string answer = string.Empty;
            int option = 0;
            bool isTrue = true;
            System.Console.WriteLine("[1]Välj kategori");
            System.Console.WriteLine("[2]Välj underkategori");
            System.Console.WriteLine("");
            // Felhantering = Kanske maxantal ord för varje. Ha det öppet så att man ser helheten
            // Felhantering = Om man skriver fel på förra så kan man gå till baka och ändra innan man skapar annons
            string rubric = string.Empty;
            string description = string.Empty;
            float price = 0f;
            string location = string.Empty;
            string municipality = string.Empty;
            int postalNumber = 0;
            User user = new();
            Advertise nyannons = new Advertise(rubric, description, price, location, municipality, postalNumber, user.Id);
            return nyannons;
        }
    }
}
