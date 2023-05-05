using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppVineda.Vistas.MenuBarra
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Ayuda : ContentPage
    {
        public Ayuda()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            txtOpcion.Text = "";
            frmCompletar.IsVisible = false;
        }

        private async void btnopciones_Clicked(object sender, EventArgs e)
        {
            string action = await DisplayActionSheet("Seleccione su opción?", "Cancel", null, "Comentario", "Reclamo", "Consulta");
            if (action == "Comentario")
            {
                txtOpcion.Placeholder = "Escriba su comentario aquí";
                frmCompletar.IsVisible = true;
            }
            else
            {
                if (action == "Reclamo")
                {
                    txtOpcion.Placeholder = "Escriba su reclamo aquí";
                    frmCompletar.IsVisible = true;
                }
                else
                {
                    if (action == "Consulta")
                    {
                        txtOpcion.Placeholder = "Escriba su consulta aquí";
                        frmCompletar.IsVisible = true;
                    }
                }                  
            }
        }

        private async void btnEnviar_Clicked(object sender, EventArgs e)
        {
            if (await DisplayAlert("Confirmación", "¿Desea enviar? ", "Sí", "No"))
            {
                OnAppearing();
            }
        }
    }
}