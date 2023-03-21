using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E3352.Models;

namespace E3352.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            return View();    
        }
        public ActionResult GridViewPartial() {
            return PartialView("_GridViewPartial", TestModel.GetDS());
        }
        public ActionResult ExportTo() {
            return GridViewExtension.ExportToPdf(GridViewHelper.GetExportSettings(Request.Params["ExportColumnsNames"]), TestModel.GetDS());
        }
    }
    public static class GridViewHelper {
        public static GridViewSettings GetExportSettings(string itemsNames) {
            GridViewSettings gridVieewSettings = GetExportSettings();

            if (!string.IsNullOrEmpty(itemsNames)) {
                string[] names = itemsNames.Split(';');
                gridVieewSettings.SettingsExport.BeforeExport = (sender, e) => {
                    MVCxGridView gridView = sender as MVCxGridView;
                    if (sender == null)
                        return;

                    gridView.Columns.Clear();

                    foreach (var name in names) {
                        if (string.IsNullOrEmpty(name)) continue;
                        gridView.Columns.Add(new MVCxGridViewColumn(name));
                    }
                };
            }

            return gridVieewSettings;
        }
        public static GridViewSettings GetExportSettings() {
            GridViewSettings gridVieewSettings = new GridViewSettings();
            gridVieewSettings.Name = "gridView";
            gridVieewSettings.KeyFieldName = "ID";
            gridVieewSettings.CallbackRouteValues = new { Controller = "Home", Action = "GridViewPartial" };

            gridVieewSettings.Columns.Add("FirstName");
            gridVieewSettings.Columns.Add("LastName");
            gridVieewSettings.Columns.Add("BirthDate");
            gridVieewSettings.Columns.Add("Information");

            return gridVieewSettings;
        }
    }
}
