// <copyright file="ControllerManager.cs" company="Chandler_Guthrie-WSU_ID:011801740">
// Copyright (c) Chandler_Guthrie-WSU_ID:011801740. All rights reserved.
// </copyright>

namespace LogicEngine
{
    /// <summary>
    /// the controller of the UI to the engine.
    /// </summary>
    public class ControllerManager
    {
        /// <summary>
        /// the current user state of the application.
        /// </summary>
        private UserState currentUserState;

        /// <summary>
        /// the current user.
        /// </summary>
        private IUser currentUser;

        /// <summary>
        /// database application is using.
        /// </summary>
        private Database database = new Database();

        /// <summary>
        /// Initializes a new instance of the <see cref="ControllerManager"/> class.
        /// </summary>
        public ControllerManager()
        {
            this.currentUser = new UserGuest();
            this.currentUserState = UserState.GUEST;
            this.PopulateDataBaseDemo();
        }

        /// <summary>
        /// when a user has been changed.
        /// </summary>
        public event EventHandler? UserChanged = null;

        /// <summary>
        /// Gets the current user state of the application.
        /// </summary>
        public UserState CurrentUserState
        {
            get => this.currentUserState;
        }

        /// <summary>
        /// saves information from student profile to user.
        /// </summary>
        /// <param name="password"> possible new password. </param>
        /// <param name="name"> possible new name. </param>
        /// <param name="email"> possible new email. </param>
        /// <param name="address"> possible new address. </param>
        /// <param name="wsuid"> possible new wsuid. </param>
        /// <param name="clubNamesToAdd"> possible clubs joined. </param>
        /// <param name="clubNamesToRemove"> possible clubs left. </param>
        public void SaveStudentUserInfo(string password, string name, string email, string address, string wsuid, List<string> clubNamesToAdd, List<string> clubNamesToRemove)
        {
            StudentLogic.SaveStudentUserInfo(password, name, email, address, wsuid, clubNamesToAdd, clubNamesToRemove, ref this.database, ref this.currentUser);
        }

        /// <summary>
        /// create student from registration information.
        /// </summary>
        /// <param name="username"> new student username. </param>
        /// <param name="password"> new student password. </param>
        /// <param name="fullname"> new student fullname. </param>
        /// <param name="email"> new student email. </param>
        /// <param name="address"> new student address. </param>
        /// <param name="wsuid"> new student wsuid. </param>
        /// <param name="clubNames"> club names that student is apart of. </param>
        /// <returns> true if user is create false if not. </returns>
        public bool CreateStudentUser(string username, string password, string fullname, string email, string address, string wsuid, List<string> clubNames)
        {
            return StudentLogic.CreateStudentUser(username, password, fullname, email, address, wsuid, clubNames, ref this.database);
        }

        /// <summary>
        /// creating a project as a student.
        /// </summary>
        /// <param name="name"> name of new project. </param>
        /// <param name="description"> decription of new project. </param>
        /// <param name="targetAmount"> target amount of new project.</param>
        /// <param name="endDate"> endtime of new project.</param>
        /// <param name="projectTypeName"> project name type for new project. </param>
        /// <param name="clubName"> !optional! club type of a club new project.</param>
        /// <returns> true if project created otherwise something went wrong. </returns>
        public bool CreateProject(string name, string description, string targetAmount, string endDate, string projectTypeName, string clubName)
        {
            return StudentLogic.CreateProject(ref this.database, this.currentUser, name, description, targetAmount, endDate, projectTypeName, clubName);
        }

        /// <summary>
        /// takes current user that is a student and creates a application to apply to a scholarship.
        /// </summary>
        /// <param name="criteriaToAnswer"> answers to the criteria. </param>
        /// <param name="scholarship"> the scholarship being applied to. </param>
        /// <returns> true if application is successfull or not. </returns>
        public bool CreateStudentApplication(Dictionary<Criteria, string> criteriaToAnswer, Scholarship scholarship)
        {
            return StudentLogic.CreateApplication(criteriaToAnswer, ref scholarship, ref this.currentUser);
        }

        /// <summary>
        /// get a student users projects.
        /// </summary>
        /// <returns> student user projects. </returns>
        public IEnumerable<Project> GetStudentUserProjects()
        {
            return StudentLogic.GetStudentUserProjects(this.database, this.currentUser);
        }

        /// <summary>
        /// gets list of student applied scholarships.
        /// </summary>
        /// <returns> student applied scholarships. </returns>
        public IEnumerable<Scholarship> GetStudentScholarships()
        {
            return StudentLogic.GetStudentScholarships(this.database, this.currentUser);
        }

        /// <summary>
        /// Gets all the club names in current database.
        /// </summary>
        /// <returns> gets the current existing clubs names. </returns>
        public IEnumerable<string> GetStudentsClubNames()
        {
            return StudentLogic.GetMemberedClubNames(this.database, this.currentUser);
        }

        /// <summary>
        /// logs in a user based on username and password.
        /// </summary>
        /// <param name="username"> username of user. </param>
        /// <param name="password"> password of user. </param>
        /// <returns> true when username and password match a user in database. </returns>
        public bool TryLoginUser(string username, string password)
        {
            if (GeneralLogic.TryLoginUser(username, password, ref this.database, ref this.currentUser, ref this.currentUserState))
            {
                this.UserChanged?.Invoke(null, EventArgs.Empty);
                return true;
            }

            return false;
        }

        /// <summary>
        /// logging out user.
        /// </summary>
        public void Logout()
        {
            GeneralLogic.Logout(ref this.currentUser, ref this.currentUserState);
            this.UserChanged?.Invoke(null, EventArgs.Empty);
        }

        /// <summary>
        /// all project type names.
        /// </summary>
        /// <returns> all existing projects type names. </returns>
        public IEnumerable<string> GetLoadedProjectTypeNames()
        {
            return GeneralLogic.GetLoadedProjectTypeNames();
        }

        /// <summary>
        /// gets a filtered list of projects.
        /// </summary>
        /// <returns> projects that are filtered. </returns>
        public IEnumerable<Project> GetDatabaseFilteredProjects()
        {
            return GeneralLogic.GetDatabaseFilteredProjects(this.database);
        }

        /// <summary>
        /// gets a filtered list of scholarships.
        /// </summary>
        /// <returns> scholarships that are filtered. </returns>
        public IEnumerable<Scholarship> GetDatabaseFilteredScholarships()
        {
            return GeneralLogic.GetDatabaseFilteredScholarships(this.database);
        }

        /// <summary>
        /// Gets all the club names in current database.
        /// </summary>
        /// <returns> gets the current existing clubs names. </returns>
        public IEnumerable<string> GetNameOfClubs()
        {
            return GeneralLogic.GetAllDatabaseClubNames(this.database);
        }

        /// <summary>
        /// saves information from donor profile to user.
        /// </summary>
        /// <param name="password"> possible new password. </param>
        /// <param name="name"> possible new name. </param>
        /// <param name="email"> possible new email. </param>
        /// <param name="address"> possible new address. </param>
        /// <param name="company"> possible new company. </param>
        /// <param name="cardNumber"> possible new number on credit card. </param>
        /// <param name="nameOnCard"> possible new name on credit card. </param>
        /// <param name="cardAddress"> possible new address on credit card. </param>
        /// <param name="country"> possible new country on credit card. </param>
        /// <param name="cvv"> possible new cvv on credit card. </param>
        /// <param name="expdate"> possible new expiration date on credit card. </param>
        /// <param name="isNameAnonymous"> possible default settings for name anonymous. </param>
        /// <param name="isAmountAnonymous"> possible default settings for amount anonymous. </param>
        public void SaveDonorUserInfo(string password, string name, string email, string address, string company, string cardNumber, string nameOnCard, string cardAddress, string country, string cvv, string expdate, bool isNameAnonymous, bool isAmountAnonymous)
        {
            DonorLogic.SaveDonorUserInfo(password, name, email, address, company, cardNumber, nameOnCard, cardAddress, country, cvv, expdate, isNameAnonymous, isAmountAnonymous, ref this.currentUser);
        }

        /// <summary>
        /// create donor from registration information.
        /// </summary>
        /// <param name="username"> new donor username. </param>
        /// <param name="password"> new donor password. </param>
        /// <param name="fullname"> new donor name. </param>
        /// <param name="email"> new donor email. </param>
        /// <param name="address"> new donor address. </param>
        /// <param name="company"> new donor company. </param>
        /// <param name="cardNumber"> new donor number on credit card. </param>
        /// <param name="nameOnCard"> new donor name on credit card. </param>
        /// <param name="cardAddress"> new donor address on credit card. </param>
        /// <param name="country"> new donor country on scredit card. </param>
        /// <param name="cvv"> new donor cvv on credit card. </param>
        /// <param name="expdate"> new donor expiration date on credit card. </param>
        /// <param name="isNameAnonymous"> new donor default settings for name anonymous. </param>
        /// <param name="isAmountAnonymous"> new donor default settings for amount anonymous. </param>
        /// <returns> true if user is create false if not. </returns>
        public bool CreateDonorUserInfo(string username, string password, string fullname, string email, string address, string company, string cardNumber, string nameOnCard, string cardAddress, string country, string cvv, string expdate, bool isNameAnonymous, bool isAmountAnonymous)
        {
            return DonorLogic.CreateDonorUserInfo(username, password, fullname, email, address, company, cardNumber, nameOnCard, cardAddress, country, cvv, expdate, isNameAnonymous, isAmountAnonymous, ref this.database);
        }

        /// <summary>
        /// gets the current users username of the application.
        /// </summary>
        /// <returns> username of user. </returns>
        public string GetUsersUsername()
        {
            return this.currentUser.Username;
        }

        /// <summary>
        /// gets the current users name of the application.
        /// </summary>
        /// <returns> name of user. </returns>
        public string GetUsersFullName()
        {
            return GeneralLogic.GetUsersFullName(this.currentUser);
        }

        /// <summary>
        /// gets the current users email of the application.
        /// </summary>
        /// <returns> email of user. </returns>
        public string GetUsersEmail()
        {
            return GeneralLogic.GetUsersEmail(this.currentUser);
        }

        /// <summary>
        /// gets the current users address of the application.
        /// </summary>
        /// <returns> address of user. </returns>
        public string GetUsersAddress()
        {
            return GeneralLogic.GetUsersAddress(this.currentUser);
        }

        /// <summary>
        /// gets the current users password.
        /// </summary>
        /// <returns> password of user. </returns>
        public string GetUsersPassword()
        {
            return GeneralLogic.GetUsersPassword(this.currentUser);
        }

        /// <summary>
        /// gets the current users student WSUID for the application.
        /// </summary>
        /// <returns> the student users WSUID. </returns>
        public string GetStudentUsersWSUID()
        {
            return StudentLogic.GetStudentUsersWSUID(this.currentUser);
        }

        /// <summary>
        /// gets the current donor users company name of the application.
        /// </summary>
        /// <returns> company name of user. </returns>
        public string GetDonorUsersCompanyName()
        {
            return DonorLogic.GetDonorUsersCompanyName(this.currentUser);
        }

        /// <summary>
        /// gets the current donor users card number of the application.
        /// </summary>
        /// <returns> card number of donor user. </returns>
        public string GetDonorUsersCIICardNumber()
        {
            return DonorLogic.GetDonorUsersCIICardNumber(this.currentUser);
        }

        /// <summary>
        /// gets the current donor users credit card name of the application.
        /// </summary>
        /// <returns> the credit card name of donor user. </returns>
        public string GetDonorUsersCCINameOnCard()
        {
            return DonorLogic.GetDonorUsersCCINameOnCard(this.currentUser);
        }

        /// <summary>
        /// gets the current donor users credit card address of the application.
        /// </summary>
        /// <returns> credit card address of donor user. </returns>
        public string GetDonorUsersCCIAddress()
        {
            return DonorLogic.GetDonorUsersCCIAddress(this.currentUser);
        }

        /// <summary>
        /// gets the current donor users credit card country of the application.
        /// </summary>
        /// <returns> credit card country of donor user. </returns>
        public string GetDonorUsersCCICountry()
        {
            return DonorLogic.GetDonorUsersCCICountry(this.currentUser);
        }

        /// <summary>
        /// gets the current donor users credit card CVV of the application.
        /// </summary>
        /// <returns> credit card CVV of donor user. </returns>
        public string GetDonorUsersCCICVV()
        {
            return DonorLogic.GetDonorUsersCCICVV(this.currentUser);
        }

        /// <summary>
        /// gets the current donor users credit card Expiration date of the application.
        /// </summary>
        /// <returns> credit card experation date of the donor user. </returns>
        public string GetDonorUsersCCIEXPDate()
        {
            return DonorLogic.GetDonorUsersCCIEXPDate(this.currentUser);
        }

        /// <summary>
        /// gets the current donor users donation settings for if their default name should be anonymous on a created donation.
        /// </summary>
        /// <returns> donor users donation setting for anonymous name. </returns>
        public bool GetIsDonorUsersDSNameAnonymous()
        {
            return DonorLogic.GetIsDonorUsersDSNameAnonymous(this.currentUser);
        }

        /// <summary>
        /// gets the current donor users donation settings for if their default amount should be anonymous on created donation.
        /// </summary>
        /// <returns> donor users donation setting for anonymous amount. </returns>
        public bool GetIsDonorUsersDSAmountAnonymous()
        {
            return DonorLogic.GetIsDonorUsersDSAmountAnonymous(this.currentUser);
        }

        /// <summary>
        /// populate the database.
        /// </summary>
        private void PopulateDataBaseDemo()
        {
            // add users.
            UserStudent userStudentUsername = new UserStudent("username", "password", "user name", "user.name@email.com", "A Land Far Far Awat", "000000000");
            UserStudent userStudentMaryJane = new UserStudent("mary_jane_456", "mySecurePass456", "Mary Jane", "mary.jane@email.com", "456 Oak Avenue, CA", "WSU00234");
            UserStudent userStudentAlexWalker = new UserStudent("alex_walker23", "alexWalkerPass345", "Alex Walker", "alex.walker@email.com", "202 Birch Blvd, IL", "WSU00567");
            UserStudent userStudentSaraMiller = new UserStudent("sara_miller84", "saraStrongPass987", "Sara Miller", "sara.miller@email.com", "101 Maple Street, FL", "WSU00456");
            UserDonor userDonorTimLee = new UserDonor(
                "tim_lee_Donor",
                "timPassword789",
                "Tim Lee",
                "tim.lee@email.com",
                "789 Pine Road, TX",
                "Test Company",
                new CreditCardInfo("Test", "Test", "Test", "Test", "Test", "Test"),
                new UserDonationSettings(true, true));
            UserDonor userDonorJaneDoe = new UserDonor(
                "jane_doe_Donor",
                "janePassword123",
                "Jane Doe",
                "jane.doe@email.com",
                "123 Maple Avenue, CA",
                "Sample Corporation",
                new CreditCardInfo("Sample", "Sample", "Sample", "Sample", "Sample", "Sample"),
                new UserDonationSettings(false, true));

            this.database.AddUser(userStudentUsername);
            this.database.AddUser(userStudentMaryJane);
            this.database.AddUser(userStudentAlexWalker);
            this.database.AddUser(userStudentSaraMiller);
            this.database.AddUser(userDonorTimLee);
            this.database.AddUser(userDonorJaneDoe);

            // add clubs (and users to the clubs)
            Club gameDevClub = new Club("Game Dev Club");
            this.database.AddClub(gameDevClub);
            this.database.GetClubByName("Game Dev Club")!.AddMember(userStudentMaryJane);
            this.database.GetClubByName("Game Dev Club")!.AddMember(userStudentSaraMiller);
            this.database.AddClub(new Club("Literature Club"));
            this.database.GetClubByName("Literature Club")!.AddMember(userStudentMaryJane);
            this.database.AddClub(new Club("Sport Club"));
            this.database.AddClub(new Club("Card Club"));

            // Create project
            ClubProject newProject = (ClubProject)ProjectFactory.CreateProject(nameof(ClubProject), "Some Cool Project", $"This Project is about a cool project {Environment.NewLine}{Environment.NewLine}I LOVE PROJECTS!", 235, DateTime.Now, new DateTime(2025, 01, 01, 23, 59, 59));
            this.database.Projects.Add(newProject);
            newProject.AddDonation(new Donation(userDonorTimLee, "29", false, false));
            newProject.AddDonation(new Donation(userDonorTimLee, "10", true, true));
            gameDevClub.AddClubProject(newProject);

            // Create Scholarship
            List<Criteria> criterias1 = new List<Criteria>();
            criterias1.Add(new RangeCriteria("GPA", 1.5, 3.5));
            criterias1.Add(new BoolCriteria("Are You A Student?", "True"));
            criterias1.Add(new RangeCriteria("Age", 18, 25));
            Scholarship scholarship = new Scholarship(
                userDonorTimLee,
                "Some Cool Scholarship",
                $"This Scholarship is about a cool scholarship {Environment.NewLine}{Environment.NewLine}I LOVE SCHOLARSHIPS!",
                new DateTime(2024, 11, 29, 23, 59, 59),
                criterias1,
                new Donation(userDonorTimLee, "100", true, true));
            this.database.Scholarships.Add(scholarship);
            scholarship.AddApplication(
                new Application(
                    userStudentMaryJane,
                    new Dictionary<Criteria, string>() { { criterias1[0], "2.3" }, { criterias1[1], "True" }, { criterias1[2], "23" } }));
            scholarship.AddApplication(
                new Application(
                    userStudentSaraMiller,
                    new Dictionary<Criteria, string>() { { criterias1[0], "3.2" }, { criterias1[1], "False" }, { criterias1[2], "19" } }));
            scholarship.AddStudentToScholarship(userStudentMaryJane);
            scholarship.AddStudentToScholarship(userStudentSaraMiller);
            scholarship.AwardStudents();

            List<Criteria> criterias2 = new List<Criteria>();
            criterias2.Add(new BoolCriteria("Served In Army?", "True"));
            criterias2.Add(new RangeCriteria("GPA", 1.5, 3.5));
            criterias2.Add(new RangeCriteria("Age", 18, 25));
            scholarship = new Scholarship(
                userDonorTimLee,
                "Another Scholarship",
                $"Scholarship {Environment.NewLine}{Environment.NewLine}SCHOLARSHIPS!",
                new DateTime(2024, 12, 01, 23, 59, 59),
                criterias2,
                new Donation(userDonorTimLee, "200", true, true));
            this.database.Scholarships.Add(scholarship);

            scholarship = new Scholarship(
                userDonorJaneDoe,
                "Need A Lift Scholarship",
                $"We Give Students The Lift They Need {Environment.NewLine}{Environment.NewLine}Operation Lift!",
                new DateTime(2025, 03, 01, 23, 59, 59),
                criterias1,
                new Donation(userDonorJaneDoe, "350", true, true));
            this.database.Scholarships.Add(scholarship);

            scholarship = new Scholarship(
                userDonorJaneDoe,
                "Helping Hand Scholarship",
                $"We Give Student a Helping Hand {Environment.NewLine}{Environment.NewLine}HELPERS ON THE WAY!",
                new DateTime(2024, 12, 01, 23, 59, 59),
                criterias2,
                new Donation(userDonorJaneDoe, "635", true, true));
            this.database.Scholarships.Add(scholarship);

        }
    }
}
