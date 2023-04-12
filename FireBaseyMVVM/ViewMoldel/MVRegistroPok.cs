using FireBaseyMVVM.Views;
using PracticaMVVM.VistaModelo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using FireBaseyMVVM.Models;
using FireBaseyMVVM.Datos;
using System.Drawing;

namespace FireBaseyMVVM.ViewMoldel
{
    public class MVRegistroPok:BaseViewModel
    {

        String _Txtcolorfondo;
        String _Txtcolortipo;
        String _Txtnombre;
        String _Txtnro;
        String _Txttipo;
        String _Txticono;

        public MVRegistroPok(INavigation navigation)
        {
            Navigation = navigation;
        }

        public String Txtcolorfondo
        {
            get { return _Txtcolorfondo;}
            set {SetValue (ref _Txtcolorfondo,value);}
        }

        public String Txtcolortipo
        {
            get { return _Txtcolortipo; }
            set { SetValue(ref _Txtcolortipo, value); }
        }

        public String Txtnombre
        {
            get { return _Txtnombre; }
            set { SetValue(ref _Txtnombre, value); }
        }

        public String Txtnro
        {
            get { return _Txtnro; }
            set { SetValue(ref _Txtnro, value); }
        }

        public String Txttipo
        {
            get { return _Txttipo; }
            set { SetValue(ref _Txttipo, value); }
        }

        public String Txticono
        {
            get { return _Txticono; }
            set { SetValue(ref _Txticono, value); }
        }

        public async Task RegLis()
        {
            await Navigation.PopAsync();
        }

        public async Task InsertarP()
        {
            // var sirva para que el propio IDE le de el tipo de datos

            var funcion = new DPokemon();
            var parametros = new MPokemon();

            parametros.Colorf = Txtcolorfondo;
            parametros.ColorPoder = Txtcolortipo;
            parametros.Icono = Txticono;
            parametros.Nombre = Txtnombre;
            parametros.Numero = Txtnro;
            parametros.Tipo = Txttipo;

            await funcion.InsertarPo(parametros);
            await RegLis();



        }

        public ICommand Vollis => new Command(async () => await RegLis());
        public ICommand ComINPo => new Command(async () => await InsertarP());

    }
}
