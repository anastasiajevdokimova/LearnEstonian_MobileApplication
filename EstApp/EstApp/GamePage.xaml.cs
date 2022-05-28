﻿using System;
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
        public static DBRepository database;
        public ObservableCollection<Product> products { get; set; }
        public GamePage()
        {
            InitializeComponent();
            database = App.Database;

            textLabel = new Label
            {
                Text = database.Products[0].EstWord.ToString(),
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };

            img = new ImageButton
            {
                Source = database.Products[0].Image
            };

            StackLayout st = new StackLayout
            {
                Children = { textLabel, img }
            };
            Content = st;
        }
    }
}