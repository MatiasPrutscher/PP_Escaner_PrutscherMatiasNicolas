using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Clase que representa un libro y hereda de Documento.
    /// </summary>
    public class Libro : Documento
    {
        #region Campos

        private int numPaginas;

        #endregion

        #region Propiedades

        public string ISBN
        {
            get => this.NumNormalizado;
        }
        public int NumPaginas
        {
            get => this.numPaginas;
        }

        #endregion

        #region Metodos

        #region Constructores

        /// <summary>
        /// Constructor de la clase Libro.
        /// </summary>
        /// <param name="titulo">Título del libro.</param>
        /// <param name="autor">Autor del libro.</param>
        /// <param name="anio">Año de publicación del libro.</param>
        /// <param name="numNormalizado">Número normalizado del libro.</param>
        /// <param name="barcode">Código de barras del libro.</param>
        /// <param name="numPaginas">Número de páginas del libro.</param>
        public Libro(string titulo = "Yerma",
                    string autor = "García Lorca, Federico",
                    int anio = 1995,
                    string numNormalizado = "1114",
                    string barcode = "22222",
                    int numPaginas = 27)
                    : base(titulo, autor, anio, numNormalizado, barcode)
        {
            this.numPaginas = numPaginas;
        }

        #endregion


        /// <summary>
        /// Sobrecarga del operador de desigualdad para libros.
        /// </summary>
        /// <param name="l1">Primer libro.</param>
        /// <param name="l2">Segundo libro.</param>
        /// <returns>True si los libros son diferentes, False en caso contrario.</returns>
        public static bool operator !=(Libro l1, Libro l2)
        {
            return !(l1 == l2);
        }

        /// <summary>
        /// Sobrecarga del operador de igualdad para libros.
        /// </summary>
        /// <param name="l1">Primer libro.</param>
        /// <param name="l2">Segundo libro.</param>
        /// <returns>True si los libros son iguales, False en caso contrario.</returns>
        public static bool operator ==(Libro l1, Libro l2)
        {
            if (ReferenceEquals(l1, l2))
            {
                return true;
            }
            if (ReferenceEquals(l1, null) || ReferenceEquals(l2, null))
            {
                return false;
            }

            return (l1.Barcode == l2.Barcode ||
                    l1.ISBN == l2.ISBN ||
                   (l1.Titulo == l2.Titulo && l1.Autor == l2.Autor));
        }

        /// <summary>
        /// Sobrecarga del metodo ToString() para mostrar la informacion del libro
        /// </summary>
        /// <returns>String con la informacion del libro</returns> 
        public override string ToString()
        {
            string aux;
            int index;
            StringBuilder sb = new StringBuilder();

            aux = base.ToString();
            index = aux.IndexOf("Cód");
            sb.AppendFormat(aux);
            aux = ("ISBN: " + this.ISBN + "\n");
            sb.Insert(index, aux);
            sb.AppendFormat("Número de páginas: {0}.\n", this.NumPaginas);

            return sb.ToString();
        }
        #endregion
    }
}
