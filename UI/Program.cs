using LOGIK;
internal class Program
{
    private static void Main(string[] args)
    {
        // DU SKA SVARA PÅ MEDDELANDET, DET GÅR EJ CHILD ROW NÅOGT!!

        //TESTAR ETT STEG I TAGET HÄR
        Identifier identifier = new();
        User user = new();
        UserDB userdb = new();
        LogInService logInService = new(identifier, userdb);
        UserService userservise = new(identifier, userdb);
        MessageDB messageDB = new();
        MessageService messageService = new(messageDB);

        //1. SKAPAKONTO

        //   user = CreateUser(user, logInService, userdb, identifier);
        //   userservise.MakeUser(userdb, user);


        // DELETE FUNKAR EJ, VAAAAD ÄR KNAAAAAS??????

        //2. LOGGA IN PÅ BEFINTLIGT KONTO
        // user = new();
        // user.Email = "angelinaholmqvist@live.se";//ConsoleInput.GetString("Enter your Email");
        // user.Password = 1010;//ConsoleInput.GetInt("Enter your Password");
        // user = logInService.UserLogIn(user); //user skriver bara i sin mail och kod
        // user.Id = logInService.UserLogInIsValid(user); //andvänder userhandler och ser om user finns
        // if (user.Id == 0) //<- tex om user är inloggad då så kommer man till user page?
        // {
        //     Console.WriteLine("Fel lösen eller mail");
        //     Environment.Exit(0);
        // }
        //  DeleteAUser(user,userdb);
        //  userservise.DeleteTheUser(userdb, user); 
        //1. TESTA GÖRA ANNONS
        AddvertiseDb dbManager = new();
        AdvertiseService advertiseService = new(dbManager);
        advertise bil = new("BlåBil", "jätteBlåBill", 20000, "borås", "borås kommun", 50764, user.Id);
        advertiseService.MakeNewAd(bil);


        //2. TESTA SÖKA ANNONS
        string search = ConsoleInput.GetString("SearchAd");
    
        List <advertise> foundad = advertiseService.SearchAd(search);
        foreach(advertise item in foundad)
        {
            System.Console.WriteLine(item.ToString());
        }



        //---Annonsen---
        //Katt
        //köp mig!
        //500 kr
        // - visningsnamn
        // annonsid 

        //3. SKRIV MEDDELANDE TILL ANNONSEN
        // int advertiseId = ConsoleInput.GetInt("Enter advertise ID to write message: ");
        // int advertiseUserId = 11 ;//= userdb.getuserid(advertiseId);
        // Message message = new("KATTEN", "Jag vill gärna köpa din katt!", user.Id, advertiseUserId);
        // messageService.MakeMessage(message);
        // Console.WriteLine("Message sent!");


        // VISA ALLA MEDDELANDEN 
        // Message message = new();
        // user.messages = messageService.ShowAllMessages(user);
        // if (user.messages.Count() == 0)
        // {
        //     Console.WriteLine("No Messages");
        // }
        // foreach (Message item in user.messages)
        // {
        //     Console.WriteLine(item.MessagesToString());
        // }
        // // VÄLJ MEDDELANDE ATT LÄSA
        // int messageId = ConsoleInput.GetInt("Enter message to read: ");
        // Message readMessage = messageService.ShowOneMessage(messageId);
        // Console.WriteLine(readMessage.WholeMessageToString());

        // //4. SVARA PÅ MEDDELANDE
        // int chocie = ConsoleInput.GetInt("1 för att svara, 2 för att tillbaka");
        // if(chocie == 1)
        // {
        //     string rubric = ConsoleInput.GetString("Rubric: ");
        //     string content = ConsoleInput.GetString("Content: ");
        //     int idToUser = readMessage.IDFromUser;
        //     Message answerMessage = new(rubric, content, user.Id, idToUser);
        //     messageService.MakeMessage(answerMessage);
        //     Console.WriteLine("Skickat");
        // }
        //5. REDIGERA PROFIL
        // DELETE USER
        DeleteAUser(user, userdb);
        userservise.DeleteTheUser(userdb, user);

        //6. VISA MINA ANNONSER

        //7. MINA SÅLDA OBJEKT?)

        //7.



    }

    // HÄR ÄR SJÄLVA BLOCKET HEMSIDAN, DEN TAR IN INTERFACES (OCH KLASSER SOM IMPLEMENTERAR DESSA)
    public static void ShowBlocketPages(int currentPage, IMessageHandeler messageHandeler, IUserHandeler userHandeler, Identifier identifier)
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
                        userHandeler.BecomeNewUser(user);
                        // här hämta id och lägg till i usern
                    }
                    break;
                case 2:
                    //PAGE 2, USERS FÖRSTASIDA 
                    currentPage = ShowUserPage(user, userHandeler);
                    break;
                case 3:
                    //PAGE 3 VISAR ALLA MEDDELANDEN SOM ÄR TILL USERN FRÅN DATABASEN
                    //  ShowAllMessages(user, messageHandeler);
                    //messagePage.ShowAllMessages(user);
                    int messageId = ConsoleInput.GetInt("Choose message to read");
                    //messagePage.ShowOneMessage(messageId);
                    //OM PERSONEN VÄLJER ETT SPECIFIKT MEDDELANDE, SÅ VISAS HELA DET MEDD.
                    ShowOneMessage(messageId, messageHandeler);
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
    public static int ShowUserPage(User user, IUserHandeler userHandeler)
    {
        Console.WriteLine($"Lägg in annons [1]  Sök annons [2]  Dina meddelanden [3]");
        Console.WriteLine($"{user.Name}");
        Console.WriteLine($"Redigera profil [4]");
        Console.WriteLine();
        Console.WriteLine("Mina annonser [5]  Sparade annonser [6] Sålda objekt [7]");

        string answer = Console.ReadLine();
        int goToPage = 0;
        switch (answer)
        {
            case "1":

                AddAdvertise();
                //admanagement.addadvertise(advertise);
                break;

            case "3":
                goToPage = 3;
                // om man väljer tex 1
                // så visaas medde med nr 1
                break;

            case "4":
                string anAnswer = ConsoleInput.GetString($" [1]Delete my account  [2]Update my Email  [3]Update my nickname  [4]Update description ");
                switch (anAnswer)
                {
                    case "1":
                        //Raderar användare om användare finns

                        string delete = ConsoleInput.GetString(" ");
                        if (userHandeler.DeleteUser(user) == true)
                        {
                            Console.WriteLine("Account deleted.");
                            Environment.Exit(0);
                        }
                        else
                        {
                            Console.WriteLine("Something went wrong.");
                        }
                        break;
                    case "2":
                        //Uppdaterar emailen 
                        string updateEmail = ConsoleInput.GetString("Update email: ");
                        // userHandeler.UpdateEmail(user, updateEmail);
                        break;
                    case "3":
                        // Uppdaterar nickname
                        string updateNickname = ConsoleInput.GetString("nickname: ");
                        userHandeler.UpdateNickName(user, updateNickname);
                        break;
                    case "4":
                        //användaren skriver in sin beskrivning
                        string updateDescription = ConsoleInput.GetString("Text: ");
                        userHandeler.UpDateDescription(user, updateDescription);
                        break;
                }
                break;
            case "5":
                goToPage = 4;
                break;
        }
        return goToPage;
    }
    public static User CreateUser(User user, LogInService logInService, UserDB userdb, Identifier identifier)
    {
        user.Email = ConsoleInput.GetString("Enter your mail-adress");
        if (userdb.UserEmailExists(user.Email) == true)
        {
            Console.WriteLine("Email allready exists");
            Environment.Exit(0);
        }
        //<-här har user med sig email, lösenord|elina tar över user och gör resten
        user.Name = ConsoleInput.GetString("name: ");
        if (userdb.NicknameExists(user.Name) == true)
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
    public static void DeleteAUser(User user, IUserHandeler userHandeler)
    {
        string answer = ConsoleInput.GetString("Are you sure you want to delete your account? [yes] [no]");
        if (answer == "yes")
        {
            userHandeler.DeleteUser(user);
            Console.WriteLine("Account deleted!");
        }
        else
        {
            Environment.Exit(0);
        }
    }

    public static void ShowOneMessage(int messageId, IMessageHandeler messageHandeler) //A
    {
        // den hittar meddelande med specifikt id
        Message message = messageHandeler.GetMessage(messageId);
        Console.WriteLine(message.ToString());
    }

    public static advertise AddAdvertise() // Metod för att skapa annons//D
    {
        string answer = string.Empty;
        int option = 0;
        bool isTrue = true;
        System.Console.WriteLine("[1]Välj kategori");
        System.Console.WriteLine("[2]Välj underkategori");
        System.Console.WriteLine("");

        while (isTrue)
        {
            switch (option)
            {



            }

        }

        //Välja kategori, underkategori, beskrivning, köpa eller sälja, bilder för annons.
        //Felhantering = Kanske maxantal ord för varje. Ha det öppet så att man ser helheten
        //Felhantering = Om man skriver fel på förra så kan man gå till baka och ändra innan man skapar annons
        string rubric = string.Empty;
        string description = string.Empty;
        float price = 0f;
        string location = string.Empty;
        string municipality = string.Empty;
        int postalNumber = 0;
        User user = new();

        advertise nyannons = new advertise(rubric, description, price, location, municipality, postalNumber, user.Id);
        return nyannons;
    }

}
