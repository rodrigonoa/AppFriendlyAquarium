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
    public partial class Pago : ContentPage
    {
        Int32 IdUsers = 0;
        Int32 IdCarrito = 0;
        string FechayHora = "";
        public decimal PagoTotal { get; set; }
        public Pago()
        {
            InitializeComponent();

        }

        private void rbPaypal_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (rbPaypal.IsChecked == true)
            {
                frmPaypal.BackgroundColor = Color.LightSlateGray;
                frmVisa.BackgroundColor = Color.Transparent;
                frmPagos.IsVisible = true;
                frm2.IsVisible = true;
                frm1.IsVisible = false;
                imgPaypal.BackgroundColor = Color.Gray;
                imgVisa.BackgroundColor = Color.White;
            }
        }

        private void rbVisa_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (rbVisa.IsChecked == true)
            {
                frmVisa.BackgroundColor = Color.LightGray;
                frmPaypal.BackgroundColor = Color.Transparent;
                frmPagos.IsVisible = true;
                frm1.IsVisible = true;
                frm2.IsVisible = false;
                imgVisa.BackgroundColor = Color.Gray;
                imgPaypal.BackgroundColor = Color.White;
            }
        }

        private void btnAbierto_Clicked(object sender, EventArgs e)
        {
            btnCerrado.IsVisible = true;
            btnAbierto.IsVisible = false;
            txtContra.IsPassword = true;
        }

        private void btnCerrado_Clicked(object sender, EventArgs e)
        {
            btnAbierto.IsVisible = true;
            btnCerrado.IsVisible = false;
            txtContra.IsPassword = false;
        }

        private async void btnConfirmarPaypal_Clicked(object sender, EventArgs e)
        {
            if (txtCorreo.Text != null && txtContra.Text != null)
            {
                if (await DisplayAlert("Confirmación", "¿Confirmar pago?", "Sí", "No"))
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
                                    DateTime dateTime = DateTime.Now;
                                    FechayHora = dateTime.ToString("dd/MM/yyyy hh:mm:ss");

                                    foreach (var producto1 in productos)
                                    {
                                        var reg = new HistorialCompra
                                        {
                                            NombrePro = producto1.NombreCar,
                                            PrecioPro = producto1.PrecioCar,
                                            ImagenPro = producto1.ImagenCar,
                                            TotalPro = producto1.Total,
                                            CantidadPro = producto1.Cantidad,
                                            IdUser_Pro = producto1.IdUser_car,
                                            FechaHora = FechayHora
                                        };
                                        var respta = await App.contexto.ingresarHistorial(reg);
                                        await App.contexto.eliminarCarrito(producto1);
                                    }
                                    await DisplayAlert("Éxito", "Su compra se realizo con exito", "OK");
                                    await Navigation.PushAsync(new MenuLateral());
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                await DisplayAlert("Error", "Los campos estan vacios", "OK");
            }
        }

        private async void btnConfirmarVisa_Clicked(object sender, EventArgs e)
        {
            if (txtNumeroTarjeta.Text != null && txtFechaMessExpiracion.Text != null && txtFechaAñoExpiracion != null && txtEmail.Text != null)
            {
                if (await DisplayAlert("Confirmación", "¿Confirmar pago?", "Sí", "No"))
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
                                    DateTime dateTime = DateTime.Now;
                                    FechayHora = dateTime.ToString("dd/MM/yyyy hh:mm:ss");

                                    foreach (var producto1 in productos)
                                    {
                                        var reg = new HistorialCompra
                                        {
                                            NombrePro = producto1.NombreCar,
                                            PrecioPro = producto1.PrecioCar,
                                            ImagenPro = producto1.ImagenCar,
                                            TotalPro = producto1.Total,
                                            CantidadPro = producto1.Cantidad,
                                            IdUser_Pro = producto1.IdUser_car,
                                            FechaHora = FechayHora
                                        };
                                        var respta = await App.contexto.ingresarHistorial(reg);
                                        await App.contexto.eliminarCarrito(producto1);
                                    }
                                    await DisplayAlert("Éxito", "Su compra se realizo con exito", "OK");
                                    await Navigation.PushAsync(new MenuLateral());
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                await DisplayAlert("Error", "Complete los campos vacios", "OK");
            }
        }
    }
}