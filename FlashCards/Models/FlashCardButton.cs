namespace FlashCards.Models {
    public class FlashCardButton {
        public string AnswerText { get; set; }
        public bool IsAnswerRight { get; set; }

        public FlashCardButton(string text, bool answerRight) {
            this.AnswerText = text;
            this.IsAnswerRight = answerRight;
        }
    }
}
