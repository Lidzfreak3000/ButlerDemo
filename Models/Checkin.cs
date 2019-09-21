using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ButlerApp.Models
{
    public class Checkin
    {
        public int Id { get; set; }
        public string CheckinTitle { get; set; }
        public string EnteredBy { get; set; }
        public DateTime EnteredOn { get; set; }
    }
}
