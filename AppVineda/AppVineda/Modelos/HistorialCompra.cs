using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace AppVineda.Modelos
{
    public class HistorialCompra
    {
        [AutoIncrement, PrimaryKey]
        public int IdPro { get; set; }
        [NotNull]
        public string NombrePro { get; set; }
        [NotNull]
        public decimal PrecioPro { get; set; }
        [NotNull]
        public string ImagenPro { get; set; }
        [NotNull]
        public decimal TotalPro { get; set; }
        [NotNull]
        public int CantidadPro { get; set; }
        [NotNull]
        public int IdUser_Pro { get; set; }
        [NotNull]
        public string FechaHora { get; set; }
    }
}
