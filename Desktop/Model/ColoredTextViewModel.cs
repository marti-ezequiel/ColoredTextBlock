using Desktop.Controls;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Documents;
using System.Windows.Media;

namespace Desktop.Model
{
    public class ColoredTextViewModel : ViewModel
    {
        #region Properties

        private readonly String InlineListPropertyName = nameof(InlineList);
        public ObservableCollection<Inline> InlineList { get; set; }

        #endregion

        #region Constructor

        public ColoredTextViewModel()
        {
            this.InlineList = new ObservableCollection<Inline>();
        }

        #endregion

        #region

        public void Clear()
        {
            this.InlineList.Clear();

            this.RaisePropertyChanged("InlineList");
        }

        public void AddTextHourText(String text, Brush brush = null)
        {
            var time = this.GetFormatedTime(DateTime.Now);

            if (InlineList.Any()) this.InlineList.Add(new Run(Environment.NewLine));

            this.InlineList.Add(new Run()
            {
                Text = time
            });

            this.InlineList.Add(new Run()
            {
                Text = text,
                Foreground = brush,
                FontWeight = System.Windows.FontWeights.Bold
            });

            this.RaisePropertyChanged(this.InlineListPropertyName);
        }
        
        private String GetFormatedTime(DateTime time)
        {
            return String.Format("[{0:HH:mm:ss}] ", time);
        }

        #endregion
    }
}
