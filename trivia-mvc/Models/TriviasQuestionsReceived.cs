using System;
using System.Collections.Generic;

#nullable disable

namespace trivia_mvc.Models
{
    public partial class TriviasQuestionsReceived
    {
        public short IdTrivia { get; set; }
        public short IdQuestion { get; set; }

        public virtual Question IdQuestionNavigation { get; set; }
        public virtual Trivia IdTriviaNavigation { get; set; }
    }
}
