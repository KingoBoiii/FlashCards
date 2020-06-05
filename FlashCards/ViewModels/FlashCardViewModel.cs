using System.Linq;
using System.Diagnostics;
using System.Windows.Controls;
using System.Collections.Generic;

namespace FlashCards.ViewModels {
    using FlashCards.Models;

    public class FlashCardViewModel : BaseViewModel {
        private Grid m_ButtonGrid;
        private FlashCard m_FlashCard;

        public string QuestionText {
            get { return m_FlashCard.Question; }
            set {
                m_FlashCard.Question = value;
                OnPropertyChanged();
            }
        }

        public FlashCardViewModel(Grid buttonGrid) {
            this.m_ButtonGrid = buttonGrid;

            m_FlashCard = new FlashCard("Hvad står HDD for?",
                new List<FlashCardButton>() {
                    new FlashCardButton("Hard Disk Drive", true),
                    new FlashCardButton("Hard Drive Disk", false),
                    new FlashCardButton("HarD Drive", false),
                }
            );

            int colLength = this.m_ButtonGrid.ColumnDefinitions.Count;
            int rowLength = this.m_ButtonGrid.RowDefinitions.Count;
            for (int row = 0; row < rowLength; row++) {
                for (int col = 0; col < colLength; col++) {
                    int buttonIndex = col + (row * colLength);

                    Button button = (Button)GetChild(this.m_ButtonGrid, row, col);
                    button.Content = $"Btn: ({row},{col})";
                    button.Click += (sender, e) => {
                        Trace.WriteLine(buttonIndex);
                    };
                }
            }
        }

        System.Windows.UIElement GetChild(Grid grid, int row, int col) {
            return grid.Children.Cast<System.Windows.UIElement>().First(e => Grid.GetRow(e) == row && Grid.GetColumn(e) == col);
        }
    }
}
