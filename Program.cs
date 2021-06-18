using System;
using System.Collections.Generic;
using System.IO;

namespace Proyecto_U5_U6
{
    public class Usuario
    {
        public string Name { get; set; }
        public Usuario(string names)
        {
            Name = names;
        }
    }
    
    public class Coment
    {
        public int ID { get; set; }   
        public string Author { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }
        public string IP { get; set; }
        public int Likes { get; set; }
    }

    class ComentarioDB
    {
        public static void SaveToFile(List<Coment> Comentarios, string path)
        {
            StreamWriter textout = null;
            try
            {
                textout = new StreamWriter(new FileStream(path, FileMode.Create, FileAccess.Write));

                foreach (var Coments in Comentarios)
                {
                    textout.Write(Coments.ID );
                    textout.Write(Coments.Author );
                    textout.Write(Coments.Date );
                    textout.Write(Coments.Comment );
                    textout.Write(Coments.IP );
                    textout.Write(Coments.Likes );
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Archivo ya existente");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                if (textout != null)
                    textout.Close();
            }
        }
        public static void NewComent(List<Coment> Comentarios, string path)
        {
            StreamWriter textout = null;
            try
            {
                textout = new StreamWriter(new FileStream(path, FileMode.Append, FileAccess.Write));
                foreach (var Coments in Comentarios)
                {
                    textout.Write(Coments.ID );
                    textout.Write(Coments.Author );
                    textout.Write(Coments.Date );
                    textout.Write(Coments.Comment );
                    textout.Write(Coments.IP );
                    textout.Write(Coments.Likes );
                }
            }
            catch (IOException)
            {
                Console.WriteLine("El Archivo ya existe");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                if (textout != null)
                    textout.Close();
            }
        }      
    }    
    class Pogram
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Escribir comentario?");
            Console.WriteLine("SI: Y, NO: N");

            try
            {
                string x = Console.ReadLine();
                if (x == "Y")
                {
                    try
                    {
                        List<Coment> NewComentario = new List<Coment>();
                        Console.WriteLine( " ID de usuario: " );
                        int a = int.Parse(Console.ReadLine());
                        Console.WriteLine( " Autor: " );
                        string b = Console.ReadLine();
                        Console.WriteLine( " Fecha de publicación " );
                        DateTime c = DateTime.Today;
                        Console.WriteLine( " Comentarios " );
                        string d = Console.ReadLine();
                        Console.WriteLine( " Dirección IP: " );
                        string e = Console.ReadLine();
                        Console.WriteLine( " Numero de Likes:  " );
                        int f = int.Parse(Console.ReadLine());
                        NewComentario.Add(new Coment { ID = a , Author = b , Date = c , Comment = d , IP = e , Likes = f });
                        ComentarioDB.NewComent(NewComentario, @"C:\Users\aleja\Documents\Proyecto U5 U6\cp.txt");
                    }
                    catch (FormatException) { Console.WriteLine("El formato es incorrecto"); }
                }
            }
            catch (Exception) { }

        }
    }
}
