﻿using SiteServer.Utils;

namespace SiteServer.CMS.Api
{
    public class ApiRoutePlugin
    {
        public const string Route = "plugins/{pluginId}";
        public const string RouteAction = "plugins/{pluginId}/{name}";
        public const string RouteActionAndId = "plugins/{pluginId}/{name}/{id}";

        public static string GetUrl(string pluginId, string name = "", string id = "")
        {
            var apiUrl = ApiManager.GetApiUrl(Route);
            apiUrl = apiUrl.Replace("{pluginId}", pluginId);
            if (!string.IsNullOrEmpty(name))
            {
                apiUrl = PageUtils.Combine(apiUrl, name);
                if (!string.IsNullOrEmpty(id))
                {
                    apiUrl = PageUtils.Combine(apiUrl, id);
                }
            }
            return apiUrl;
        }
    }
}