using System;
using System.Collections.Generic;

#nullable disable

namespace trivia_mvc.Models
{
    public partial class TriviasQuestionsReceived
    {
        public int IdTrivia { get; set; }
        public int IdQuestion { get; set; }

        public virtual Question IdQuestionNavigation { get; set; }
        public virtual Trivia IdTriviaNavigation { get; set; }
    }
}
