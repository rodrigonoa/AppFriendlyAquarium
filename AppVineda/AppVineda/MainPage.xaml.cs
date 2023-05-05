using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Newtonsoft.Json;
using AppVineda.Modelos;
using System.Net.Http;
using System.Net;
using SQLite;

namespace AppVineda
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }


        private async void Button_Clicked(object sender, EventArgs e)
        {
            string Correo = txtEmail.Text;
            string Contra = txtContra.Text;

            string dbPath = App.contexto.cnx.DatabasePath;
            using (SQLiteConnection conn = new SQLiteConnection(dbPath))
            {
                conn.CreateTable<Usuarios>();
                var user = conn.Table<Usuarios>().FirstOrDefault(u => u.correo.ToLower() == Correo.ToLower() && u.contra == Contra);
                if (user != null)
                {
                    user.sesion = 1;
                    var nreg = await App.contexto.modificar(user);
                    if (nreg == 1)
                    {
                        await DisplayAlert("AVISO", "Inicio de sesión exitoso", "OK");
                        await Navigation.PushAsync(new Vistas.MenuLateral());
                    }
                }
                else
                {
                    await DisplayAlert("Error", "Inicio de sesión fallido", "OK");
                }
            }
        }

        private async void btnRegister_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Vistas.RegistrarUsuario());
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        private async void btnMenu_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Vistas.MenuLateral());
        }
    }
}
