using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HighSchoolApplication.Infrastructure.Models
{
    public partial class Users
    {
        public Users()
        {
            Absents = new HashSet<Absents>();
            Class = new HashSet<Class>();
            Diary = new HashSet<Diary>();
            Documents = new HashSet<Documents>();
            FinalExams = new HashSet<FinalExams>();
            UsersClass = new HashSet<UsersClass>();
            UsersSubjectPoints = new HashSet<UsersSubjectPoints>();
        }

        [Required]
        [Key]
        [Column("UserId")]
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Gender { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public int? PhoneNumber { get; set; }
        public DateTime? Birthdate { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public byte[] Password { get; set; }
        public byte[] ConfirmPassword { get; set; }
        public bool? IsActive { get; set; }
        public int? AddressId { get; set; }
        public int? RoleId { get; set; }
        public int? SchoolId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public string Notes { get; set; }
        public string NrAmze { get; set; }
        public int? StatusId { get; set; }

        public Address Address { get; set; }
        public Roles Role { get; set; }
        public School School { get; set; }
        public UsersStatus Status { get; set; }
        public ICollection<Absents> Absents { get; set; }
        public ICollection<Class> Class { get; set; }
        public ICollection<Diary> Diary { get; set; }
        public ICollection<Documents> Documents { get; set; }
        public ICollection<FinalExams> FinalExams { get; set; }
        public ICollection<UsersClass> UsersClass { get; set; }
        public ICollection<UsersSubjectPoints> UsersSubjectPoints { get; set; }
    }
}
