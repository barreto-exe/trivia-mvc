using System;
using System.Collections.Generic;

#nullable disable

namespace trivia_mvc.Models
{
    public partial class Answer
    {
        public short IdQuestion { get; set; }
        public short IdAnswer { get; set; }
        public string Description { get; set; }
        public bool IsCorrect { get; set; }

        public virtual Question IdQuestionNavigation { get; set; }
    }
}
