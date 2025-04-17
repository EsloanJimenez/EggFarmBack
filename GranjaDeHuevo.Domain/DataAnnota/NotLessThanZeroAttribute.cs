using System.ComponentModel.DataAnnotations;

namespace GranjaDeHuevo.Domain.DataAnnota
{
    public class NotLessThanZeroAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is int intValue)
            {
                if (intValue < 0)
                    return false;
            }

            return true;
        }
    }
}
