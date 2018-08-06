using Desktop.Model;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace Desktop.Controls
{
    public partial class ColoredTextBlock : UserControl
    {
        #region Properties
        
        public TextWrapping TextWrapping
        {
            get { return (TextWrapping)GetValue(TextWrappingProperty); }
            set { SetValue(TextWrappingProperty, value); }
        }

        public ColoredTextViewModel Control
        {
            get { return (ColoredTextViewModel)GetValue(ControlProperty); }
            set { SetValue(ControlProperty, value); }
        }

        public static readonly DependencyProperty ControlProperty =
            DependencyProperty.Register("Control", typeof(ColoredTextViewModel), typeof(ColoredTextBlock), new PropertyMetadata(new ColoredTextViewModel(), OnControlChanged));

        private static void OnControlChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var textBlock = (ColoredTextBlock)d;

            textBlock.Container.DataContext = (ColoredTextViewModel)e.NewValue;
        }


        #endregion

        #region Dependency Properties

        public static readonly DependencyProperty TextWrappingProperty =
            DependencyProperty.Register("TextWrapping", typeof(TextWrapping), typeof(ColoredTextBlock), new PropertyMetadata(TextWrapping.NoWrap, OnTextWrappingChange));

        #endregion

        #region Events

        private static void OnTextWrappingChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var textBlock = (ColoredTextBlock)d;

            textBlock.TextContainer.TextWrapping = (TextWrapping)e.NewValue;
        }

        #endregion

        #region Constructor

        public ColoredTextBlock()
        {
            InitializeComponent();
        }

        #endregion
    }
}
