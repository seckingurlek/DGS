using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossCuttingConcerns.Exceptions
{
    public class BusinessExceptions : Exception
    {
        public BusinessExceptions(string message): base(message) 
        {
            
        }
    }
}
