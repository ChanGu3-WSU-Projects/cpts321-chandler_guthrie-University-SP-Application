// <copyright file="AddApplicationTest.cs" company="Chandler_Guthrie-WSU_ID:011801740">
// Copyright (c) Chandler_Guthrie-WSU_ID:011801740. All rights reserved.
// </copyright>

using LogicEngine_Tests.ProjectTesting;

namespace LogicEngine.Test.ScholarshipAddApplication
{
    /// <summary>
    /// testing the AddApplication from Scholarship.
    /// </summary>
    internal class AddApplicationTest
    {
        /// <summary>
        /// the setup for tests.
        /// </summary>
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// normal testing.
        /// </summary>
        [Test]
        public void NormalTest()
        {
            UserDonor userDonor = new UserDonor(
                    "username1",
                    "password1",
                    "name1",
                    "email1",
                    "address1",
                    "company1",
                    new CreditCardInfo(
                        "cardnumber1", "nameoncard1", "address1", "country1", "cvv1", "expdate1"),
                    new UserDonationSettings(false, false));

            BoolCriteria boolCriteria = new BoolCriteria("boolC1", "True");
            RangeCriteria rangeCriteria = new RangeCriteria("rangeC1", 2, 5);

            Scholarship scholarship = new Scholarship(
                userDonor,
                "scholarship",
                "description",
                new DateTime(9999, 1, 1),
                new List<Criteria> { boolCriteria, rangeCriteria },
                new Donation(userDonor, "500", userDonor.UserDonationSettings.IsNameAnonymous, userDonor.UserDonationSettings.IsAmountAnonymous));

            UserStudent userStudent2 = new UserStudent("username2", "password2", "name2", "email2", "address2", "wsuid2");
            UserStudent userStudent3 = new UserStudent("username3", "password3", "name3", "email3", "address3", "wsuid3");
            UserStudent userStudent4 = new UserStudent("username4", "password4", "name4", "email4", "address4", "wsuid4");

            Assert.That(
                scholarship.AddApplication(new Application(userStudent2, new Dictionary<Criteria, string>() { { boolCriteria, "True" }, { rangeCriteria, "3" } })),
                Is.EqualTo(true)); // new student applies

            Assert.That(
                scholarship.AddApplication(new Application(userStudent2, new Dictionary<Criteria, string>() { { boolCriteria, "True" }, { rangeCriteria, "3" } })),
                Is.EqualTo(false)); // same student applies
        }
    }
}
