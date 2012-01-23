using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Validators.Validate.Validator;
using System.Reflection;

namespace Validators
{
    class Chain
    {
        private Dictionary<string, List<IValidator>> rules;

        private Dictionary<string, dynamic> values;

        private List<string> messages = new List<string>();

        public Chain()
        { 
            
        }

        public Chain(Dictionary<string, List<IValidator>> _rules, Dictionary<string, dynamic> _values)
        {
            addRules(_rules);
            addValues(_values);
        }

        public Chain(Dictionary<string, List<IValidator>> _rules)
        {
            addRules(_rules);
        }

        public void addRules(Dictionary<string, List<IValidator>> _rules)
        {
            if (!(rules is Dictionary<string, List<IValidator>>)) {
                rules = new Dictionary<string, List<IValidator>>();
            }

            foreach (KeyValuePair<string, List<IValidator>> rule in _rules) {
                rules.Add(rule.Key, rule.Value);
            }
        }

        public void addValues(Dictionary<string, dynamic> _values)
        {
            if (!(values is Dictionary<string, dynamic>)) {
                values = new Dictionary<string, dynamic>();
            }

            foreach (KeyValuePair<string, dynamic> value in _values)
            {
                rules.Add(value.Key, value.Value);
            }
        }

        public Boolean isValid()
        {
            bool valid = true;

            foreach (KeyValuePair<string, dynamic> validationValue in values)
            {
                List<IValidator> rule = rules.FirstOrDefault(
                    r => r.Key == validationValue.Key
                ).Value;

                if (null == rule) {
                    continue;
                }

                foreach (IValidator validator in rule) {
                    if (!validator.isValid(validationValue.Value)) {
                        messages.Add(validator.getErrorMessage());
                        valid = false;
                    }
                }
            }

            return valid;
        }

        public Boolean isValid(Dictionary<string, dynamic> _values)
        {
            values = _values;
            return isValid();
        }

        public Boolean isValid(object values)
        {
            PropertyInfo[] info = values.GetType().GetProperties();
            Dictionary<string, dynamic> validate = new Dictionary<string, dynamic>();
            foreach (PropertyInfo property in info) {
                dynamic value = values.GetType()
                    .GetProperty(property.Name)
                    .GetValue(values, null);
                validate.Add(property.Name, value);
            }

            return isValid(validate);
        }

        public List<string> getErrorMessages()
        {
            return messages;
        }
    }
}
