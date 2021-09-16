using System;
using System.Collections.Generic;

#nullable disable

namespace trivia_mvc.Models
{
    public partial class User
    {
        public User()
        {
            Trivia = new HashSet<Trivia>();
        }

        public short IdUser { get; set; }
        public string Username { get; set; }
        public DateTime DateBirth { get; set; }
        public DateTime DateIn { get; set; }

        public virtual ICollection<Trivia> Trivia { get; set; }
    }
}
