using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
   public class EmailConfirmation :Entity
    {
        public EmailConfirmation()
        {
            OldEmailAdress = string.Empty; // veya null! kullanabilirsin
            NewEmailAdress = string.Empty;
        }
        public string OldEmailAdress { get; set; }
        public string NewEmailAdress { get; set; }
    }
}
