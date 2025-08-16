using SRM.Domain.Common.Models;
using System.Text.RegularExpressions;
using ErrorOr;

namespace SRM.Domain.UserAggregate;

public class EmailAddress : ValueObject
{
   public string Value { get; }

   private EmailAddress (string emailAddress)
   {
        Value = emailAddress;
   }

   internal static ErrorOr<EmailAddress> CreateEmailAddress(string emailAddress)
   {
        if (!IsValidEmail(emailAddress))
        {
            return Error.Validation(
                    code: "EmailAddress.Validation",
                    description: "Email must be a Qatar Energy LNG address");
        }

        return new EmailAddress(emailAddress);
   }

   private static bool IsValidEmail(string emailAddress)
   {
        const string pattern = @"^[^@\s]+@qatarenergylng\.qa$";
        return Regex.IsMatch(emailAddress, pattern, RegexOptions.IgnoreCase);
   }

   public override IEnumerable<object> GetEqualityComponents()
   {
        yield return Value;
   }
}
