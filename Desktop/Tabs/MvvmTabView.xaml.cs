using System.Windows.Controls;

namespace Desktop.Tabs
{
    public partial class MvvmTabView : UserControl
    {
        public MvvmTabViewModel ViewModel
        {
            get
            {
                return (MvvmTabViewModel)this.DataContext;
            }
        }

        public MvvmTabView()
        {
            InitializeComponent();

            this.DataContext = new MvvmTabViewModel();
        }
    }
}
