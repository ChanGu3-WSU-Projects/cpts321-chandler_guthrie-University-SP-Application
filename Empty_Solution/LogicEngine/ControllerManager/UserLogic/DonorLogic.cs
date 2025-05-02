// <copyright file="DonorLogic.cs" company="Chandler_Guthrie-WSU_ID:011801740">
// Copyright (c) Chandler_Guthrie-WSU_ID:011801740. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicEngine
{
    /// <summary>
    /// donor specific logic.
    /// </summary>
    internal static class DonorLogic
    {
        /// <summary>
        /// saves information from donor profile to user.
        /// </summary>
        /// <param name="password"> possible new password. </param>
        /// <param name="name"> possible new name. </param>
        /// <param name="email"> possible new email. </param>
        /// <param name="address"> possible new address. </param>
        /// <param name="company"> possible new company. </param>
        /// <param name="cardNumber"> possible new number on credit card. </param>
        /// <param name="nameOnCard"> possible new name on credit card. </param>
        /// <param name="cardAddress"> possible new address on credit card. </param>
        /// <param name="country"> possible new country on credit card. </param>
        /// <param name="cvv"> possible new cvv on credit card. </param>
        /// <param name="expdate"> possible new expiration date on credit card. </param>
        /// <param name="isNameAnonymous"> possible default settings for name anonymous. </param>
        /// <param name="isAmountAnonymous"> possible default settings for amount anonymous. </param>
        /// <param name="currentUser"> donor user logged in saving info. </param>
        public static void SaveDonorUserInfo(string password, string name, string email, string address, string company, string cardNumber, string nameOnCard, string cardAddress, string country, string cvv, string expdate, bool isNameAnonymous, bool isAmountAnonymous, ref IUser currentUser)
        {
            GeneralLogic.SaveGeneralUserInfo(ref currentUser, password, name, email, address);
            UserDonor donorUser = (UserDonor)currentUser;
            donorUser.CompanyName = company;

            // credit card info
            donorUser.CreditCardInfo.CardNumber = cardNumber;
            donorUser.CreditCardInfo.NameOnCard = nameOnCard;
            donorUser.CreditCardInfo.Address = cardAddress;
            donorUser.CreditCardInfo.Country = country;
            donorUser.CreditCardInfo.CVV = cvv;
            donorUser.CreditCardInfo.ExpDate = expdate;

            // user settings
            donorUser.UserDonationSettings.IsNameAnonymous = isNameAnonymous;
            donorUser.UserDonationSettings.IsAmountAnonymous = isAmountAnonymous;
        }

        /// <summary>
        /// create donor from registration information.
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
        /// <param name="database"> database to add new donor user to. </param>
        /// <returns> true if user is create false if not. </returns>
        public static bool CreateDonorUserInfo(string username, string password, string fullname, string email, string address, string company, string cardNumber, string nameOnCard, string cardAddress, string country, string cvv, string expdate, bool isNameAnonymous, bool isAmountAnonymous, ref Database database)
        {
            // strings empty
            if (username == string.Empty ||
                password == string.Empty ||
                fullname == string.Empty ||
                email == string.Empty ||
                address == string.Empty)
            {
                return false;
            }

            try
            {
                database.AddUser(new UserDonor(username, password, fullname, email, address, company, new CreditCardInfo(cardNumber, nameOnCard, cardAddress, country, cvv, expdate), new UserDonationSettings(isNameAnonymous, isAmountAnonymous)));
                return true;
            }
            catch (NotSupportedException)
            {
                return false;
            }
        }

        /// <summary>
        /// gets the current donor users company name of the application.
        /// </summary>
        /// <param name="user"> donor user retrieving data from. </param>
        /// <returns> company name of user. </returns>
        public static string GetDonorUsersCompanyName(IUser user)
        {
            return ((UserDonor)user).CompanyName;
        }

        /// <summary>
        /// gets the current donor users card number of the application.
        /// </summary>
        /// <param name="user"> donor user retrieving data from. </param>
        /// <returns> card number of donor user. </returns>
        public static string GetDonorUsersCIICardNumber(IUser user)
        {
            return ((UserDonor)user).CreditCardInfo.CardNumber;
        }

        /// <summary>
        /// gets the current donor users credit card name of the application.
        /// </summary>
        /// <param name="user"> donor user retrieving data from. </param>
        /// <returns> the credit card name of donor user. </returns>
        public static string GetDonorUsersCCINameOnCard(IUser user)
        {
            return ((UserDonor)user).CreditCardInfo.NameOnCard;
        }

        /// <summary>
        /// gets the current donor users credit card address of the application.
        /// </summary>
        /// <param name="user"> donor user retrieving data from. </param>
        /// <returns> credit card address of donor user. </returns>
        public static string GetDonorUsersCCIAddress(IUser user)
        {
            return ((UserDonor)user).CreditCardInfo.Address;
        }

        /// <summary>
        /// gets the current donor users credit card country of the application.
        /// </summary>
        /// <param name="user"> donor user retrieving data from. </param>
        /// <returns> credit card country of donor user. </returns>
        public static string GetDonorUsersCCICountry(IUser user)
        {
            return ((UserDonor)user).CreditCardInfo.Country;
        }

        /// <summary>
        /// gets the current donor users credit card CVV of the application.
        /// </summary>
        /// <param name="user"> donor user retrieving data from. </param>
        /// <returns> credit card CVV of donor user. </returns>
        public static string GetDonorUsersCCICVV(IUser user)
        {
            return ((UserDonor)user).CreditCardInfo.CVV;
        }

        /// <summary>
        /// gets the current donor users credit card Expiration date of the application.
        /// </summary>
        /// <param name="user"> donor user retrieving data from. </param>
        /// <returns> credit card experation date of the donor user. </returns>
        public static string GetDonorUsersCCIEXPDate(IUser user)
        {
            return ((UserDonor)user).CreditCardInfo.ExpDate;
        }

        /// <summary>
        /// gets the current donor users donation settings for if their default name should be anonymous on a created donation.
        /// </summary>
        /// <param name="user"> donor user retrieving data from. </param>
        /// <returns> donor users donation setting for anonymous name. </returns>
        public static bool GetIsDonorUsersDSNameAnonymous(IUser user)
        {
            return ((UserDonor)user).UserDonationSettings.IsNameAnonymous;
        }

        /// <summary>
        /// gets the current donor users donation settings for if their default amount should be anonymous on created donation.
        /// </summary>
        /// <param name="user"> donor user retrieving data from. </param>
        /// <returns> donor users donation setting for anonymous amount. </returns>
        public static bool GetIsDonorUsersDSAmountAnonymous(IUser user)
        {
            return ((UserDonor)user).UserDonationSettings.IsAmountAnonymous;
        }
    }
}
