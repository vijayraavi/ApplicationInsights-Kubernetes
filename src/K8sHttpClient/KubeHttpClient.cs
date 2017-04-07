﻿namespace Microsoft.ApplicationInsights.Netcore.Kubernetes
{
    using System.Net.Http;
    using System.Net.Http.Headers;

    internal class KubeHttpClient : HttpClient
    {
        public KubeHttpClientSettingsProvider Settings { get; private set; }

        public KubeHttpClient(KubeHttpClientSettingsProvider settingsProvider) : base(settingsProvider.CreateMessageHandler())
        {
            this.Settings = settingsProvider;
            string token = settingsProvider.GetToken();
            if (!string.IsNullOrEmpty(token))
            {
                this.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
            this.BaseAddress = settingsProvider.ServiceBaseAddress;
        }
    }
}