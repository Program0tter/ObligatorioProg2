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

        //Metodo que recibe todos los datos necesarios para crear un objeto clase Mecanico, lo crea y lo agrega a la lista correspondiente.
        public void registrarMecanicoEnEmpresa(string unNombre, string unTelefono, Direccion unaDireccionResidencia, int unValorJornal, int unNumeroRegistro, bool seCapacitoExtra)
        {
            Mecanico unMecanico = new Mecanico(unNombre, unTelefono, unaDireccionResidencia, unValorJornal, unNumeroRegistro, seCapacitoExtra);
            listaMecanicos.Add(unMecanico);
        }

        //Metodo que recibe todos los datos necesarios para crear un objeto clase Embarcacion, lo crea y lo agrega a la lista correspondiente.
        public void registrarNuevaEmbarcacionConstruida(string unNombre, DateTime unaFechaConstruccion, int unTipoMotor)
        {
            Embarcacion unaEmbarcacion = new Embarcacion(unNombre, unaFechaConstruccion, unTipoMotor);
            listaEmbarcacionesFabricadas.Add(unaEmbarcacion);
        }

        //Metodo que recibe todos los datos necesarios para crear un objeto clase Reparacion, lo crea y lo agrega a la lista correspondiente.
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

        //Metodo en el cual se recorre la lista de mecanicos de la empresa con un while y se buscan los mecanicos que tengan su valor 'RealizoCapacitacion' en falso. Si hay una coincidencia
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
                index++;
            }
            return listaMecanicosSinCapacitacionExtra;
        }

        //Metodo en el cual se recorre la lista de mecanicos y se revisa el numero de cada objeto mecánico contra un valor int ingresado. Si hay una coincidencia en la busqueda se sale del while
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
                index++;         
            }

            return seEncontro;
        }

        //Metodo que recorre la lista de embarcaciones comparando el atributo int ingresado contra el atributo CodigoIdentificador de cada objeto Embarcacion. Si hay una 
        //coincidencia devuelve un booleano 'verdadero', sino devuelve falso.
        public bool codigoEmbarcacionExiste(int codigoEmbarcacion)
        {
            int index = 0;
            bool existe = false;
            while (index < listaEmbarcacionesFabricadas.Count() && existe == false)
            {
                if(listaEmbarcacionesFabricadas[index].CodigoIdentificador == codigoEmbarcacion)
                {
                    existe = true;
                }
                index++;
            }
            return existe;
        }

        //Metodo que recorre la lista de embarcaciones comparando el atributo int ingresado contra el atributo CodigoIdentificador de cada objeto Embarcacion.
        //Cuando se encuentra una coincidencia, se guarda el objeto cuyo CodigoIdentificador es igual al int codigo y se devuelve. No se devuelve 'null' porque se realiza
        //una comprobación previa usando otro metodo para asegurarse de que el codigo es valido.
        public Embarcacion devolverEmbarcacionPorCodigoIdentificador(int codigo)
        {
            Embarcacion unaEmbarcacion = null;
            int index = 0;
            bool seEncontro = false;
            while (seEncontro == false && index < listaEmbarcacionesFabricadas.Count())
            {
                if(listaEmbarcacionesFabricadas[index].CodigoIdentificador == codigo)
                {
                    unaEmbarcacion = listaEmbarcacionesFabricadas[index];
                    seEncontro = true;
                }
                index++;
            }
            return unaEmbarcacion;
        }




    }
}
