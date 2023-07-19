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
        static void Main(string[] args)
        {
            List<string> orden = new List<string>();
            List<int> numeroorden = new List<int>();

            DateTimeOffset horadesayunos = new DateTimeOffset(2023, 1, 1, 8, 1, 0, TimeSpan.FromHours(-8));
            DateTimeOffset horadecomida = new DateTimeOffset(2023, 1, 1, 12, 1, 0, TimeSpan.FromHours(-8));
            DateTimeOffset horacena = new DateTimeOffset(2023, 1, 1, 18, 0, 0, TimeSpan.FromHours(-8));
            DateTimeOffset horacierre = new DateTimeOffset(2023, 1, 1, 23, 30, 0, TimeSpan.FromHours(-8));
            DateTimeOffset horaapertura = new DateTimeOffset(2023, 1, 1, 8, 0, 0, TimeSpan.FromHours(8));

            string[] menudesayuno =
           {
                "Hot cakes", "huevos con chorizo", "chilaquiles rojos", "chilaquiles verdes", "huevos revueltos", "huevos a la mexicana", "platanos fritos", "chocomilk", "licuado de platano", "cafe"
            };

            int[] preciosdesayuno =
                { 80, 95, 85, 85, 90, 105, 80, 30, 25, 15};

            string[] menucomida =
            {
                "tacos de carne asada", "consome", "gorditas de cerdo", "carne asada", "tacos dorados", "empanadas de quesillo", "empanadas de qesillo con carne asada"
            };

            int[] precioscomida =
                {10, 35, 15, 85, 12, 10, 15};

            string[] menucena =
            {
                "hamburguesa", "quesadilla con carne asada", "pizza de peperoni", "alitas BBQ",
            };

            int[] precioscena =
                { 88, 45, 80, 125};

            if (horadesayunos > horaapertura || horadesayunos < horadecomida)
            {
                Console.WriteLine("este es nuestro menú de desayunos");
                for (int i = 0; i < menudesayuno.Length; i++)
                {
                    Console.WriteLine("{0}.{1} - {2}", i + 1, menudesayuno[i], "$" + preciosdesayuno[i]);
                }

                Console.WriteLine("¿Que desea ordenar?");
                orden.Add(Console.ReadLine());

            }

            if (horadecomida < horadesayunos || horadecomida > horacena)
            {
                Console.WriteLine("Este es nuestro menú de comidas");
                for (int j = 0; j < menucomida.Length; j++)
                {
                    Console.WriteLine("{0}.{1} - {2}", j + 1, menucomida[j], "$" + precioscomida[j]);
                }

                Console.WriteLine("¿Que desea ordenar?");
                orden.Add(Console.ReadLine());

                if (orden.Equals(menucomida))
                {
                    Console.WriteLine("¿cuantos desea ordenar?");
                    numeroorden.Add(Convert.ToInt32(Console.ReadLine()));
                }
                else
                {
                    Console.WriteLine("Disculpa, agergaste un platillo fuera del menú");
                }

            }

            if (horacena > horadecomida || horacena < horacierre)
            {
                Console.WriteLine("este es nuestro menú de cena");
                for (int k = 0; k < menucena.Length; k++)
                {
                    Console.WriteLine("{0}.{1} - {2}", k + 1, menucena[k], "$" + precioscena[k]);
                }
               
                Console.WriteLine("¿Que desea ordenar?");
                orden.Add(Console.ReadLine());

                if (orden.Equals(menucena))
                {
                    Console.WriteLine("¿cuantos desea ordenar?");
                    numeroorden.Add(Convert.ToInt32(Console.ReadLine()));
                    Console.WriteLine("¿Es correcta su orden?:");
                   
                    foreach (string palabra in orden)
                    {
                        Console.WriteLine(palabra);
                    }
                }
                else
                {
                    Console.WriteLine("Disculpa, agregaste un platillo fuera del menú");
                }

            }

            Console.ReadKey();
        }

    }
}
