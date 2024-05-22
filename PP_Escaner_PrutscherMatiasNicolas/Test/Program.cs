using Entidades;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int extension;
            int cantidad;
            string resumen;
            Libro l1 = new Libro("Yerma", "García Lorca, Federico",1995 , "1114", "22222", 0);
            Libro l2 = new Libro("Yerma", "García Lorca, Federico", 1995, "1114", "22222", 27);
            Libro l3 = new Libro();
            Libro l4 = new Libro("Yerma", "García Lorca, Federico", 1995, "1114", "22222", 27);
            Libro l5 = new Libro("El Gato", "G, Federico", 1995, "5a", "3333", 50);
            Mapa m1 = new Mapa("Cordoba", "Instituto de Geografia", 2022, "1", 30, 20);
            Mapa m2 = new Mapa("Ciudad Autónoma de Buenos Aires", "Instituto de Geografia", 2022, "8888", 30, 20);
            Mapa m3 = new Mapa("Ciudad Autónoma de Buenos Aires", "Instituto de Geografia", 2022, "8888", 30, 20);
            Mapa m4 = new Mapa("Ciudad Autón Buenos Aires", " Geografia", 1950, "7888", 35, 50);

            Escaner mapoteca = new Escaner("hp", Escaner.TipoDoc.mapa);
            Escaner procesosTecnicos = new Escaner("epson", Escaner.TipoDoc.libro);
            bool a = mapoteca + m1;
            a = mapoteca + l5;
            a = mapoteca + m2;
            a = mapoteca + m3;
            a = mapoteca + l2;
            a = mapoteca + l4;
            a = mapoteca + l5;

            a = procesosTecnicos + l1;
            a = procesosTecnicos + l4;
            a = procesosTecnicos + l3;
            a = procesosTecnicos + m4;
            a = procesosTecnicos + m1;
            a = procesosTecnicos + m2;
            a = procesosTecnicos + m3;
            a = procesosTecnicos + l5;
            //a = procesosTecnicos + null;


            Informes.MostrarDistribuidos(mapoteca, out extension, out cantidad, out resumen);
            Console.WriteLine("Mapoteca: \n");
            Console.WriteLine(resumen);

            Informes.MostrarDistribuidos(procesosTecnicos, out extension, out cantidad, out resumen);
            Console.WriteLine("Procesos tecnicos: \n");
            Console.WriteLine(resumen);

            m1.AvanzarEstado();

            Informes.MostrarDistribuidos(mapoteca, out extension, out cantidad, out resumen);
            Console.WriteLine("Mapoteca: \n");
            Console.WriteLine(resumen);

            Informes.MostrarEnEscaner(mapoteca, out extension, out cantidad, out resumen);
            Console.WriteLine("Mapoteca: \n");
            Console.WriteLine(resumen);

            

        }
    }
}
