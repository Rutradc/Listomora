using System.ComponentModel.DataAnnotations;

namespace ListomoraFront.Models.Validators
{
    public class FutureTimeAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is TimeSpan time)
            {
                return time > DateTime.UtcNow.TimeOfDay;
            }

            return false;
        }
    }
}
