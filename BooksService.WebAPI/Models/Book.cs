using System;
using System.ComponentModel.DataAnnotations;

namespace BooksService.WebAPI.Models
{
    public class Book : IValidatableObject
    {
        [Required(ErrorMessage = "Title field is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Author field is required")]
        [Range(3, 30, ErrorMessage = "")]
        public string Author { get; set; }

        [Required(ErrorMessage = "PublicationDate Field is required")]
        [DataType(DataType.DateTime)]
        public DateTime PublicationDate { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Title.Length < 0 || Title.Length > 255)
            {
                yield return new ValidationResult("Title is invalid: Title must contain a minimum of 5 characters and a maximum of 255, and the first letter should be in upper case");
            }
            if (Author.Length < 3 || Author.Length > 30)
            {
                yield return new ValidationResult("Author is invalid: Author must contain a minimum of 3 characters and a maximum of 30, and the first letter should be in upper case");
            }
            if(PublicationDate.Date > DateTime.Now.Date || PublicationDate.Date < new DateTime(1900,1,1))
            {
                yield return new ValidationResult("PublicationDate is invalid: PublicationDate must be after 01/01/1900 and before the current date");
            }
        }
    }
}