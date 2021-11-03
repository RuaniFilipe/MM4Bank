using MM4Bank.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM4Bank.Domain.Entities
{
    public sealed class Transaction : Entity
    {
        public Decimal Value { get; private set; }
        public Account Origin { get; private set; }
        public Account Destiny { get; private set; }
    }
}