// <copyright file="UserGuest.cs" company="Chandler_Guthrie-WSU_ID:011801740">
// Copyright (c) Chandler_Guthrie-WSU_ID:011801740. All rights reserved.
// </copyright>

namespace LogicEngine
{
    /// <summary>
    /// guest donor.
    /// </summary>
    internal class UserGuest : IUser
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserGuest"/> class.
        /// </summary>
        public UserGuest()
        {
            this.Username = string.Empty;
            this.Password = string.Empty;
            this.FullName = string.Empty;
            this.Email = string.Empty;
            this.Address = string.Empty;
        }

        /// <summary>
        /// Gets or sets the username of the student user.
        /// </summary>
        public string Username
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the password of the student user.
        /// </summary>
        public string Password
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the name of the student user.
        /// </summary>
        public string FullName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the email of the student user.
        /// </summary>
        public string Email
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the address of the student user.
        /// </summary>
        public string Address
        {
            get;
            set;
        }
    }
}
