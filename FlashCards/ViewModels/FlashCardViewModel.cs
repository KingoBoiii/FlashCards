using System.Windows;
using System.Diagnostics;
using System.Windows.Controls;

namespace FlashCards.ViewModels {
    using FlashCards.Models;

    public class FlashCardViewModel : BaseViewModel {
        Grid m_ButtonGrid;

        FlashCard m_FlashCard;

        public delegate void OnButtonClickedEvent(FlashCardButton button);

        public string QuestionText {
            get { return m_FlashCard.Question; }
            set {
                m_FlashCard.Question = value;
                OnPropertyChanged();
            }
        }

        public FlashCardViewModel(Grid buttonGrid) {
            this.m_ButtonGrid = buttonGrid;
            NewFlashCard();
        }

        void NewFlashCard() {
            ClearGrid(m_ButtonGrid);

            System.Random random = new System.Random();
            int randomNumber = random.Next(0, FlashCardLibrary.HardwareForkortelser.Count);
            m_FlashCard = FlashCardLibrary.HardwareForkortelser[randomNumber];
            OnPropertyChanged(nameof(QuestionText));

            for (int i = 0; i < m_FlashCard.Buttons.Count; i++) {
                AddButtonToGrid(m_ButtonGrid, m_FlashCard.Buttons[i], i, OnButtonClicked);
            }
        }

        void OnButtonClicked(FlashCardButton button) {
            if(button.IsAnswerRight) {
                NewFlashCard();
                Trace.WriteLine("Correct Answer!");
                return;
            }

            Trace.WriteLine($"{button.AnswerText}: {button.IsAnswerRight}");
        }

        void AddButtonToGrid(Grid grid, FlashCardButton buttonInfo, int index, OnButtonClickedEvent callback) {
            Button button = new Button {
                Name = "Button" + index,
                Content = buttonInfo.AnswerText,
                Height = 135.0,
                Margin = new Thickness(10.0),
                Padding = new Thickness(10.0),
                Style = (Style)Application.Current.FindResource("MaterialDesignOutlinedButton"),
                Command = new RelayCommand(() => {
                    if (callback != null) {
                        callback.Invoke(buttonInfo);
                    }
                })
            };

            /// https://stackoverflow.com/questions/16790584/converting-index-of-one-dimensional-array-into-two-dimensional-array-i-e-row-a
            int colLength = grid.ColumnDefinitions.Count;
            int col = index % colLength;

            int rowLength = grid.RowDefinitions.Count;
            int row = index / rowLength;

            Grid.SetColumn(button, col);
            Grid.SetRow(button, row);

            grid.Children.Add(button);
        }

        void ClearGrid(Grid grid) {
            if(grid.Children.Count > 0) {
                grid.Children.Clear();
            }
        }

        /*
        System.Windows.UIElement GetChild(Grid grid, int row, int col) {
            return grid.Children.Cast<System.Windows.UIElement>().First(e => Grid.GetRow(e) == row && Grid.GetColumn(e) == col);
        }
        */
        }
    }
