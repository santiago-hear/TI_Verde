using System;
using System.Collections.Generic;
using System.IO;
using Domain.Producto;
using Domain.Usuario;
using System.Linq;
using Domain.Donacion;

namespace Persistence.Repositories
{
    public class RepositorioInstituciones : IRepositorioInstituciones
    {
        //readonly string pathProductosEnVenta = @"..\Persistence\Data\ProductosEnVenta.json";
        //readonly string pathTalleres = @"..\Persistence\Data\Talleres.json";
        //readonly string pathDestrucciones = @"..\Persistence\Data\Destrucciones.json";
        readonly string pathInstituciones = @"..\Persistence\Data\Instituciones.json";
        readonly string institucionesString;
        string jsonString;
        private List<Institucion> instituciones;

        public RepositorioInstituciones()
        {
            institucionesString = File.ReadAllText(pathInstituciones);
        }

        public List<Institucion> GetInstituciones()
        {
            instituciones = System.Text.Json.JsonSerializer.Deserialize<List<Institucion>>(institucionesString);
            return instituciones;
        }

        public Institucion BuscarInstitucion(int Id)
        {
            instituciones = System.Text.Json.JsonSerializer.Deserialize<List<Institucion>>(institucionesString);
            Institucion institucion = instituciones.FirstOrDefault(p => p.Id == Id);
            if (institucion == null)
            {
                throw new AsignacionIncorrectaException("La institucion con id: " + Id + " no existe");
            }
            return institucion;
        }

        public void RegistrarInstitucion(Institucion institucion)
        {
            instituciones = System.Text.Json.JsonSerializer.Deserialize<List<Institucion>>(institucionesString);
            instituciones.Add(institucion);
            jsonString = System.Text.Json.JsonSerializer.Serialize(instituciones);
            File.WriteAllText(pathInstituciones, jsonString);
        }

        public void EliminarInstitucion(int Id)
        {
            throw new NotImplementedException();
        }

        public void DonarProducto(Donacion donacion, Institucion institucion)
        {
            instituciones = System.Text.Json.JsonSerializer.Deserialize<List<Institucion>>(institucionesString);
            foreach (Institucion inst in instituciones)
            {
                if (inst.Id == institucion.Id)
                {
                    inst.Recibidos.Add(donacion);
                }
            }
            jsonString = System.Text.Json.JsonSerializer.Serialize(instituciones);
            File.WriteAllText(pathInstituciones, jsonString);
        }

        //public void RegistrarDestruccion(Producto p)
        //{
        //    throw new NotImplementedException();
        //}

        //public bool GetProductoEnVenta(int id)
        //{
        //    List<Producto> productos;
        //    string productosString = File.ReadAllText(pathProductosEnVenta);
        //    productos = System.Text.Json.JsonSerializer.Deserialize<List<Producto>>(productosString);
        //    Producto producto = productos.FirstOrDefault(p => p.Id == id);

        //    if (producto != null)
        //    {
        //        throw new ProductoEnVentaException("El producto con id: " + id + " ya está en venta");
        //    }
        //    return false;
        //}

        //public void PonerEnVenta(Producto producto)
        //{
        //    List<Producto> productos;
        //    string productosString = File.ReadAllText(pathProductosEnVenta);
        //    productos = System.Text.Json.JsonSerializer.Deserialize<List<Producto>>(productosString);
        //    productos.Add(producto);
        //    string jsonString = System.Text.Json.JsonSerializer.Serialize(productos);
        //    File.WriteAllText(pathProductosEnVenta, jsonString);
        //}

        //public List<Producto> GetProductosEnVenta()
        //{
        //    List<Producto> productos;
        //    string productosString = File.ReadAllText(pathProductosEnVenta);
        //    productos = System.Text.Json.JsonSerializer.Deserialize<List<Producto>>(productosString);

        //    return productos;
        //}
    }
}
