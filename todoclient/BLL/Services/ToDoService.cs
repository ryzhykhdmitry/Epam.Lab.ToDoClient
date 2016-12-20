using BLL.Interfaces.DTO;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;

namespace BLL.Services
{
    public static class ToDoService
    {
        /// <summary>
        /// The service URL.
        /// </summary>
        private static readonly string serviceApiUrl = ConfigurationManager.AppSettings["ToDoServiceUrl"];

        /// <summary>
        /// The url for getting all todos.
        /// </summary>
        private static string GetAllUrl = "ToDos?userId={0}";

        /// <summary>
        /// The url for updating a todo.
        /// </summary>
        private static string UpdateUrl = "ToDos";

        /// <summary>
        /// The url for a todo's creation.
        /// </summary>
        private static string CreateUrl = "ToDos";

        /// <summary>
        /// The url for a todo's deletion.
        /// </summary>
        private static string DeleteUrl = "ToDos/{0}";

        private static readonly HttpClient httpClient;

        /// <summary>
        /// Creates the service.
        /// </summary>
        static ToDoService()
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        /// <summary>
        /// Gets all todos for the user.
        /// </summary>
        /// <param name="userId">The User Id.</param>
        /// <returns>The list of todos.</returns>
        public static IList<BllTask> GetItems(int userId)
        {
            var dataAsString = httpClient.GetStringAsync(string.Format(serviceApiUrl + GetAllUrl, userId)).Result;
            return JsonConvert.DeserializeObject<IList<BllTask>>(dataAsString);
        }

        /// <summary>
        /// Creates a todo. UserId is taken from the model.
        /// </summary>
        /// <param name="item">The todo to create.</param>
        public static void CreateItem(BllTask item)
        {
            httpClient.PostAsJsonAsync(serviceApiUrl + CreateUrl, item)
                .Result.EnsureSuccessStatusCode();
        }

        /// <summary>
        /// Updates a todo.
        /// </summary>
        /// <param name="item">The todo to update.</param>
        public static void UpdateItem(BllTask item)
        {
            httpClient.PutAsJsonAsync(serviceApiUrl + UpdateUrl, item)
                .Result.EnsureSuccessStatusCode();
        }

        /// <summary>
        /// Deletes a todo.
        /// </summary>
        /// <param name="id">The todo Id to delete.</param>
        public static void DeleteItem(int id)
        {
            httpClient.DeleteAsync(string.Format(serviceApiUrl + DeleteUrl, id))
                .Result.EnsureSuccessStatusCode();
        }
    }
}
