using System.Web;
using System.Linq;
using System.Collections;
using System.Data.Linq.Mapping;

namespace DevExpress.Razor.Models {
    public static class NorthwindDataProvider {
        const string NorthwindDataContextKey = "DXNorthwindDataContext";

        public static NorthwindDataContext DB {
            get {
                if (HttpContext.Current.Items[NorthwindDataContextKey] == null)
                    HttpContext.Current.Items[NorthwindDataContextKey] = new NorthwindDataContext();
                return (NorthwindDataContext)HttpContext.Current.Items[NorthwindDataContextKey];
            }
        }
        public static IEnumerable GetEmployees() {
            return from employee in DB.Employees select employee;
        }
        public static IEnumerable GetColumnsNames() {
            var model = new AttributeMappingSource().GetModel(typeof(NorthwindDataContext));
            return from name in model.GetMetaType(typeof(Employee)).DataMembers
                   select name.MappedName;
        }
    }
}