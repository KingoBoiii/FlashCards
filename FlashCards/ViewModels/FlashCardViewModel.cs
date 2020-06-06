using System.Windows;
using System.Diagnostics;
using System.Windows.Controls;
using System.Collections.Generic;

namespace FlashCards.ViewModels {
    using FlashCards.Models;

    public class FlashCardViewModel : BaseViewModel {
        Grid m_ButtonGrid;

        List<FlashCard> m_FlashCards;
        FlashCard m_CurrentFlashCard;
        List<AnsweredQuestion> m_AnsweredQuestions;

        public delegate void OnButtonClickedEvent(FlashCardButton button);

        public string QuestionText {
            get { return m_CurrentFlashCard.Question; }
            set {
                m_CurrentFlashCard.Question = value;
                OnPropertyChanged();
            }
        }


        public FlashCardViewModel(Grid buttonGrid) {
            this.m_ButtonGrid = buttonGrid;
            this.m_AnsweredQuestions = new List<AnsweredQuestion>();
            m_FlashCards = new List<FlashCard>(FlashCardLibrary.HardwareForkortelser);

            NewFlashCard();
        }

        void NewFlashCard() {
            ClearGrid(m_ButtonGrid);

            m_FlashCards.Remove(m_CurrentFlashCard);
            if (m_FlashCards.Count > 0) {
                System.Random random = new System.Random();
                int randomNumber = random.Next(0, m_FlashCards.Count);
                m_CurrentFlashCard = m_FlashCards[randomNumber];
                OnPropertyChanged(nameof(QuestionText));

                for (int i = 0; i < m_CurrentFlashCard.Buttons.Count; i++) {
                    AddButtonToGrid(m_ButtonGrid, m_CurrentFlashCard.Buttons[i], i, OnButtonClicked);
                }
            } else {
                PageViewModel.SetPage(new Views.FlashCardResultsView());
                Trace.WriteLine("Done!");
            }
        }

        void OnButtonClicked(FlashCardButton button) {
            if (button.IsAnswerRight) {
                m_AnsweredQuestions.Add(new AnsweredQuestion() { Question = m_CurrentFlashCard.Question, CorrectAnswer = true });
                Trace.WriteLine("Correct Answer!");
            } else {
                m_AnsweredQuestions.Add(new AnsweredQuestion() { Question = m_CurrentFlashCard.Question, CorrectAnswer = false });
                Trace.WriteLine($"{button.AnswerText}: {button.IsAnswerRight}");
            }
            NewFlashCard();
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
