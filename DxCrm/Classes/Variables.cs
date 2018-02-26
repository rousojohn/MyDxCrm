using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DxCrm.Classes
{
    public class VarValues
    {
        public string Description { get; set; }
        public string Value { get; set; }
        public VarType Type { get; set; }
    }

    public enum VarType {
        String,
        Int,
        Decimal,
        Long,
        Double
    }

    public class Variables
    {
        [Key]
        public ObjectId Id { get; set; }

        public VarValues[] Values { get; set; }

        public Variables ()
        {
            Id = new ObjectId();
            Values = new VarValues[2]
            {
                new VarValues() {Description = "IncomeInitialValue", Type = VarType.Double} ,
                new VarValues() {Description = "OutcomeInitialValue", Type = VarType.Double}
            };
        }
    }
}
