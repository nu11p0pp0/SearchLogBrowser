using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Configuration;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;
using SearchLogBrowser.Domain;
using SearchLogBrowser.Database;

namespace SearchLogBrowser
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        private String startUrl = "http://www.google.com";
        private AppSetting appSettings;
        public MainWindow()
        {
            InitializeComponent();
            // ブラウザの初期設定（ロケール）.
            browser.BrowserSettings.AcceptLanguageList = "ja-JP";
            browser.FrameLoadEnd += Browser_LoadEnd;
            // 設定ファイルの読み込み.
            appSettings = new AppSetting();
            searchEngineList.Items.Clear();
            foreach (SearchEngineItem item in appSettings.SearchEngineItems)
            {
                searchEngineList.Items.Add(item);
            }
            searchEngineList.SelectedIndex = 0;
            browser.Address = startUrl;
            addressBar.Text = new Uri(startUrl).ToString();

        }

        /**
         * アドレスバー.キー押下イベント.
         */
        private void AddressBar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.Equals(Key.Enter))
            {
                browser.Address = new Uri(addressBar.Text).ToString();
            }
        }
        /**
         * 戻るボタン.キー押下イベント. 
         */
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if (browser.CanGoBack) browser.GetBrowser().GoBack();
        }

        /**
         * 進むボタン.キー押下イベント. 
         */
        private void Next_Click(object sender, RoutedEventArgs e)
        {
            if (browser.CanGoForward) browser.GetBrowser().GoForward();
        }

        /**
         * 検索エンジン.選択イベント.
         */
        private void SearchEngineList_Change(object sender, SelectionChangedEventArgs e)
        {
            if (!String.IsNullOrEmpty(searchWord.Text.Trim()))
            {
                var selected = ((SearchEngineItem) searchEngineList.SelectedItem);
                var searchUrl = new Uri(selected.Value + searchWord.Text);
                browser.Address = searchUrl.ToString();
                MainWindow1.Title = selected.Title;
            }
        }

        /**
         * 検索ワード.キー押下イベント
         */
        private void SearchWord_KeyDown(object sender, KeyEventArgs e)
        {
            if (!String.IsNullOrEmpty(searchWord.Text.Trim()) && e.Key.Equals(Key.Enter))
            {
                var selected = ((SearchEngineItem) searchEngineList.SelectedItem);
                // URL作成 ～ ブラウザへセット.
                var searchUrl = new Uri(selected.Value + searchWord.Text);
                browser.Address = searchUrl.ToString();
                MainWindow1.Title = selected.Title;
                // 検索ログ書き込み.
                using (var context = new SLBDbContext())
                {
                    //context.Searchwords.Add(new Searchword {
                    //    Id = appSettings.Id
                    //    , SearchTimestamp = DateTime.Now
                    //    , SearchWord = searchWord.Text
                    //    , Url = searchUrl.ToString()
                    //});

                    context.Searchlogs.Add(new Searchlog
                    {
                        Username = appSettings.Id
                        , Searchtext = searchWord.Text
                        , Url = searchUrl.ToString()
                        , Resolved = 0
                        , Searchdate = DateTime.Now
                    });

                    context.SaveChanges();

                }
            }
        }

        /**
         * Webブラウザ.ロード完了後イベント.
         */
        private void Browser_LoadEnd(object sender, CefSharp.FrameLoadEndEventArgs e)
        {
            // アドレスバーへの書き込み（ロードされたページのURL）.
            this.Dispatcher.Invoke(new Action(() => { addressBar.Text = e.Url; }));
        }
    }
}
