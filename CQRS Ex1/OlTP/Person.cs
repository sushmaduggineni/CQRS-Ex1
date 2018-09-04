using CQRS_Ex1.Commands;
using CQRS_Ex1.Events;
using CQRS_Ex1.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_Ex1.OlTP
{
    public class Person
    {
        private int Age;
        private EventAndCommandAndQueryHandler EventBroker;

        public Person(EventAndCommandAndQueryHandler broker)
        {
            this.EventBroker = broker;
            broker.Commands += BrokerOnCommands;
            broker.Queries += BrokerOnQueries;
        }

        public void BrokerOnCommands(object sender, Command command)
        {
            var cac = command as ChangeAgeCommand;
            if (cac != null && cac.Target == this)
            {
                if (cac.Register) EventBroker.AllEvents.Add(new AgeChangedEvent(this, this.Age, cac.Age));
                this.Age = cac.Age;
            }
        }

        public void BrokerOnQueries(object sender, Query query)
        {
            var aq = query as AgeQuery;
            if (aq != null && aq.Target == this)
            {
                aq.Result = this.Age;
            }
        }
    }
}
