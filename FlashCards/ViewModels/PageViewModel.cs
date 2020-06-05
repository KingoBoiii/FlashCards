using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCards.ViewModels {
    public class PageViewModel : BaseViewModel {
        public static PageViewModel Instance { get; private set; }

        private object m_PageDataContext;
        public object PageDataContext {
            get { return m_PageDataContext; }
            set {
                m_PageDataContext = value;
                OnPropertyChanged();
            }
        }

        public PageViewModel() {
            Instance = this;
        }

        public static void SetPage(object view) {
            Instance.PageDataContext = view;
        }
    }
}
