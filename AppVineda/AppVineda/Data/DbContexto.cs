using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AppVineda.Modelos;
using SQLite;

namespace AppVineda.Data
{
    public class DbContexto
    {
        public readonly SQLiteAsyncConnection cnx;

        public DbContexto(string data)
        {
            cnx = new SQLiteAsyncConnection(data);
            cnx.CreateTableAsync<Usuarios>().Wait();
            cnx.CreateTableAsync<Misproductos>().Wait();
            cnx.CreateTableAsync<MiCarrito>().Wait();
            cnx.CreateTableAsync<HistorialCompra>().Wait();
        }

        public async Task<int> ingresar(Usuarios registro)
        {
            return await cnx.InsertAsync(registro);
        }
        public async Task<int> eliminar(Usuarios registro)
        {
            return await cnx.DeleteAsync(registro);
        }
        public async Task<List<Usuarios>> GetUsuarios()
        {
            return await cnx.Table<Usuarios>().ToListAsync();
        }
        public async Task<int> modificar(Usuarios registro)
        {
            return await cnx.UpdateAsync(registro);

        }

        //Para mi tabla misproductos

        public async Task<int> ingresarProductos(Misproductos producto)
        {
            return await cnx.InsertAsync(producto);
        }
        public async Task<int> eliminarProductos(Misproductos producto)
        {
            return await cnx.DeleteAsync(producto);
        }
        public async Task<List<Misproductos>> GetProductos()
        {
            return await cnx.Table<Misproductos>().ToListAsync();
        }
        public async Task<int> modificarProductos(Misproductos producto)
        {
            return await cnx.UpdateAsync(producto);
        }
        //
        public async Task<int> ingresarCarrito(MiCarrito carro)
        {
            return await cnx.InsertAsync(carro);
        }
        public async Task<int> eliminarCarrito(MiCarrito carro)
        {
            return await cnx.DeleteAsync(carro);
        }
        public async Task<List<MiCarrito>> GetCarrito()
        {
            return await cnx.Table<MiCarrito>().ToListAsync();
        }
        public async Task<int> modificarCarrito(MiCarrito carro)
        {
            return await cnx.UpdateAsync(carro);
        }
        //Historial de compra
        public async Task<int> ingresarHistorial(HistorialCompra compra)
        {
            return await cnx.InsertAsync(compra);
        }
        public async Task<int> eliminarHistorial(HistorialCompra compra)
        {
            return await cnx.DeleteAsync(compra);
        }
        public async Task<List<HistorialCompra>> GetHistorial()
        {
            return await cnx.Table<HistorialCompra>().ToListAsync();
        }
        public async Task<int> modificarHistorial(HistorialCompra compra)
        {
            return await cnx.UpdateAsync(compra);
        }
    }
}
