using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace FlashCards.Models {

    public class FlashCardLib {
        public string LibName { get; set; }
        public List<FlashCard> FlashCards { get; set; }
    }

    public static class FlashCardLibrary {
        public static ObservableCollection<FlashCardLib> FlashCards { get; } = new ObservableCollection<FlashCardLib>() {
            new FlashCardLib { LibName = "Hardware Forkortelser", FlashCards = HardwareForkortelser }
        };

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
