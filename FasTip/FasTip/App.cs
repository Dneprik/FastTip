using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace FasTip
{
    public class App : Application
    {


        public static int ScreenWidth { get; set; }
        public static int ScreenHeight { get; set; }


        public App()
        {
            //Determine the width of Editor field
            int editorwith;
            if (ScreenWidth > ScreenHeight)
                editorwith = ScreenHeight;
            else editorwith = ScreenWidth;
            //

            //Procent of tip
            double tip = 17;
            double tipAmount = 0;
            double totalAmount = 0;
            //

            Editor editor = new Editor()
            {
                BackgroundColor = Color.FromHex("CEC8C8"),
                WidthRequest = editorwith / 2 * 0.8,
                HeightRequest = 40,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Start,
                //   TranslationY = 75,
                Keyboard = Keyboard.Numeric
            };

            Button btn = new Button()
            {
                BackgroundColor = Color.Gray,
                WidthRequest = 200,
                Text = "Calculate Tip",
                HeightRequest = 50,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Start,
                //  TranslationY = 150,
                BorderColor = Color.Black,
                FontSize = 25
            };

            editor.Focused += (sender, e) =>
            {
                (sender as Editor).BackgroundColor = Color.FromHex("CBCBD3");
            };
            editor.Unfocused += (sender, e) =>
            {
                (sender as Editor).BackgroundColor = Color.FromHex("CEC8C8");
            };


            Label labelTipPercentage = new Label()
            {
                Text = "Tip percentage\t" + tip + "%",
                //TranslationY = 200,
                HorizontalOptions = LayoutOptions.Center,
                TextColor = Color.Black,
                FontSize = 25
            };

            Label labelTipAmount = new Label()
            {
                Text = "Tip Amount\t$" + tipAmount,
                //   TranslationY = 250,
                HorizontalOptions = LayoutOptions.Center,
                TextColor = Color.Black,
                FontSize = 25
            };

            Label lableTotalAmount = new Label()
            {
                Text = "Total amount\t$" + totalAmount,
                TextColor = Color.Green,
                //TranslationY = 300,
                HorizontalOptions = LayoutOptions.Center,
                FontSize = 27
            };

            btn.Clicked += (sender, e) =>
             {
                 if (editor.Text != "")
                 {
                     tipAmount = Convert.ToDouble(editor.Text) / 100 * tip;
                     totalAmount = Convert.ToDouble(editor.Text) + tipAmount;
                     labelTipAmount.Text = "Tip Amount\t$" + tipAmount.ToString();
                     lableTotalAmount.Text = "Total amount\t$" + totalAmount.ToString();

                 }
             };


            var editorfont = new FormattedString();
            editorfont.Spans.Add(new Span { ForegroundColor = Color.Black, FontSize = 25, FontAttributes = FontAttributes.Bold });


            // The root page of your application
            MainPage = new ContentPage
            {
                Content = new StackLayout
                {
                    BackgroundColor = Color.White,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    Padding = 10,
                    Children = {
                        editor, btn,
                        labelTipPercentage,
                        labelTipAmount,
                        lableTotalAmount
                    }
                }


            };

        }



        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }


    }



}
