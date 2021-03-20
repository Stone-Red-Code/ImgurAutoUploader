using Imgur.API.Authentication;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ImgurAutoUploader
{
    /// <summary>
    /// Interaktionslogik für EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        private BitmapSource bitmap;
        private ApiClient apiClient;

        private struct OriginalSize
        {
            public OriginalSize(double x, double y)
            {
                X = x;
                Y = y;
            }

            public double X { get; set; }
            public double Y { get; set; }
        }

        private OriginalSize originalSize = new OriginalSize(10, 10);

        public EditWindow(BitmapSource bitmapSource, ApiClient client)
        {
            InitializeComponent();
            bitmap = bitmapSource;
            apiClient = client;

            inkCanvas.Width = bitmap.Width;
            inkCanvas.Height = bitmap.Height;

            ImageBrush ib = new ImageBrush();
            ib.ImageSource = bitmapSource;
            inkCanvas.Background = ib;
        }

        private void InkCanvas_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (e.Delta > 0)
            {
                originalSize.X++;
                originalSize.Y++;
            }
            else if (originalSize.X > 1)
            {
                originalSize.X--;
                originalSize.Y--;
            }

            UpdateScale();
        }

        private void InkCanvas_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            inkCanvas.EditingMode = InkCanvasEditingMode.EraseByPoint;
        }

        private void InkCanvas_PreviewMouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            inkCanvas.EditingMode = InkCanvasEditingMode.Ink;
        }

        private void InkCanvas_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            inkCanvas.DefaultDrawingAttributes.Height = originalSize.Y;
            inkCanvas.DefaultDrawingAttributes.Width = originalSize.X;
            inkCanvas.EraserShape = new EllipseStylusShape(inkCanvas.DefaultDrawingAttributes.Width, inkCanvas.DefaultDrawingAttributes.Height);
        }

        private void InkCanvas_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            UpdateScale();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            this.IsEnabled = false;
            this.Cursor = Cursors.Wait;
            Clipboard.SetImage(ControlToImage(inkCanvas));
            this.Close();
        }

        private async void UploadButton_Click(object sender, RoutedEventArgs e)
        {
            this.IsEnabled = false;
            Mouse.OverrideCursor = Cursors.Wait;

            UploadProgressBar.Visibility = Visibility.Visible;
            SecretButton.Visibility = Visibility.Collapsed;
            UploadButton.Visibility = Visibility.Collapsed;

            string link = await UploadManager.Upload(bitmap, apiClient);

            Clipboard.SetText(link);
            UploadProgressBar.Visibility = Visibility.Collapsed;
            this.Close();

            Mouse.OverrideCursor = null;
        }

        public BitmapImage ControlToImage(FrameworkElement control)
        {
            RenderTargetBitmap rtb = new RenderTargetBitmap((int)control.ActualWidth, (int)control.ActualHeight, 96, 96, PixelFormats.Pbgra32);
            rtb.Render(control);

            BitmapImage bitmapImage = new BitmapImage();
            PngBitmapEncoder bitmapEncoder = new PngBitmapEncoder();
            bitmapEncoder.Frames.Add(BitmapFrame.Create(rtb));

            using (var stream = new MemoryStream())
            {
                bitmapEncoder.Save(stream);
                stream.Seek(0, SeekOrigin.Begin);

                bitmapImage.BeginInit();
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.StreamSource = stream;
                bitmapImage.EndInit();
            }
            return bitmapImage;
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            UpdateScale();
        }

        private void UpdateScale()
        {
            double a = originalSize.Y * viewBox.GetScaleFactor() + 1;
            double b = originalSize.X * viewBox.GetScaleFactor() + 1;
            inkCanvas.DefaultDrawingAttributes.Height = a;
            inkCanvas.DefaultDrawingAttributes.Width = b;
            inkCanvas.EraserShape = new EllipseStylusShape(inkCanvas.DefaultDrawingAttributes.Width, inkCanvas.DefaultDrawingAttributes.Height);
        }
    }

    public static class ViewBoxExtensions
    {
        public static double GetScaleFactor(this Viewbox viewbox)
        {
            if (viewbox.Child == null ||
                (viewbox.Child is FrameworkElement) == false)
            {
                return double.NaN;
            }
            FrameworkElement child = viewbox.Child as FrameworkElement;
            return viewbox.ActualWidth / child.ActualWidth;
        }
    }
}