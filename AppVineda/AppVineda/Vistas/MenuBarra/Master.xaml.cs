using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppVineda.Modelos;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppVineda.Vistas.MenuBarra
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Master : ContentPage
    {
        public Master()
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
                    txtNombre.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase("Bienvenid@ "+usuario.nom_usuario+" " + usuario.ape_usuario);
                    imgPerfil.Source = usuario.foto_usuario;
                }
            }
        }

        private async void btnSalir_Clicked(object sender, EventArgs e)
        {
            string dbPath = App.contexto.cnx.DatabasePath;
            using (SQLiteConnection conn = new SQLiteConnection(dbPath))
            {
                conn.CreateTable<Usuarios>();
                var user = conn.Table<Usuarios>().FirstOrDefault(u => u.sesion == 1);
                if (user != null)
                {
                    user.sesion = 0;
                    var nreg = await App.contexto.modificar(user);
                    if (nreg == 1)
                    {
                        await DisplayAlert("Success", "Su sesión termino", "OK");
                        await Navigation.PushAsync(new MainPage());
                    }
                }
            }
        }

        private void btnOpciones_Clicked(object sender, EventArgs e)
        {
            if (options.IsVisible)
            {
                options.IsVisible = false;
                optionsRow.Height = 0;
                btnCategoria.BackgroundColor = Color.FromHex("#00355B");
            }
            else
            {
                options.IsVisible = true;
                optionsRow.Height = GridLength.Auto;
                btnCategoria.BackgroundColor = Color.FromHex("#FF3149");
            }
        }

        private async void btnConfig_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Vistas.GestionarPerfil());
        }

        private async void btnHistorial_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Vistas.MenuBarra.HistorialCompras());
        }

        private async void btnTienda_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Vistas.MenuBarra.TiendaFisica());
        }

        private async void btnAcercaNosotros_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Vistas.MenuBarra.AcercaNosotros());
        }

        private async void btnAyudda_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Vistas.MenuBarra.Ayuda());
        }

        private async void btnOpcion1_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Vistas.MenuBarra.Categorias.Peces());
        }

        private async void btnOpcion2_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Vistas.MenuBarra.Categorias.Alimento());
        }

        private async void btnOpcion3_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Vistas.MenuBarra.Categorias.Peceras());
        }

        private async void btnOpcion4_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Vistas.MenuBarra.Categorias.Accesorios());
        }

        private async void btnOpcion5_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Vistas.MenuBarra.Categorias.Limpieza());
        }
    }
}