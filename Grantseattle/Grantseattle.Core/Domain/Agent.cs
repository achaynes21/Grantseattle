using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;
using InventoryERP.Domain;
using Newtonsoft.Json;

namespace InvertoryERP.Core.Domain
{
    public class Agent : Entity, IAggregateRoot
    {
        public Agent()
        {
            Properties = new List<Propertys>();
        }
        [Required]
        [Display(Name = "Last Name")]
        public virtual string LastName { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public virtual string FirstName { get; set; }
        [Display(Name = "Street Name")]
        public virtual string Address1 { get; set; }
        [Display(Name = "Address")]
        public virtual string Address2 { get; set; }

        [Required]
        //[DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public virtual string Email { get; set; }
        [Display(Name = "Contact No")]
        //[DataType(DataType.PhoneNumber, ErrorMessage = "Phone Number is not valid")]
        [Required]
        public virtual string ContactNo { get; set; }
        public virtual string Remarks { get; set; }
        public virtual string ImageUrl { get; set; }
        public virtual int AgentStatus { get; set; }

        //[DataType(DataType.Upload)]
        //[JsonIgnore]
        //public virtual HttpPostedFileBase UploadImage { get; set; }
        public virtual IList<Propertys> Properties { get; set; }

        public class AgentStatusText
        {
            public static int Active
            {
                get { return 1; }
            }

            public static int InActive
            {
                get { return 2; }
            }

            public static int Delete
            {
                get { return 3; }
            }
        }

        public int Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
