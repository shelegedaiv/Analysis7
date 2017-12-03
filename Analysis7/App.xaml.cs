using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Analysis7.Model;
using Analysis7.ViewModel;

namespace Analysis7
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            var model = new ModelStarter();
            var viewModel = new MainViewModel(model);
            var view=new MainWindow(){DataContext = viewModel };
            view.Show();
        }
    }
}
