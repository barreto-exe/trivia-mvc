using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace trivia_mvc.Models
{
    public partial class User
    {
        public User()
        {
            Trivia = new HashSet<Trivia>();
        }

        public int IdUser { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public DateTime DateBirth { get; set; }
        public DateTime DateIn { get; set; }

        public virtual ICollection<Trivia> Trivia { get; set; }
    }
}
