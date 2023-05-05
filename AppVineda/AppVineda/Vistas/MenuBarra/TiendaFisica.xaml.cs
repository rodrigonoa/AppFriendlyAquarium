using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppVineda.Vistas.MenuBarra
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TiendaFisica : ContentPage
    {
        public TiendaFisica()
        {
            InitializeComponent();
        }

        private void btnFacebook_Clicked(object sender, EventArgs e)
        {
            Browser.OpenAsync("https://www.facebook.com/groups/347641153492535", BrowserLaunchMode.SystemPreferred);
        }

        private void btnInstagram_Clicked(object sender, EventArgs e)
        {
            Browser.OpenAsync("https://www.instagram.com/aquariomarinhodorio/", BrowserLaunchMode.SystemPreferred);
        }

        private void btnTwitter_Clicked(object sender, EventArgs e)
        {
            Browser.OpenAsync("https://twitter.com/AquariOfficial", BrowserLaunchMode.SystemPreferred);
        }
    }
}