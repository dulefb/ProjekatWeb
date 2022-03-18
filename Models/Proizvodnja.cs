using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Models
{
    public class Proizvodnja
    {
        [Key]
        public int ID { get; set; }

        public Burad Burad { get; set; }

        public Radnik Radnik { get; set; }
    }
}