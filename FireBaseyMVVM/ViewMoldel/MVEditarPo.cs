using FireBaseyMVVM.Datos;
using FireBaseyMVVM.Models;
using FireBaseyMVVM.Views;
using PracticaMVVM.VistaModelo;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace FireBaseyMVVM.ViewMoldel
{
    public class MVEditarPo:BaseViewModel
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
            get { return this._Colorf; }
            set { SetValue(ref this._Colorf, value); }
        }

        public String Icono
        {
            get { return this._Icono; }
            set { SetValue(ref _Icono, value); }
        }

        public String Nombre
        {
            get { return this._Nombre; }
            set { SetValue(ref this._Nombre, value); }
        }

        public String Numero
        {
            get { return this._Numero; }
            set { SetValue(ref this._Numero, value); }
        }

        public String Tipo
        {
            get { return this._Tipo; }
            set { SetValue(ref this._Tipo, value); }
        }

        public String Idpokemon
        {
            get { return this._Idpokemon; }
            set { SetValue(ref this._Idpokemon, value); }
        }
            
        public String ColorPoder
        {
            get { return this._ColorPoder; }
            set { SetValue(ref this._ColorPoder, value); }
        }

        public MPokemon parametrosRe { get; set; }

        public MVEditarPo(INavigation navigation, MPokemon parametrosTra)
        {
            Navigation = navigation;
            parametrosRe = new MPokemon
            {
                Colorf = Colorf,
                Icono = Icono,
                Nombre = Nombre,
                Numero = Numero,
                Tipo = Tipo,
                Idpokemon = parametrosTra.Idpokemon,
                ColorPoder = ColorPoder
            };

            Colorf = parametrosTra.Colorf;
            Icono = parametrosTra.Icono;
            Nombre = parametrosTra.Nombre;
            Numero = parametrosTra.Numero;
            Tipo = parametrosTra.Tipo;
            Idpokemon = parametrosTra.Idpokemon;
            ColorPoder = parametrosTra.ColorPoder;


        }

        public async Task RegLis()
        {
            await Navigation.PushAsync(new ListaPokemon());
        }

        public async Task EdiPo()
        {

            parametrosRe = new MPokemon
            {
                Colorf = Colorf,
                Icono = Icono,
                Nombre = Nombre,
                Numero = Numero,
                Tipo = Tipo,
                Idpokemon = parametrosRe.Idpokemon,
                ColorPoder = ColorPoder
            };

            var funcion = new DPokemon();



            await funcion.EditarPo(parametrosRe);

            await DisplayAlert("d","d","D");
        }

        public ICommand ComEdiPo => new Command(async () => await EdiPo());


    }
}
