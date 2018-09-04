using CQRS_Ex1.Commands;
using CQRS_Ex1.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_Ex1
{
    public class EventAndCommandAndQueryHandler
    {
        public IList<Event> AllEvents = new List<Event>();
        public event EventHandler<Command> Commands;
        public event EventHandler<Query> Queries;


        public void Command(Command c)
        {
            Commands?.Invoke(this, c);
        }

        public T Query<T>(Query q)
        {
            Queries?.Invoke(this, q);
            return (T)q.Result;
        }

        public void UndoLast()
        {
            var e = AllEvents.LastOrDefault();
            var ac = e as AgeChangedEvent;
            if (ac != null)
            {
                Command(new ChangeAgeCommand(ac.Target, ac.OldValue) { Register = false });
                AllEvents.Remove(e);
            }
        }
    }
}
