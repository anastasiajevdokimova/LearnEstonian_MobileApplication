using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EstApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GamePage : ContentPage
    {
        Label textLabel;
        Image img;
        Button button1, button2;
        ProgressBar progressBar;
        public static DBRepository database;
        public ObservableCollection<Product> products { get; set; }
        public GamePage()
        {
            database = App.Database;
            var product = App.database.GetRamdomItem();
            progressBar = new ProgressBar
            {
                Progress = 0.0,
                ProgressColor = Color.Orange
            };
            textLabel = new Label
            {
                Text = product.EngWord.ToString(),
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };

            img = new Image
            {
                Source = product.Image,
                HeightRequest = 350,
                WidthRequest = 350
            };
            button1 = new Button
            {
                Text = product.EstWord.ToString(),
                BackgroundColor = Color.Gray
            };
            button2 = new Button
            {
                Text = App.database.GetRamdomString().ToString(),
                BackgroundColor = Color.Gray
            };
            button1.Clicked += Button1_Clicked;
            button2.Clicked += Button2_Clicked;
            StackLayout st = new StackLayout
            {
                Children = { textLabel, img, button1, button2, progressBar }
            };
            Content = st;
        }
        private async void Button2_Clicked(object sender, EventArgs e)
        {
            button2.BackgroundColor = Color.Red;
            var product = App.database.GetRamdomItem();
            await Task.Delay(400);

            textLabel.Text = product.EngWord.ToString();
            img.Source = product.Image;
            button1.Text = product.EstWord.ToString();
            button2.Text = App.database.GetRamdomString().ToString();

            button2.BackgroundColor = Color.Gray;
        }

        private async void Button1_Clicked(object sender, EventArgs e)
        {
            button1.BackgroundColor = Color.Green;
            var product = App.database.GetRamdomItem();

            await Task.Delay(400);

            textLabel.Text = product.EngWord.ToString();
            img.Source = product.Image;
            button1.Text = product.EstWord.ToString();
            button2.Text = App.database.GetRamdomString().ToString();

            button1.BackgroundColor = Color.Gray;

            progressBar.Progress += 0.1;
            if (progressBar.Progress > 0.9)
            {
                var ans = await DisplayAlert("Congratulations", "Game Over!", "OK", "NO");
                if (ans == true)
                {
                    progressBar.Progress = 0.0;
                }
            }
        }
    }
}