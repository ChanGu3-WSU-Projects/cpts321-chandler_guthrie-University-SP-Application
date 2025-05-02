// <copyright file="SaveStudentUserInfoTest.cs" company="Chandler_Guthrie-WSU_ID:011801740">
// Copyright (c) Chandler_Guthrie-WSU_ID:011801740. All rights reserved.
// </copyright>

namespace LogicEngine.Test.StudentLogicSaveStudentUserInfo
{
    /// <summary>
    /// testing StudentLogic method SaveStudentUserInfo.
    /// </summary>
    internal class SaveStudentUserInfoTest
    {
        /// <summary>
        /// the datbase where the clubs are.
        /// </summary>
        private Database database;

        /// <summary>
        /// student user were saving info.
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
        }

        /// <summary>
        /// normal test cases.
        /// </summary>
        [Test]
        public void NormalTest()
        {
            List<string> clubToAdd = new List<string>() { "SportsClub" };
            List<string> clubToRemove = new List<string>() { "TestClub", "GameClub", "TreeClub" };
            StudentLogic.SaveStudentUserInfo("STUDENT", "STUDENT", "STUDENT", "STUDENT", "STUDENT", clubToAdd, clubToRemove, ref this.database, ref this.user);
            Assert.That(this.database.GetClubByName("SportsClub")!.CurrentMembers.Values.Contains(this.user), Is.EqualTo(true)); // added sports club to student

            clubToAdd = new List<string>() { };
            clubToRemove = new List<string>() { "TestClub", "GameClub", "TreeClub", "SportsClub" };
            StudentLogic.SaveStudentUserInfo("STUDENT", "STUDENT", "STUDENT", "STUDENT", "STUDENT", clubToAdd, clubToRemove, ref this.database, ref this.user);
            Assert.That(this.database.GetClubByName("SportsClub")!.CurrentMembers.Values.Contains(this.user), Is.EqualTo(false)); // removed sports club from student
        }

        /// <summary>
        /// edge test cases.
        /// </summary>
        [Test]
        public void EdgeTest()
        {
            List<string> clubToAdd = new List<string>() { "SportsClub", "GameClub" };
            List<string> clubToRemove = new List<string>() { "TestClub", "GameClub", "TreeClub", "SportsClub" };
            StudentLogic.SaveStudentUserInfo("STUDENT", "STUDENT", "STUDENT", "STUDENT", "STUDENT", clubToAdd, clubToRemove, ref this.database, ref this.user);
            Assert.That(this.database.GetClubByName("SportsClub")!.CurrentMembers.Values.Contains(this.user), Is.EqualTo(true)); // club name is in both add and remove means it will remove then add club,

            clubToAdd = new List<string>() { };
            clubToRemove = new List<string>() { };
            StudentLogic.SaveStudentUserInfo("STUDENT", "STUDENT", "STUDENT", "STUDENT", "STUDENT", clubToAdd, clubToRemove, ref this.database, ref this.user);
            Assert.That(this.database.GetClubByName("GameClub")!.CurrentMembers.Values.Contains(this.user), Is.EqualTo(true)); // not adding or removing does nothing
        }

        /// <summary>
        /// Exception test cases.
        /// </summary>
        /// <param name="testCase"> type of testing being conducted. </param>
        /// <returns> type of exception thrown. </returns>
        [Test]
        [TestCase(0, ExpectedResult = typeof(NullReferenceException))] // removing a club that does not exist
        [TestCase(1, ExpectedResult = typeof(NullReferenceException))] // adding a club that does not exist
        public Type? ExceptionTest(int testCase)
        {
            List<string> clubToAdd;
            List<string> clubToRemove;

            try
            {
                switch (testCase)
                {
                    case 0:
                        clubToAdd = new List<string>() { "SportsClub" };
                        clubToRemove = new List<string>() { "TestClub", "GameClub", "TreeClub", "NOTACLUB" };
                        StudentLogic.SaveStudentUserInfo("STUDENT", "STUDENT", "STUDENT", "STUDENT", "STUDENT", clubToAdd, clubToRemove, ref this.database, ref this.user);
                        break;
                    case 1:
                        clubToAdd = new List<string>() { "NOTACLUB" };
                        clubToRemove = new List<string>() { "TestClub", "GameClub", "TreeClub", "SportsClub" };
                        StudentLogic.SaveStudentUserInfo("STUDENT", "STUDENT", "STUDENT", "STUDENT", "STUDENT", clubToAdd, clubToRemove, ref this.database, ref this.user);
                        break;
                }

                return null;
            }
            catch (Exception ex)
            {
                return ex.GetBaseException().GetType();
            }
        }
    }
}
