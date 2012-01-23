using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Validators.Validate.Validator;

namespace Validators
{
    class Program
    {
        class User
        { 
            private string _name;
            private string _email;

            public string email { 
                get { 
                    return _email;
                }
                set {
                    _email = value;
                }
            }

            public string name
            {
                get
                {
                    return _name;
                }
                set
                {
                    _name = value;
                }
            }
        }

        static void Main(string[] args)
        {
            User user = new User() {
                name = "jhon" , 
                email = "jhon.jhon@jhon.de"
            };

            Dictionary<string, List<IValidator>> rules = new Dictionary<string, List<IValidator>>();
            rules.Add("email", new List<IValidator>().Add(new Email()));
            Chain chain = new Chain(rules);
            if (!chain.isValid(user)) {
                foreach (string rule in chain.getErrorMessages()) {
                    Console.WriteLine(rule);
                }
            }

            System.Threading.Thread.Sleep(3000);
        }
    }
}
