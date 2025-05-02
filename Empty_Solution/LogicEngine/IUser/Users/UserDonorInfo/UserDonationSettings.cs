// <copyright file="UserDonationSettings.cs" company="Chandler_Guthrie-WSU_ID:011801740">
// Copyright (c) Chandler_Guthrie-WSU_ID:011801740. All rights reserved.
// </copyright>

namespace LogicEngine
{
    /// <summary>
    /// donor users donation defualt settings.
    /// </summary>
    internal class UserDonationSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserDonationSettings"/> class.
        /// </summary>
        /// <param name="isNameAnonymous"> wether user wants name to be anonymous. </param>
        /// <param name="isAmountAnonymous"> wether user wants amount to be anonymous. </param>
        public UserDonationSettings(bool isNameAnonymous, bool isAmountAnonymous)
        {
            this.IsNameAnonymous = isNameAnonymous;
            this.IsAmountAnonymous = isAmountAnonymous;
        }

        /// <summary>
        /// Gets or Sets a value indicating whether the users amount anonymous setting.
        /// </summary>
        public bool IsNameAnonymous
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or Sets a value indicating whether the users amount anonymous setting.
        /// </summary>
        public bool IsAmountAnonymous
        {
            get;
            set;
        }
    }
}
