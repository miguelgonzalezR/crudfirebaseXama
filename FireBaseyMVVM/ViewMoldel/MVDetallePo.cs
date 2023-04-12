using FireBaseyMVVM.Datos;
using FireBaseyMVVM.Models;
using FireBaseyMVVM.Views;
using PracticaMVVM.VistaModelo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace FireBaseyMVVM.ViewMoldel
{
    public class MVDetallePo:BaseViewModel
    {

        private String _Colorf;
        private String _Icono;
        private String _Nombre;
        private String _Numero;
        private String _Tipo;
        private String _Idpokemon;
        private String _ColorPoder;

        public String Colorf
        {
            get { return _Colorf; }
            set { SetValue(ref _Colorf, value); }
        }

        public String Icono
        {
            get { return _Icono; }
            set { SetValue(ref _Icono, value); }
        }

        public String Nombre
        {
            get { return _Nombre; }
            set { SetValue(ref _Nombre, value); }
        }

        public String Numero
        {
            get { return _Numero; }
            set { SetValue(ref _Numero, value); }
        }

        public String Tipo
        {
            get { return _Tipo; }
            set { SetValue(ref _Tipo, value); }
        }

        public String Idpokemon
        {
            get { return _Idpokemon; }
            set { SetValue(ref _Idpokemon, value); }
        }

        public String ColorPoder
        {
            get { return _ColorPoder; }
            set { SetValue(ref _ColorPoder, value); }
        }


        public MPokemon parametrosRe { get; set; }  

        public MVDetallePo(INavigation navigation, MPokemon parametrosTra)
        {
            Navigation = navigation;
            parametrosRe = parametrosTra;

            Colorf = parametrosTra.Colorf;
            Icono = parametrosTra.Icono;
            Nombre = parametrosTra.Nombre;
            Numero  = parametrosTra.Numero.ToString();
            Tipo = parametrosTra.Tipo;
            Idpokemon = parametrosTra.Idpokemon;
            ColorPoder = parametrosTra.ColorPoder;


        }

        public async Task RegLis()
        {
            await Navigation.PopAsync();
        }



        public async Task EliPo()
        {
            var funcion = new DPokemon();

            await funcion.EliminarPo(Idpokemon);

            await RegLis();
        }

        public async Task IrAct(MPokemon paremetros)
        {
            await Navigation.PushAsync(new EditarPo(paremetros));
        }

        public ICommand ComEliPo => new Command(async () => await EliPo());
        public ICommand ComIrAct => new Command<MPokemon>(async (p) => await IrAct(p));

    }
}
