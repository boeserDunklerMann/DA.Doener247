using Microsoft.Extensions.Logging;

namespace DA.Doener247.SQliteAccess.Test
{
	public static class MauiProgram
	{
		public static MauiApp CreateMauiApp()
		{
			var builder = MauiApp.CreateBuilder();
			builder
				.UseMauiApp<App>()
				.ConfigureFonts(fonts =>
				{
					fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
					fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				});

#if DEBUG
			builder.Logging.AddDebug();
#endif
			builder.Services.AddSingleton(_ => new DbContext(Path.Combine(FileSystem.AppDataDirectory, "doener247.db3")));
			builder.Services.AddTransient<MainPage>();

			return builder.Build();
		}
	}
}
