using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;

namespace MyArchitect.Utils
{
    public static class ValidationHelper
    {
        public static string ParsValidationErrors(this IEnumerable<ValidationFailure> errors)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var error in errors)
            {
                sb.AppendFormat("{0} : {1}{2}", error.PropertyName, error.ErrorMessage, Environment.NewLine);
            }
            return sb.ToString();
        }
    }
}
