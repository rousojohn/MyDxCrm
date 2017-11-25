using MongoDB.Bson;
using System;
using System.ComponentModel;

namespace DxCrm.Classes
{

    public class Member
    {
        const string RootGroup = "<Root>";
        //const string Photo = RootGroup + "/" + "<Photo->";
        const string FirstNameAndLastName = RootGroup + "/" + "<FirstAndLastName->";
        const string TabbedGroup = RootGroup + "/" + "{Tabs}";
        const string ContactGroup = TabbedGroup + "/" + "Contact";
        const string MoreInfoGroup = TabbedGroup + "/" + "More";

        // Contact Group controls
        const string FatherMother = ContactGroup + "/" + "<FatherMother->";
        const string BDateAndBplace = ContactGroup + "/" + "<BDateAndBplace->";
        const string AddressesGroup = ContactGroup + "/" + "<AddressesGroup->";
        const string PhonesEmailsGroup = ContactGroup + "/" + "<PhonesEmailsGroup->";

        // More Info Group controls
        const string AmAndActiveAndType = MoreInfoGroup + "/" + "<AmAndActiveAndType->";
        const string SubExpDateSubYear = MoreInfoGroup + "/" + "<SubExpDateSubYear->";
        const string JobGroup = MoreInfoGroup + "/" + "<JobGroup->";

        private object emails;
        private object phones;
        private object addresses;

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

        //public MemberType Type { get; set; }
        public string TypeId;


        public Member()
        {
            Id = new ObjectId();
            Phones = new BindingList<Telephone>();
            Addresses = new BindingList<Address>();
            Emails = new BindingList<string>();
        }


    }
}
