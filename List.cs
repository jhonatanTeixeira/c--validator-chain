using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Validators
{
    class List<Type> : System.Collections.Generic.List<Type>
    {
        public List<Type> Add(Type item)
        {
            base.Add(item);
            return this;
        }
    }
}
