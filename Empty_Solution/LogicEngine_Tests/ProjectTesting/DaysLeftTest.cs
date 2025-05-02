// <copyright file="DaysLeftTest.cs" company="Chandler_Guthrie-WSU_ID:011801740">
// Copyright (c) Chandler_Guthrie-WSU_ID:011801740. All rights reserved.
// </copyright>

using LogicEngine_Tests.ProjectTesting;

namespace LogicEngine.Test.ProjectDaysLeft
{
    /// <summary>
    /// testing the DaysLeft from Project.
    /// </summary>
    internal class DaysLeftTest
    {
        /// <summary>
        /// normal test cases.
        /// </summary>
        [Test]
        public void NormalTest()
        {
            DateTime dateTimeFakeNow = new DateTime(2024, 12, 1);

            TestProject testProject;
            testProject = new TestProject("Project Name", "Description", 200d, dateTimeFakeNow, new DateTime(9999, 1, 1));
            Assert.That(testProject.DaysLeft(), Is.EqualTo(2912469)); // date in the future

            testProject = new TestProject("Project Name", "Description", 200d, dateTimeFakeNow, new DateTime(1, 1, 1));
            Assert.That(testProject.DaysLeft(), Is.EqualTo(0)); // date in the past
        }
    }
}
