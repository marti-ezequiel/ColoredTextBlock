using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace Desktop.Tabs
{
    public partial class CodeBehindTab : UserControl
    {
        public CodeBehindTab()
        {
            InitializeComponent();

            //this.txtResults.InlineList = new ObservableCollection<Inline>();
        }

        private void OnClickClearCommand(Object sender, RoutedEventArgs e)
        {
            //this.txtResults.InlineList.Clear();
        }

        private void OnClickMainCommand(Object sender, RoutedEventArgs e)
        {
            this.AddResultLine("Result Text");
        }

        private void AddResultLine(String text)
        {
            //if (this.txtResults.InlineList.Any())
            //    this.txtResults.InlineList.Add(new Run(Environment.NewLine));

            //this.txtResults.InlineList.Add(new Run(text));
        }
    }
}
