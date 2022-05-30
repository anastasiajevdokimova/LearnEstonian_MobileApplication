using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EstApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GamePage : ContentPage
    {
        private Label textLabel;
        private ImageButton img;
        private Button button1, button2;
        public static DBRepository database;
        public ObservableCollection<Product> products { get; set; }
        public GamePage()
        {
            InitializeComponent();
            database = App.Database;
            var product = App.database.GetRamdomItem();
            textLabel = new Label
            {
                Text = product.EngWord.ToString(),
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };

            img = new ImageButton
            {
                Source = product.Image
            };
            button1 = new Button
            {
                Text = product.EstWord.ToString()

            };
            button1.Clicked += Button1_Clicked;
            StackLayout st = new StackLayout
            {
                Children = { textLabel, img, button1 }
            };
            Content = st;
        }
        private void Button1_Clicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}