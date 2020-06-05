using System.Diagnostics;
using System.Collections.Generic;

namespace FlashCards.Models {
    public class FlashCard {
        public string Question { get; set; }
        public List<FlashCardButton> Buttons { get; set; }

        public FlashCard(string question, List<FlashCardButton> buttons) {
            this.Question = question;
            this.Buttons = buttons;

            Trace.WriteLine($"Question: {this.Question}, Buttons: ({this.Buttons.Count})");
        }
    }
}
