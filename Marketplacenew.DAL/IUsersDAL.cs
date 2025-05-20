using System.Data;
using Marketplacenew.Models;

namespace Marketplacenew.DAL
{
    public interface IUsersDAL
    {
        DataTable getById_alloweddevices(string usersid);
        string Register_Profile(usersModel model);
        usersModel getById_users(string usersid);
        string Update_Profile(usersModel model);
        string Suspend_Profile(string id, string loginUserID);
        string get_decryptedPassword(string userName);
        DataTable get_roleAuthorizations(string viewactionroles);
        DataTable get_project_Menu(string viewactionroles, string subsystem);
        DataTable get_roles(string roles, string parentname);
        DataTable CheckAuthentication(userloginModel model);
        DataTable get_Dashboard_Items(string viewactionroles);
        DataTable List_of_User_Profiles(string tenantid);
        DataTable get_all_users(string tenantid);
        string ChangePassword(usersChangePasswordModel model);
        DataTable getById_allinfo_users(string usersid);
    }
}
