using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeReport.Models
{
    public class Pager
    {
        public const int MaxPerPage = 50;
        public int PageNumber { get; set; } = 1;
        private int _pageSize = 10;
        public int PageSize 
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPerPage) ? _pageSize = MaxPerPage : value;            
        }

    }
}
