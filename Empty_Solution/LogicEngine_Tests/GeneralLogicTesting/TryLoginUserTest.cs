// <copyright file="TryLoginUserTest.cs" company="Chandler_Guthrie-WSU_ID:011801740">
// Copyright (c) Chandler_Guthrie-WSU_ID:011801740. All rights reserved.
// </copyright>

namespace LogicEngine.Test.GeneralLogicTryLoginUser
{
    /// <summary>
    /// testing general logic TryLoginUser method.
    /// </summary>
    internal class TryLoginUserTest
    {
        /// <summary>
        /// data base to test on.
        /// </summary>
        private Database database;

        /// <summary>
        /// acts as current user during testing.
        /// </summary>
        private IUser currentUser;

        /// <summary>
        /// acts as current user state during testing.
        /// </summary>
        private UserState currentUserState;

        /// <summary>
        /// user student to test with.
        /// </summary>
        private UserStudent userStudent;

        /// <summary>
        /// user donor to test with.
        /// </summary>
        private UserDonor userDonor;

        /// <summary>
        /// setup for testing.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            this.userStudent = new UserStudent("Student", "Student", "Student", "Student", "Student", "Student");
            this.userDonor = new UserDonor("Donor", "Donor", "Donor", "Donor", "Donor", "Donor", new CreditCardInfo("Donor", "Donor", "Donor", "Donor", "Donor", "Donor"), new UserDonationSettings(false, false));
            this.database = new Database();
            this.currentUser = new UserGuest();
            this.currentUserState = UserState.GUEST;

            this.database.AddUser(this.userDonor);
            this.database.AddUser(this.userStudent);
        }

        /// <summary>
        /// normal test cases.
        /// </summary>
        /// <param name="username"> username to login to. </param>
        /// <param name="password"> password to login with. </param>
        /// <returns> state that was changed. </returns>
        [Test]
        [TestCase("Student", "Student", ExpectedResult = true)] // normal login.
        [TestCase("Student", "Wrong password", ExpectedResult = false)] // wrong password login.
        [TestCase("UserNotExist", "UserNotExist", ExpectedResult = false)] // user doesn't exist login.
        public bool? NormalTest(string username, string password)
        {
            return GeneralLogic.TryLoginUser(username, password, ref this.database, ref this.currentUser, ref this.currentUserState);
        }

        /// <summary>
        /// Exception test cases.
        /// </summary>
        /// <param name="username"> username to login to. </param>
        /// <param name="password"> password to login with. </param>
        /// <returns> type of exception thrown. </returns>
        [Test]
        [TestCase(null, null, ExpectedResult = typeof(ArgumentNullException))] // adding user with the same username.
        public Type? ExceptionTest(string? username, string? password)
        {
            try
            {
                GeneralLogic.TryLoginUser(username!, password!, ref this.database, ref this.currentUser, ref this.currentUserState);
                return null;
            }
            catch (Exception ex)
            {
                return ex.GetBaseException().GetType();
            }
        }
    }
}
