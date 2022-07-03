# asp-net-core-logging
- For handling and logging errors globally we can use built-in middleware `UseExceptionHandler`.
- As an alternative approach we can implement `IExceptionFilter` interface.

## Note
IMPORTANT! The order is important! It won't work if you will put `app.ConfigureGlobalExceptionLogging(...)` after `app.UseEndpoints(...)`.

## Details
 - The `appsettings.Default.json` contains configuration for different built-in log providers.
 - The Log4Net log file can be found in `bin\Debug\net6.0`.
 
 ## Configure logging in appsettings.json
 Example:
 
 ```json
 {
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "Debug": { 
      "LogLevel": {
        "Default": "Information",
        "Microsoft.Hosting": "Trace"
      }
    },
	"EventSource": {
      "LogLevel": {
        "Default": "Warning"
      }
    }
}
 ```
 
 - `Default` and `Microsoft.AspNetCore` are categories.
 - The category string is arbitrary, but the convention is to use the class name.
 - `Microsoft.AspNetCore` category applies to all categories that start with `Microsoft.AspNetCore`. For example: `Microsoft.AspNetCore.Routing.EndpointMiddleware`.
 - The `Microsoft.AspNetCore` category logs at log level Warning and higher.