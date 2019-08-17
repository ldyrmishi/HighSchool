using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HighSchoolApplication.Infrastructure.Models
{
    public partial class Finances
    {
        [Required]
        [Key]
        [Column("FinanceId")]
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public string Description { get; set; }
        public int? Amount { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public int? SchoolId { get; set; }
        public bool? IsExpense { get; set; }

        public School School { get; set; }
    }
}
