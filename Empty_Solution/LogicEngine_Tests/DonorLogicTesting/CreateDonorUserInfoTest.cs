// <copyright file="CreateDonorUserInfoTest.cs" company="Chandler_Guthrie-WSU_ID:011801740">
// Copyright (c) Chandler_Guthrie-WSU_ID:011801740. All rights reserved.
// </copyright>

using System.Diagnostics.Metrics;
using System.Net;

namespace LogicEngine.Test.DonorLogicCreateDonorUserInfo
{
    /// <summary>
    /// testing DonorLogic method CreateDonorUserInfo.
    /// </summary>
    internal class CreateDonorUserInfoTest
    {
        /// <summary>
        /// the datbase where the user will be added to.
        /// </summary>
        private Database database;

        /// <summary>
        /// setup for testing.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            this.database = new Database();
            this.database.AddUser(new UserStudent("STUDENT", "STUDENT", "STUDENT", "STUDENT", "STUDENT", "STUDENT"));
        }

        /// <summary>
        /// normal test cases.
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
        /// <returns> whether the creation of the donor user succeeded. </returns>
        [Test]
        [TestCase("username", "password", "fullname", "email", "address", "company", "cardNumber", "nameOnCard", "cardAddress", "country", "cvv", "expdate", false, true, ExpectedResult = true)] // creates donor and succeeds
        [TestCase("STUDENT", "password", "fullname", "email", "address", "company", "cardNumber", "nameOnCard", "cardAddress", "country", "cvv", "expdate", false, true, ExpectedResult = false)] // fails creation same username as another user.
        [TestCase("", "password", "fullname", "email", "address", "company", "cardNumber", "nameOnCard", "cardAddress", "country", "cvv", "expdate", false, true, ExpectedResult = false)] // fails creation username empty.
        [TestCase("username", "", "fullname", "email", "address", "company", "cardNumber", "nameOnCard", "cardAddress", "country", "cvv", "expdate", false, true, ExpectedResult = false)] // fails creation password empty.
        [TestCase("username", "password", "", "email", "address", "company", "cardNumber", "nameOnCard", "cardAddress", "country", "cvv", "expdate", false, true, ExpectedResult = false)] // fails creation fullname empty.
        [TestCase("username", "password", "fullname", "", "address", "company", "cardNumber", "nameOnCard", "cardAddress", "country", "cvv", "expdate", false, true, ExpectedResult = false)] // fails creation email empty.
        [TestCase("username", "password", "fullname", "email", "", "company", "cardNumber", "nameOnCard", "cardAddress", "country", "cvv", "expdate", false, true, ExpectedResult = false)] // fails creation address empty.
        public bool NormalTest(string username, string password, string fullname, string email, string address, string company, string cardNumber, string nameOnCard, string cardAddress, string country, string cvv, string expdate, bool isNameAnonymous, bool isAmountAnonymous)
        {
            return DonorLogic.CreateDonorUserInfo(
                username,
                password,
                fullname,
                email,
                address,
                company,
                cardNumber,
                nameOnCard,
                cardAddress,
                country,
                cvv,
                expdate,
                false,
                true,
                ref this.database);
        }
    }
}
