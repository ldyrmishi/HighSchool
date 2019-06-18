using System;
using System.Collections.Generic;

namespace HighSchoolApplication.Infrastructure.Models
{
    public partial class Finances : BaseEntity
    {
        public int FinanceId { get; set; }
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
