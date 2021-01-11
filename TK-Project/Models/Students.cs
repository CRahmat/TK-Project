using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using TK_Project.Models;

namespace TK_Project.Models
{
    [Table("Students")]
    public class Students : ApplicationUser
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
        public string FamilyHead { get; set; }
        public string DeedNumber { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string RTRW { get; set; }
        public string SubDistrict { get; set; }
        public string Districts { get; set; }
    }
    public class Metadata
    {
        public bool IsDeleted { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset Updated { get; set; }
        public DateTimeOffset Deleted { get; set; }
        public DateTimeOffset Published { get; set; }
        public DateTimeOffset Approved { get; set; }
        public Status Status { get; set; }
        public virtual ApplicationUser CreatedBy { get; set; }
        public virtual ApplicationUser UpdatedBy { get; set; }
        public virtual ApplicationUser DeletedBy { get; set; }
        public virtual ApplicationUser PublishedBy { get; set; }
        public virtual ApplicationUser ApprovedBy { get; set; }

        public Metadata()
        {
            this.Created = DateTimeOffset.UtcNow;
            this.Updated = DateTimeOffset.UtcNow;
        }
        public Metadata(ApplicationUser user)
        {
            this.CreatedBy = user;
            this.UpdatedBy = user;
            this.Created = DateTimeOffset.UtcNow;
            this.Updated = DateTimeOffset.UtcNow;
        }
    }
    public enum RegistrationStatus
    {
        Rejected,
        Approved,
        Pending
    }
    public enum Departement
    {
        VillageHead,
        Admin,
        Citizen
    }
    public enum Religion
    {
        Islam,
        Kristen,
        Katolik,
        Hindu,
        Budha,
        KongHuCu
    }
    public enum Status
    {
        Approved,
        Pending,
        OnCheck,
        Rejected
    }
}