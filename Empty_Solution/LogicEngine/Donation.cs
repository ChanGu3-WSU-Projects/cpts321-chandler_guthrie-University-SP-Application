// <copyright file="Donation.cs" company="Chandler_Guthrie-WSU_ID:011801740">
// Copyright (c) Chandler_Guthrie-WSU_ID:011801740. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicEngine
{
    /// <summary>
    /// donations.
    /// </summary>
    public class Donation
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Donation"/> class.
        /// </summary>
        /// <param name="userDonated"> user that makes a donation. </param>
        /// <param name="amount"> amount of donation. </param>
        /// <param name="isNameAnonymous"> name on donation.  </param>
        /// <param name="isAmountAnonymous"> amount on donation. </param>
        public Donation(IUser userDonated, string amount, bool isNameAnonymous, bool isAmountAnonymous)
        {
            this.UserDonated = userDonated;
            this.DateCreated = DateTime.Now;

            if (isNameAnonymous == true)
            {
                this.VisibleDonorName = "Anonymous";
            }
            else
            {
                this.VisibleDonorName = userDonated.FullName;
            }

            this.ActualAmount = Convert.ToDouble(amount);
            if (isAmountAnonymous == true)
            {
                this.VisibleAmount = "Hidden";
            }
            else
            {
                this.VisibleAmount = amount;
            }
        }

        /// <summary>
        /// Gets the user that made the donation.
        /// </summary>
        public IUser UserDonated
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the actual amount of the donation.
        /// </summary>
        public double ActualAmount
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the date the donation was created.
        /// </summary>
        public DateTime DateCreated
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the amount the donor donated.
        /// </summary>
        public string VisibleAmount
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the donors name of the donation.
        /// </summary>
        public string VisibleDonorName
        {
            get;
            private set;
        }
    }
}
