using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppVineda.Vistas.MenuBarra
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AcercaNosotros : ContentPage
    {
        public AcercaNosotros()
        {
            InitializeComponent();
            web_video.Source = "https://www.youtube.com/watch?v=Xp759asPH3U";
            BindingContext = this;
        }
    }
}