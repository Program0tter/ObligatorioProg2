using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObligatorioProg2Parte1
{
    class Program
    {
        static Empresa unaEmpresa = new Empresa();
        static void Main(string[] args)
        {
            Embarcacion.UltimoNumeroCodigo = 100;

        }

        static void registrarEmbarcacionEnSistema()
        {
            Console.WriteLine("Ingrese nombre de la embarcación");
            string nombre = Console.ReadLine().Trim();
            if(nombre == "")
            {
                Console.WriteLine("ERROR: Debe ingresar un nombre");
            }else if(unaEmpresa.nombreEmbarcacionExiste(nombre))
            {
                Console.WriteLine("ERROR: Ya hay una embarcación con ese nombre en la base de datos.");
            }
            else
            {
                Console.WriteLine("Ingrese la fecha de construcción:")
                //Quedo de ver si hay que usar DateTime o string para las fechas.
            }
        }
        
        static void regitrarMecanicoEnSistema()
        {
            Console.WriteLine("Ingrese el numero de registro del mecánico:");
            int numeroRegistroMecanico = Convert.ToInt32(Console.ReadLine());
            if (unaEmpresa.mecanicoExiste(numeroRegistroMecanico))
            {
                Console.WriteLine("ERROR: Ya existe este código dentro de la base de datos. Debe ingresar un nuevo código.");
            }
            else
            {
                Console.WriteLine("Ingrese un nombre:");
                string nombreMecanico = Console.ReadLine().Trim();
                if(nombreMecanico == "")
                {
                    Console.WriteLine("ERROR: Debe ingresar el nombre del mecánico.");
                }
                else
                {
                    Console.WriteLine("Ingrese la calle de residencia:");
                    string calle = Console.ReadLine().Trim();
                    if (calle == "")
                    {
                        Console.WriteLine("ERROR: Debe ingresar una calle.");
                    }
                    else
                    {
                        Console.WriteLine("Ingrese el numero de puerta de la residencia.");
                        string numeroPuerta = Console.ReadLine().Trim();
                        if(numeroPuerta == "")
                        {
                            Console.WriteLine("ERROR: Debe ingresar un numero de puerta.");
                        }
                        else
                        {
                            Console.WriteLine("Ingrese la ciudad de residencia");
                            string ciudad = Console.ReadLine().Trim();
                            if (ciudad == "")
                            {
                                Console.WriteLine("ERROR: Debe ingresar una ciudad.");
                            }
                            else
                            {
                                Console.WriteLine("Ingrese un numero de contacto para el mecánico.");
                                string telefono = Console.ReadLine().Trim();
                                if (telefono == "")
                                {
                                    Console.WriteLine("ERROR: Debe ingresar un numero de telefono.");
                                }
                                else
                                {
                                    Console.WriteLine("Ingrese el valor del jornal del mecánico:");
                                    int valorJornal = Convert.ToInt32(Console.ReadLine());
                                    if(valorJornal <= 0)
                                    {
                                        Console.WriteLine("ERROR: Debe ingresar un valor mayor a 0 para el jornal del mecánico.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("¿El mecánico ha realizado capacitación extra?\n1 - Si.\n2 - No.");
                                        int opcionElegida = Convert.ToInt32(Console.ReadLine());
                                        bool seCapacito = false;
                                        if(opcionElegida < 0 || opcionElegida > 2)
                                        {
                                            Console.WriteLine("ERROR: Debe elegír una opción válida.");
                                        }
                                        else
                                        {
                                            if (opcionElegida == 1)
                                            {
                                                seCapacito = true;
                                            }
                                            Direccion unaDireccion = unaEmpresa.crearNuevaDireccion(calle, numeroPuerta, ciudad);
                                            unaEmpresa.registrarMecanicoEnEmpresa(nombreMecanico, telefono, unaDireccion, valorJornal, numeroRegistroMecanico, seCapacito);
                                            Console.WriteLine("Mecanico agregado al sistema exitosamente.");
                                        }
                                    }
                                }
                            }
                        }
                   

                    }
                }
            }
             
        }
    }
}
