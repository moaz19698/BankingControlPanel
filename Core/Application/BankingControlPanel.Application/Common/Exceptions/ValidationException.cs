using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingControlPanel.Application.Common.Exceptions
{
    public class ValidationException : Exception
    {
        public IDictionary<string, string[]> Errors { get; }

        public ValidationException()
            : base("One or more validation failures have occurred.")
        {
            Errors = new Dictionary<string, string[]>();
        }

        public ValidationException(IEnumerable<ValidationFailure> failures)
            : this()
        {
            Errors = new Dictionary<string, string[]>();

            foreach (var failure in failures)
            {
                if (Errors.ContainsKey(failure.PropertyName))
                {
                    var errors = new List<string>(Errors[failure.PropertyName])
                    {
                        failure.ErrorMessage
                    };
                    Errors[failure.PropertyName] = errors.ToArray();
                }
                else
                {
                    Errors[failure.PropertyName] = new[] { failure.ErrorMessage };
                }
            }
        }
    }
}
