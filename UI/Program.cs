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
        bool loggedInAsAdmin = false;
        int adminOptions = 0;
        int choice = 0;
        MessageService messageService = new(new MessageDB(), new MessageDB(), new AdminMessageDB());
        AdminService adminService = new(new UserDB(), new UserEditorDB(), new AdminDB(), new AdminEditorDB(), new AddvertiseDb(), new AdminExistsDB());
        LogInService logInService = new(new AdminDB(), new Validator(), new EmailSender(), new UserExistsDB(), new AdminExistsDB());
        UserService userservise = new(new UserDB(), new UserEditorDB(), new UserExistsDB());
        AdminMessageService adminMessageService = new(new AdminMessageDB(), new MessageDB());
        AdvertiseService advertiseService = new(new AddvertiseDb());
        advertiseoperator advertiseoperator = new(advertiseService);
        UserOperator userOperator = new(logInService, userservise, new Validator());
        AdminOperator adminOperator = new(logInService, adminService, userservise, new AdminEditorDB(), new Validator());
        MessageOperator messageOperator = new(messageService);
        AdminMessageOperator adminMessageOperator = new(adminMessageService);
        User user = new();
        Admin admin = new();
        Console.Clear();
        while (loginPage)
        {
            System.Console.WriteLine("Scam_Blocket");
            System.Console.WriteLine("");
            System.Console.WriteLine("[1] Create account");
            System.Console.WriteLine("[2] Log in");
            System.Console.WriteLine("[3] Log in as admin");
            loginOption = ConsoleInput.GetInt("Go to page: ");
            switch (loginOption)
            {// felhantering funkar för det mesta, ska skapa 2 editor databasklasser och dela upp
                case 1:
                    userOperator.CreateUser(user, logInService);
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
                    admin = new();
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
        while (loggedInAsUser)
        {
            user = userOperator.GetUser(user);
            System.Console.WriteLine(user.Name.ToUpper() + "'s Account");
            System.Console.WriteLine("-------------------------------");
            System.Console.WriteLine("[1] Create Ad     [2] Show My Ads     [3] Search For Ads     [4] My Messages");
            System.Console.WriteLine("[5] Edit profile");
            System.Console.WriteLine("[6] Contact us     [7] Log Out");
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
                    choice = ConsoleInput.GetInt("[1] Write message to advertise   [2] Return");
                    {
                        if (choice == 1)
                        {
                            advertiseID = ConsoleInput.GetInt("Advertise Number: ");
                            int adUserID = advertiseoperator.GetUserIdFromAdvertise(advertiseID);
                            messageOperator.SendMessage(adUserID, user, "user");
                        }
                        else if (choice == 2)
                        {
                            LoggedInOptions = 1;
                        }
                    }
                    break;
                case 4:
                    messageOperator.ShowAllMessages(user);
                    Console.WriteLine("Messages from Admin (will be shown here for 7 days): ");
                    Console.WriteLine("----------------------");
                    messageOperator.ShowMessagesFromAdmin(user);
                    do
                    {
                        choice = ConsoleInput.GetInt("[1] Read Message  [2] Return");
                    }while(1>choice || choice>2);
                    if (choice == 2)
                    {
                        break;
                    }
                    int messageId = ConsoleInput.GetInt("Enter message to read: ");
                    int participantId = messageOperator.GetSender(messageId);
                    messageOperator.ShowMessageConversation(messageId, participantId, user);
                    int chocie = ConsoleInput.GetInt("[1] Reply    [2] Delete conversation    [3] Return");
                    if (chocie == 1)
                    {
                        messageOperator.SendMessage(participantId, user, "user");
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
                    if (choice == 1)
                    {
                        messageOperator.SendMessage(0, user, "admin");
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
            adminOptions = ConsoleInput.GetInt("[1] Add new admin-account   [2] Check advertises   [3] User-handeler   [4] Advertise-handeler [5] Update email [6] Delete admin account  [7] Log out");
            switch (adminOptions)
            {
                case 1:
                    admin = adminOperator.CreateAdmin(admin);
                    break;
                case 2:
                    adminOperator.GetNonCheckedAds();
                    int advertiseID = ConsoleInput.GetInt("Enter advertise id to check: ");
                    advertiseoperator.CheckAd(advertiseID);
                    break;
                case 3:
                    adminMessageOperator.ShowUsersUnreadMessages(admin);
                    choice = ConsoleInput.GetInt("[1] Reply   [2] Return");
                    if (choice == 1)
                    {
                        int messageId = ConsoleInput.GetInt("Message ID to reply: ");
                        int userId = adminMessageOperator.AdminGetSender(messageId);
                        adminMessageOperator.AdminMakeMessage(admin, userId, messageId);
                    }
                    // För vidare utveckling
                    break;
                case 4:
                    // Advertise Handeler för vidare utveckling
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
                case 7:
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
