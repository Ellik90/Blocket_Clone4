using LOGIK;
internal class Program
{
    private static void Main(string[] args)
    {
        bool start = true;
        int loginOption = 0;
        string answer = string.Empty;
        bool loggedInAsUser = true;
        int LoggedInOptions = 0;
        bool loginPage = true;
        //TESTAR ETT STEG I TAGET HÄR
        Admin admin = new();
        AdminDB adminDB = new();
        Identifier identifier = new();

        User user = new();
        UserDB userdb = new();
        AdminDB admindb = new();
        LogInService logInService = new(identifier, userdb, admindb);
        UserService userservise = new(identifier, userdb, userdb);
        MessageDB messageDB = new();
        MessageService messageService = new(messageDB, messageDB);
        AdminService adminService = new(identifier, userdb, userdb, adminDB);
        UserOperator userOperator = new(logInService, user, userservise);
        AdminOperator adminOperator = new(logInService, adminService, userservise);


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

                    CreateUser(user, logInService, userdb, identifier);

                    // user = userOperator.CreateUser(user, logInService, userdb, identifier);
                    // userservise.MakeUser(user);

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
                        break;
                    }

                    user = userservise.GetTheUser(user);

                    break;

                case 3:

                    admin = new();

                    admin.Email = ConsoleInput.GetString("Enter your Email");
                    admin.PassWord = ConsoleInput.GetInt("Enter your Password");
                    admin = logInService.AdminLogIn(admin); //user skriver bara i sin mail och kod
                    admin.Id = logInService.AdminLogInIsValid(admin); //andvänder userhandler och ser om user finns
                    if (admin.Id == 0) //<- tex om user är inloggad då så kommer man till user page?
                    {
                        Console.WriteLine("Fel lösen eller mail");
                        Environment.Exit(0);
                    }
                    admin = adminService.GetTheAdmin(admin);

                    string delete = ConsoleInput.GetString("Admin email: ");
                    if (adminDB.AdminEmailExists(admin.Email) > 0)
                    {
                        adminService.DeleteAdmin(admin);
                        Console.WriteLine("admin deleted ");
                    }
                    break;
            }
        }
        //While och switch för användare som är inloggade
        while (loggedInAsUser)
        {
            System.Console.WriteLine(user.Name.ToUpper() + "Konto");
            System.Console.WriteLine("[1] Skapa annons ");
            System.Console.WriteLine("[2] Visa mina annonser");
            System.Console.WriteLine("[3] Sök annons");
            System.Console.WriteLine("[4] Mina meddelanden");
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
                    string search = ConsoleInput.GetString("SearchAd");

                    // // NÄR DU HÄMTAR ALLA ANNONSER I DATABASEN, LÄGG ÄVEN TILL ANNONSEN OCH USERNS ID!!
                    List<Advertise> foundad = advertiseService.SearchAd(search);

                    foreach (Advertise item in foundad)
                    {
                        System.Console.WriteLine(item.ToString());
                    }
                    break;



                case 4:

                // Message message = new();
                // int advertiseId = ConsoleInput.GetInt("Enter advertise ID to write message: ");
                // int adUserId = userdb.GetUserIdFromAdvertise(advertiseId);
                // // UserMakesMessage(toUserId, user, messageService); GAMLA STATISKA METODEN, TA BORT NÄR DEN NEDAN ÄR TESTAD
                // // HÄR GÖR OBJEKT AV KLASSEN MESSAGEOPERATION OCH ANROPAR WRITEMESSAGETOAD METODEN HÄR
                // MessageOperator messageOperator = new(messageService, messageDB);
                // messageOperator.WriteMessageToAd(adUserId, user);

                // VISA ALLA MEDDELANDEN 
                // =======================================
                // messageOperator.ShowAllMessages(user);

                // VÄLJ MEDDELANDE ATT LÄSA  
                //=========================================
                // int messageId = ConsoleInput.GetInt("Enter message to read: ");
                // hämta det meddealndet via detta id!   så stoppar vi in touser och from user här under
                // int participantId = messageOperator.GetSender(messageId);
                // VISA HELA KONVERSATIONEN PÅ VALT MESSAGE ID
                // messageOperator.ShowMessageConversation(messageId, participantId, user);

                //4. SVARA PÅ MEDDELANDE    // RADERA KONVERSATION   // ELLER TILLBAKA
                // int chocie = ConsoleInput.GetInt("1 för att svara, 2 för att radera, 3 för tillbaka");
                // if (chocie == 1)
                // {
                //     messageOperator.ReplyToMessage(participantId, user);
                // }
                // else if (chocie == 2)
                // {
                //     messageOperator.DeleteConversation(user, participantId);
                // }
                // break;


                case 5:
                    // string anAnswer = ConsoleInput.GetString($" [1]Delete my account  [2]Update my Email  [3]Update my nickname  [4]Update description ");
                    // switch (anAnswer)
                    // {
                    //     case "1":
                    //         //Raderar användare om användare finns

                    //         string delete = ConsoleInput.GetString(" ");
                    //         if (userHandeler.DeleteUser(user) > 0)
                    //         {
                    //             Console.WriteLine("Account deleted.");
                    //             Environment.Exit(0);
                    //         }
                    //         else
                    //         {
                    //             Console.WriteLine("Something went wrong.");
                    //         }
                    //         break;
                    //     case "2":
                    //         // //Uppdaterar emailen 
                    //         string updateEmail = ConsoleInput.GetString("Update email: ");
                    //         userHandeler.UpdateEmail(user, updateEmail);
                    //         break;
                    //     case "3":
                    //         // // Uppdaterar nickname
                    //         string updateNickname = ConsoleInput.GetString("nickname: ");
                    //         userEditor.UpdateNickName(user, updateNickname);
                    //         break;
                    //     case "4":
                    //         // //användaren skriver in sin beskrivning
                    //         string updateDescription = ConsoleInput.GetString("Text: ");
                    //         userEditor.UpDateDescription(user, updateDescription);
                    //         break;
                    // }
                    break;


            }
        }


        // 3. SKRIV MEDDELANDE TILL ANNONSENS ANVÄNDARE 
        // =========================================

        Message message = new();
        int advertiseId = ConsoleInput.GetInt("Enter advertise ID to write message: ");
        int adUserId = userdb.GetUserIdFromAdvertise(advertiseId);
        // UserMakesMessage(toUserId, user, messageService); GAMLA STATISKA METODEN, TA BORT NÄR DEN NEDAN ÄR TESTAD
        // HÄR GÖR OBJEKT AV KLASSEN MESSAGEOPERATION OCH ANROPAR WRITEMESSAGETOAD METODEN HÄR
        MessageOperator messageOperator = new(messageService);
        messageOperator.WriteMessageToAd(adUserId, user);

        static void ShowBlocketPages(int currentPage, IMessageHandeler messageHandeler, IUserHandeler userHandeler, Identifier identifier, IUserEditor userEditor)
        {
            User user = new();
            while (true)
            {           //CURRENTPAGE ÄR 1 NÄR DET STARTAR SÅ VI HAMNAR PÅ CASE 1 - INLOGG
                switch (currentPage)
                {
                    case 1:
                        int choice = ConsoleInput.GetInt("[1] Log In   [2] New User");
                        if (choice == 1)
                        {
                            //I SHOWLOGINPAGE SKRIVER ANVÄNDAREN MAIL OCH LÖSEN, DET HÄMTAS UT TILL EN USER
                            // user = ShowLogInPage(identifier);
                            //DENNA KOLLAR OM ANVÄNDAREN FINNS I DATABASEN, OM DEN FINNS RETURNERAR TRUE
                            if (identifier.CheckIfUserExists(userHandeler, user) == true)
                            {   //OM RETURNERAR TRUE SÅ SKICKAS TILL PAGE 2, USERS PAGE
                                currentPage = 2;
                            }
                            else
                            {
                                Console.WriteLine("Wrong email or password.");
                                currentPage = 1;
                            }
                        }
                        else if (choice == 2)
                        {   //SKAPAR NYTT LOGIN OCH GER UT EN USER MED DEN MAILEN OCH LÖSEN
                            // user = ShowNewLogInPage(user, identifier);
                            //SÄTTER NAME TILL USERN
                            user.Name = ConsoleInput.GetString("Nickname: ");
                            //USERN SKICKAS IN I BECOMENEWUSER SOM SÄTTER IN USER I DATABASEN
                            userHandeler.CreateUser(user);
                            // här hämta id och lägg till i usern
                        }
                        break;
                    case 2:
                        //PAGE 2, USERS FÖRSTASIDA 
                        // currentPage = ShowUserPage(user, userHandeler, userEditor);
                        break;
                    case 3:
                        //PAGE 3 VISAR ALLA MEDDELANDEN SOM ÄR TILL USERN FRÅN DATABASEN
                        //  ShowAllMessages(user, messageHandeler);
                        //messagePage.ShowAllMessages(user);
                        int messageId = ConsoleInput.GetInt("Choose message to read");
                        //messagePage.ShowOneMessage(messageId);
                        //OM PERSONEN VÄLJER ETT SPECIFIKT MEDDELANDE, SÅ VISAS HELA DET MEDD.
                        //ShowOneMessageConvo(messageId, messageHandeler);
                        currentPage = ConsoleInput.GetInt("[2] Return");
                        break;
                        //VI FÅR PRATA OM HUR VI SKA GÖRA MED SWITCHARNA
                        // case 4:
                        //     // string? aAnswer = Console.ReadLine();
                        //     // userHandeler.UpdateInfo(user);
                        //     Console.WriteLine("Här visas users annonser?");
                        //     currentPage = ConsoleInput.GetInt("[2] Return");
                        //     break;
                        // case 5:
                        //     Console.WriteLine("Sparade annonser?? hmm");
                        //     currentPage = ConsoleInput.GetInt("[2] Return"); 
                        //     break;
                        //User user1 = ();
                }
            }
        }
        static void ShowUserPage(User user, IUserHandeler userHandeler, IUserEditor userEditor)
        {

        }
        static Admin CreateAdmin(Admin admin, AdminDB adminDB, LogInService logInService, Identifier identifier)
        {
            admin.Email = ConsoleInput.GetString("Enter your mail-adress");
            if (adminDB.AdminEmailExists(admin.Email) > 0)
            {
                Console.WriteLine("Email allready exists");
                Environment.Exit(0);
            }
            //<-här har user med sig email, lösenord|elina tar över user och gör resten
            admin.Name = ConsoleInput.GetString("name: ");
            if (adminDB.AdminNameExists(admin.Name) > 0)
            {
                Console.WriteLine("Nickname allready exists");
                Environment.Exit(0);
            }
            admin.SocialSecurityNumber = ConsoleInput.GetString("social security number: ");
            if (identifier.ValidateSocialSecurityNumber(admin.SocialSecurityNumber) == false)
            {
                Console.WriteLine("Social security number incorrect");
                Environment.Exit(0);
            }
            admin = logInService.MakeNewLogIn(admin);
            return admin;
        }




        static User CreateUser(User user, LogInService logInService, UserDB userdb, Identifier identifier)
        {
            user.Email = ConsoleInput.GetString("Enter your mail-adress");
            if (userdb.UserEmailExists(user.Email) > 0)
            {
                Console.WriteLine("Email allready exists");
                Environment.Exit(0);
            }
            //<-här har user med sig email, lösenord|elina tar över user och gör resten
            user.Name = ConsoleInput.GetString("name: ");
            if (userdb.NicknameExists(user.Name) > 0)
            {
                Console.WriteLine("Nickname allready exists");
                Environment.Exit(0);
            }
            user.SocialSecurityNumber = ConsoleInput.GetString("social security number: ");
            if (identifier.ValidateSocialSecurityNumber(user.SocialSecurityNumber) == false)
            {
                Console.WriteLine("Social security number incorrect");
                Environment.Exit(0);
            }
            user.Adress = ConsoleInput.GetString("adress: "); //FÖR USER HAR EMAIL HÄR // och password
            user = logInService.MakeNewLogIn(user);                       //user = new(input, num, adress, email, password);
            return user;
        }


        static void UpDateDescription(IUserHandeler userHandeler, User user, IUserEditor userEditor)
        {
            string updateDescription = ConsoleInput.GetString("Text: ");

            userEditor.UpDateDescription(user, updateDescription);
        }
        static Advertise AddAdvertise() // Metod för att skapa annons//D
        {
            string answer = string.Empty;
            int option = 0;
            bool isTrue = true;
            System.Console.WriteLine("[1]Välj kategori");
            System.Console.WriteLine("[2]Välj underkategori");
            System.Console.WriteLine("");

            //     //     while (isTrue)
            //          {
            //     //         switch (option)
            //              {



            //              }//     Välja kategori, underkategori, beskrivning, köpa eller sälja, bilder för annons.
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
