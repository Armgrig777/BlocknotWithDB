using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BlocknotWithRepo.Data.Entites
{
    public class Address : EntityBase
    {
        public string Street { get; set; }
        public string City { get; set; }
        public override string ToString()
        {
            return $"{Street} - {City}";
        }
    }
}
