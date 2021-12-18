using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Attributes
{
    /// <summary>
    ///     Specifies the maximum length of collection/string data allowed in a property.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter,
        AllowMultiple = false)]
    public class GreaterThenZeroAttribute : ValidationAttribute
    {
        private const int MaxAllowableLength = -1;

        /// <summary>
        ///     Initializes a new instance of the <see cref="MaxLengthAttribute" /> class.
        /// </summary>
        /// <param name="length">
        ///     The maximum allowable length of collection/string data.
        ///     Value must be greater than zero.
        /// </param>
        public GreaterThenZeroAttribute()
            : base(() => DefaultErrorMessageString)
        {

        }

        private static string DefaultErrorMessageString => "Price has to be greater then 0";

        public override bool IsValid(object value)
        {
            decimal price = 0;
            // Automatically pass if value is null. RequiredAttribute should be used to assert a value is not null.
            if (value == null)
            {
                return true;
            }
            if (value is decimal)
            {
                price = (decimal)value;
                return price > 0;
            }

            return false;
            
        }
    }
}
