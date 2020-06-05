using System.Windows;
using System.Windows.Input;

using System.Net.Mail;
using System.Net;

namespace FlashCards.ViewModels {
    public class AppBarViewModel : BaseViewModel {
        enum PageIndex {
            Home = 0, FlashCard = 1, Dev_STM = 2, GitHub = 3
        }

        private object m_PageDataContext;
        public object PageDataContext {
            get { return m_PageDataContext; }
            set {
                m_PageDataContext = value;
                OnPropertyChanged();
            }
        }

        private int m_SelectedPage;
        public int SelectedPage { 
            get { return m_SelectedPage; }
            set {
                m_SelectedPage = value;
                OnPropertyChanged();
                ChangePage();
            }
        }

        public ICommand OpenMenuCommand { get; set; }
        public ICommand CloseMenuCommand { get; set; }

        public ICommand ExitWindowCommand { get; set; }

        public AppBarViewModel() {
            OpenMenuCommand = new RelayCommand(() => { });
            CloseMenuCommand = new RelayCommand(() => { });

            ExitWindowCommand = new RelayCommand(() => { Application.Current.Shutdown(); });

            Application.Current.MainWindow.Loaded += (sender, e) => {
                SelectedPage = 0;
            };
        }

        void SendMail(string mailTo) {
            try {
                //                     MailMessage(from, to, subject, body);
                MailMessage mail = new MailMessage("kingo@kingo.dev", mailTo, "Test Mail From WPF Program", "If this works, you have recieved a E-mail!");

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

        void ChangePage() {
            System.Diagnostics.Trace.WriteLine($"Selected Index: {SelectedPage}");
            switch(SelectedPage) {
                case (int)PageIndex.Home:       PageViewModel.SetPage(new Views.HomeView()); break;
                case (int)PageIndex.FlashCard:  PageViewModel.SetPage(new Views.FlashCard()); break;
                case (int)PageIndex.Dev_STM:    SendMail("kingodk@outlook.dk"); break;
                case (int)PageIndex.GitHub:     break;
            }
        }
    }
}
