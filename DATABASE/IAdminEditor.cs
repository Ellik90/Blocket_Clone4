using TYPES;
namespace DATABASE;
public interface IAdminEditor
{
    public int UpdateAdminEmail(Admin admin, string adminEmail);
   // public int UpdateAdminName(Admin admin,string name); //anänds ej
}