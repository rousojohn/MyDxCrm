using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DxCrm.Classes
{
    public class AccIncome
    {
        [Key]
        public ObjectId Id { get; set; }

        public string Member { get; set; }

        public DateTime Date { get; set; }

        public long Amount { get; set; }

        public int AA { get; set; }

        public string Type { get; set; }

        public string Notes { get; set; }

        [BsonIgnore]
        public string MemberName { get; set; }

        [BsonIgnore]
        public string TypeDescr { get; set; }

        public AccIncome ()
        {
            Id = new ObjectId();
        }
    }
}