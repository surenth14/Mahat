using System.Data;
using Marketplacenew.Models;

namespace Marketplacenew.DAL
{
    public interface ITenantDAL
    {
        string Create_tenant(tenantModel model);
        tenantModel getById_tenant(string tenantid);
        string Update_tenant(tenantModel model);
        string Remove_tenant(string id, string loginUserID);
        DataTable ViewList_tenant();
        DataTable get_all_tenant(string tenantid);
        DataTable get_project_tenant(string businesstype, string tenantid);
        DataTable getById_allinfo_tenant(string tenantid);
        DataTable lookup_tenant_parentid(string businesstype = "");
    }
}
