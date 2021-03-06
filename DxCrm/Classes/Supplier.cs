﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel;

namespace DxCrm.Classes
{

    public class SupplierEmail
    {
        public string Email { get; set; }
    }

    public class Supplier
    {
        private object emails;
        private object phones;
        private object addresses;

        public ObjectId Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }


        public object Emails
        {
            get
            {
                if (emails == null)
                {
                    emails = new BindingList<string>();
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



        public string Job { get; set; }

        public string Notes { get; set; }


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

        [BsonIgnore]
        public int Version { get; set; }

        public Supplier()
        {
            Version = 0;
            Id = new ObjectId();
            Phones = new BindingList<Telephone>();
            Addresses = new BindingList<Address>();
            Emails = new BindingList<SupplierEmail>();
        }


    }
}
