﻿using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FluentResults;
using Newtonsoft.Json;

namespace CleanHouse.Application.Extensions
{
    /// <summary>
    /// Помощник для API запросов
    /// </summary>
    public static class ApiClientExtensions
    {
        /// <summary>
        /// Post метод для обращения в сервис поручений
        /// </summary>
        public static async Task<Result<TResponse>> SendPostRequestAsync<TResponse>(
            this HttpClient httpClient,
            string jsonData,
            string url,
            Dictionary<string, string> headers = null,
            CancellationToken cts = default)
        {
            if (headers != null)
            {
                foreach (var header in headers)
                    httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);
            }

            var request = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(url, request, cts);
            
            if (!response.IsSuccessStatusCode)
                return Result.Fail($"Запрос завершился неудачно, статус запроса: {response.StatusCode} ({(int)response.StatusCode})");

            var jsonDataResponse = await response.Content.ReadAsStringAsync();
            var responseData = JsonConvert.DeserializeObject<TResponse>(jsonDataResponse);
            
            return Result.Ok(responseData);
        }

        /// <summary>
        /// Post метод для обращения в сервис поручений
        /// </summary>
        public static async Task<Result> SendPostRequestAsync(
            this HttpClient httpClient,
            string json,
            string url,
            Dictionary<string, string> headers = null,
            CancellationToken cts = default)
        {
            if (headers != null)
            {
                foreach (var header in headers)
                    httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);
            }

            var request = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(url, request, cts);

            if (!response.IsSuccessStatusCode)
                return Result.Fail($"Статус запроса: {response.StatusCode}");

            return Result.Ok();
        }

        /// <summary>
        /// Post метод для обращения в сервис поручений
        /// </summary>
        public static async Task<Result<TResponse>> SendGetRequestAsync<TResponse>(
            this HttpClient httpClient,
            string url,
            Dictionary<string, string> args = default,
            Dictionary<string, string> headers = default,
            CancellationToken cts = default)
        {
            var urlSb = new StringBuilder(url);

            if (!headers.IsNullOrEmpty())
            {
                foreach (var header in headers)
                    httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);
            }

            if (!args.IsNullOrEmpty())
            {
                urlSb.Append("?");
                var argsList = args.Select(arg => $"{arg.Key}={arg.Value}");
                urlSb.Append(string.Join("&", argsList));
            }

            var response = await httpClient.GetAsync(urlSb.ToString(), cts);

            if (!response.IsSuccessStatusCode)
                return Result.Fail($"Запрос завершился неудачно, статус: {response.StatusCode}");

            var jsonData = await response.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<TResponse>(jsonData);
            return Result.Ok(data);
        }
    }
}