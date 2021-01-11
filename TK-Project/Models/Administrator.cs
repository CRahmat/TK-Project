using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TK_Project.Models
{
    [Table("Administrator")]
    public class Administrator : ApplicationUser
    {
        public Departement Departement { set; get; }
        public bool Gender { set; get; }
        public Status Status { set; get; }
        public string Citizenship { set; get; }
        public DateTimeOffset DOB { get; set; }
        public string NIK { set; get; }
        public Religion Religion { set; get; }
        public virtual ApplicationUser ApprovedBy { set; get; }
        public DateTimeOffset Approved { get; set; }
        public DateTimeOffset Registered { get; set; }
        public DateTimeOffset Updated { get; set; }
        public RegistrationStatus RegistrationStatus { get; set; }
        public string KKNumber { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string RTRW { get; set; }
        public string SubDistrict { get; set; }
        public string Districts { get; set; }
    }
}