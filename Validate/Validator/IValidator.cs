using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Validators.Validate.Validator
{
    interface IValidator
    {
        Boolean isValid(dynamic value);
        string getErrorMessage();
    }
}
