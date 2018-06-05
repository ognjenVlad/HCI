using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows.Controls;
namespace RasporedRC
{
    public class Validation : ValidationRule
    {
        public String tip { get; set; }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if(tip == "year")
            {
                int i;
                Convert.ToDateTime(value.ToString());
                try
                {
                    return new ValidationResult(true, null);
                }

                catch
                {
                    return new ValidationResult(false, "Unesite datum ispravno.");
                }

               

            }else if (tip == "double")
            {
                double i;
                if (value.ToString().Length == 0)
                {
                    return new ValidationResult(false, "Popunite polje.");
                }
                if (double.TryParse(value.ToString(), out i))
                    return new ValidationResult(true, null);

                return new ValidationResult(false, "Unesite broj.");

            }
            else
            {

                int i;
                if (value.ToString().Length == 0)
                {
                    return new ValidationResult(false, "Popunite polje.");
                }
                if (int.TryParse(value.ToString(), out i))
                    return new ValidationResult(true, null);

                return new ValidationResult(false, "Unesite broj.");

            }
            
        }
    }

}
