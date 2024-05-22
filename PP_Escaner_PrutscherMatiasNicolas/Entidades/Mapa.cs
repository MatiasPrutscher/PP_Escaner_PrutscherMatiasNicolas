using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Clase que representa un mapa y hereda de Documento.
    /// </summary>
    public class Mapa : Documento
    {
        #region Campos

        private int alto;
        private int ancho;

        #endregion

        #region Propiedades

        public int Alto
        {
            get => this.alto;
        }
        public int Ancho
        {
            get => this.ancho;
        }
        public int Superficie
        {
            get => (this.Ancho * this.Alto);
        }


        #endregion

        #region Metodos

        #region Constructores
        /// <summary>
        /// Constructor de la clase Mapa.
        /// </summary>
        /// <param name="titulo">Título del mapa.</param>
        /// <param name="autor">Autor del mapa.</param>
        /// <param name="anio">Año de publicación del mapa.</param>
        /// <param name="codebar">Código de barras del mapa.</param>
        /// <param name="ancho">Ancho del mapa.</param>
        /// <param name="alto">Alto del mapa.</param>
        public Mapa(string titulo = "Ciudad Autónoma de Buenos Aires",
                    string autor = "Instituto de Geografia",
                    int anio = 2022, string codebar = "8888",
                    int ancho = 30,
                    int alto = 20)
                    : base(titulo, autor, anio, "", codebar)
        {
            this.alto = alto;
            this.ancho = ancho;
        }
        #endregion

        /// <summary>
        /// Sobrecarga del operador de desigualdad para mapas.
        /// </summary>
        /// <param name="m1">Primer mapa.</param>
        /// <param name="m2">Segundo mapa.</param>
        /// <returns>True si los mapas son diferentes, False en caso contrario.</returns>
        public static bool operator !=(Mapa m1, Mapa m2)
        {
            return !(m1 == m2);
        }

        /// Sobrecarga del operador de igualdad para mapas.
        /// </summary>
        /// <param name="m1">Primer mapa.</param>
        /// <param name="m2">Segundo mapa.</param>
        /// <returns>True si los mapas son iguales, False en caso contrario.</returns>
        public static bool operator ==(Mapa m1, Mapa m2)
        {
            if (ReferenceEquals(m1, m2))
            {
                return true;
            }
            if (ReferenceEquals(m1, null) || ReferenceEquals(m2, null))
            {
                return false;
            }

            return (m1.Barcode == m2.Barcode ||
                   (m1.Titulo == m2.Titulo && m1.Autor == m2.Autor && m1.Anio == m2.Anio && m1.Superficie == m2.Superficie));
        }

        /// <summary>
        /// Sobrecarga del metodo ToString() para mostrar la informacion del mapa
        /// </summary>
        /// <returns>String con la informacion del mapa</returns> 
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat(base.ToString());
            sb.AppendFormat("Supericie: {0} * {1} = {2} cm2.\n", this.Alto, this.Ancho, this.Superficie);

            return sb.ToString();

        }
        #endregion
    }
}
