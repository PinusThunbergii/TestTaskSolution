using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Networking
{
    public static class Helpers
    {
        public static async Task<string> GetContent(string url, Action<HttpRequestHeaders> headerSetter)
        {
            var client = new HttpClient();
            headerSetter(client.DefaultRequestHeaders);
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return content;
        }

        readonly static System.Text.Encoding WINDOWS1251 = Encoding.GetEncoding(1251);
        readonly static System.Text.Encoding UTF8 = Encoding.UTF8;

        static string ConvertWin1251ToUTF8(string inString)
        {
            return UTF8.GetString(WINDOWS1251.GetBytes(inString));
        }
        public static void AddFireFoxHeader(HttpRequestHeaders headers)
        {
            headers.Add("User-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:107.0) Gecko/20100101 Firefox/107.0");
            headers.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,*/*;q=0.8");
            headers.Add("Accept-Language", "en-US,uk;q=0.5");
            headers.Add("Connection", "keep-alive");
            headers.Add("Upgrade-Insecure-Requests", "1");
            headers.Add("Sec-Fetch-Dest", "document");
            headers.Add("Sec-Fetch-Mode", "navigate");
            headers.Add("Sec-Fetch-Site", "none");
            headers.Add("Sec-Fetch-User", "?1");
        }
    }
}
