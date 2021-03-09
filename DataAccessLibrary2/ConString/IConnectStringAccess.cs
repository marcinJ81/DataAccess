using Microsoft.Extensions.Configuration;

namespace DataAccessLibrary2.ConString
{
    public interface IConnectStringAccess
    {
        string GetConString { get; }
    }
}