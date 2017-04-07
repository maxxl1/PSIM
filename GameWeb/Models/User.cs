using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GameWeb.Models
{
    public class User
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(450)]
        [Index(IsUnique = true)]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string City { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public int Status {get;set;}
        [Required]
        public string Email { get; set; }
        public string PhotoURl { get; set; }
        public IList<Mark> Marks { get; set; }
        public IList<Post> Posts { get; set; }
    }
}