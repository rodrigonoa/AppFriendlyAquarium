using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppVineda.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuLateral : MasterDetailPage
    {
        public MenuLateral()
        {
            InitializeComponent();
            this.Master = new Vistas.MenuBarra.Master();
            this.Detail = new NavigationPage(new Home());
            App.MAsterDet = this;
        }
    }
}