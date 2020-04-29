using Microsoft.Extensions.Hosting;
using Jlion.NetCore.User.Application.Constracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;


namespace Jlion.NetCore.User.Application.Test
{
	public class BaseTest
	{
		protected IServiceProvider servProvider;

		public IUserService userService;

		public BaseTest()
		{
			ConfigurationBuilder configbuild = new ConfigurationBuilder();
			configbuild.AddJsonFile("appsettings.json", true);

			var cBuild = configbuild.Build();
			var serviceCollection = new ServiceCollection();
			serviceCollection.AddSingleton<IConfiguration>(cBuild);
			serviceCollection.AddApplicationDI();
			servProvider = serviceCollection.BuildServiceProvider();

			userService = servProvider.GetService<IUserService>();

		}
	}
}
