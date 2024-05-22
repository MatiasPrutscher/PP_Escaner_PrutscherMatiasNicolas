using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Clase abstracta que representa un documento y sus propiedades.
    /// </summary>
    public abstract class Documento
    {
        #region Campos

        private int anio;
        private string autor;
        private string barcode;
        private Paso estado;
        private string numNormalizado;
        private string titulo;

        #endregion

        #region Propiedades
        public int Anio
        {
            get => this.anio; 
        }
        public string Autor
        {
            get => this.autor; 
        }
        public string Barcode
        {
            get => this.barcode; 
        }
        public Paso Estado
        {
            get => this.estado; 
        }
        protected string NumNormalizado
        {
            get => this.numNormalizado; 
        }
        public string Titulo
        {
            get => this.titulo; 
        }
        #endregion

        #region Metodos

        #region Constructores
        /// <summary>
        /// Constructor de la clase Documento.
        /// </summary>
        /// <param name="titulo">Título del documento.</param>
        /// <param name="autor">Autor del documento.</param>
        /// <param name="anio">Año de publicación del documento.</param>
        /// <param name="numNormalizado">Número normalizado del documento.</param>
        /// <param name="barcode">Código de barras del documento.</param>
        public Documento(string titulo, string autor, int anio, string numNormalizado, string barcode)
        {
            this.titulo = titulo;
            this.autor = autor;
            this.anio = anio;
            this.numNormalizado = numNormalizado;
            this.barcode = barcode;
            this.estado = Paso.Inicio;
        }
        #endregion

        /// <summary>
        /// Avanza el estado del documento al siguiente paso.
        /// </summary>
        /// <returns>True si el estado se actualizó correctamente, False si ya está en estado Terminado.</returns>
        public bool AvanzarEstado()
        {
            if (this.Estado == Paso.Terminado)
            {
                return false;
            }
            else
            {
                this.estado++;
                return true;
            }
        }

        /// <summary>
        /// Sobrecarga del metodo ToString() para mostrar la informacion del documento
        /// </summary>
        /// <returns>String con la informacion del documento</returns> 
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Titulo: {0}\n", this.titulo);
            sb.AppendFormat("Autor: {0}\n", this.autor);
            sb.AppendFormat("Año: {0}\n", this.anio);
            sb.AppendFormat("Cód. de barras: {0}\n", this.Barcode);

            return sb.ToString();
        }
        #endregion

        #region Enumerados
        public enum Paso
        {
            Inicio,
            Distribuido,
            EnEscaner,
            EnRevision,
            Terminado
        }

        #endregion

    }
}
