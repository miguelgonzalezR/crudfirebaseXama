using PracticaMVVM.VistaModelo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using FireBaseyMVVM.Views;
using System.Windows.Input;
using FireBaseyMVVM.Models;
using FireBaseyMVVM.Datos;
using System.Collections.ObjectModel;

namespace FireBaseyMVVM.ViewMoldel
{
    public class MVPokemonLis:BaseViewModel
    {
        ObservableCollection<MPokemon> _ListPo;
        List<MPokemon> _ListPokemonLi;

        public ObservableCollection<MPokemon> ListPokemon
        {
            get { return _ListPo; }
            set { SetValue (ref _ListPo, value); 
                OnPropertyChanged ();
            }
        }

        public List<MPokemon> ListPokemonLi
        {
            get { return _ListPokemonLi; }
            set
            {
                SetValue(ref _ListPokemonLi, value);
                OnPropertyChanged();
            }
        }

        public MVPokemonLis(INavigation navigation)
        {
            Navigation = navigation;
            MostrarPo();
        }

        public async Task Iraregistros()
        {
            await Navigation.PushAsync(new RegistrarPo());
        }

        public async Task MostrarPo()
        {
            var funcion = new DPokemon();
            ListPokemonLi = await funcion.MostarPoLi();
        }

        public async Task IrDe(MPokemon paremetros)
        {
            await Navigation.PushAsync (new DetallePo(paremetros));
        }

        public ICommand ProIrRE => new Command(async () => await Iraregistros());
        public ICommand ComDe => new Command<MPokemon>(async (p) => await IrDe(p));

    }
}
