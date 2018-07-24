using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Vueling.Aplication.Dto
{
    public class PolizasDto
    {
        public Guid id { get; set; }
        public decimal amountInsured { get; set; }
        public string email { get; set; }
        public System.DateTime inceptionDate { get; set; }
        public bool installmentPayment { get; set; }
        public Guid clientId { get; set; }
    }
}
