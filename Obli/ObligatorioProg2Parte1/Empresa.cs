using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObligatorioProg2Parte1
{
    class Empresa
    {
        private List<Reparacion> listaReparaciones;
        private List<Mecanico> listaMecanicos;        
        private List<MaterialImportado> listaMaterialesImportados;
        private List<MaterialNacional> listaMaterialesNacionales;
        private List<Embarcacion> listaEmbarcacionesFabricadas;

        public Empresa()
        {
            listaReparaciones = new List<Reparacion>();
            listaMecanicos = new List<Mecanico>();
            listaMaterialesImportados = new List<MaterialImportado>();
            listaMaterialesNacionales = new List<MaterialNacional>();
            listaEmbarcacionesFabricadas = new List<Embarcacion>();
        }

        public void registrarMecanicoEnEmpresa(string unNombre, string unTelefono, Direccion unaDireccionResidencia, int unValorJornal, int unNumeroRegistro, bool seCapacitoExtra)
        {
            Mecanico unMecanico = new Mecanico(unNombre, unTelefono, unaDireccionResidencia, unValorJornal, unNumeroRegistro, seCapacitoExtra);
            listaMecanicos.Add(unMecanico);
        }

        public void registrarNuevaEmbarcacionConstruida(string unNombre, DateTime unaFechaConstruccion, int unTipoMotor)
        {
            Embarcacion unaEmbarcacion = new Embarcacion(unNombre, unaFechaConstruccion, unTipoMotor);
            listaEmbarcacionesFabricadas.Add(unaEmbarcacion);
        }

        public void ingresarReparacionDeEmbarcacion(DateTime unaFechaIngreso, DateTime unaFechaPromesa, Embarcacion unaEmbarcacion)
        {
            Reparacion unaReparacion = new Reparacion(unaFechaIngreso, unaFechaPromesa, unaEmbarcacion);
            listaReparaciones.Add(unaReparacion);
        }

        //Esto va aca? No saco muy bien donde debería ir la creación de un objeto dirección, no me parece que le competa mucho a la empresa hacerlo. Capaz que ponerlo en el program de 1?
        public Direccion crearNuevaDireccion(string unaCalle, string unNumeroPuerta, string unaCiudad)
        {
            Direccion unaDireccion = new Direccion(unaCalle, unNumeroPuerta, unaCiudad);

            return unaDireccion;
        }

        //Se recorre la lista de mecanicos de la empresa con un while y se buscan los mecanicos que tengan su valor 'RealizoCapacitacion' en falso. Si hay una coincidencia
        //en la busqueda, se agrega ese objeto Mecanico a una lista que se devuelve al terminar el recorrido.
        public List<Mecanico> devolverListaDeMecanicosSinCapacitacionExtra()
        {
            List<Mecanico> listaMecanicosSinCapacitacionExtra = new List<Mecanico>();
            int index = 0;
            while(index < listaMecanicos.Count())
            {
                if(!listaMecanicos[index].RealizoCapacitacion)
                {
                    listaMecanicosSinCapacitacionExtra.Add(listaMecanicos[index]);
                }
            }
            return listaMecanicosSinCapacitacionExtra;
        }

        //Se recorre la lista de mecanicos y se revisa el numero de cada objeto mecánico contra un valor int ingresado. Si hay una coincidencia en la busqueda se sale del while
        //para acortar el tiempo gracias a la condición del booleano y se devuelve el valor 'true'. Si no hay ninguna coincidencia se devuelve el valor 'false' 
        //(el numero identificador no estaba en la lista). 
        public bool mecanicoExiste(int numeroRegistroMecanico)
        {
            int index = 0;
            bool seEncontro = false;
            while (index < listaMecanicos.Count() && seEncontro == false)
            {
                if(listaMecanicos[index].NumeroRegistro == numeroRegistroMecanico)
                {
                    seEncontro = true;
                }               
            }
            return seEncontro;
        }

        public bool nombreEmbarcacionExiste(string nombreEmbarcacion)
        {
            int index = 0;
            bool existe = false;
            while(index < listaEmbarcacionesFabricadas.Count() && existe == false)
            {
                if(listaEmbarcacionesFabricadas[index].Nombre == nombreEmbarcacion)
                {                    
                    existe = true;
                }
            }
            return existe;
        }






    }
}
