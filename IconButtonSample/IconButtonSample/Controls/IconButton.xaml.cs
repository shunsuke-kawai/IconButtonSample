using System;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace IconButtonSample.Controls
{
    public partial class IconButton : ContentView
    {
        private bool addedAnimation;

        public static readonly BindableProperty IconSourceProperty =
            BindableProperty.Create(
                "IconSource",
                typeof(ImageSource),
                typeof(IconButton),
                null,
                propertyChanged: (bindable, oldValue, newValue) =>
                {
                    ((IconButton)bindable).IconSource = (ImageSource)newValue;
                }
            );

        public ImageSource IconSource
        {
            get { return (ImageSource)GetValue(IconSourceProperty); }
            set
            {
                SetValue(IconSourceProperty, value);
                imgIcon.Source = value;
            }
        }

        public static readonly BindableProperty IconMarginProperty =
            BindableProperty.Create(
                "IconMargin",
                typeof(Thickness),
                typeof(IconButton),
                new Thickness(0),
                propertyChanged: (bindable, oldValue, newValue) =>
                {
                    ((IconButton)bindable).IconMargin = (Thickness)newValue;
                }
            );

        public Thickness IconMargin
        {
            get { return (Thickness)GetValue(IconMarginProperty); }
            set
            {
                SetValue(IconMarginProperty, value);
                imgIcon.Margin = value;
            }
        }

        public IconButton()
        {
            InitializeComponent();
        }

        private void imgIcon_BindingContextChanged(object sender, EventArgs e)
        {
            if (addedAnimation || GestureRecognizers.Count == 0)
                return;

            var tapGesture = GestureRecognizers[0] as TapGestureRecognizer;
            if (tapGesture == null)
                return;

            tapGesture.Tapped += (tapsender, tape) =>
            {
                Device.BeginInvokeOnMainThread(async () => await tappedAnimation());
            };

            addedAnimation = true;
        }

        private async Task tappedAnimation()
        {
            BackgroundColor = Color.FromRgba(68, 68, 68, 70);
            await imgIcon.ScaleTo(0.8, 75);
            await imgIcon.ScaleTo(1.0, 75);
            BackgroundColor = Color.Transparent;
        }
    }
}
