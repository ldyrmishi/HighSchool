using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace HighSchoolApplication.API.Models
{
    [DataContract]
    public class UsersModel
    {
        [DataMember(Name ="Id")]
        public int Id { get; set; }

        [DataMember(Name = "FirstName")]
        public string Firstname { get; set; }

        [DataMember(Name = "LastName")]
        public string Lastname { get; set; }

        [DataMember(Name = "Gender")]
        public string Gender { get; set; }

        [DataMember(Name = "Username")]
        public string Username { get; set; }

        [DataMember(Name = "Email")]
        public string Email { get; set; }

        [DataMember(Name = "PhoneNumber")]
        public int? PhoneNumber { get; set; }

        [DataMember(Name = "Birthdate")]
        public DateTime? Birthdate { get; set; }

        [DataMember(Name = "RegistrationDate")]
        public DateTime? RegistrationDate { get; set; }

        [DataMember(Name = "Password")]
        public string Password { get; set; }

        [DataMember(Name = "ConfirmPassword")]
        public string ConfirmPassword { get; set; }

        [DataMember(Name = "IsActive")]
        public bool? IsActive { get; set; }

        [DataMember(Name = "CreatedAt")]
        public DateTime? CreatedAt { get; set; }

        [DataMember(Name = "ModifiedAt")]
        public DateTime? ModifiedAt { get; set; }

        [DataMember(Name = "Notes")]
        public string Notes { get; set; }

        [DataMember(Name = "NrAmze")]
        public string NrAmze { get; set; }

        [DataMember(Name = "AddressId")]
        public int? AddressId { get; set; }


        [DataMember(Name = "RoleId")]
        public int? RoleId { get; set; }

        [DataMember(Name = "SchoolId")]
        public int? SchoolId { get; set; }

        public int? StatusId { get; set; }

        [DataMember(Name = "Address")]
        public AddressModel Address { get; set; }

        [DataMember(Name = "Role")]
        public RolesModel Role { get; set; }

        [DataMember(Name = "School")]
        public SchoolModel School { get; set; }

        [DataMember(Name = "Status")]
        public UsersStatusModel Status { get; set; }

        [DataMember(Name = "Absents")]
        public ICollection<AbsentsModel> Absents { get; set; }

        [DataMember(Name = "Class")]
        public ICollection<ClassModel> Class { get; set; }

        [DataMember(Name = "Diary")]
        public ICollection<DiaryModel> Diary { get; set; }

        [DataMember(Name = "Documents")]
        public ICollection<DocumentsModel> Documents { get; set; }

        [DataMember(Name = "FinalExams")]
        public ICollection<FinalExamsModel> FinalExams { get; set; }

        [DataMember(Name = "UsersClass")]
        public ICollection<UsersClassModel> UsersClass { get; set; }

        [DataMember(Name = "UsersSubjectPoints")]
        public ICollection<UsersSubjectPointsModel> UsersSubjectPoints { get; set; }
    }
}
