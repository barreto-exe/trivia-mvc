using System;
using System.Collections.Generic;

#nullable disable

namespace trivia_mvc.Models
{
    public partial class Question
    {
        public Question()
        {
            Answers = new HashSet<Answer>();
            TriviasQuestionsReceiveds = new HashSet<TriviasQuestionsReceived>();
        }

        public int IdQuestion { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }

        public virtual Category CategoryNavigation { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
        public virtual ICollection<TriviasQuestionsReceived> TriviasQuestionsReceiveds { get; set; }
    }
}
