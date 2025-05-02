// <copyright file="CreditCardInfo.cs" company="Chandler_Guthrie-WSU_ID:011801740">
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
    /// user credit card info.
    /// </summary>
    internal class CreditCardInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreditCardInfo"/> class.
        /// </summary>
        /// <param name="cardnumber"> cardnumber of creditcardinfo. </param>
        /// <param name="nameoncard"> nameoncard of creditcardinfo. </param>
        /// <param name="address"> address of creditcardinfo. </param>
        /// <param name="country"> country of creditcardinfo. </param>
        /// <param name="cvv"> cvv of creditcardinfo. </param>
        /// <param name="expdate"> expdate of creditcardinfo. </param>
        public CreditCardInfo(string cardnumber, string nameoncard, string address, string country, string cvv, string expdate)
        {
            this.CardNumber = cardnumber;
            this.NameOnCard = nameoncard;
            this.Address = address;
            this.Country = country;
            this.CVV = cvv;
            this.ExpDate = expdate;
        }

        /// <summary>
        /// Gets or sets the creditcard number of user.
        /// </summary>
        public string CardNumber
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or Sets the creditcard name of user.
        /// </summary>
        public string NameOnCard
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the creditcard address of user.
        /// </summary>
        public string Address
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or Sets the creditcard country of user.
        /// </summary>
        public string Country
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or Sets the creditcard cvv of user.
        /// </summary>
        public string CVV
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or Sets the creditcard expdate of user.
        /// </summary>
        public string ExpDate
        {
            get;
            set;
        }
    }
}
