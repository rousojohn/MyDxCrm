using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

using System.ComponentModel.DataAnnotations;

namespace DxCrm.Classes
{
    public class MemberType
    {
        [Key, Display(AutoGenerateField =false)]
        public ObjectId Id { get; set; }

        public string Description { get; set; }

        public MemberType()
        {
            Id = new ObjectId();
        }
    }
}
