using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace APIModel.RequestModels
{
    public class PageModel : IValidatableObject
    {
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> result = new List<ValidationResult>();
            if (PageNumber <= 0)
                result.Add(new ValidationResult("Invalid page number", new[] { nameof(PageNumber) }));

            if (PageSize <= 0 || PageSize > 200)
                result.Add(new ValidationResult("Invalid page size", new[] { nameof(PageSize) }));

            return result;
        }
    }
}
