using FireBaseyMVVM.Models;
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
    public partial class DetallePo : ContentPage
    {
        public DetallePo(MPokemon parametros)
        {
            InitializeComponent();
            BindingContext = new MVDetallePo(Navigation,parametros);
        }
    }
}