using CQRS_Ex1.OlTP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_Ex1.Queries
{
    public class AgeQuery : Query
    {
        public Person Target;
    }

}
