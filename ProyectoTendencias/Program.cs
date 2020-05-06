using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoTendencias
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Introduzca el path de los estudiantes");            var pathEstudiantes = @"" + Console.ReadLine();            //if (!Directory.Exists(pathEstudiantes))            //{            //    Console.WriteLine("El directorio no existe");            //    Console.ReadKey();            //    return;            //}

            Console.WriteLine("Introduzca el path de los temas");            var pathTemas = @"" + Console.ReadLine();            //if (!Directory.Exists(pathTemas))            //{            //    Console.WriteLine("El directorio no existe");
            //    Console.ReadKey();
            //    return;            //}

            Console.WriteLine("Introduzca el tamaño del grupo");
            int size = int.Parse(Console.ReadLine());

            Grupo[] GruposFinales = SeparateGroups(size, pathEstudiantes, pathTemas);
            ImprimirTodosGrupos(GruposFinales);
            Console.ReadKey();
        }

        public static Grupo[] SeparateGroups(int size, string estudiantes, string temas)
        {
            
            string[] listaTemas = File.ReadAllLines(temas);
            string[] listaEstudiantes = File.ReadAllLines(estudiantes);
            int quantityofGroups = listaEstudiantes.Length/size;

            //foreach (string line in listaEstudiantes)
            //    Console.WriteLine(line);

            //foreach (string line in listaTemas)
            //    Console.WriteLine(line);

            if (size > listaEstudiantes.Length)
            {
                Console.WriteLine("La cantidad de estudiantes es menor que el tamaño del grupo");
                return null;
            }

            if (quantityofGroups > listaTemas.Length)
            {
                Console.WriteLine("La cantidad de temas es menor que la cantidad de grupos.");
                return null;
            }

            Grupo[] grupos = new Grupo[quantityofGroups];

            for (int i = 0; i < grupos.Length; i++)
            {
                grupos[i] = new Grupo();
            }

            var rand = new Random();            List<int> listNumbers = new List<int>();            int number;                        for (int i = 0; i < listaEstudiantes.Length; i++)            {                for (int j = 0; j < quantityofGroups; j++)
                {
                    do
                    {
                        number = rand.Next(0, listaEstudiantes.Length - 1);
                    } while (listNumbers.Contains(number));
                    listNumbers.Add(number);
                    grupos[j].Integrantes.Add(listaEstudiantes[number]);
                    if (grupos[j].Integrantes.Count == size)
                    {
                        break;
                    }
                }
            }

            var rand2 = new Random();            List<int> listNumbers2 = new List<int>();            int number2;

            for (int i = 0; i < listaTemas.Length; i++)            {                for (int j = 0; j < quantityofGroups; j++)u
                {
                    do
                    {
                        number2 = rand.Next(0, listaTemas.Length - 1);
                    } while (listNumbers2.Contains(number2));

                    listNumbers.Add(number2);
                    grupos[j].Temas.Add(listaTemas[number2]);
                }
            }
            return grupos;
        }

        static void ImprimirTodosGrupos(Grupo[] todosGrupos)
        {
            for (int i = 0; i < todosGrupos.Length; i++)
            {
                Console.WriteLine("Grupo {0}\nIntegrantes: ", i + 1);
                foreach (var integrante in todosGrupos[i].Integrantes)
                {
                    Console.WriteLine(integrante);
                }

                Console.WriteLine("Temas:\n");
                foreach (var tema in todosGrupos[i].Temas)
                {
                    Console.WriteLine(tema);
                }
                Console.WriteLine();
            }
        }

    }
}
