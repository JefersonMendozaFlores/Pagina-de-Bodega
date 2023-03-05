using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

// importando librerias
using PrjProyecto_Tienda_Bodega.Models;
using Microsoft.Reporting.WebForms; // ReportViewer



namespace PrjProyecto_Tienda_Bodega.Controllers
{
    public class ReportesController : Controller
    {
        // definir la variable 
        VentasDAO dao_venta = new VentasDAO();
        ClientesDAO dao_cli = new ClientesDAO();

        // GET: Reportes
        public ActionResult ReporteVentas()
        {
            // datos del reporte 
            var listado = dao_venta.usp_reporte_ventas();

            // configurando el reporte
            // pasos:
            // 1. Origen de datos del Reporte
            ReportDataSource rds = 
                new ReportDataSource("DataSet1", listado);

            // 2. Establecer el ReportViewer
            ReportViewer rv = new ReportViewer();
            rv.ProcessingMode = ProcessingMode.Local;
            rv.SizeToReportContent = true;

            rv.LocalReport.ReportPath =
                Request.MapPath(Request.ApplicationPath) + 
                // @ o \\
                @"Reportes\Report1.rdlc";

            rv.LocalReport.DataSources.Add(rds);

            // 3. Almacenar el reporteviewer en un ViewBag
            ViewBag.REPORTE = rv;

            // retornamos la vista
            return View(listado);
        }

        // GET: Reportes
        public ActionResult ReporteClientes()
        {
            // datos del reporte 
            var listado = dao_cli.ReporteClientes();

            // configurando el reporte
            // pasos:
            // 1. Origen de datos del Reporte
            ReportDataSource rds =
                new ReportDataSource("DataSet1", listado);

            // 2. Establecer el ReportViewer
            ReportViewer rv = new ReportViewer();
            rv.ProcessingMode = ProcessingMode.Local;
            rv.SizeToReportContent = true;

            rv.LocalReport.ReportPath =
                Request.MapPath(Request.ApplicationPath) +
                // @ o \\
                @"Reportes\ReportCliente.rdlc";

            rv.LocalReport.DataSources.Add(rds);

            // 3. Almacenar el reporteviewer en un ViewBag
            ViewBag.REPORTECLIENTE = rv;

            // retornamos la vista
            return View(listado);
        }
    }
}