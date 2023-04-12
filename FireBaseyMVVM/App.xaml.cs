using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FireBaseyMVVM.Views;

namespace FireBaseyMVVM
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new NavigationPage(new ListaPokemon());
            MainPage = new NavigationPage(new ListaPokemon());
            //MainPage = new EditarPo();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
