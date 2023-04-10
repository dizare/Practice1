using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Configuration;
using Practice.Core;
using Practice1.Core;
using System.Collections.Generic;

namespace Practice.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]

public class StringsController : ControllerBase
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration configuration;

    public StringsController(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        this.configuration = configuration;
    }

    [HttpGet]
    public async Task<IActionResult> ProceedString(string inputString, [FromQuery] SortingModel sorting)
    {
        AppSettings settings = AppSettings.Load();
        if (!StringHelper.ValidateString(inputString, out var invalidChars))
        {
            return BadRequest(new
            {
                message = "Были введены неподходящие символы",
                badCharacters = invalidChars.Select(x => x)
            });
        }
        List<string> blacklistWordsFound = new List<string>();
        foreach (string blacklistedWord in settings.Settings.Blacklist)
        {
            if (inputString.Contains(blacklistedWord))
            {
                blacklistWordsFound.Add(blacklistedWord);
            }
        }

        if (blacklistWordsFound.Count > 0)
        {
            string errorMessage = $"Используются слова из Blacklist: {string.Join(", ", blacklistWordsFound)}";
            return BadRequest(errorMessage);
        }

        var halfLengthLine = inputString.Length / 2;
        var reversedString = inputString.Length % 2 == 0
            ? StringHelper.ReverseString(inputString.Substring(0, halfLengthLine)) +
              StringHelper.ReverseString(inputString.Substring(halfLengthLine))
            : StringHelper.ReverseString(inputString) + inputString;

        object sortedProceededString = sorting.Sorting switch
        {
            SortingEnum.Quick => Sort.QuickSort(reversedString),
            SortingEnum.Tree => Sort.TreeSort(reversedString),
            _ => string.Empty
        };

        var stringWithRemovedIndex = await RemoveRandomChar(reversedString);


        return Ok(new
        {
            proceededString = reversedString,
            countCharacters = StringHelper.CountRepeatedCharacters(reversedString),
            longestVowelSubstring = StringHelper.FindLongestVowelSubstring(reversedString),
            sortedString = sortedProceededString,
            stringWithRemovedChar = stringWithRemovedIndex
        });
    }

    private async Task<int> GetRandomNumberByApi(int stringLength)
    {
        var url = configuration.GetValue<string>("RandomAPI");
        var response = await _httpClient.GetAsync(url);
        var responseBody = await response.Content.ReadAsStringAsync();
        return int.Parse(responseBody);
    }


    private async Task<string> RemoveRandomChar(string inputString)
    {
        try
        {
            var randomNumberByApi = await GetRandomNumberByApi(inputString.Length);
            return inputString.Remove(randomNumberByApi, 1);
        }
        catch (Exception)
        {
            var randomNumberByNet = new Random().Next(inputString.Length);
            return inputString.Remove(randomNumberByNet, 1);
        }
    }
}
