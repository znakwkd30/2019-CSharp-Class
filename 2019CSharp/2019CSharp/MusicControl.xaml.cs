using CefSharp;
using CefSharp.Wpf;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using ClassLibrary;

namespace _2019CSharp
{
    /// <summary>
    /// Interaction logic for MusicControl.xaml
    /// </summary>
    public partial class MusicControl : UserControl
    {
        private bool userIsDraggingSlider = false;
        //private int idx = 0;

        public MusicControl()
        {
            InitializeComponent();
            //InitBrowser();
            //this.mePlayer.MediaEnded += mePlayer_MediaEnded;
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        private void PlayButton(object sender, RoutedEventArgs e)
        {
            mePlayer.Play();
        }

        private void PauseButton(object sender, RoutedEventArgs e)
        {
            mePlayer.Pause();
        }

        private void StopButton(object sender, RoutedEventArgs e)
        {
            mePlayer.Stop();
        }

        //void mePlayer_MediaEnded(object sender, RoutedEventArgs e)
        //{
        //    if(idx >= App.uris.Count - 1)
        //    {
        //        idx = 0;
        //        mePlayer.Source = App.uris[idx];
        //        mePlayer.Play();
        //        return;
        //    }

        //    idx++;
        //    mePlayer.Source = App.uris[idx];
        //    mePlayer.Play();
        //}
        private void folderOpen(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Media files (*.mp3;*.mpg;*.mpeg)|*.mp3;*.mpg;*.mpeg|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                mePlayer.Source = new Uri(openFileDialog.FileName);
                mePlayer.Play();
            }

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if ((mePlayer.Source != null) && (mePlayer.NaturalDuration.HasTimeSpan) && (!userIsDraggingSlider))
            {
                sliProgress.Minimum = 0;
                sliProgress.Maximum = mePlayer.NaturalDuration.TimeSpan.TotalSeconds;
                sliProgress.Value = mePlayer.Position.TotalSeconds;
            }
        }

        private void sliProgress_DragStarted(object sender, DragStartedEventArgs e)
        {
            userIsDraggingSlider = true;
        }

        private void sliProgress_DragCompleted(object sender, DragCompletedEventArgs e)
        {
            userIsDraggingSlider = false;
            mePlayer.Position = TimeSpan.FromSeconds(sliProgress.Value);
        }

        private void sliProgress_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lblProgressStatus.Text = TimeSpan.FromSeconds(sliProgress.Value).ToString(@"hh\:mm\:ss");
        }

        private void Grid_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            mePlayer.Volume += (e.Delta > 0) ? 0.1 : -0.1;
        }

        async void btnSearch_Click(object sender, RoutedEventArgs e)
        {

            var youtube = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = "AIzaSyCdYzrgvTCowhvOxk9Yd92RdM5o857e8io", // Api Key 지정
                ApplicationName = "CSharp Music",
            });

            var request = youtube.Search.List("snippet");
            request.Q = txtSearch.Text;
            request.MaxResults = 10;

            var result = await request.ExecuteAsync();

            searchList.Items.Clear();

            Debug.WriteLine("------");
            foreach (var item in result.Items)
            {
                if (item.Id.Kind == "youtube#video" || item.Id.Kind == "youtube#playlist")
                {
                    Music music = new Music();
                    music.Name = item.Snippet.Title;
                    music.videoId = item.Id.VideoId;
                    searchList.Items.Add(music);
                }
            }
           
            searchList.Items.Refresh();
        }

        private void SearchList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (searchList.SelectedItem == null) return;

            string selectItem = searchList.SelectedItem.ToString();
            string item = selectItem.ToString();
        }

        private void SearchList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Music music = (searchList.SelectedItem as Music);


            var videoId = music.videoId;

            Debug.WriteLine("-----");
            Debug.WriteLine(videoId);
            string youtubeUrl = "http://youtube.com/watch?v=" + videoId;
            web.Source = new Uri(youtubeUrl);
            // 디폴트 브라우져에서 실행
            //Process.Start(youtubeUrl);
        }

        private void ThisIsCalledWhenPropertyIsChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string youtubeUrl = "http://youtube.com";
            web.Source = new Uri(youtubeUrl);
        }
    }
}
