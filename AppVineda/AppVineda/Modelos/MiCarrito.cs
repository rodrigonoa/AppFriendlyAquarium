using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace AppVineda.Modelos
{
    public class MiCarrito
    {
        [AutoIncrement, PrimaryKey]
        public int IdCar { get; set; }
        [NotNull]
        public string NombreCar { get; set; }
        [NotNull]
        public decimal PrecioCar { get; set; }
        [NotNull]
        public string ImagenCar { get; set; }
        [NotNull]
        public decimal Total { get; set; }
        [NotNull]
        public int Cantidad { get; set; }
        [NotNull]
        public int IdUser_car { get; set; }

    }
}
