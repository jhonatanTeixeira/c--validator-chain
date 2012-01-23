using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Validators.Validate.Validator
{
    class Email : IValidator
    {
        public bool isValid(dynamic value)
        {
            string pattern = "[0-9a-zA-Z._-]+@[a-zA-Z0-9]+\\.[a-zA-Z]{2,4}$";
            Regex regex = new Regex(pattern);

            return regex.IsMatch(Convert.ToString(value));
        }


        public string getErrorMessage()
        {
            return "email invalido";
        }
    }
}
