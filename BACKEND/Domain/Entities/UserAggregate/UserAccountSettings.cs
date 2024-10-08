using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.UserAggregate
{
    public class UserAccountSettings: IAggregateRoot
    {

        public string Test { get; private set; }
        public UserAccountSettings(string test) 
        {
            Test = test;
        }
    }
}
