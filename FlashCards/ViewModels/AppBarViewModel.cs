using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;

using System.Net.Mail;
using System.Net;

namespace FlashCards.ViewModels {
    using FlashCards.Models;

    public class AppBarViewModel : BaseViewModel {
        enum PageIndex {
            Home = 0, FlashCard = 1, Dev_STM = 2, GitHub = 3
        }

        private AppBarModel m_Model;

        public object PageDataContext {
            get { return m_Model.PageDataContext; }
            set {
                m_Model.PageDataContext = value;
                OnPropertyChanged();
            }
        }

        public string PageTitle {
            get { return m_Model.PageTitle; }
            set {
                m_Model.PageTitle = value;
                OnPropertyChanged();
            }
        }

        public int SelectedPage { 
            get { return m_Model.SelectedPage; }
            set {
                m_Model.SelectedPage = value;
                OnPropertyChanged();
                ChangePage();
            }
        }

        public ICommand OpenMenuCommand { get; set; }
        public ICommand CloseMenuCommand { get; set; }

        public ICommand ExitWindowCommand { get; set; }

        public AppBarViewModel(Button openMenuButton, Button closeMenuButton) {
            this.m_Model = new AppBarModel();

            OpenMenuCommand = new RelayCommand(() => {
                openMenuButton.Visibility = Visibility.Collapsed;
                closeMenuButton.Visibility = Visibility.Visible;
            });
            CloseMenuCommand = new RelayCommand(() => {
                openMenuButton.Visibility = Visibility.Visible;
                closeMenuButton.Visibility = Visibility.Collapsed;
            });

            ExitWindowCommand = new RelayCommand(() => { Application.Current.Shutdown(); });

            Application.Current.MainWindow.Loaded += (sender, e) => {
                SelectedPage = 0;
            };
        }

        void ChangePage() {
            System.Diagnostics.Trace.WriteLine($"Selected Index: {SelectedPage}");
            switch (SelectedPage) {
                case (int)PageIndex.Home: { 
                        PageTitle = "Home";
                        PageViewModel.SetPage(new Views.HomeView()); 
                        break; 
                    }
                case (int)PageIndex.FlashCard: {
                        PageTitle = "Flash Cards"; 
                        PageViewModel.SetPage(new Views.FlashCard());
                        break;
                    }
                case (int)PageIndex.Dev_STM: {
                        PageTitle = "Send Test Mail"; SendMail("kingodk@outlook.dk");
                        break; 
                    }
                case (int)PageIndex.GitHub: { 
                        PageTitle = "Github"; 
                        break; 
                    }
            }
        }

        void SendMail(string to) {
            try {
                //                     MailMessage(from, to, subject, body);
                MailMessage mail = new MailMessage("kingo@kingo.dev", to, "Test Mail From WPF Program", "If this works, you have recieved an E-mail!");

                ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
                SmtpClient smtpServer = new SmtpClient {
                    Host = "server12mail.chosting.dk",
                    Port = 587,
                    Credentials = new NetworkCredential("kingo@kingo.dev", "vict3948_kingo.dev!"),
                    EnableSsl = true,
                };
                smtpServer.Send(mail);
            } catch(SmtpException smtpEx) {
                System.Diagnostics.Trace.WriteLine(smtpEx.Message);
            } catch (System.Exception ex) {
                System.Diagnostics.Trace.WriteLine(ex.Message);
            }
        }
    }

}
