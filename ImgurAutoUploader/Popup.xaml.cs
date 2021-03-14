using Imgur.API.Authentication;
using Imgur.API.Endpoints;
using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace ImgurAutoUploader
{
    /// <summary>
    /// Interaktionslogik für Popup.xaml
    /// </summary>
    public partial class Popup : Window
    {
        private BitmapSource bitmap;
        private ApiClient apiClient;
        private DispatcherTimer timer = new DispatcherTimer();
        private bool upload = false;

        public Popup(BitmapSource bitmapSource, ApiClient client)
        {
            InitializeComponent();
            Rect desktopWorkingArea = SystemParameters.WorkArea;
            Left = desktopWorkingArea.Right - Width;
            Top = desktopWorkingArea.Bottom - Height;
            imageBox.Source = bitmapSource;
            bitmap = bitmapSource;
            apiClient = client;

            timer.Interval = TimeSpan.FromSeconds(5);
            timer.Tick += TimerTick;
            timer.Start();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void UploadButton_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            using (var fileStream = new FileStream("img.png", FileMode.Create))
            {
                BitmapEncoder encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(bitmap));
                encoder.Save(fileStream);
            }
            Upload();
        }

        private void SecretButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private async void Upload()
        {
            upload = true;
            UploadProgressBar.Visibility = Visibility.Visible;
            SecretButton.Visibility = Visibility.Collapsed;
            UploadButton.Visibility = Visibility.Collapsed;

            HttpClient httpClient = new();

            string filePath = @"img.png";
            using var fileStream = File.OpenRead(filePath);

            ImageEndpoint imageEndpoint = new ImageEndpoint(apiClient, httpClient);
            var imageUpload = await imageEndpoint.UploadImageAsync(fileStream);

            string link = imageUpload?.Link ?? "Error";
            Clipboard.SetText(link);

            UploadProgressBar.Visibility = Visibility.Collapsed;
            LinkTextBlock.Visibility = Visibility.Visible;
            LinkTextBlock.Text = imageUpload.Link;

            timer.Start();
        }

        private void TimerTick(object sender, EventArgs e)
        {
            DispatcherTimer timer = (DispatcherTimer)sender;
            timer.Stop();
            timer.Tick -= TimerTick;
            Close();
        }

        private void Grid_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (!upload)
                timer.Stop();
        }

        private void Grid_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (!upload)
                timer.Start();
        }
    }
}