using Imgur.API.Authentication;
using System;
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
        private bool allowHide = true;

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

        private async void UploadButton_Click(object sender, RoutedEventArgs e)
        {
            this.IsEnabled = false;

            timer.Stop();
            allowHide = false;
            UploadProgressBar.Visibility = Visibility.Visible;
            SecretButton.Visibility = Visibility.Collapsed;
            UploadButton.Visibility = Visibility.Collapsed;

            string link = await UploadManager.Upload(bitmap, apiClient);

            Clipboard.SetText(link);

            LinkTextBlock.Text = link;
            UploadProgressBar.Visibility = Visibility.Collapsed;
            LinkTextBlock.Visibility = Visibility.Visible;
            timer.Start();
        }

        private void SecretButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
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
            if (allowHide)
                timer.Stop();
        }

        private void Grid_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (allowHide)
                timer.Start();
        }

        private void EditButton_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            editLabel.Visibility = Visibility.Visible;
            imageBox.Opacity = 0.5;
        }

        private void EditButton_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            editLabel.Visibility = Visibility.Collapsed;
            imageBox.Opacity = 1;
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            allowHide = false;
            this.Hide();
            new EditWindow(bitmap, apiClient).ShowDialog();
            this.Close();
        }
    }
}