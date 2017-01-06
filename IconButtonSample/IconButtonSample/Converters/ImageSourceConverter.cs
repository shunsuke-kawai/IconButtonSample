using System;
using System.Globalization;
using System.Reflection;
using Xamarin.Forms;

namespace IconButtonSample.Converters
{
    public class ImageSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is string))
            {
                return default(ImageSource);
            }

            var path = value.ToString();

            if (Device.OS == TargetPlatform.iOS || Device.OS == TargetPlatform.Android)
            {
                return ImageSource.FromResource(path);
            }
            else
            {
                var assembly = typeof(App).GetTypeInfo().Assembly;
                return ImageSource.FromResource(path, assembly);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
