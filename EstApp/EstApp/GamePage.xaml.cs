using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EstApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GamePage : ContentPage
    {
        Label productName;
        Image productImage;
        Button button1, button2, button3, button4;
        private List<Button> buttonList;
        private List<Product> quizProducts;
        ProgressBar progressBar;
        public static DBRepository database;
        Product product;
        public ObservableCollection<Product> products { get; set; }
        public GamePage()
        {
            InitializeComponent();

            database = App.Database;
            quizProducts = new List<Product>(database.Products);
            product = GetRandomProduct();

            productName = new Label
            {
                Text = product.EngWord.ToString(),
                FontSize = 24,
                FontAttributes = FontAttributes.Bold,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };

            productImage = new Image
            {
                Source = product.Image,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                HeightRequest = 350,
                WidthRequest = 350
            };

            progressBar = new ProgressBar
            {
                Progress = 0.0,
                ProgressColor = Color.Orange,
            };

            //buttons
            button1 = new Button
            {
                Text = " ",
                BackgroundColor = Color.LightBlue
            };
            button2 = new Button
            {
                Text = " ",
                BackgroundColor = Color.LightBlue
            };
            button3 = new Button
            {
                Text = " ",
                BackgroundColor = Color.LightBlue
            };
            button4 = new Button
            {
                Text = " ",
                BackgroundColor = Color.LightBlue
            };
            buttonList = new List<Button>{};
            //Add buttons to list
            buttonList.Add(button1);
            buttonList.Add(button2);
            buttonList.Add(button3);
            buttonList.Add(button4);

            button1.Clicked += CheckAnswer;
            button2.Clicked += CheckAnswer;
            button3.Clicked += CheckAnswer;
            button4.Clicked += CheckAnswer;

            StackLayout st = new StackLayout
            {
                Children = { productName, productImage, progressBar, button1, button2, button3, button4}
            };
            Content = st;
            SetCorrectWord();
        }

        private void SetCorrectWord()
        {
            string correctWord = product.EstWord;
            Random rnd = new Random();
            int randomButton = rnd.Next(0,3);

            buttonList[randomButton].Text = correctWord;
            quizProducts.Remove(product);

            List<Product> tempProducts = new List<Product>(database.Products);
            tempProducts.Remove(product);
            foreach (Button b in buttonList)
            {
                if(b.Text != correctWord)
                {
                    int prodIndex = rnd.Next(0, tempProducts.Count-1);
                    b.Text = tempProducts[prodIndex].EstWord;
                    tempProducts.RemoveAt(prodIndex);
                }
            }

        }

        private async void CheckAnswer(object sender, EventArgs e)
        {
            string s = (sender as Button).Text;
            if (s == product.EstWord)
            {
                //correct
                (sender as Button).BackgroundColor = Color.LightGreen;
                progressBar.Progress += 0.1;
                await Task.Delay(400);
                if(progressBar.Progress >= 0.9)
                {
                    //game over
                    await DisplayAlert("Congratulations", "Now you know a bit more!", "Play again");
                    progressBar.Progress = 0.0;
                    //NewGame
                    quizProducts = new List<Product>(database.Products);
                    SetNewQuestion();
                }
                else
                {
                    SetNewQuestion();
                }
            }
            else
            {
                //incorrect
                (sender as Button).BackgroundColor = Color.Crimson;
            }
        }

        private void SetNewQuestion()
        {
            product = GetRandomProduct();
            productName.Text = product.EngWord.ToString();
            productImage.Source = product.Image;
            foreach (Button b in buttonList)
            {
                b.BackgroundColor = Color.LightBlue;
                b.Text = " ";
            }
            SetCorrectWord();

        }

        private Product GetRandomProduct()
        {
            Random rnd = new Random();
            int index = rnd.Next(0, quizProducts.Count - 1);
            product = quizProducts[index];
            return product;
        }
    }
}