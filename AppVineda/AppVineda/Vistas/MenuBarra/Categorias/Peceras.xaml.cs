using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppVineda.Vistas.MenuBarra.Categorias
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Peceras : ContentPage
    {
        public Peceras()
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
            var reg_contac = await App.contexto.GetProductos();
            if (reg_contac.Count > 0)
            {
                var productos = reg_contac.Where(p => p.category == 5);
                if (productos.Any())
                {
                    carouselView1.ItemsSource = productos;
                }
            }
        }
        private async void btnImagen1_Clicked(object sender, EventArgs e)
        {
            // Obtener el Id del producto seleccionado
            var productoId = (int)((ImageButton)sender).CommandParameter;

            // Hacer lo que sea necesario con el Id del producto seleccionado
            // Por ejemplo, buscar el producto correspondiente en la lista de productos
            var reg_contac = await App.contexto.GetProductos();
            var productoSeleccionado = reg_contac.FirstOrDefault(p => p.Id == productoId);
            if (productoSeleccionado != null)
            {
                var imagenselecc = new ProcesoCompra();
                imagenselecc.IdSele = productoSeleccionado.Id;
                await Navigation.PushAsync(imagenselecc);
            }
        }
    }
}