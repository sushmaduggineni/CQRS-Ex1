using CQRS_Ex1.OlTP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_Ex1.Events
{
    public class AgeChangedEvent : Event
    {
        public Person Target;
        public int OldValue, NewValue;

        public AgeChangedEvent(Person target, int oldvalue, int newvalue)
        {
            this.Target = target;
            this.OldValue = oldvalue;
            this.NewValue = newvalue;
        }
        public override string ToString()
        {
            return $"Age changed from {OldValue} to {NewValue}";
        }
    }
}
