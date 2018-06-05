using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace RasporedRC
{
    public class CollectionNotEmptyValidation: ValidationRule
    {
        public string ErrorMessage
        { get; set; }
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            ValidationResult lResult = null;
            Console.WriteLine("AHA");
            IEnumerable<object> lCollection = (IEnumerable<object>)value;
            if (lCollection == null || lCollection.Count() == 0)
            {
                lResult = new ValidationResult(false, ErrorMessage);
            }
            else
            {
                lResult = new ValidationResult(true, null);
            }

            return lResult;
        }
    }
}
