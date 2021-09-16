using System;
using System.Collections.Generic;

#nullable disable

namespace trivia_mvc.Models
{
    public partial class Category
    {
        public Category()
        {
            Questions = new HashSet<Question>();
            Trivia = new HashSet<Trivia>();
        }

        public string Name { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<Trivia> Trivia { get; set; }
    }
}
