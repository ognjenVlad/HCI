using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace RasporedRC
{
    class EmptyValidation:ValidationRule
    {

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value.ToString().Length == 0)
            {
                return new ValidationResult(false, "Popunite polje.");
            }
                  return new ValidationResult(true, null);
            }
        
    }


}
