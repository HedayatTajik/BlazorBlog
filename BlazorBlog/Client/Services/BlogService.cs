using BlazorBlog.Shared;
using System.Net.Http.Json;

namespace BlazorBlog.Client.Services
{
    public class BlogService : IBlogService
    {
        private readonly HttpClient _http;
        public BlogService(HttpClient http)
        {
            _http = http;
        }

        public HttpClient Http { get; }

        public async Task<BlogPost> GetBlogPostByUrl(string url)
        {

            var result = await _http.GetAsync($"api/Blog/{url}");
            if (result.StatusCode != System.Net.HttpStatusCode.OK)
            {
                var message = await result.Content.ReadAsStringAsync();
                Console.WriteLine(message);
                return new BlogPost { Title = message };
            }
            {

                return await result.Content.ReadFromJsonAsync<BlogPost>();
            }
        }

        public async Task<List<BlogPost>> GetBlogPosts()
        {
            return await _http.GetFromJsonAsync<List<BlogPost>>("api/Blog/");
        }

        public async Task<BlogPost> CreateNewBlogPost(BlogPost request)
        {
            var result = await _http.PostAsJsonAsync("api/Blog", request);
            return await result.Content.ReadFromJsonAsync<BlogPost>();
        }
    }
}
