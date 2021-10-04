using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LR4.Models
{
    public class Spravochnik
    {
        [Key]
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Phone_number { get; set; }
    }
}