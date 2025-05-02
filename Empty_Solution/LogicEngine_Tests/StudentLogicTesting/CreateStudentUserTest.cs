// <copyright file="CreateStudentUserTest.cs" company="Chandler_Guthrie-WSU_ID:011801740">
// Copyright (c) Chandler_Guthrie-WSU_ID:011801740. All rights reserved.
// </copyright>

using System.ComponentModel.Design;

namespace LogicEngine.Test.StudentLogicCreateStudentUser
{
    /// <summary>
    /// testing StudentLogic method CreateStudentUser.
    /// </summary>
    internal class CreateStudentUserTest
    {
        /// <summary>
        /// the datbase where the clubs are.
        /// </summary>
        private Database database;

        /// <summary>
        /// setup for testing.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            this.database = new Database();
            this.database.AddUser(new UserStudent("username1", "password", "fullname", "email", "address", "wsuid"));
            this.database.AddClub(new Club("SportsClub"));
            this.database.AddClub(new Club("TestClub"));
            this.database.AddClub(new Club("GameClub"));
            this.database.AddClub(new Club("TreeClub"));
        }

        /// <summary>
        /// normal test cases.
        /// </summary>
        /// <param name="testcase"> the current test. </param>
        /// <returns> expected value of method return and extra expected results. </returns>
        [Test]
        [TestCase(0, ExpectedResult = true)] // adding user without anyclubs
        [TestCase(1, ExpectedResult = false)] // no username
        [TestCase(2, ExpectedResult = false)] // no password
        [TestCase(3, ExpectedResult = false)] // no fullname
        [TestCase(4, ExpectedResult = false)] // no email
        [TestCase(5, ExpectedResult = false)] // no address
        [TestCase(6, ExpectedResult = false)] // no wsuid
        [TestCase(7, ExpectedResult = true)] // adding a club
        [TestCase(8, ExpectedResult = false)] // adding user with same username as existing one
        public bool? NormalTest(int testcase)
        {
            List<string> clubsToAdd;
            switch (testcase)
            {
                case 0:
                    clubsToAdd = new List<string>() { };
                    return StudentLogic.CreateStudentUser("username", "password", "fullname", "email", "address", "wsuid", clubsToAdd, ref this.database);
                case 1:
                    clubsToAdd = new List<string>() { };
                    return StudentLogic.CreateStudentUser(string.Empty, "password", "fullname", "email", "address", "wsuid", clubsToAdd, ref this.database);
                case 2:
                    clubsToAdd = new List<string>() { };
                    return StudentLogic.CreateStudentUser("username", string.Empty, "fullname", "email", "address", "wsuid", clubsToAdd, ref this.database);
                case 3:
                    clubsToAdd = new List<string>() { };
                    return StudentLogic.CreateStudentUser("username", "password", string.Empty, "email", "address", "wsuid", clubsToAdd, ref this.database);
                case 4:
                    clubsToAdd = new List<string>() { };
                    return StudentLogic.CreateStudentUser("username", "password", "fullname", string.Empty, "address", "wsuid", clubsToAdd, ref this.database);
                case 5:
                    clubsToAdd = new List<string>() { };
                    return StudentLogic.CreateStudentUser("username", "password", "fullname", "email", string.Empty, "wsuid", clubsToAdd, ref this.database);
                case 6:
                    clubsToAdd = new List<string>() { };
                    return StudentLogic.CreateStudentUser("username", "password", "fullname", "email", "address", string.Empty, clubsToAdd, ref this.database);
                case 7:
                    clubsToAdd = new List<string>() { "TreeClub" };
                    return StudentLogic.CreateStudentUser("username", "password", "fullname", "email", "address", "wsuid", clubsToAdd, ref this.database);
                case 8:
                    clubsToAdd = new List<string>() { };
                    return StudentLogic.CreateStudentUser("username1", "password", "fullname", "email", "address", "wsuid", clubsToAdd, ref this.database);
            }

            return null;
        }

        /// <summary>
        /// Exception test cases.
        /// </summary>
        /// <param name="testCase"> type of testing being conducted. </param>
        /// <returns> type of exception thrown. </returns>
        [Test]
        [TestCase(0, ExpectedResult = typeof(NullReferenceException))] // adding a club that does not exist upon creation
        public Type? ExceptionTest(int testCase)
        {
            try
            {
                List<string> clubsToAdd = new List<string>() { "NOTACLUB" };
                StudentLogic.CreateStudentUser("username", "password", "fullname", "email", "address", "wsuid", clubsToAdd, ref this.database);
                return null;
            }
            catch (Exception ex)
            {
                return ex.GetBaseException().GetType();
            }
        }
    }
}
