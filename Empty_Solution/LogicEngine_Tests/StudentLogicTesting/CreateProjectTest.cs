// <copyright file="CreateProjectTest.cs" company="Chandler_Guthrie-WSU_ID:011801740">
// Copyright (c) Chandler_Guthrie-WSU_ID:011801740. All rights reserved.
// </copyright>

namespace LogicEngine.Test.StudentLogicCreateProject
{
    /// <summary>
    /// testing StudentLogic method CreateProject.
    /// </summary>
    internal class CreateProjectTest
    {
        /// <summary>
        /// the datbase where the clubs are.
        /// </summary>
        private Database database;

        /// <summary>
        /// student user thats creating project.
        /// </summary>
        private IUser user;

        /// <summary>
        /// setup for testing.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            this.database = new Database();
            this.user = new UserStudent("STUDENT", "STUDENT", "STUDENT", "STUDENT", "STUDENT", "STUDENT");
            this.database.AddClub(new Club("SportsClub"));
            this.database.AddClub(new Club("TestClub"));
            this.database.AddClub(new Club("GameClub"));
            this.database.AddClub(new Club("TreeClub"));
            this.database.GetClubByName("SportsClub")!.AddMember(this.user);
        }

        /// <summary>
        /// normal test cases.
        /// </summary>
        /// <param name="name"> name of new project. </param>
        /// <param name="description"> decription of new project. </param>
        /// <param name="targetAmount"> target amount of new project.</param>
        /// <param name="endDate"> endtime of new project.</param>
        /// <param name="projectTypeName"> project name type for new project. </param>
        /// <param name="clubName"> !optional! club type of a club new project.</param>
        /// <returns> true if project is created. </returns>
        [Test]
        [TestCase("", "description", "100", "01/01/99", "ClubProject", "SportsClub", ExpectedResult = false)] // project name empty
        [TestCase("name", "description", "100", "01/01/99", "", "SportsClub", ExpectedResult = false)] // project type name empty
        [TestCase("name", "", "100", "01/01/99", "ClubProject", "SportsClub", ExpectedResult = false)] // decscription empty
        [TestCase("name", "description", "", "01/01/99", "ClubProject", "SportsClub", ExpectedResult = false)] // targetamount empty
        [TestCase("name", "description", "100", "", "ClubProject", "SportsClub", ExpectedResult = false)] // enddate empty
        [TestCase("name", "description", "100", "01/01/99", "ClubProject", "", ExpectedResult = false)] // club name empty
        [TestCase("name", "description", "100", "NOTADATE", "ClubProject", "SportsClub", ExpectedResult = false)] // not an enddate empty
        [TestCase("name", "description", "100", "01/01/99", "IndividualProject", "", ExpectedResult = true)] // adding an individual project
        [TestCase("name", "description", "100", "01/01/99", "ClubProject", "SportsClub", ExpectedResult = true)] // adding a club project
        public bool? NormalTest(string name, string description, string targetAmount, string endDate, string projectTypeName, string clubName)
        {
            return StudentLogic.CreateProject(ref this.database, this.user, name, description, targetAmount, endDate, projectTypeName, clubName);
        }

        /// <summary>
        /// edge test cases.
        /// </summary>
        [Test]
        public void EdgeTest()
        {
            Assert.That(StudentLogic.CreateProject(ref this.database, this.user, "name", "description", "100", "01/01/99", "ClubProject", "TestClub"), Is.EqualTo(true)); // can create project not apart of causing project to be created and only members of clubs are added
            Assert.That(StudentLogic.CreateProject(ref this.database, this.user, "name", "description", "100", "01/01/99", "IndividualProject", "TestClub"), Is.EqualTo(true)); // create a individual project but with a club name but club name doesnt do anything
        }

        /// <summary>
        /// Exception test cases.
        /// </summary>
        /// <param name="testCase"> type of testing being conducted. </param>
        /// <returns> type of exception thrown. </returns>
        [Test]
        [TestCase(0, ExpectedResult = typeof(NullReferenceException))] // creating a project for a club that does not exist
        public Type? ExceptionTest(int testCase)
        {
            try
            {
                StudentLogic.CreateProject(ref this.database, this.user, "name", "description", "100", "01/01/99", "ClubProject", "NOTACLUB");
                return null;
            }
            catch (Exception ex)
            {
                return ex.GetBaseException().GetType();
            }
        }
    }
}
