using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Exceptions
{
    public class AccountNotFoundException : Exception
    {
        public AccountNotFoundException(string msg) : base(msg)
        {
            
        }
    }
}
