using Desktop.Controls;
using Desktop.Model;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using System.Windows.Media;

namespace Desktop.Tabs
{
    public class MvvmTabViewModel : ViewModel
    {
        #region Attributes

        #endregion

        #region Properties

        public ICommand MainCommand { get; private set; }

        public ICommand ClearCommand { get; private set; }

        public ColoredTextViewModel TextControl { get; set; }

        #endregion

        #region Custom Properties

        #endregion

        #region Constructor

        public MvvmTabViewModel()
        {
            this.TextControl = new ColoredTextViewModel();
        }

        protected override void AddCommands()
        {
            base.AddCommands();

            this.MainCommand = new Command<String>(s => this.MainCommandAction());

            this.ClearCommand = new Command<String>(s => this.ClearCommandAction());
        }

        #endregion

        #region Methods

        private void MainCommandAction()
        {
            this.AddResultLine("Result Text", Brushes.Black);

            this.AddResultLine("Result Text", Brushes.Blue);
        }

        private void ClearCommandAction()
        {
            this.TextControl.Clear();
        }

        private void AddResultLine(String text, Brush brush)
        {
            this.TextControl.AddTextHourText(text, brush);
        }

        #endregion
    }
}
