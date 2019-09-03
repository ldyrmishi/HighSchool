using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HighSchoolApplication.Web.ViewModels
{
    public class FinancesTabViewModel
    {
        public Tab ActiveTab { get; set; }

    }

    public enum Tab
    {
        Expenses,
        Incomings
    }
}
