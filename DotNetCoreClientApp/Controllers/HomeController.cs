using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DotNetCoreClientApp.Models;
using System.Net.Http;
using Microsoft.Identity.Client;
using System.Security;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Azure.Services.AppAuthentication;

namespace DotNetCoreClientApp.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> IndexAsync()
        {
            HttpClient httpClient = new HttpClient();
            
            
            var appId = "6b44cc8d-6e15-4bda-9b75-71e12a9143c3";
            var tenantId = "72f988bf-86f1-41af-91ab-2d7cd011db47";
            var azureServiceTokenProvider = new AzureServiceTokenProvider();
            string accessToken = await azureServiceTokenProvider.GetAccessTokenAsync(appId, tenantId);

            var response = await httpClient.GetAsync("https://functionauthtest20191001124049.azurewebsites.net/api/Function1?code=MoaaaImqfjEzCPtCsSy5fant3Xn/cHxXTaEYWI3CJ9fKLIZCabMABg==");
            var responseContent = await response.Content.ReadAsStringAsync();
            ViewData["ResponseContent"] = responseContent;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
