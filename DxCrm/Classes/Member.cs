using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DxCrm.Classes
{
    public class MemberEmail
    {
        public string Email { get; set; }
    }

    public class Member
    {

        private object emails;
        private object phones;
        private object addresses;

        [BsonIgnore]
        public int Version { get; set; }

        [Key]
        public ObjectId Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string FatherName { get; set; }

        public string MotherName { get; set; }

        public DateTime Birthdate { get; set; }

        public string Birthplace { get; set; }

        public object Emails
        {
            get
            {
                if (emails == null)
                {
                    emails = new BindingList<MemberEmail>();
                }
                return emails;
            }

            set
            {
                emails = value;
            }
        }

        public object Phones
        {
            get
            {
                if (phones == null)
                    phones = new BindingList<Telephone>();
                return phones;
            }

            set
            {
                phones = value;
            }
        }


        public Int64 AM { get; set; }

        public string Job { get; set; }

        public DateTime SubscriptionDate { get; set; }

        public DateTime ExpirationDate { get; set; }

        public bool IsActive { get; set; }

        public string Notes { get; set; }

        public int SubscriptionYear { get; set; }

        public object Addresses
        {
            get
            {
                if (addresses == null)
                    addresses = new BindingList<Address>();
                return addresses;
            }

            set
            {
                addresses = value;
            }
        }

        public int Age { get; set; }

        public string TypeId { get; set; }


        [BsonIgnore]
        public string MemberName { get; set; }

        [BsonIgnore]
        public string TypeDescr { get; set; }

        public Member()
        {
            Version = 0;
            Id = new ObjectId();
            Phones = new BindingList<Telephone>();
            Addresses = new BindingList<Address>();
            Emails = new BindingList<MemberEmail>();
        }


    }
}
