using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedGrape.Infra.Core.Models
{
    public class Aggregate<TAggregate, TKeyType> : Entity<TAggregate, TKeyType>, IEntity<TAggregate>
           where TAggregate : Entity<TAggregate, TKeyType>
           where TKeyType : Id, IId<TAggregate>
    {
        protected Aggregate(TKeyType id) : base(id)
        {
        }
    }
    public class Aggregate<T> : Entity<T> where T : Aggregate<T>
    {
        protected Aggregate(Id<T> id) : base(id)
        {
        }
    }
}
