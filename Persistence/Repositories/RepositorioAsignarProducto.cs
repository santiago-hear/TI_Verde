using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Domain.Producto;
using Domain.Usuario;
using Domain.Taller;
using System.Linq;
using Domain.Donacion;

namespace Persistence.Repositories
{
    public class RepositorioAsignarProducto : IRepositorioAsignarProducto
    {
        //readonly string pathProductosEnVenta = @"..\Persistence\Data\ProductosEnVenta.json";
        readonly string pathInstituciones = @"..\Persistence\Data\Instituciones.json";
        readonly string pathTalleres = @"..\Persistence\Data\Talleres.json";
        //readonly string pathDestrucciones = @"..\Persistence\Data\Destrucciones.json";

        private List<Producto> productos;
        private List<Taller> talleres;
        private List<Institucion> instituciones;

        public void AsignarATaller(Producto p, Taller t)
        {
            string talleresString = File.ReadAllText(pathTalleres);
            talleres = System.Text.Json.JsonSerializer.Deserialize<List<Taller>>(talleresString);
            foreach (Taller taller in talleres)
            {
                if (taller.Id == t.Id)
                {
                    taller.Asignaciones.Add(p);
                }
            }
            talleresString = System.Text.Json.JsonSerializer.Serialize(talleres);
            File.WriteAllText(pathTalleres, talleresString);
        }

        public bool GetProductoEnVenta(int id)
        {
            //List<Producto> productos;
            //string productosString = File.ReadAllText(pathProductosEnVenta);
            //productos = System.Text.Json.JsonSerializer.Deserialize<List<Producto>>(productosString);
            //Producto producto = productos.FirstOrDefault(p => p.Id == id);

            //if (producto != null) {
            //    throw new ProductoEnVentaException("El producto con id: " + id + " ya está en venta");
            //}
            return false;
        }

        public void PonerEnVenta(Producto producto)
        {
            //List<Producto> productos;
            //string productosString = File.ReadAllText(pathProductosEnVenta);
            //productos = System.Text.Json.JsonSerializer.Deserialize<List<Producto>>(productosString);
            //productos.Add(producto);
            //string jsonString = System.Text.Json.JsonSerializer.Serialize(productos);
            //File.WriteAllText(pathProductosEnVenta, jsonString);
        }
        public List<Producto> GetProductosEnVenta()
        {
            //List<Producto> productos;
            //string productosString = File.ReadAllText(pathProductosEnVenta);
            //productos = System.Text.Json.JsonSerializer.Deserialize<List<Producto>>(productosString);

            return productos;
        }

        public void AsignarAInstitucion(Donacion d, Institucion i)
        {
            List<Institucion> instituciones;
            string institucionesString = File.ReadAllText(pathInstituciones);
            instituciones = System.Text.Json.JsonSerializer.Deserialize<List<Institucion>>(institucionesString);

            foreach (Institucion inst in instituciones)
            {
                if (inst.Id == i.Id)
                {
                    inst.Recibidos.Add(d);
                }
            }

            institucionesString = System.Text.Json.JsonSerializer.Serialize(instituciones);
            File.WriteAllText(pathInstituciones, institucionesString);
        }

        public Institucion BuscarInstitucion(int Id)
        {
            List<Institucion> instituciones;
            string institucionesString = File.ReadAllText(pathInstituciones);
            instituciones = System.Text.Json.JsonSerializer.Deserialize<List<Institucion>>(institucionesString);
            Institucion institucion = instituciones.FirstOrDefault(p => p.Id == Id);

            if (institucion == null)
            {
                throw new AsignacionIncorrectaException("La institucion con id: " + Id + " no existe");
            }
            return institucion;
        }

        public Taller BuscarTaller(int Id)
        {
            List<Taller> talleres;
            string talleresString = File.ReadAllText(pathTalleres);
            talleres = System.Text.Json.JsonSerializer.Deserialize<List<Taller>>(talleresString);
            Taller taller = talleres.FirstOrDefault(p => p.Id == Id);

            if (taller == null)
            {
                throw new AsignacionIncorrectaException("El taller con id: " + Id + " no existe");
            }
            return taller;
        }

        public void RegistrarDestruccion(Producto p)
        {
            throw new NotImplementedException();
        }
        public List<Taller> getTalleres()
        {
            List<Taller> talleres;
            string talleresString = File.ReadAllText(pathTalleres);
            talleres = System.Text.Json.JsonSerializer.Deserialize<List<Taller>>(talleresString);

            return talleres;
        }

        public List<Institucion> getInstituciones()
        {
            List<Institucion> instituciones;
            string institucionesString = File.ReadAllText(pathInstituciones);
            instituciones = System.Text.Json.JsonSerializer.Deserialize<List<Institucion>>(institucionesString);

            return instituciones;
        }
    }
}
