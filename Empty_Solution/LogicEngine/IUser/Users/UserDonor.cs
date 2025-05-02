// <copyright file="UserDonor.cs" company="Chandler_Guthrie-WSU_ID:011801740">
// Copyright (c) Chandler_Guthrie-WSU_ID:011801740. All rights reserved.
// </copyright>

namespace LogicEngine
{
    /// <summary>
    /// donor user.
    /// </summary>
    internal class UserDonor : IUser
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserDonor"/> class.
        /// </summary>
        /// <param name="username"> username of donor user. </param>
        /// <param name="password"> password of donor user. </param>
        /// <param name="name"> name of donor user. </param>
        /// <param name="email"> email of donor user. </param>
        /// <param name="address"> address of donor user. </param>
        /// <param name="company"> company of the donor user. </param>
        /// <param name="creditCardInfo"> creditcardinfo of the donor user. </param>
        /// <param name="userDonationSettings"> donationsettings of the donor user. </param>
        public UserDonor(string username, string password, string name, string email, string address, string company, CreditCardInfo creditCardInfo, UserDonationSettings userDonationSettings)
        {
            this.Username = username;
            this.Password = password;
            this.FullName = name;
            this.Email = email;
            this.Address = address;
            this.CompanyName = company;
            this.CreditCardInfo = creditCardInfo;
            this.UserDonationSettings = userDonationSettings;
        }

        /// <summary>
        /// Gets the username of the donor user.
        /// </summary>
        public string Username
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets or Sets the password of the donor user.
        /// </summary>
        public string Password
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or Sets the name of the donor user.
        /// </summary>
        public string FullName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or Sets the email of the donor user.
        /// </summary>
        public string Email
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or Sets the address of the donor user.
        /// </summary>
        public string Address
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or Sets the company of the donor user.
        /// </summary>
        public string CompanyName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or setse the credit card info of donor user.
        /// </summary>
        public CreditCardInfo CreditCardInfo
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the donation settings of donor user.
        /// </summary>
        public UserDonationSettings UserDonationSettings
        {
            get;
            set;
        }
    }
}
