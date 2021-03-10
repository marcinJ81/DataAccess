using Microsoft.Extensions.Configuration;

namespace DataAccessLibrary_netCore.ConString
{
    public interface IConnectStringAccess
    {
        string GetConString { get; }
    }
}