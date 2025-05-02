// <copyright file="Criteria.cs" company="Chandler_Guthrie-WSU_ID:011801740">
// Copyright (c) Chandler_Guthrie-WSU_ID:011801740. All rights reserved.
// </copyright>

namespace LogicEngine
{
    /// <summary>
    /// base for what a criteria needs.
    /// </summary>
    public abstract class Criteria
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Criteria"/> class.
        /// </summary>
        /// <param name="name"> describes Criteria. </param>
        public Criteria(string name)
        {
            this.Name = name;
        }

        /// <summary>
        /// Gets the name that Describes Criteria.
        /// </summary>
        public string Name
        {
            get;
            private set;
        }
    }
}
