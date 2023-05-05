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
    public partial class RegistrarUsuario : ContentPage
    {
        public RegistrarUsuario()
        {
            InitializeComponent();
        }

        private async void btnRegistrar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var reg = new Usuarios
                {
                    nom_usuario = txtNombre.Text,
                    ape_usuario = txtApellido.Text,
                    correo = txtEmail.Text,
                    contra = txtContra.Text,
                    sesion = 0
                };
                var respta = await App.contexto.ingresar(reg);
                if (respta == 1)
                {
                    //await DisplayAlert("Aviso", "se grabó los datos", "Aceptar");
                    await Navigation.PushAsync(new MainPage());
                }
                else
                {
                    await DisplayAlert("Aviso", "No se grabó los datos", "Aceptar");
                }
            }
            catch (Exception er)
            {
                await DisplayAlert("Aviso", er.Message, "Aceptar");
            }
            // Obtener la lista de usuarios y guardarla en una variable
            //List<Login> usuarios = Usuario.Usuarios;

            //// Verificar si ya existe un usuario con el mismo correo electrónico
            //bool existeUsuario = usuarios.Any(u => u.Email == txtEmail.Text);

            //if (existeUsuario)
            //{
            //    // Si ya existe un usuario con el mismo correo electrónico, mostrar un mensaje de error
            //    await DisplayAlert("Error", "Ya existe un usuario con este correo electrónico", "OK");
            //}
            //else
            //{
            //    // Si no existe un usuario con el mismo correo electrónico, agregar el nuevo usuario a la lista
            //    var nuevoUsuario = new Login
            //    {
            //        Nombres = txtNombre.Text,
            //        Apellidos = txtApellido.Text,
            //        Email = txtEmail.Text,
            //        Contra = txtContra.Text
            //    };
            //    usuarios.Add(nuevoUsuario);
            //    await Navigation.PushAsync(new Vistas.Home());
            //}
        }

        private async void btnMostrar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Vistas.MostrarUsuario());
        }
    }
}