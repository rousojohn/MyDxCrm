using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DxCrm.Classes
{
    public class OutcomeType
    {
        [Key, Display(AutoGenerateField = false)]
        public ObjectId Id { get; set; }

        public string Description { get; set; }

        public OutcomeType()
        {
            Id = new ObjectId();
        }
    }
}

