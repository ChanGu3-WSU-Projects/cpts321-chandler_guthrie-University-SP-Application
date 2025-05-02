// <copyright file="GetMemberByUsernameTest.cs" company="Chandler_Guthrie-WSU_ID:011801740">
// Copyright (c) Chandler_Guthrie-WSU_ID:011801740. All rights reserved.
// </copyright>

using LogicEngine_Tests.ProjectTesting;

namespace LogicEngine.Test.ProjectGetMemberByUsername
{
    /// <summary>
    /// testing the GetMemberByUsername from Project.
    /// </summary>
    internal class GetMemberByUsernameTest
    {
        /// <summary>
        /// project to test on.
        /// </summary>
        private TestProject testProject;

        /// <summary>
        /// the setup for tests.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            this.testProject = new TestProject("Project Name", "Description", 200d, DateTime.Now, new DateTime(9999, 1, 1));
            this.testProject.AddMemberToProject(new UserStudent("username1", "password1", "name1", "email1", "address1", "wsuid1"));
            this.testProject.AddMemberToProject(new UserStudent("username2", "password2", "name2", "email2", "address2", "wsuid2"));
            this.testProject.AddMemberToProject(new UserStudent("username3", "password3", "name3", "email3", "address3", "wsuid3"));
            this.testProject.AddMemberToProject(new UserStudent("username4", "password4", "name4", "email4", "address4", "wsuid4"));
        }

        /// <summary>
        /// normal testing.
        /// </summary>
        /// <param name="username"> username of user wanted. </param>
        /// <returns> the username of the user. </returns>
        [Test]
        [TestCase("username1", ExpectedResult = "username1")]
        [TestCase("username3", ExpectedResult = "username3")]
        [TestCase("unknown", ExpectedResult = null)]
        public string? NormalTest(string username)
        {
            IUser? user = this.testProject.GetMemberByUsername(username);
            if (user is null)
            {
                return null;
            }

            return user.Username;
        }
    }
}
