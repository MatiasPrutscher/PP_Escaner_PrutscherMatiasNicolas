using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Clase que representa un escáner de documentos y permite establecer el estado de los documentos en el mismo.
    /// </summary>
    public class Escaner
    {
        #region Campos

        private List<Documento> listaDocumentos;
        private Departamento locacion;
        private string marca;
        private TipoDoc tipo;

        #endregion

        #region Propiedades

        public List<Documento> ListaDocumentos
        {
            get => this.listaDocumentos;
        }
        public Departamento Locacion
        {
            get => this.locacion;
        }
        public string Marca
        {
            get => this.marca;
        }
        public TipoDoc Tipo
        {
            get => this.tipo;
        }
        #endregion

        #region Metodos

        #region Constructores

        /// <summary>
        /// Constructor de la clase Escaner.
        /// </summary>
        /// <param name="marca">Marca del escáner.</param>
        /// <param name="tipo">Tipo de documentos que puede escanear el escáner.</param>
        public Escaner(string marca, TipoDoc tipo)
        {
            this.marca = marca;
            this.tipo = tipo;
            this.listaDocumentos = new List<Documento>();
            switch (tipo)
            {
                case TipoDoc.libro:
                    this.locacion = Departamento.procesosTecnicos;
                    break;
                case TipoDoc.mapa:
                    this.locacion = Departamento.mapoteca;
                    break;
                default:
                    this.locacion = Departamento.nulo;
                    break;
            }
        }
        #endregion

        /// <summary>
        /// Cambia el estado de un documento escaneado por el escáner.
        /// </summary>
        /// <param name="d">Documento cuyo estado se va a cambiar.</param>
        /// <returns>True si el estado del documento se cambió con éxito, False si ya está en estado Terminado.</returns>
        public bool CambiarEstadoDocumento(Documento d)
        {
            return d.AvanzarEstado();
        }

        #region Sobrecargas

        /// <summary>
        /// Sobrecarga del operador de igualdad para comparar si un documento está en el escaner o si el documento es de otro tipo que no corresponde.
        /// </summary>
        /// <param name="e">Escaner a comparar.</param>
        /// <param name="d">Documento a comparar.</param>
        /// <returns>True si el documento está en el escáner/no corresponde, False en caso contrario.</returns>
        public static bool operator ==(Escaner e, Documento d)
        {
            //Si el documento no corresponde al tipo de documento que escanea el escáner, se devuelve true.
            if ((e.Tipo == TipoDoc.libro && d is not Libro) ||
               (e.Tipo == TipoDoc.mapa && d is not Mapa))
            {
                return true;
            }
            //Se recorre la lista de documentos del escáner y se compara si el documento ya está en el escáner.
            foreach (Documento item in e.ListaDocumentos)
            {
                if ((item is Mapa && d is Mapa mapa && mapa == (Mapa)item) ||
                    (item is Libro && d is Libro libro && libro == (Libro)item))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Sobrecarga del operador de desigualdad para comparar si un documento está en el escaner.
        /// </summary>
        /// <param name="e">Escaner a comparar.</param>
        /// <param name="d">Documento a comparar.</param>
        /// <returns>True si el documento no está en el escáner, False en caso contrario.</returns>
        public static bool operator !=(Escaner e, Documento d)
        {

            return !(e == d);
        }

        /// <summary>
        /// Sobrecarga del operador de adición para agregar un documento al escáner.
        /// </summary>
        /// <param name="e">Escaner al que se le agrega el documento.</param>
        /// <param name="d">Documento a agregar al escáner.</param>
        /// <returns>True si el documento se agregó correctamente, False en caso contrario.</returns>
        public static bool operator +(Escaner e, Documento d)
        {
            if (d != null && e != d && d.Estado == Paso.Inicio)
            {
                e.CambiarEstadoDocumento(d);
                e.ListaDocumentos.Add(d);
                return true;
            }
            return false;
        }
        #endregion
        #endregion
    }
}
