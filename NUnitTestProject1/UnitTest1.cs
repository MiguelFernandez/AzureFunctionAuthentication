using Microsoft.Azure.Services.AppAuthentication;
using NUnit.Framework;

namespace NUnitTestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async System.Threading.Tasks.Task Test1Async()
        {
            var appId = "6b44cc8d-6e15-4bda-9b75-71e12a9143c3";
            var tenantId = "72f988bf-86f1-41af-91ab-2d7cd011db47";
            var azureServiceTokenProvider = new AzureServiceTokenProvider();
            string accessToken = await azureServiceTokenProvider.GetAccessTokenAsync(appId, tenantId);
            Assert.Pass();
        }
    }
}