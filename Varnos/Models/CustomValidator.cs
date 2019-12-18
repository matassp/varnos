using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Varnos.Models
{
    public class CustomValidator : ValidationAttribute
    {
        public CustomValidator(int id, int max)
        {
            Id = id;
            Max = max;
        }

        public int Id { get; }
        public int Max { get; }

        public string GetErrorMessage() =>
            $"Selected species' quantity cannot be over {Max}.";

        protected override ValidationResult IsValid(object value,
            ValidationContext validationContext)
        {
            int selectedId = ((ItemPointMap)validationContext.ObjectInstance).FkItemidItem;
            if (selectedId == Id && (int)value > Max)
                return new ValidationResult(GetErrorMessage());
            return ValidationResult.Success;
        }
    }
}
