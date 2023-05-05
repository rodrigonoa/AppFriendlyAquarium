using AppVineda.Modelos;
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
    public partial class HistorialCompras : ContentPage
    {
        Int32 IdUser = 0;
        public HistorialCompras()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            CargarAgendas();
        }
        private async void CargarAgendas()
        {
            var reg_contac = await App.contexto.GetUsuarios();
            if (reg_contac.Count > 0)
            {
                var usuario = reg_contac.FirstOrDefault(u => u.sesion == 1);
                if (usuario != null)
                {
                    IdUser = usuario.id_usuario;
                    var producto = await App.contexto.GetHistorial();
                    if (producto.Count > 0)
                    {
                        var productos = producto.Where(p => p.IdUser_Pro == IdUser);
                        if (productos.Any())
                        {
                            carouselView1.ItemsSource = productos;
                            BindingContext = this;
                        }
                    }
                }
            }
        }
    }
}