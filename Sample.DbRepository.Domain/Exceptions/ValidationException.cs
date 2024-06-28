using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sample.DbRepository.Domain
{
    public sealed class ApiValidationException : Exception
    {
        private readonly List<ApiValidationError> _Errors = new List<ApiValidationError>();

        public ApiValidationException(IEnumerable<ApiValidationError> errors)
        {
            this._Errors.AddRange(errors);
        }

        public ApiValidationException(ApiValidationError error)
        {
            this._Errors.Add(error);
        }

        public ApiValidationException(string code, string context, string message)
        {
            _Errors.Add(new ApiValidationError()
            {
                Code = code,
                Context = context,
                Message = message,
            });
        }

        public ApiValidationException(string message)
            : base(message)
        {
        }

        public ApiValidationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public ApiValidationException()
        {
        }

        public IReadOnlyCollection<ApiValidationError> Errors => _Errors;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var error in this.Errors)
            {
                sb.AppendFormat("Code: {0} - Context: {1} - Message: {2}", error.Code, error.Context, error.Message);
                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}
