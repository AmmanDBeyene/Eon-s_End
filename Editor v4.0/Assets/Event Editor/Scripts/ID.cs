using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Event_Editor.Scripts
{
    public class ID
    {
        private string _value;
        public ID()
        {
            _value = Guid.NewGuid().ToString();
        }
        public override string ToString()
        {
            return _value;
        }

        public static bool operator ==(ID lhs, ID rhs)
        {
            return lhs._value == rhs._value;
        }

        public static bool operator !=(ID lhs, ID rhs)
        {
            return lhs._value != rhs._value;
        }
    }
}
