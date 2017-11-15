using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

using System.ComponentModel.DataAnnotations;
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
        


        //[Key, Display(AutoGenerateField = false)]
        public ObjectId Id { get; set; }

        //[Required, Display(Name = "First name", GroupName = FirstNameAndLastName)]
        public string Name { get; set; }

        //[Required, Display(Name = "Last name", GroupName = FirstNameAndLastName)]
        [Bindable(true,BindingDirection.TwoWay)]
        public string Surname { get; set; }

        //[Display(Name = "Father's Name", GroupName = FatherMother)]
        public string FatherName { get; set; }

        //[Display(Name = "Mother's Name", GroupName = FatherMother)]
        public string MotherName { get; set; }

        //[Display(Name= "Birthday", GroupName = BDateAndBplace)]
        public DateTime Birthdate { get; set; }

        //[Display(Name="Birth place", GroupName = BDateAndBplace)]
        public string Birthplace { get; set; }

        //[Display(AutoGenerateField = false)]
        //[Display(Name = "Emails", GroupName = PhonesEmailsGroup)]
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

        //[Display(AutoGenerateField = false)]
        //public BindingList<Telephone> Phones { get; set; }
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

        //[Display(AutoGenerateField = false)]

        public Int64 AM { get; set; }
        //[Display(AutoGenerateField = false)]

        public string Job { get; set; }




        //[Display(AutoGenerateField = false)]

        public DateTime SubscriptionDate { get; set; }

        //[Display(AutoGenerateField = false)]

        public DateTime ExpirationDate { get; set; }

        //[Display(AutoGenerateField = false)]

        public bool IsActive { get; set; }

        //[Display(AutoGenerateField = false)]
        public string Notes { get; set; }

        //[Display(AutoGenerateField = false)]

        public int SubscriptionYear { get; set; }

        //[Display(AutoGenerateField = false)]
        //[Display(Name = "Addresses", GroupName = AddressesGroup)]
        //[DataType(DataType.Custom)]
        //public BindingList<Address> Addresses { get; set; }
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



        //[Display(AutoGenerateField = false)]
        public int Age { get; set; }

        //[Display(AutoGenerateField = false)]

        public MemberType Type { get; set; }


        public Member()
        {
            Id = new ObjectId();
            Phones = new BindingList<Telephone>();
            Addresses = new BindingList<Address>();
            Emails = new BindingList<string>();


        }


    }
}
