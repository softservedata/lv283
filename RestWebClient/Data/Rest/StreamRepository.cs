﻿using System.Collections.Generic;

namespace RestWebClient.Data.Rest
{
	public class StreamRepository
	{
		private volatile static StreamRepository instance;
		private static object lockingObject = new object();

		private StreamRepository()
		{
		}
		public static StreamRepository Get()
		{
			if (instance == null)
			{
				lock (lockingObject)
				{
					if (instance == null)
					{
						instance = new StreamRepository();
					}
				}
			}
			return instance;
		}

		public string Url()
		{
			return "http://httpbin.org/stream/1";
		}		

		public string Id()
		{
			return "0";
		}
		public string Host()
		{
			return "httpbin.org";
		}
		public string Connection()
		{
			return "close";
		}
	}
}
