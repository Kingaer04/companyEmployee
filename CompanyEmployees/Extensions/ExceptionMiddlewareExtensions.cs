using Contracts;
using Entities.ErrorModel;
using Entities.Exceptions;
using Microsoft.AspNetCore.Diagnostics;

namespace CompanyEmployees.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this WebApplication app, ILoggerManager logger)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    Console.WriteLine("========================================");
                    Console.WriteLine("EXCEPTION HANDLER ENTERED");
                    Console.WriteLine("========================================");

                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                    Console.WriteLine($"contextFeature is null: {contextFeature == null}");

                    if (contextFeature != null)
                    {
                        Console.WriteLine($"Exception Type: {contextFeature.Error.GetType().Name}");
                        Console.WriteLine($"Exception Message: {contextFeature.Error.Message}");
                        Console.WriteLine($"Exception StackTrace: {contextFeature.Error.StackTrace}");

                        context.Response.StatusCode = contextFeature.Error switch
                        {
                            NotFoundException => StatusCodes.Status404NotFound,
                            _ => StatusCodes.Status500InternalServerError
                        };

                        Console.WriteLine($"Status Code: {context.Response.StatusCode}");

                        logger.LogError($"Something went wrong: {contextFeature.Error}");

                        var errorDetails = new ErrorDetails()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = contextFeature.Error.Message,
                        };

                        Console.WriteLine($"ErrorDetails JSON: {errorDetails.ToString()}");
                        Console.WriteLine($"About to write response...");

                        await context.Response.WriteAsJsonAsync(errorDetails);

                        Console.WriteLine($"Response written!");
                        Console.WriteLine($"Response HasStarted: {context.Response.HasStarted}");
                        Console.WriteLine($"Response ContentLength: {context.Response.ContentLength}");
                    }

                    Console.WriteLine("========================================");
                    Console.WriteLine("EXCEPTION HANDLER COMPLETED");
                    Console.WriteLine("========================================");
                });
            });
        }
    }
}