
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alba;


namespace MisTests
{
    public class ApiBlacksFixxture : IDisposable
    {
        public readonly SystemUnderTest systemUnderTest;
        public ApiBlacksFixxture()
        {
            systemUnderTest = SystemUnderTest.ForStartup<blackstore_firebase_api.Startup>();
        }
        public void Dispose()
        {
            systemUnderTest?.Dispose();
        }
    }
}
