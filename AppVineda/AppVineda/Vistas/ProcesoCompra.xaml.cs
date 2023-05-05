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

    public partial class ProcesoCompra : ContentPage
    {
        string ImagenOK = "";
        public int IdSele { get; set; }
        Int32 cantidad = 0;
        decimal totalPrecio = 0;
        decimal PrecioProducto = 0;
        decimal precio = 0;
        Int32 MiId = 0;
        public ProcesoCompra()
        {
            InitializeComponent();
            BindingContext = this;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            CargarProducto();
        }
        private async void CargarProducto()
        {
            var reg_contac = await App.contexto.GetProductos();
            if (reg_contac.Count > 0)
            {
                var usuario = reg_contac.FirstOrDefault(u => u.Id == IdSele);
                if (usuario != null)
                {
                    lblNombre.Text = usuario.Nombre;
                    imgProducto.Source = usuario.Imagen;
                    ImagenOK = usuario.Imagen;
                    precio = usuario.Precio;
                    lblPrecio.Text = string.Format("S/. {0:#,0.00}", usuario.Precio.ToString());
                    PrecioProducto = usuario.Precio;
                    txtCantidad.Text = "0";
                    txtTotal.Text = "S/. 0.00";
                    lblDescripcion.Text = usuario.Descripcion;
                }
            }

            var reg_cont = await App.contexto.GetUsuarios();
            if (reg_cont.Count > 0)
            {
                var usuario1 = reg_cont.FirstOrDefault(u => u.sesion == 1);
                if (usuario1 != null)
                {
                    MiId = usuario1.id_usuario;
                }
            }
        }


        private void btnMas_Clicked(object sender, EventArgs e)
        {
            cantidad = cantidad + 1;
            totalPrecio = cantidad * PrecioProducto;
            txtTotal.Text = string.Format("S/. {0:#,0.00}", totalPrecio);
            txtCantidad.Text = cantidad.ToString();
        }

        private void btnMenos_Clicked(object sender, EventArgs e)
        {
            if (cantidad > 0)
            {
                cantidad = cantidad - 1;
                totalPrecio = cantidad * PrecioProducto;
                txtTotal.Text = string.Format("S/. {0:#,0.00}", totalPrecio);
                txtCantidad.Text = cantidad.ToString();
            }
            else
            {
                txtCantidad.Text = "0";
                txtTotal.Text = "S/. 0.00";
            }
        }

        private async void btnCarrito_Clicked(object sender, EventArgs e)
        {
            if (cantidad == 0)
            {
                await DisplayAlert("Advertencia", "La cantidad de productos que intentas pedir no es valida", "OK");
            }
            else
            {
                if (await DisplayAlert("Confirmación", "¿Estás seguro de que deseas agregar este producto a tu carrito de compras ? ", "Sí", "No"))
                {
                    var reg = new MiCarrito
                    {
                        NombreCar = lblNombre.Text,
                        ImagenCar = ImagenOK,
                        PrecioCar = precio,
                        Total = totalPrecio,
                        Cantidad = Convert.ToInt32(txtCantidad.Text),
                        IdUser_car = MiId
                    };
                    var respta = await App.contexto.ingresarCarrito(reg);
                    if (respta == 1)
                    {
                        //await DisplayAlert("Aviso", "se grabó los datos", "Aceptar");
                        await DisplayAlert("Confirmación", "El producto a sido agregado a tu carrito", "OK");
                        await Navigation.PopAsync();
                    }
                    else
                    {
                        await DisplayAlert("Aviso", "No se grabó los datos", "Aceptar");
                    }
                }
            }
        }

        private async void btnVolver_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Vistas.MenuLateral());
        }

        private void btnMegusta_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (btnMegusta.IsChecked)
            {
                btnMegusta.Color = Color.Red;
            }
            else
            {
                btnMegusta.Color = Color.White;
            }
        }

        private async void btnMiCarrito_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Vistas.Carrito());
        }
    }
}