// <copyright file="UserStudent.cs" company="Chandler_Guthrie-WSU_ID:011801740">
// Copyright (c) Chandler_Guthrie-WSU_ID:011801740. All rights reserved.
// </copyright>

namespace LogicEngine
{
    /// <summary>
    /// student user.
    /// </summary>
    internal class UserStudent : IUser
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserStudent"/> class.
        /// </summary>
        /// <param name="username"> username of student user. </param>
        /// <param name="password"> password of student user. </param>
        /// <param name="name"> name of student user. </param>
        /// <param name="email"> email of student user. </param>
        /// <param name="address"> address of student user. </param>
        /// <param name="wsuid"> wsuid of student user.</param>
        public UserStudent(string username, string password, string name, string email, string address, string wsuid)
        {
            this.Username = username;
            this.Password = password;
            this.FullName = name;
            this.Email = email;
            this.Address = address;
            this.WSUID = wsuid;
        }

        /// <summary>
        /// Gets the username of the student user.
        /// </summary>
        public string Username
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets or Sets the password of the student user.
        /// </summary>
        public string Password
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or Sets the name of the student user.
        /// </summary>
        public string FullName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or Sets the email of the student user.
        /// </summary>
        public string Email
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or Sets the address of the student user.
        /// </summary>
        public string Address
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or Sets the WSUID of the student user.
        /// </summary>
        public string WSUID
        {
            get;
            set;
        }
    }
}
