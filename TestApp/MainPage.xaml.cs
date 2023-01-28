using CommunityToolkit.Maui.Alerts;

namespace TestApp;

public partial class MainPage : ContentPage
{
    bool isRandom;
    string hexValue;
    public MainPage()
    {
        InitializeComponent();
    }


    private void slider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        if (!isRandom)
        {
            var red = sldRed.Value;
            var grn = sldGreen.Value;
            var blue = sldBlue.Value;

            Color color = Color.FromRgb(red, grn, blue);
            SetColor(color);
        }
    }

    private void SetColor(Color color)
    {
        Container.BackgroundColor = color;
        rndBtn.BackgroundColor = color;
        hexValue = color.ToHex();
        lblHex.Text = hexValue;
    }

    private void rndBtn_Clicked(object sender, EventArgs e)
    {
        isRandom = true;
        var random = new Random();
        Color color = Color.FromRgb(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256));
        SetColor(color);
        sldRed.Value = color.Red;
        sldGreen.Value = color.Green;
        sldBlue.Value = color.Blue;
        isRandom = false;
    }

    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
        await Clipboard.SetTextAsync(hexValue);
        var toast = Toast.Make("Color Copied!", CommunityToolkit.Maui.Core.ToastDuration.Long, 12);
        await toast.Show();
    }
}

