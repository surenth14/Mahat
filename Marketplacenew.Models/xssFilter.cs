namespace Marketplacenew.Models{
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using System.Text;

public class xssFilter : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        string strValue = value as string;
        if (string.IsNullOrEmpty(strValue))
        {
            return ValidationResult.Success;
        }

        string encodedValue = HtmlEncoder.Default.Encode(strValue);
        if (string.Equals(encodedValue, strValue, StringComparison.Ordinal))
        {
            return ValidationResult.Success;
        }

        return new ValidationResult($"Input for {validationContext.DisplayName} contains potentially unsafe characters.");
    }
}
}

