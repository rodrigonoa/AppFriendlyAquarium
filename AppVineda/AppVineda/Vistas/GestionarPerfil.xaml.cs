using AppVineda.Modelos;
using Plugin.Media;
using Plugin.Media.Abstractions;
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
    public partial class GestionarPerfil : ContentPage
    {
        private MediaFile photo;
        int id = 0;
        string contraseña = "";
        int sesion_user = 0;
        private bool _fotoSeleccionada = false;

        string foto_user="";
        public GestionarPerfil()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtContra.Text = "";
            txtConfirContra.Text = "";
            if (!_fotoSeleccionada) // Si la foto no ha sido seleccionada
            {
                Mostrar(); // Ejecute el método mostrar
            }
            _fotoSeleccionada = false;
        }
        private async void Mostrar()
        {
            var reg_contac = await App.contexto.GetUsuarios();
            if (reg_contac.Count > 0)
            {
                var usuario = reg_contac.FirstOrDefault(u => u.sesion == 1);
                if (usuario != null)
                {
                    if (usuario.foto_usuario == null)
                    {
                        imgPerfil.Source = "sinperfil.png";
                        txtNombre.Placeholder = usuario.nom_usuario;
                        txtApellido.Placeholder = usuario.ape_usuario;
                        txtCorreo.Text = usuario.correo;
                        contraseña = usuario.contra;
                        id = usuario.id_usuario;
                        sesion_user = usuario.sesion;
                    }
                    else
                    {
                        imgPerfil.Source = usuario.foto_usuario;
                        txtNombre.Placeholder = usuario.nom_usuario;
                        txtApellido.Placeholder = usuario.ape_usuario;
                        txtCorreo.Text = usuario.correo;
                        contraseña = usuario.contra;
                        id = usuario.id_usuario;
                        sesion_user = usuario.sesion;
                    }
                }
            }
        }

        private async void btnSeleccionar_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("Error", "No se pueden seleccionar fotos", "Aceptar");
                return;
            }

            photo = await CrossMedia.Current.PickPhotoAsync();

            if (photo != null)
            {
                imgPerfil.Source = ImageSource.FromStream(() => photo.GetStream());
                _fotoSeleccionada = true;

                var path = photo.Path;
                foto_user = path;
            }
        }

        private async void btnActualizar_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (txtContra.Text != txtConfirContra.Text)
                {
                    await DisplayAlert("Error", "Las contraseñas ingresadas no son iguales", "Aceptar");
                    return;
                }

                var reg = new Usuarios
                {
                    id_usuario = id,
                    nom_usuario = string.IsNullOrEmpty(txtNombre.Text) ? txtNombre.Placeholder : txtNombre.Text,
                    ape_usuario = string.IsNullOrEmpty(txtApellido.Text) ? txtApellido.Placeholder : txtApellido.Text,
                    correo = txtCorreo.Text,
                    contra = string.IsNullOrEmpty(txtContra.Text) ? contraseña : txtContra.Text,
                    sesion = sesion_user,
                    foto_usuario = foto_user
                };
                //Reg se envía al contexto llamando al método insertar
                var nreg = await App.contexto.modificar(reg);
                if (nreg == 1)
                {
                    await DisplayAlert("AVISO", "PERFIL ACTUALIZADO", "OK");
                    OnAppearing();
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Aceptar");
            }

        }
    }
}