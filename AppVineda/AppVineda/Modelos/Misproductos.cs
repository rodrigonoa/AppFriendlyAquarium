using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace AppVineda.Modelos
{
    public class Misproductos
    {
        [AutoIncrement,PrimaryKey]
        public int Id { get; set; }
        [NotNull]
        public string Nombre { get; set; }
        [NotNull]
        public decimal Precio { get; set; }
        [NotNull]
        public string Imagen { get; set; }
        [NotNull]
        public int category { get; set; }
        //Peces = 1
        //Limpieza = 2
        //Accesorios = 3
        //Alimento = 4
        //Acuarios = 5

        [NotNull]
        public string Descripcion { get; set; }
    }
}
