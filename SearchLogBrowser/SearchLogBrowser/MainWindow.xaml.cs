using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SearchLogBrowser
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        private String startUrl = "http://www.google.com";
        public MainWindow()
        {
            InitializeComponent();
            browser.Navigate(new Uri(startUrl));
            addressBar.Text = startUrl;

        }

        /**
         * アドレスバー.キー押下イベント.
         */
        private void AddressBar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.Equals(Key.Enter))
            {
                browser.Navigate(new Uri(addressBar.Text));
            }
        }
    }
}
