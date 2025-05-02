// <copyright file="DatabaseTests.cs" company="Chandler_Guthrie-WSU_ID:011801740">
// Copyright (c) Chandler_Guthrie-WSU_ID:011801740. All rights reserved.
// </copyright>

using System.Reflection;
using LogicEngine_Tests;

namespace LogicEngine.Test.ClassDatabase
{
    /// <summary>
    /// testing for database functionality.
    /// </summary>
    internal class DatabaseTests
    {
        /// <summary>
        /// the database setup.
        /// </summary>
        private Database database;

        /// <summary>
        /// database user info.
        /// </summary>
        private FieldInfo? databaseUsersInfo;

        /// <summary>
        /// database user field.
        /// </summary>
        private Dictionary<string, IUser> users;

        /// <summary>
        /// setup for testing.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            this.databaseUsersInfo = ReflectionMethods.GetField("users", typeof(Database), BindingFlags.Instance | BindingFlags.NonPublic);

            this.database = new Database();

            this.users = (Dictionary<string, IUser>)this.databaseUsersInfo!.GetValue(this.database)!;

            IUser newUser;

            newUser = new UserStudent("mary_jane_456", "mySecurePass456", "Mary Jane", "mary.jane@email.com", "456 Oak Avenue, CA", "WSU00234");
            this.users.Add(newUser.Username, newUser);

            newUser = new UserDonor(
                "tim_lee_student",
                "timPassword789",
                "Tim Lee",
                "tim.lee@email.com",
                "789 Pine Road, TX",
                "Test Company",
                new CreditCardInfo("Test", "Test", "Test", "Test", "Test", "Test"),
                new UserDonationSettings(true, true));

            this.users.Add(newUser.Username, newUser);

            newUser = new UserStudent("sara_miller84", "saraStrongPass987", "Sara Miller", "sara.miller@email.com", "101 Maple Street, FL", "WSU00456");
            this.users.Add(newUser.Username, newUser);

            newUser = new UserStudent("alex_walker23", "alexWalkerPass345", "Alex Walker", "alex.walker@email.com", "202 Birch Blvd, IL", "WSU00567");
            this.users.Add(newUser.Username, newUser);
        }

        /// <summary>
        /// normal test cases.
        /// </summary>
        [Test]
        public void NormalTest()
        {
            IUser newStudent = new UserStudent("john_smith92", "securePass123", "John Smith", "john.smith@email.com", "123 Elm Street, NY", "WSU00123");
            this.database.AddUser(newStudent);
            Assert.That(this.users[newStudent.Username], Is.EqualTo(newStudent)); // Add User Test
            Assert.That(this.database.GetUserByUsername(newStudent.Username), Is.EqualTo(newStudent)); // Get User Test
            Assert.That(this.database.GetUserByUsername("UserNotInDataBase"), Is.EqualTo(null));
        }

        /// <summary>
        /// Exception test cases. (0 AddUser, 1 GetUserByUsername).
        /// </summary>
        /// <param name="testCase"> test number corresponding to function. </param>
        /// <returns> type of exception thrown. </returns>
        [Test]
        [TestCase(0, ExpectedResult = typeof(NotSupportedException))] // adding user with the same username.
        public Type? ExceptionTest(int testCase)
        {
            try
            {
                switch (testCase)
                {
                    case 0:
                        IUser newStudent = new UserStudent("john_smith92", "securePass123", "John Smith", "john.smith@email.com", "123 Elm Street, NY", "WSU00123");
                        this.users.Add(newStudent.Username, newStudent);
                        newStudent = new UserStudent("john_smith92", "securePass123", "John Smith", "john.smith@email.com", "123 Elm Street, NY", "WSU00123");
                        this.database.AddUser(newStudent);
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
