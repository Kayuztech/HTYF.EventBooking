using HTYF.Application.DTOs;
using HTYF.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Text;
using System.Text.Json;

namespace HTYF.Infrastructure.Memberbase
{
    public class MemberbaseService : IMemberbaseService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<MemberbaseService> _logger;

        public MemberbaseService(
            HttpClient httpClient,
            IConfiguration configuration,
            ILogger<MemberbaseService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;

            var apiKey = configuration["Memberbase:ApiKey"];
            if (string.IsNullOrWhiteSpace(apiKey))
            {
                _logger.LogCritical("Memberbase API key is missing from configuration.");
                throw new InvalidOperationException("Memberbase API key is missing.");
            }
        }

        public async Task CreateOrUpdateContactAsync(
            string email,
            string fullName,
            string eventName)
        {
            try
            {
                var payload = new MemberbaseContactDto
                {
                    Email = email,
                    Name = fullName,
                    Tag = $"Event: {eventName}"
                };

                var json = JsonSerializer.Serialize(payload);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                _logger.LogInformation(
                    "Sending contact to Memberbase. Email: {Email}, Event: {Event}",
                    email,
                    eventName);

                var response = await _httpClient.PostAsync("/api/contacts", content);

                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    _logger.LogError(
                        "Memberbase API failed. Status: {StatusCode}, Response: {Response}",
                        response.StatusCode,
                        error);
                }

                response.EnsureSuccessStatusCode();

                _logger.LogInformation(
                    "Memberbase contact created/updated successfully for {Email}",
                    email);
            }
            catch (Exception ex)
            {
                // IMPORTANT: we log but DO NOT crash the booking flow
                _logger.LogError(
                    ex,
                    "Error while syncing booking to Memberbase for {Email}",
                    email);
            }
        }
    }
}