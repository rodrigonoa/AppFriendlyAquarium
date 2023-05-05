using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace AppVineda.Modelos
{
    public class Usuarios
    {
        [PrimaryKey, AutoIncrement]
        public int id_usuario { get; set; }
        [MaxLength(25),NotNull]
        public String nom_usuario { get; set; }
        [MaxLength(25),NotNull]
        public String ape_usuario { get; set; }
        [Unique , MaxLength(35)]
        public String correo { get; set; }
        [MaxLength(35),NotNull]
        public String contra { get; set; }
        [MaxLength(1)]
        public int sesion { get; set; }
        public string foto_usuario { get; set; }
    }
}