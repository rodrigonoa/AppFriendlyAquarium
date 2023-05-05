using AppVineda.Data;
using System;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppVineda
{
    public partial class App : Application
    {
        public static MasterDetailPage MAsterDet { get; set; }
        public static DbContexto contexto { get; set; }
        public App()
        {
            InitializeComponent();

            crearBD();
            //Navigationpage es para navegar entre páginas de contenido
            MainPage = new NavigationPage(new MainPage())
            {
                BarBackgroundColor = Color.FromHex("#00144D")
            };
        }
        private void crearBD()
        {
            //la BD se crea en el proyecto
            var carpeta = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var data = System.IO.Path.Combine(carpeta, "DB_Prueba1.db3");
            SQLitePCL.Batteries_V2.Init();
            contexto = new DbContexto(data);
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
