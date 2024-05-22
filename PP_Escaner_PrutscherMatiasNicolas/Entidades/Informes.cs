using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Clase estática que permite generar informes sobre los documentos de un escáner.
    /// </summary>
    public static class Informes
    {
        /// <summary>
        /// Genera un informe de documentos por estado.
        /// </summary>
        /// <param name="e">Escaner del que se generarán los informes.</param>
        /// <param name="estado">El estado de los documentos para los que se generará el informe.</param>
        /// <param name="extension">La extensión total de los documentos en el estado especificado.</param>
        /// <param name="cantidad">La cantidad total de documentos en el estado especificado.</param>
        /// <param name="resumen">El resumen del informe generado.</param>
        private static void MostrarDocumentosPorEstado(Escaner e, Documento.Paso estado, out int extension, out int cantidad, out string resumen)
        {
            int contaExtension = 0;
            int contaCantidad = 0;
            StringBuilder resumenBuilder = new StringBuilder();

            foreach (Documento d in e.ListaDocumentos)
            {
                if (d.Estado == estado)
                {
                    contaCantidad++;
                    resumenBuilder.AppendLine(d.ToString());
                    if (d is Libro l)
                    {
                        contaExtension += l.NumPaginas;
                    }
                    else if (d is Mapa m)
                    {
                        contaExtension += m.Superficie;
                    }
                }
            }
            if (contaCantidad == 0)
            {
                extension = 0;
                cantidad = 0;
                resumen = "No hay documentos en este estado.";
                return;
            }
            extension = contaExtension;
            cantidad = contaCantidad;
            resumen = resumenBuilder.ToString();
        }

        /// <summary>
        /// Genera un informe de documentos distribuidos por el escáner.
        /// </summary>
        /// <param name="e">Escaner del que se generarán los informes.</param>
        /// <param name="extension">La extensión total de los documentos distribuidos.</param>
        /// <param name="cantidad">La cantidad total de documentos distribuidos.</param>
        /// <param name="resumen">El resumen del informe generado.</param>
        public static void MostrarDistribuidos(Escaner e, out int extension, out int cantidad, out string resumen)
        {
            MostrarDocumentosPorEstado(e, Documento.Paso.Distribuido, out extension, out cantidad, out resumen);
        }

        /// <summary>
        /// Genera un informe de documentos en el escáner.
        /// </summary>
        /// <param name="e">Escaner del que se generarán los informes.</param>
        /// <param name="extension">La extensión total de los documentos en el escáner.</param>
        /// <param name="cantidad">La cantidad total de documentos en el escáner.</param>
        /// <param name="resumen">El resumen del informe generado.</param>
        public static void MostrarEnEscaner(Escaner e, out int extension, out int cantidad, out string resumen)
        {
            MostrarDocumentosPorEstado(e, Documento.Paso.EnEscaner, out extension, out cantidad, out resumen);
        }

        /// <summary>
        /// Genera un informe de documentos en revisión por el escáner.
        /// </summary>
        /// <param name="e">Escaner del que se generarán los informes.</param>
        /// <param name="extension">La extensión total de los documentos en revisión.</param>
        /// <param name="cantidad">La cantidad total de documentos en revisión.</param>
        /// <param name="resumen">El resumen del informe generado.</param>
        public static void MostrarEnRevisión(Escaner e, out int extension, out int cantidad, out string resumen)
        {
            MostrarDocumentosPorEstado(e, Documento.Paso.EnRevision, out extension, out cantidad, out resumen);
        }

        /// <summary>
        /// Genera un informe de documentos terminados por el escáner.
        /// </summary>
        /// <param name="e">Escaner del que se generarán los informes.</param>
        /// <param name="extension">La extensión total de los documentos terminados.</param>
        /// <param name="cantidad">La cantidad total de documentos terminados.</param>
        /// <param name="resumen">El resumen del informe generado.</param>
        public static void MostrarTerminados(Escaner e, out int extension, out int cantidad, out string resumen)
        {
            MostrarDocumentosPorEstado(e, Documento.Paso.Terminado, out extension, out cantidad, out resumen);
        }
    }
}

