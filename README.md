# asp-net-core-logging
- For handling and logging errors globally we can use built-in middleware `UseExceptionHandler`.
- As an alternative approach we can implement `IExceptionFilter` interface.

## Note
IMPORTANT! The order is important! It won't work if you will put `app.ConfigureGlobalExceptionLogging(...)` after `app.UseEndpoints(...)`.

## Details
The `appsettings.Default.json` contains configuration for different built-in log providers.