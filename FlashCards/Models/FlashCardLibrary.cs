using System.Collections.Generic;

namespace FlashCards.Models {
    public static class FlashCardLibrary {
        public static List<FlashCard> HardwareForkortelser { get; } = new List<FlashCard>() {
            new FlashCard("Hvad står RAM for?", new List<FlashCardButton>() { 
                new FlashCardButton("Random Access Memory", true),
                new FlashCardButton("Rapid Access Memory", false),
                new FlashCardButton("Read Access Memory", false),
            }),
            new FlashCard("Hvad står CPU for?", new List<FlashCardButton>() {
                new FlashCardButton("Central Processing Unity", false),
                new FlashCardButton("Central Processing Unit", true),
            }),
            new FlashCard("Hvad står HDD for?", new List<FlashCardButton>() {
                new FlashCardButton("Hard Disk Drive", true),
                new FlashCardButton("Hard Disk", false),
                new FlashCardButton("Hard Drive Disk", false),
            })
        };
    }
}
