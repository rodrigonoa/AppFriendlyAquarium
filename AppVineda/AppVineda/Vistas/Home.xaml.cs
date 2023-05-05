using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;
using AppVineda.Modelos;
using Xamarin.Essentials;

namespace AppVineda.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentPage
    {

        public Home()
        {
            InitializeComponent();
            BindingContext = this;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            CargarAgendas();
        }
        private async void CargarAgendas()
        {
            var reg_contac = await App.contexto.GetProductos();
            var totalProductos = reg_contac.Count;
            var mitad = totalProductos / 2;

            var productos1 = reg_contac.Take(mitad).OrderBy(p => Guid.NewGuid()).ToList();
            var productos2 = reg_contac.Skip(mitad).Take(mitad).OrderBy(p => Guid.NewGuid()).ToList();

            carouselView1.ItemsSource = productos1;
            carouselView2.ItemsSource = productos2;
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

        private async void btnImagen2_Clicked(object sender, EventArgs e)
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
                await Navigation.PushAsync(imagenselecc); ;
            }
        }

        private async void toolCarrito_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Carrito());
        }
    }
}