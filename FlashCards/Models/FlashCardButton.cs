namespace FlashCards.Models {
    public class FlashCardButton {
        public string ButtonText { get; set; }
        public bool IsAnswerRight { get; set; }

        public FlashCardButton(string text, bool answerRight) {
            this.ButtonText = text;
            this.IsAnswerRight = answerRight;
        }
    }
}
