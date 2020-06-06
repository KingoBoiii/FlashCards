﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FlashCards.Views {
    /// <summary>
    /// Interaction logic for AppBar.xaml
    /// </summary>
    public partial class AppBar : UserControl {
        public AppBar() {
            InitializeComponent();
            this.DataContext = new ViewModels.AppBarViewModel(ButtonOpenMenu, ButtonCloseMenu);
        }
    }
}
