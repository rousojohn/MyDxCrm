﻿using System;
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
        [Display(Name ="Διεύθυνση", AutoGenerateField = true)]
        public string Street { get; set; }

        [Display(Name = "Νούμερο", AutoGenerateField = true)]
        public string StreetNo { get; set; }

        [Display(Name = "Περιοχή", AutoGenerateField = true)]

        public string Region { get; set; }

        [Display(Name = "Τ.Κ.", AutoGenerateField = true)]
        public int PostalCode { get; set; }
    }
}
