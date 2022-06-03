using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EstApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DictionaryPage : ContentPage
    {
        public static DBRepository database;
        public List<Product> Products;
        public DictionaryPage()
        {
            InitializeComponent();

        }
        private void LanguageChange(object sender, ToggledEventArgs e)
        {
            if (e.Value)
            {
                swLabel.Text = "Search in estonian";
            }
            else
            {
                swLabel.Text = "Search in english";
            }
        }
        private void SearchItem(object sender, TextChangedEventArgs e)
        {
            var keyword = searchBox.Text;

            //если текст в поиск не введён, показывается весь список
            if (string.IsNullOrEmpty(e.NewTextValue))
            {
                wordsList.ItemsSource = App.Database.Products;
            }

            else
            {
                //сравнение введенного в поиск текста с данными в БД
                if (swLanguage.IsToggled == true)
                {
                    //если словарь с эстонского на английский, то ищем по эстонскому слову
                    wordsList.ItemsSource = App.Database.Products.Where(x => x.EstWord.StartsWith(e.NewTextValue));
                }
                else
                {
                    //если словарь с английского на эстонский - ищем по английскому слову
                    wordsList.ItemsSource = App.Database.Products.Where(x => x.EngWord.StartsWith(e.NewTextValue));
                    var what = new ImageCell();
                    what.SetBinding(ImageCell.TextProperty, "EngWord");
                    what.SetBinding(ImageCell.ImageSourceProperty, "Image");
                    what.SetBinding(ImageCell.DetailProperty, "EstWord");
                }
            }
        }
        protected override void OnAppearing()
        {
            wordsList.ItemsSource = App.Database.Products;
            base.OnAppearing();
        }
    }
}