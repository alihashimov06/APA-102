namespace _34_Front_To_BackSqlConnection.Services.Interfaces
{
    public interface ILayoutServices
    {
        Task<Dictionary<string, string>> GetSettingAsync();
    }
}
