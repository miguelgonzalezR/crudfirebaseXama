using FireBaseyMVVM.ViewMoldel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FireBaseyMVVM.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaPokemon : ContentPage
    {
        MVPokemonLis vmp;
        public ListaPokemon()
        {
            InitializeComponent();
            vmp = new MVPokemonLis(Navigation);
            BindingContext = vmp;
            this.Appearing += ListaPokemon_Appearing;
        }

        public async void ListaPokemon_Appearing(object sender, EventArgs e)
        {
            await vmp.MostrarPo();
        }

    }
}