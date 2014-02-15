using System;
using System.Drawing;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace DRE_ApplicationLists.DreApplicationListComponents.AppValueConverters
{
    public class FilePathToIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (targetType != typeof(ImageSource))
            {
                throw new InvalidOperationException("Converter: FilePathToIconConverter is an image converter specifically to get icons.");
            }
            ImageSource variable = null;
            if (value is string)
            {
                try
                {
                    var extractAssociatedIcon = Icon.ExtractAssociatedIcon(value as string);
                    if (extractAssociatedIcon != null)
                    {
                        variable = GetImageSourceFromIco(extractAssociatedIcon);
                    }
                }
                // ReSharper disable once EmptyGeneralCatchClause
                catch
                {
                    //Returns the default image stored in AppCardImages
                    const string newone = @"\DreApplicationListComponents\AppCardImages\IconNotFoundDefault.jpg";

                    var bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(newone, uriKind: UriKind.RelativeOrAbsolute);
                    bitmap.DecodePixelHeight = 32;
                    bitmap.DecodePixelWidth = 32;                    
                    bitmap.EndInit();
                    variable = bitmap;
                }
            }
            return variable;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }

        private ImageSource GetImageSourceFromIco(Icon img)
        {
            Bitmap bitmap = img.ToBitmap();
            IntPtr hBitmap = bitmap.GetHbitmap();            
            var wpfBitmap =
                 Imaging.CreateBitmapSourceFromHBitmap(
                      hBitmap, IntPtr.Zero, Int32Rect.Empty,
                      BitmapSizeOptions.FromEmptyOptions());
            
            return wpfBitmap;
        }
    }//end of class
}//end of Namespace