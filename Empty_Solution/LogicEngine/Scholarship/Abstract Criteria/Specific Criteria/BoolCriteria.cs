// <copyright file="BoolCriteria.cs" company="Chandler_Guthrie-WSU_ID:011801740">
// Copyright (c) Chandler_Guthrie-WSU_ID:011801740. All rights reserved.
// </copyright>

namespace LogicEngine
{
    /// <summary>
    /// true or false questions for criteria.
    /// </summary>
    public class BoolCriteria : Criteria
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BoolCriteria"/> class.
        /// </summary>
        /// <param name="name"> describes Criteria. </param>
        /// <param name="expectedValue"> what the criteria is expecting. </param>
        public BoolCriteria(string name, string expectedValue)
            : base(name)
        {
            this.ExpectedValue = expectedValue;
        }

        /// <summary>
        /// Gets the expected bool value as a string.
        /// </summary>
        public string ExpectedValue
        {
            get;
            private set;
        }
    }
}
