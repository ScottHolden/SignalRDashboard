using System;
using Microsoft.Owin;
using Microsoft.Owin.FileSystems;
using Microsoft.Owin.StaticFiles;
using Owin;
[assembly: OwinStartup(typeof(SignalRDashboard.Startup))]

namespace SignalRDashboard
{
	public class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			app.MapSignalR();

			string appDataPath = AppDomain.CurrentDomain.GetData("DataDirectory").ToString();

			PhysicalFileSystem fileSystem = new PhysicalFileSystem(appDataPath);

			FileServerOptions fileServerOptions = new FileServerOptions
			{
				EnableDefaultFiles = true,
				EnableDirectoryBrowsing = false,
				FileSystem = fileSystem
			};

			fileServerOptions.StaticFileOptions.ServeUnknownFileTypes = true;
			fileServerOptions.StaticFileOptions.FileSystem = fileSystem;
			fileServerOptions.DefaultFilesOptions.DefaultFileNames = new[] { "index.html" };

			app.UseFileServer(fileServerOptions);
		}
	}
}