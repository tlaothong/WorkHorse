using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Markup;
using System.Windows.Resources;
using System.IO;

namespace DemoPageManager
{
	public partial class ManagerPage : UserControl
	{
        public static readonly DependencyProperty HostFileProperty = DependencyProperty.Register("HostFile", typeof(object), typeof(ManagerPage), new PropertyMetadata(null, new PropertyChangedCallback(OnHostFileChanged)));

        public string HostFile
        {
            get { return (string)this.GetValue(HostFileProperty); }
            set { this.SetValue(HostFileProperty, value); }
        }

        private static void OnHostFileChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            ManagerPage hostControl = (ManagerPage)sender;
            string newValue = (string)e.NewValue;

            if (!string.IsNullOrEmpty(newValue)) {
                Uri uri = new Uri("/DemoPageManager;component/" + newValue, UriKind.Relative);
                StreamResourceInfo streamResourceInfo = Application.GetResourceStream(uri);
                StreamReader sr = new StreamReader(streamResourceInfo.Stream);

                object loadedLevel = XamlReader.Load(sr.ReadToEnd());
                hostControl.PageContentPresenter.Content = loadedLevel;
            }
        }

		public ManagerPage()
		{
			InitializeComponent();
		}
	}
}