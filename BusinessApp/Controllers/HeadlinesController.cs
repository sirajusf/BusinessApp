using BusinessApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Http.Json;
using System.Text.Json;

namespace BusinessApp.Controllers
{
    public class HeadlinesController: Controller
    {
        public async Task<IActionResult> Index()
        {
            string api_key = "cfd88b4fd66a43959290b6f47b6db429";
            string end_point = $"https://newsapi.org/v2/top-headlines?country=us&category=business&apiKey={api_key}";
            
            using HttpClient client = new();
            client.DefaultRequestHeaders.Add("User-Agent", "BusinessApp");
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            try
            {
                NewsAPIResponse? response = await client.GetFromJsonAsync<NewsAPIResponse>(end_point, options);

                if (response != null && response.status == "ok")
                {
                    return View(response.articles);
                } else
                {
                    if (response == null)
                    {
                        return View(new List<Headline>());
                    }
                    else
                    {
                        return View(new List<Headline>());
                    }
                }
            }
            catch (Exception e)
            {
                return View(new List<Headline>());
            }
            
        }
    }
}
