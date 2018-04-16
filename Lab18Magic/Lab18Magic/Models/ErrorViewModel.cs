using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab18Magic.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }
        public bool ShowRequesId => !string.IsNullOrEmpty(RequestId);
    }
}
