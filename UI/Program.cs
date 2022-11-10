using LOGIK;
internal class Program
{
    private static void Main(string[] args)
    {

        //TESTAR ETT STEG I TAGET HÄR
        Identifier identifier = new();
        User user = new();
        UserDB userdb = new();
        LogInService logInService = new(identifier, userdb);       
        UserService userservise = new(identifier, userdb);
        //1. SKAPAKONTO

        user = CreateUser(user, logInService, userdb);
        userservise.MakeUser(userdb, user);

        //2. LOGGA IN PÅ BEFINTLIGT KONTO
        user.Email = ConsoleInput.GetString("Enter your Email");
        user.Password = ConsoleInput.GetInt("Enter your Password");
        user = logInService.UserLogIn(user); //user skriver bara i sin mail och kod
        bool isLoggedIn = logInService.UserLogInIsValid(user); //andvänder userhandler och ser om user finns
        if (isLoggedIn == true) //<- tex om user är inloggad då så kommer man till user page?
<<<<<<< HEAD

        {
=======
        {
            Console.WriteLine("Du är inloggad!");
<<<<<<< HEAD
>>>>>>> b39c978a83f1254a19a8b5b46d058ae1e6520bc8
=======
        }
        else
        {
            Console.WriteLine("Fel lösen eller mail");
            Environment.Exit(0);
        }
>>>>>>> d2cdfdd3a1f8712824ad115b9b0fde7faa9da863
            //1. TESTA GÖRA ANNONS

        //2. TESTA SÖKA ANNONS

        //3. VISA ALLA MEDDELANDEN (SAMT ETT)
            MessageDB messageDB = new();
        MessageService messageService = new(messageDB);
        try
        {
            List<Message> usersMessages = messageService.ShowAllMessages(user);
            foreach (Message item in usersMessages)
            {
                Console.WriteLine(item.MessagesToString());
            }
        }
        catch (NullReferenceException)
        {
            Console.WriteLine("No messages.");
        }


        //4. SKICKA MEDDELANDE

        //5. REDIGERA PROFIL

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
                        // string delete = ConsoleInput.GetString(" ");
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
                        userHandeler.UpdateEmail(user, updateEmail);
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
    public static User CreateUser(User user, LogInService logInService, UserDB userdb)
    {
        user.Email = ConsoleInput.GetString("Enter your mail-adress");
        user = logInService.MakeNewLogIn(user);//<-här har user med sig email, lösenord|elina tar över user och gör resten
        user.Name = ConsoleInput.GetString("name: ");
        user.SocialSecurityNumber = ConsoleInput.GetString("social security number: ");
        user.Adress = ConsoleInput.GetString("adress: ");
        user.Email = user.Email; //FÖR USER HAR EMAIL HÄR // och password
                                 //user = new(input, num, adress, email, password);
        return user;
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
        advertise nyannons = new advertise(rubric, description, price, location, municipality, postalNumber);
        return nyannons;
    }

}
