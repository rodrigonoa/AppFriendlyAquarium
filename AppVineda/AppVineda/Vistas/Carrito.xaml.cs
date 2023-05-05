using AppVineda.Modelos;
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
    public partial class Carrito : ContentPage
    {
        decimal sumTotal = 0;
        Int32 IdUsers = 0;
        public Carrito()
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
                    IdUsers = usuario.id_usuario;
                    var producto = await App.contexto.GetCarrito();
                    if (producto.Count > 0)
                    {
                        var productos = producto.Where(p => p.IdUser_car == IdUsers);
                        if (productos.Any())
                        {
                            listaProductos.ItemsSource = productos;
                            sumTotal = productos.Sum(p => p.Total);
                            txtSumTotal.Text = string.Format("S/. {0:#,0.00}", sumTotal);
                            BindingContext = this;
                        }
                    }
                }
            }
        }

        private async void btnPagar_Clicked(object sender, EventArgs e)
        {
            var pagando = new Pago();
            pagando.PagoTotal = sumTotal;
            await Navigation.PushAsync(pagando);
        }

        private async void btnEliminar_Clicked(object sender, EventArgs e)
        {
            if (await DisplayAlert("Responder", "¿Desea eliminar?", "Si", "No"))
            {
                var elemento = (MiCarrito)(sender as MenuItem).CommandParameter;
                var nreg = await App.contexto.eliminarCarrito(elemento);

                // Obtener la lista de elementos después de eliminar el elemento actual
                var productos = await App.contexto.GetCarrito();
                var producto = productos.Where(p => p.IdUser_car == IdUsers);

                // Verificar si hay solo un elemento en la lista
                if (producto.Count() == 0)
                {
                    await DisplayAlert("Aviso", "Tu Carrito de compras esta vacio", "OK");
                    await Navigation.PopAsync(); // Volver a la página anterior
                }
                else
                {
                    CargarAgendas();
                }
            }
        }
    }
}