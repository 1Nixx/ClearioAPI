using Core.CleanerRepository;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
	public class CleanerRepository : ICleanerRepository
	{
		private readonly HttpClient _httpClient;
		public CleanerRepository()
		{
			_httpClient = new HttpClient();
			_httpClient.BaseAddress = new Uri("http://127.0.0.1:8000/");
			_httpClient.DefaultRequestHeaders.Accept.Clear();
			_httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
		}
		 
		public Task<int> AddCleanerAsync(CleanerShortInfo cleanerInfo)
		{
			var newCleaner = new CleanerRemoteInfo()
			{
				name = cleanerInfo.CleanerName.Split(" ")[0],
				surname = cleanerInfo.CleanerName.Split(" ")[1],
				//city = city,
				isworking = false,
				phonenumber = cleanerInfo.PhoneNumber,
				rating = 0
			};
			return Task.FromResult(0);
		}

		public async Task<List<CleanerInfo>> GetAllCleanersAsync()
		{
			var resultList = new List<CleanerInfo>();
			HttpResponseMessage response = await _httpClient.GetAsync("cleaners/");
			if (response.IsSuccessStatusCode)
			{
				var cleaners = await response.Content.ReadFromJsonAsync<CleanerRemoteInfo[]>();
				for (int i = 0; i < cleaners.Length; i++)
					resultList.Add(GetCleanerInfoFromRemote(cleaners[i]));
			}
			return resultList;
		}

		public async Task<List<CleanerInfo>> GetALLCleanersByAddressAsync(string address)
		{
			var resultList = new List<CleanerInfo>();
			var city = GetCityFromAddress(address);
			HttpResponseMessage response = await _httpClient.GetAsync($"cleaners/?city={city}");
			if (response.IsSuccessStatusCode)
			{
				var cleaners = await response.Content.ReadFromJsonAsync<CleanerRemoteInfo[]>();
				for (int i = 0; i < cleaners.Length; i++)
					resultList.Add(GetCleanerInfoFromRemote(cleaners[i]));
			}
			return resultList;
		}

		public async Task<CleanerInfo> GetCleanerAsync(string address)
		{
			var result = new CleanerInfo();
			var city = GetCityFromAddress(address);
			HttpResponseMessage response = await _httpClient.GetAsync($"byone/?city={city}");
			if (response.IsSuccessStatusCode)
			{
				var cleaners = await response.Content.ReadFromJsonAsync<ByoneRemoteInfo>();
				result = GetCleanerInfoFromRemote(cleaners.results[0]);
			}
			return result;
		}

		public async Task<CleanerInfo> GetCleanerByIdAsync(int cleanerId)
		{
			var result = new CleanerInfo();
			HttpResponseMessage response = await _httpClient.GetAsync($"cleaners/{cleanerId}");
			if (response.IsSuccessStatusCode)
			{
				var cleaner = await response.Content.ReadFromJsonAsync<CleanerRemoteInfo>();
				result = GetCleanerInfoFromRemote(cleaner);
			}
			return result;
		}

		public async Task<List<CleanerInfo>> GetSetOfCleanersAsync(int amount, string address)
		{
			var resultList = new List<CleanerInfo>();
			var city = GetCityFromAddress(address);
			HttpResponseMessage response = await _httpClient.GetAsync($"byone/?city={city}&limit={amount}&offset=1");
			if (response.IsSuccessStatusCode)
			{
				var cleaners = await response.Content.ReadFromJsonAsync<ByoneRemoteInfo>();
				for (int i = 0; i < cleaners.results.Length; i++)
					resultList.Add(GetCleanerInfoFromRemote(cleaners.results[i]));
			}
			return resultList;
		}

		public Task RemoveCleanerAsync(int cleanerId)
		{
			return Task.CompletedTask;
		}

		public static CleanerInfo GetCleanerInfoFromRemote(CleanerRemoteInfo cleanerRemote)
		{
			return new CleanerInfo()
			{
				CleanerId = cleanerRemote.id,
				CleanerName = cleanerRemote.name + " " + cleanerRemote.surname,
				PhoneNumber = cleanerRemote.phonenumber
			};
		}
	
		public static string GetCityFromAddress(string address)
		{
			var items = address.Split(" ", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
			return items[0];
		}
	}
}
