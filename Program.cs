using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio_claseauto
{
    class Program
    {
        //ajustes
        //***Ejercicio 2 (Restaurante)***
        //--Hacer un menu de restaurante(Desayuno, comida y cena). Hecho
        //--Hacer pedidos a los comensales sin saber cuantos son. Hecho
        //--Ordenar conforme al menu que ya se hizo prebiamente. Falta checar bien las horas
        //--Al finalizar mostrar que pidio cada uno de los comensales. Medio punto

        //Reglas de negocio.
        //--Ningun comensal puede pedir si no es la hora correcta. Checar validaciones
        //Ejemplo
        //Desayuno 8 - 11 am
        //Comida 12 - 5 pm
        //Cena 6 - 10 pm
        //La fecha se debe de calcular conforme a la hora del dia actual.

        //Si son las 12 no puede pedir desayuno.
        static void Main(string[] args)
        {
            List<string> orden = new List<string>();
            List<int> numeroorden = new List<int>();

            //DateTimeOffset horadesayunos = new DateTimeOffset(2023, 1, 1, 8, 1, 0, TimeSpan.FromHours(-8));
            //DateTimeOffset horadecomida = new DateTimeOffset(2023, 1, 1, 12, 1, 0, TimeSpan.FromHours(-8));
            //DateTimeOffset horacena = new DateTimeOffset(2023, 1, 1, 18, 0, 0, TimeSpan.FromHours(-8));
            //DateTimeOffset horacierre = new DateTimeOffset(2023, 1, 1, 23, 30, 0, TimeSpan.FromHours(-8));
            //DateTimeOffset horaapertura = new DateTimeOffset(2023, 1, 1, 8, 0, 0, TimeSpan.FromHours(8));
            DateTime horariodesayuno = DateTime.Today.AddHours(8);
            DateTime horariocomida = DateTime.Today.AddHours(12);
            DateTime horariocena = DateTime.Today.AddHours(18);
            DateTime horariodeapertura = DateTime.Today.AddHours(7);
            DateTime horariocierre = DateTime.Today.AddHours(23);
            DateTime hora = DateTime.Now;

            string[] menudesayuno =
           {
                "Hot cakes", "huevos con chorizo", "chilaquiles rojos", "chilaquiles verdes", "huevos revueltos", "huevos a la mexicana", "platanos fritos", "chocomilk", "licuado de platano", "cafe"
            };

            int[] preciosdesayuno =
                { 80, 95, 85, 85, 90, 105, 80, 30, 25, 15};

            var menucomida = new string[]
            {
                "tacos de carne asada", "consome", "gorditas de cerdo", "carne asada", "tacos dorados", "empanadas de quesillo", "empanadas de quesillo con carne asada"
            };

            int[] precioscomida =
                {10, 35, 15, 85, 12, 10, 15};

            var menucena = new string[]
            {
                "hamburguesa", "quesadilla con carne asada", "pizza de peperoni", "alitas BBQ",
            };

            int[] precioscena =
                { 88, 45, 80, 125};

            if (horariodesayuno < horariodeapertura & horariodesayuno > horariocomida)
            {
                Console.WriteLine("este es nuestro menú de desayunos");
                for (int i = 0; i < menudesayuno.Length; i++)
                {
                    Console.WriteLine("{0}.{1} - {2}", i + 1, menudesayuno[i], "$" + preciosdesayuno[i]);
                }

                if (horariocomida > horariodesayuno & horariocomida > horariocena)
                {
                    Console.WriteLine("Este es nuestro menú de comidas");
                    for (int j = 0; j < menucomida.Length; j++)
                    {
                        Console.WriteLine("{0}.{1} - {2}", j + 1, menucomida[j], "$" + precioscomida[j]);
                    }

                    bool valor = true;
                    while (valor == true)
                    {
                        Console.WriteLine("¿Que desea ordenar? Ingrese 'fin' para terminar su pedido");
                        string validacion = Console.ReadLine();

                        if (validacion == "fin")
                        {
                            valor = false;
                        }
                        else
                        {
                            int indice = Array.IndexOf(menucena, valor);
                            if (indice != -1)
                            {
                                Console.WriteLine("¿Cuantos desea ordenar?");
                                string cantidad = Console.ReadLine();
                                int numero = int.Parse(cantidad);
                                orden.Add(validacion);
                                numeroorden.Add(precioscena[indice] * numero);
                                Console.WriteLine("Ha agregado {0} {1} por un total de: {2}", numero, validacion, "$" + precioscena[indice] * numero);
                            }
                            else
                            {
                                Console.WriteLine("Has ingresado un platillo fuera del menú");
                            }
                        }
                    }
                    Console.Clear();
                    Console.WriteLine("¿ES correcto su pedido?");
                    for (int p = 0; p < orden.Count; p++)
                    {
                        Console.WriteLine("{0} - {1}", orden[p], "$", numeroorden[p]);
                    }
                }
            }

            if (horariocena > horariocomida & horariocena < horariocierre)
            {
                Console.WriteLine("este es nuestro menú de cena");
                for (int k = 0; k < menucena.Length; k++)
                {
                    Console.WriteLine("{0}.{1} - {2}", k + 1, menucena[k], "$" + precioscena[k]);
                }

                bool valor = true;
                while (valor == true)
                {
                    Console.WriteLine("¿Que desea ordenar? Ingrese 'fin' para terminar su pedido");
                    string validacion = Console.ReadLine().ToLower();

                    if (validacion == "fin")
                    {
                        valor = false;
                    }
                    else
                    {
                        int indice = Array.FindIndex(menucena, q => q == validacion);
                        if (indice != -1)
                        {
                            Console.WriteLine("¿Cuantos desea ordenar?");
                            string cantidad = Console.ReadLine();
                            int numero = int.Parse(cantidad);
                            orden.Add(validacion);
                            numeroorden.Add(precioscena[indice] * numero);
                            Console.WriteLine("Ha agregado {0} {1} por un total de: {2}", numero, validacion, "$" + precioscena[indice] * numero);
                        }
                        else
                        {
                            Console.WriteLine("Has ingresado un platillo fuera del menú");
                        }
                    }
                }
                Console.Clear();

                Console.WriteLine("¿Desea pagar en efectivo o con tarjeta?");
                string forma = Console.ReadLine();

                if (forma.Equals("tarjeta"))
                {
                    Console.WriteLine("introduce el numero de tarjeta");
                    int numero_cuenta = Convert.ToInt32(Console.ReadLine());//cambia el int32 por Int64
                    for (int p = 0; p < orden.Count; p++)
                    {
                        //Console.WriteLine("Tu cuenta {0} - $ {1}ha sido pagado con: {3}", orden[p], numeroorden[p], numero_cuenta);
                        Console.WriteLine("Tu cuenta "+ orden[p] + " - $ "+ numeroorden[p] + " ha sido pagado con: "+ numero_cuenta +"");//Cambialo por esto.
                    }
                }
                else if (forma.Equals("efectivo"))
                {
                    for (int p = 0; p < orden.Count; p++)
                    {
                        Console.WriteLine("Tu cuenta {0} - {1}", orden[p], "$", numeroorden[p] + "ha sido pagado con efectivo");
                    }
                }
                else
                {
                    Console.WriteLine("la forma de pago es incorrecta");
                }
            }

            Console.ReadKey();
        }
    }
}