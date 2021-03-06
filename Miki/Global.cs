﻿using SharpRaven;
using System;
using StatsdClient;
using StackExchange.Redis.Extensions.Core;
using Newtonsoft.Json;
using Miki.Framework.FileHandling;
using Miki.API;

namespace Miki
{
    /// <summary>
    /// Global data for constant folder structures and versioning.
    /// </summary>
    public class Global
    {
        public static RavenClient ravenClient;
		public static ICacheClient redisClient;
		public static Config Config
		{
			get
			{
				if (config == null)
				{
					if (FileReader.FileExist("settings.json", "miki"))
					{
						FileReader reader = new FileReader("settings.json", "miki");
						config = JsonConvert.DeserializeObject<Config>(reader.ReadAll());
						reader.Finish();
					}
					else
					{
						FileWriter writer = new FileWriter("settings.json", "miki");
						writer.Write(JsonConvert.SerializeObject(new Config(), Formatting.Indented));
						writer.Finish();
						config = new Config();
					}
				}
				return config;
			}
		}
		public static MikiApi MikiApi => mikiApi;

		private static Config config = null;
		private static MikiApi mikiApi = new MikiApi(Config.MikiApiBaseUrl, Config.MikiApiKey);
	}
  
	  public class Constants
    {
        public const string NotDefined = "$not-defined";
    }
}