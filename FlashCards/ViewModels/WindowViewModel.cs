namespace FlashCards.ViewModels {
    using FlashCards.Models;

    public class WindowViewModel : BaseViewModel {
        private readonly WindowModel m_Model;

        public double MinWidth { get { return m_Model.MinWidth; } }
        public double MinHeight { get { return m_Model.MinHeight; } }

        public string Title { get { return m_Model.Title; } }

        public WindowViewModel() {
            m_Model = new WindowModel();

            PageViewModel.SetPage(new Views.HomeView());
        }
    }
}
