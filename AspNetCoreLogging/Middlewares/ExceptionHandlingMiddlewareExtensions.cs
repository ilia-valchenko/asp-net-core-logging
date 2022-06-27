using Microsoft.AspNetCore.Diagnostics;

namespace AspNetCoreLogging.Middlewares
{
    public static class ExceptionHandlingMiddlewareExtensions
    {
        public static void ConfigureGlobalExceptionLogging(this IApplicationBuilder appBuilder, ILogger logger)
        {
            if (appBuilder == null)
            {
                throw new ArgumentNullException(nameof(appBuilder));
            }

            appBuilder.UseExceptionHandler(builder =>
                builder.Run(async context =>
                {
                    await Task.Run(() =>
                    {
                        var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                        if (contextFeature != null)
                        {
                            logger.LogError($"Something went wrong: {contextFeature.Error}");
                        }
                    });
                }
            ));
        }
    }
}
