using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GameWeb.Models
{
    public class Post
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public User User { get; set; }
        [Required]
        public Game Game { get; set; }
        [Required]
        public string Text { get; set; }
        public DateTime PostDate { get; set; }

    }
}