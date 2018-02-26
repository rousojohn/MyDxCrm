using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel;

namespace DxCrm.Classes
{
    public class AccOutcome
    {
        public ObjectId Id { get; set; }

        public string Supplier { get; set; }

        public DateTime Date { get; set; }

        public double Amount { get; set; }

        public int AA { get; set; }

        public string Type { get; set; }

        public string Notes { get; set; }

        [BsonIgnore]
        public string SupplierName { get; set; }

        [BsonIgnore]
        public string TypeDescr { get; set; }

        public AccOutcome()
        {
            Id = new ObjectId();
        }
    }
}
