// <copyright file="RangeCriteria.cs" company="Chandler_Guthrie-WSU_ID:011801740">
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
    /// range of criteria.
    /// </summary>
    public class RangeCriteria : Criteria
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RangeCriteria"/> class.
        /// </summary>
        /// <param name="name"> describes Criteria. </param>
        /// <param name="min"> range starting. </param>
        /// <param name="max"> range ending. </param>
        public RangeCriteria(string name, double min, double max)
            : base(name)
        {
             this.Min = min;
             this.Max = max;
        }

        /// <summary>
        /// Gets the minimum of the range accepting.
        /// </summary>
        public double Min
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the maximum of the range accepting.
        /// </summary>
        public double Max
        {
            get;
            private set;
        }
    }
}
