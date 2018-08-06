using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace Desktop.Controls
{
    public class SelectableTextBlock : TextBlock
    {
        public ObservableCollection<Inline> InlineList
        {
            get { return (ObservableCollection<Inline>)GetValue(InlineListProperty); }
            set { SetValue(InlineListProperty, value); }
        }

        public static readonly DependencyProperty InlineListProperty =
            DependencyProperty.Register("InlineList", typeof(ObservableCollection<Inline>), typeof(SelectableTextBlock), new UIPropertyMetadata(null, OnInlineListChanged));

        private static void OnInlineListChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var textBlock = (SelectableTextBlock)sender;
            var list = (ObservableCollection<Inline>)e.NewValue;
            list.CollectionChanged += new NotifyCollectionChangedEventHandler(textBlock.InlineCollectionChanged);
        }

        private void InlineCollectionChanged(Object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                Int32 idx = e.NewItems.Count - 1;
                Inline inline = e.NewItems[idx] as Inline;
                this.Inlines.Add(inline);
            }

            if (e.Action == NotifyCollectionChangedAction.Reset)
            {
                this.Inlines.Clear();
            }
        }

        static SelectableTextBlock()
        {
            FocusableProperty.OverrideMetadata(typeof(SelectableTextBlock), new FrameworkPropertyMetadata(true));
            TextEditorWrapper.RegisterCommandHandlers(typeof(SelectableTextBlock), true, true, true);
            
            FocusVisualStyleProperty.OverrideMetadata(typeof(SelectableTextBlock), new FrameworkPropertyMetadata((Object)null));
        }

        private readonly TextEditorWrapper _editor;

        public SelectableTextBlock()
        {
            this._editor = TextEditorWrapper.CreateFor(this);
        }
    }

}
