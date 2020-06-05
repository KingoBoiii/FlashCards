using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace FlashCards.ViewModels {
    using FlashCards.Models;

    public class HomeViewModel : BaseViewModel {
        public ObservableCollection<FlashCardLib> FlashCards { get; } = FlashCardLibrary.FlashCards;

        public HomeViewModel() {
            OnPropertyChanged(nameof(FlashCards));
        }
    }
}
