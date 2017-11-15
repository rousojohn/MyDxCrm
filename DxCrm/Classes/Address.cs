using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DxCrm.Classes
{
    [DisplayColumn("Addresses")]
    public class Address
    {
        [Display(Name ="Street", AutoGenerateField = true)]
        public string Street { get; set; }

        [Display(Name = "Number", AutoGenerateField = true)]
public string StreetNo { get; set; }

        [Display(Name = "Region", AutoGenerateField = true)]

        public string Region { get; set; }

        [Display(Name = "Posta lCode", AutoGenerateField = true)]
        public int PostalCode { get; set; }
    }
}
