using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GameWeb.Models
{
    public class Game
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public double Averge { get; set; }
        public string Genre { get; set; }
        public string Platform { get; set; }
        public string Photo { get; set; }
        public string Studio { get; set; }
        public string Publisher { get; set; }
        public int MinAge { get; set; }
        public IList<Mark> Marks { get; set; }
        public IList<Post> Posts { get; set; }

    }
}