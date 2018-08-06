using Desktop.Tabs;
using System.Windows;

namespace Desktop
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.tabPresenter.Content = new CodeBehindTab();
            this.tabMvvm.Content = new MvvmTabView();
        }
    }
}
