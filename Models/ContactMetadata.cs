using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Contact.Models
{
    // I extended my auto-generated EF class to create new properties and apply metadata (field names and validation)

    [MetadataType(typeof(ContactMetadata))]
    public partial class Contact
    {

        /// <summary>
        /// Returns FirstName + MiddleInitial + LastName if they exist with spaces in between.
        /// </summary>
        public string FullName
        {
            get
            {
                // FirstName is guaranteed to not be null, but just in case things change later, I'm going to double-check for null values.
                var fullname = this.FirstName ?? "";  

                // append MI
                fullname += String.IsNullOrWhiteSpace(this.MiddleInitial) ? "" : " " + this.MiddleInitial;

                // append LastName
                fullname += String.IsNullOrWhiteSpace(this.LastName) ? "" : " " + this.LastName;

                return fullname;
            }
        }
    }

    public class ContactMetadata
    {
        // this is the only required field right now
        [Required(ErrorMessage = "First Name is required"), DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Middle Initial")]
        public string MiddleInitial { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("Line 1")]  // this matches the example in the requirements
        public string Address1 { get; set; }

        [DisplayName("Line 2")]  // this matches the example in the requirements
        public string Address2 { get; set; }

        [DisplayName("City")]
        public string City { get; set; }

        [DisplayName("Province")]
        public string Province { get; set; }

        [DisplayName("Postal Code")]
        public string PostalCode { get; set; }

        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }

        [DisplayName("Email")]
        public string Email { get; set; }

        [DisplayName("Full Name")]
        public string FullName { get; set; }
    }
}