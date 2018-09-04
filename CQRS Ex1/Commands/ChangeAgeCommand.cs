using CQRS_Ex1.OlTP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_Ex1.Commands
{
    public class ChangeAgeCommand : Command
    {

        public Person Target;
        public int Age;
        public ChangeAgeCommand(Person target, int age)
        {
            this.Target = target;
            this.Age = age;
        }
    }
}
