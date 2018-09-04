using CQRS_Ex1.Commands;
using CQRS_Ex1.OlTP;
using CQRS_Ex1.Queries;
using System;

namespace CQRS_Ex1
{
    class Program
    {
        static void Main(string[] args)
        {
            var eb = new EventAndCommandAndQueryHandler();
            var p = new Person(eb);
            eb.Command(new ChangeAgeCommand(p, 123));

            foreach(var ev in eb.AllEvents)
            {
                Console.WriteLine(ev);
            }

            int age = eb.Query<int>(new AgeQuery { Target = p });

            Console.WriteLine(age);

            eb.UndoLast();

            foreach (var ev in eb.AllEvents)
            {
                Console.WriteLine(ev);
            }

            age = eb.Query<int>(new AgeQuery { Target = p });

            Console.WriteLine(age);
            Console.ReadKey();
        }
    }
   
}
