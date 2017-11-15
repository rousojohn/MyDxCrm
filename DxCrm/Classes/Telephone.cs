using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DxCrm.Classes
{
    public enum TelephoneType
    {
        Home,
        Work,
        Mobile,
        Other
    }

    public class Telephone
    {
        public string Number { get; set; }
        public TelephoneType Type { get; set; }
    }
}
