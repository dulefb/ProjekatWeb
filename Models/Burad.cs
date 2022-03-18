using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Models
{
    [Table("Burad")]
    public class Burad
    {
        [Key]
        public int ID{ get; set; }

        [Required]
        [Range(0,500)]
        public int Kolicina { get; set; }

        public Proizvod Proizvod { get; set; }

        [Required]
        [Range(1900,2022)]
        public string Godina { get; set; }

        public List<Proizvodnja> Proizvodnja { get; set; }
    }
}