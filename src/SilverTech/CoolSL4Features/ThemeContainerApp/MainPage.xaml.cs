using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace ThemeContainerApp
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();

            Loaded += new RoutedEventHandler(MainPage_Loaded);
            listBox1.SelectionChanged += new SelectionChangedEventHandler(listBox1_SelectionChanged);
        }

        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            listBox1.Items.Add(typeof(System.Windows.Controls.Theming.BubbleCremeTheme));
            listBox1.Items.Add(typeof(System.Windows.Controls.Theming.BureauBlackTheme));
            listBox1.Items.Add(typeof(System.Windows.Controls.Theming.BureauBlueTheme));
            listBox1.Items.Add(typeof(System.Windows.Controls.Theming.ExpressionDarkTheme));
            listBox1.Items.Add(typeof(System.Windows.Controls.Theming.ExpressionLightTheme));
            listBox1.Items.Add(typeof(System.Windows.Controls.Theming.RainierOrangeTheme));
            listBox1.Items.Add(typeof(System.Windows.Controls.Theming.RainierPurpleTheme));
            listBox1.Items.Add(typeof(System.Windows.Controls.Theming.ShinyBlueTheme));
            listBox1.Items.Add(typeof(System.Windows.Controls.Theming.ShinyRedTheme));
            listBox1.Items.Add(typeof(System.Windows.Controls.Theming.TwilightBlueTheme));
            listBox1.Items.Add(typeof(System.Windows.Controls.Theming.WhistlerBlueTheme));
            // this theme causes some problems about the background when change to the other theme later.
            listBox1.Items.Add(typeof(System.Windows.Controls.Theming.SystemColorsTheme));

            //listBox1.Items.Add(new System.Windows.Controls.Theming.BubbleCremeTheme());
            //listBox1.Items.Add(new System.Windows.Controls.Theming.BureauBlackTheme());
            //listBox1.Items.Add(new System.Windows.Controls.Theming.BureauBlueTheme());
            //listBox1.Items.Add(new System.Windows.Controls.Theming.ExpressionDarkTheme());
            //listBox1.Items.Add(new System.Windows.Controls.Theming.ExpressionLightTheme());
            //listBox1.Items.Add(new System.Windows.Controls.Theming.RainierOrangeTheme());
            //listBox1.Items.Add(new System.Windows.Controls.Theming.RainierPurpleTheme());
            //listBox1.Items.Add(new System.Windows.Controls.Theming.ShinyBlueTheme());
            //listBox1.Items.Add(new System.Windows.Controls.Theming.ShinyRedTheme());
            //listBox1.Items.Add(new System.Windows.Controls.Theming.SystemColorsTheme());
            //listBox1.Items.Add(new System.Windows.Controls.Theming.TwilightBlueTheme());
            //listBox1.Items.Add(new System.Windows.Controls.Theming.WhistlerBlueTheme());
        }

        void listBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                //System.Windows.Controls.Theming.Theme selTheme = listBox1.SelectedItem as System.Windows.Controls.Theming.Theme;
                //themeContainer.ThemeUri = selTheme.ThemeUri;

                Type t = listBox1.SelectedItem as Type;
                t.InvokeMember("SetIsApplicationTheme", System.Reflection.BindingFlags.InvokeMethod, null, null, new object[] { App.Current, true });
                //System.Windows.Controls.Theming.WhistlerBlueTheme.SetIsApplicationTheme(App.Current, true);
            }
        }
    }
}
