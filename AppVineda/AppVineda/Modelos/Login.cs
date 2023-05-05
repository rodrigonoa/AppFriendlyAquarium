using System;
using System.Collections.Generic;
using System.Text;

namespace AppVineda.Modelos
{
    public class Login
    {
        public string Email { get; set; }
        public string Contra { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
    }
    public class Usuario
    {
        public static List<Login> Usuarios = new List<Login>
        {
            new Login { Email = "rodrigo@gmail.com", Contra = "123456", Nombres="Rodrigo", Apellidos="Noa"}
        };
    }
}
