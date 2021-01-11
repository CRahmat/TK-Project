using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TK_Project.Models;

namespace TK_Project.ViewModels
{
    public class Students
    {
    }
    public class AddStudent
    {
        [Required(ErrorMessage = "NIK wajib diisi")]
        [RegularExpression("^((1[1-9])|(21)|([37][1-6])|(5[1-4])|(6[1-5])|([8-9][1-2]))[0-9]{2}[0-9]{2}(([0-6][0-9])|(7[0-1]))((0[1-9])|(1[0-2]))([0-9]{2})[0-9]{4}$", ErrorMessage = "Format NIK Tidak Sesuai")]
        [Remote("IsValidNik", "Account", HttpMethod = "POST", ErrorMessage = "NIK Telah Terdaftar")]        
        [Display(Name = "NIK")]
        public string NIK { get; set; }
        [Required(ErrorMessage = "Nomor KK wajib diisi")]
        [RegularExpression("^((1[1-9])|(21)|([37][1-6])|(5[1-4])|(6[1-5])|([8-9][1-2]))[0-9]{2}[0-9]{2}(([0-6][0-9])|(7[0-1]))((0[1-9])|(1[0-2]))([0-9]{2})[0-9]{4}$", ErrorMessage = "Format NO KK Tidak Sesuai")]
        [Display(Name = "Nomor KK")]
        public string KKNumber { get; set; }
        [Display(Name = "Nama Kepala Keluarga")]
        public string FamilyHead { get; set; }
        [Required(ErrorMessage = "Nomor Akte Kelahiran lengkap wajib diisi")]
        [Display(Name = "Nomor Akte Kelahiran")]
        public string DeedNumber { get; set; }
        [Required(ErrorMessage = "Nama lengkap wajib diisi")]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        [EmailAddress(ErrorMessage = "Email address is not valid")]
        [Required(ErrorMessage = "Alamat email wajib diisi")]
        [Display(Name = "Alamat Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Kata sandi wajib diisi")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "Panjang karakter minimal 6.", MinimumLength = 6)]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[#$^+=!*()@%&]).{8,}$", ErrorMessage = "Password Minimal 6 Karakter dan terdiri dari Angka, Huruf dan Karakter")]
        [Display(Name = "Kata Sandi")]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Konfirmasi Kata Sandi")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Kata sandi harus sama.")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Tanggal Lahir wajib diisi")]
        [Display(Name = "Tanggal Lahir")]
        [RegularExpression(@"^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[13-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$", ErrorMessage = "Penulisan Tanggal Lahir Tidak Sesuai")]
        public DateTimeOffset DOB { get; set; }
        [Required(ErrorMessage = "Provinsi wajib diisi")]
        [Display(Name = "Provinsi")]

        public string Province { get; set; }
        [Required(ErrorMessage = "Wajib memilih Kota/Kabupaten")]
        [Display(Name = "Kota")]

        public string City { get; set; }
        [Display(Name = "RT/RW")]
        [Required(ErrorMessage = "RT/RW wajib diisi ")]

        public string RTRW { get; set; }
        [Display(Name = "Kelurahan")]
        [Required(ErrorMessage = "Kelurahan wajib diisi ")]

        public string SubDistrict { get; set; }
        [Display(Name = "Kecamatan")]
        [Required(ErrorMessage = "Kecamatan wajib diisi ")]
        public string Districts { get; set; }
        public string Avatar { get; set; }
        [Display(Name = "Alamat Lengkap")]
        [Required(ErrorMessage = "Alamat Lengkap wajib diisi ")]
        public string Address { get; set; }
        public RegistrationStatus RegistrationStatus { get; set; }
        [Display(Name = "Jenis Kelamin")]
        [Required(ErrorMessage = "Jenis Kelamin wajib diisi ")]
        public bool Gender { get; set; }
        [Display(Name = "Kewarganegaraan")]
        [Required(ErrorMessage = "Kewarganegaraan wajib diisi ")]
        public string Citizenship { set; get; }
        [Display(Name = "Agama")]
        [Required(ErrorMessage = "Agama wajib diisi ")]
        public Religion Religion { set; get; }
        public Departement Roles { set; get; }
    }
    public class EditStudent
    {
        public string NIK { get; set; }
        public string KKNumber { get; set; }
        public string FamilyHead { get; set; }
        public string DeedNumber { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public DateTimeOffset DOB { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string RTRW { get; set; }
        public string SubDistrict { get; set; }
        public string Districts { get; set; }
        public string Avatar { get; set; }
        public string Address { get; set; }
        public string Descriptions { get; set; }
        public RegistrationStatus RegistrationStatus { get; set; }
        public bool Gender { get; set; }
        public string Citizenship { set; get; }
        public Religion Religion { set; get; }
        public Departement Roles { set; get; }
    }
    [DataContract]
    public class DataPointStudents
    {
        public DataPointStudents(string label, double y)
        {
            this.Label = label;
            this.Y = y;
        }

        [DataMember(Name = "label")]
        public string Label = "";

        //Explicitly setting the name to be used while serializing to JSON.
        [DataMember(Name = "y")]
        public Nullable<double> Y = null;
    }
}