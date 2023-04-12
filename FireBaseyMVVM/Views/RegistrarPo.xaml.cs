using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FireBaseyMVVM.ViewMoldel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FireBaseyMVVM.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrarPo : ContentPage
    {
        public RegistrarPo()
        {
            InitializeComponent();
            BindingContext = new MVRegistroPok(Navigation);
        }
    }
}