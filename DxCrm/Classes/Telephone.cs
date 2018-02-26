using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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


    [DisplayColumn("Phones")]
    public class Telephone
    {
        [Display(Name = "Τηλέφωνο", AutoGenerateField = true)]
        public string Number { get; set; }

        [Display(Name = "Τύπος", AutoGenerateField = true)]
        public TelephoneType Type { get; set; }
    }
}
