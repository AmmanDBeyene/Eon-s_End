using EECore.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEDemo
{
    public class Flag
    {
        public string name   { get; }
        
        private object _state;
        public object state  {
            get
            {
                return _state;
            }
            set
            {
                _state = value;
                Type computedType = _state.GetType();
                
                if (computedType == typeof(string))
                {
                    type = FlagType.String;
                    return;
                }

                if (computedType == typeof(bool))
                {
                    type = FlagType.Boolean;
                    return;
                }

                if (computedType == typeof(int)
                    || computedType == typeof(float)
                    || computedType == typeof(double))
                {
                    type = FlagType.Number;
                    return;
                }

                type = null;
            }
        }

        public FlagType? type { get; private set; }

        public Flag()
            : this("") { }

        public Flag(string name)
            : this (name, 0) { }
        
        public Flag(string name, object state)
        {
            this.name = name;
            this.state = state;
        }
    }
}
