using System.ComponentModel.DataAnnotations;

namespace ListomoraFront.Models.Validators
{
    public class FutureDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is DateTime date)
            {
                return date.Date >= DateTime.Now.Date;
            }

            return false;
        }
    }
}
