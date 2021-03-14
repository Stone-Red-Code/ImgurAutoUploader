using Imgur.API.Authentication;
using System;
using System.Windows;
using System.Windows.Threading;

namespace ImgurAutoUploader
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ApiClient apiClient;
        private bool check = true;

        private double width = 0;
        private double height = 0;

        public MainWindow()
        {
            InitializeComponent();
            apiClient = new ApiClient(".");
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (Clipboard.ContainsImage() && check)
            {
                check = false;
                var image = Clipboard.GetImage();
                if (width != image.Width || height != image.Height)
                {
                    width = image.Width;
                    height = image.Height;
                    new Popup(image, apiClient).ShowDialog();
                }
                check = true;
            }
        }
    }
}