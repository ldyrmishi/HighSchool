using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace HighSchoolApplication.API.Models
{
    [DataContract]
    public class FinancesModel
    {
        [DataMember(Name ="FinanceId")]
        public int FinanceId { get; set; }
        [DataMember(Name = "Date")]
        public DateTime? Date { get; set; }
        [DataMember(Name = "Description")]
        public string Description { get; set; }
        [DataMember(Name = "Amount")]
        public int? Amount { get; set; }
        [DataMember(Name = "CreatedAt")]
        public DateTime? CreatedAt { get; set; }
        [DataMember(Name = "ModifiedAt")]
        public DateTime? ModifiedAt { get; set; }
        [DataMember(Name = "IsExpense")]
        public bool? IsExpense { get; set; }

        [DataMember(Name = "School")]
        public SchoolModel School { get; set; }
    }
}
