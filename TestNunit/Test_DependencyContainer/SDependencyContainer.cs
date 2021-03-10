using DataAccessLibrary_netCore.Dependency;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestNunit.Test_DependencyContainer
{
    public static class SDependencyContainer
    {
        private static ICreatorOfDBConnection creatorOfDBConnection { get; set; }
        public static ICreatorOfDBConnection getCreatorOfDBConnection => (ICreatorOfDBConnection)creatorOfDBConnection;
        static SDependencyContainer()
        {
            creatorOfDBConnection = new CreatorOfDBConnection();
        }
    }
}
