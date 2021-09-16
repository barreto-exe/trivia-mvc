using System;
using System.Collections.Generic;

#nullable disable

namespace trivia_mvc.Models
{
    public partial class Trivia
    {
        public Trivia()
        {
            TriviasQuestionsReceiveds = new HashSet<TriviasQuestionsReceived>();
        }

        public short IdTrivia { get; set; }
        public short IdUser { get; set; }
        public string Category { get; set; }
        public DateTime DateMade { get; set; }

        public virtual Category CategoryNavigation { get; set; }
        public virtual User IdUserNavigation { get; set; }
        public virtual ICollection<TriviasQuestionsReceived> TriviasQuestionsReceiveds { get; set; }
    }
}
