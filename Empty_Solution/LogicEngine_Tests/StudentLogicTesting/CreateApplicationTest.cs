// <copyright file="CreateApplicationTest.cs" company="Chandler_Guthrie-WSU_ID:011801740">
// Copyright (c) Chandler_Guthrie-WSU_ID:011801740. All rights reserved.
// </copyright>

namespace LogicEngine.Test.StudentLogicCreateApplication
{
    /// <summary>
    /// testing StudentLogic method CreateApplication.
    /// </summary>
    internal class CreateApplicationTest
    {
        /// <summary>
        /// the scholarship being applied to.
        /// </summary>
        private Scholarship scholarship;

        /// <summary>
        /// the user applying to the scholarship.
        /// </summary>
        private IUser user;

        /// <summary>
        /// criteria added to scholarship.
        /// </summary>
        private List<Criteria> criterias;

        /// <summary>
        /// setup for testing.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            this.user = new UserStudent("STUDENT", "STUDENT", "STUDENT", "STUDENT", "STUDENT", "STUDENT");

            this.criterias = new List<Criteria>() { new RangeCriteria("TEST", 1.5, 3.5), new BoolCriteria("TEST", "True"), new RangeCriteria("TEST", 18, 25) };

            UserDonor userDonorTimLee = new UserDonor(
                "tim_lee_student",
                "timPassword789",
                "Tim Lee",
                "tim.lee@email.com",
                "789 Pine Road, TX",
                "Test Company",
                new CreditCardInfo("Test", "Test", "Test", "Test", "Test", "Test"),
                new UserDonationSettings(true, true));

            this.scholarship = new Scholarship(
                userDonorTimLee,
                "Scholarship",
                $"Scholarship {Environment.NewLine}{Environment.NewLine}Scholarship",
                new DateTime(2024, 11, 29, 23, 59, 59),
                this.criterias,
                new Donation(userDonorTimLee, "100", true, true));
        }

        /// <summary>
        /// normal test cases.
        /// </summary>
        /// <param name="answer1"> criteria answer 1. </param>
        /// <param name="answer2"> criteria answer 2. </param>
        /// <param name="answer3"> criteria answer 3. </param>
        /// <returns> if the application succeeds. </returns>
        [Test]
        [TestCase("", "answer2", "answer3", ExpectedResult = false)] // no answer for 1
        [TestCase("answer1", "", "answer3", ExpectedResult = false)] // no answer for 2
        [TestCase("answer1", "answer2", "", ExpectedResult = false)] // no answer for 3
        [TestCase("answer1", "answer2", "answer3", ExpectedResult = true)] // all answers
        public bool? NormalTest(string answer1, string answer2, string answer3)
        {
            Dictionary<Criteria, string> criteriaAnswers = new Dictionary<Criteria, string>() { { this.criterias[0], answer1 }, { this.criterias[1], answer2 }, { this.criterias[2], answer3 } };
            return StudentLogic.CreateApplication(criteriaAnswers, ref this.scholarship, ref this.user);
        }

        /// <summary>
        /// edge test cases.
        /// </summary>
        [Test]
        public void EdgeTest()
        {
            Dictionary<Criteria, string> criteriaAnswers = new Dictionary<Criteria, string>() { { this.criterias[0], "3" }, { this.criterias[1], "True" }, { new BoolCriteria("yep", "True"), "False" } };
            Assert.That(StudentLogic.CreateApplication(criteriaAnswers, ref this.scholarship, ref this.user), Is.EqualTo(false));
        }

        /// <summary>
        /// Exception test cases.
        /// </summary>
        /// <param name="testcase"> type of test being conducted. </param>
        /// <returns> type of exception thrown. </returns>
        [Test]
        [TestCase(0, ExpectedResult = typeof(ArgumentException))] // to many criteria answers
        [TestCase(1, ExpectedResult = typeof(ArgumentException))] // to few criteria answers
        public Type? ExceptionTest(int testcase)
        {
            Dictionary<Criteria, string> criteriaAnswers;
            try
            {
                switch (testcase)
                {
                    case 0:
                        criteriaAnswers = new Dictionary<Criteria, string>() { { this.criterias[0], "3" }, { this.criterias[1], "True" }, { this.criterias[2], "23" }, { new BoolCriteria("yep", "True"), "23" } };
                        StudentLogic.CreateApplication(criteriaAnswers, ref this.scholarship, ref this.user);
                        break;
                    case 1:
                        criteriaAnswers = new Dictionary<Criteria, string>() { { this.criterias[0], "3" }, { this.criterias[1], "True" } };
                        StudentLogic.CreateApplication(criteriaAnswers, ref this.scholarship, ref this.user);
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
