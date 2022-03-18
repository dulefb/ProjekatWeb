using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Models
{
    public class Proizvod
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(30)]
        public string Naziv { get; set; }

        public List<Burad> Burad { get; set; }
    }
}