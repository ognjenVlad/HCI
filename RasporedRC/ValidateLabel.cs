using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows.Controls;
using RasporedRC.Model;
namespace RasporedRC
{
    class ValidateLabel : ValidationRule
    {
        public String tip { get; set; }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value.ToString().Length == 0)
            {
                return new ValidationResult(false, "Popunite polje.");
            }
            if (tip == "ucionica")
            {
                foreach (Classroom c in MainWindow.classrooms)
                {
                    Console.WriteLine(value.ToString());
                    String myString = value.ToString().Replace("\r\n", string.Empty);
                    if (c.label == myString)
                    {

                        return new ValidationResult(false, "Uneta oznaka vec postoji.");
                    }
                }
            }else if(tip == "smer")
            {
                foreach (Course c in MainWindow.courses)
                {
                    Console.WriteLine(value.ToString());
                    String myString = value.ToString().Replace("\r\n", string.Empty);
                    if (c.label == myString)
                    {

                        return new ValidationResult(false, "Uneta oznaka vec postoji.");
                    }
                }
            }
            else if (tip == "predmet")
            {
                foreach (Subject c in MainWindow.subjects)
                {
                    Console.WriteLine(value.ToString());
                    String myString = value.ToString().Replace("\r\n", string.Empty);
                    if (c.label == myString)
                    {

                        return new ValidationResult(false, "Uneta oznaka vec postoji.");
                    }
                }
            }
            else if (tip == "softver")
            {
                foreach (Software c in MainWindow.softwares)
                {
                    Console.WriteLine(value.ToString());
                    String myString = value.ToString().Replace("\r\n", string.Empty);
                    if (c.label == myString)
                    {

                        return new ValidationResult(false, "Uneta oznaka vec postoji.");
                    }
                }
            }


            return new ValidationResult(true, null);

        }
    
    }
}
