using Microsoft.AspNetCore.Http.HttpResults;
using MyArchive.ApiService.Services;

namespace MyArchive.ApiService.Endpoints
{
    public static class ImageEndpoints
    {
        public static void MapImageEndpoints(this WebApplication app)
        {
            var image = app.MapGroup("/api/image");
            image.MapGet("/", () => "this is an image api");
            image.MapGet("/{imageName}", GetImageAsync);
        }

        private static async Task GetImageAsync(string imageName, ImageService imageService, HttpContext context)
        {
            try
            {
                var imageBytes = imageService.GetImageBytes(imageName);
                if (imageBytes == null)
                {
                    context.Response.StatusCode = StatusCodes.Status404NotFound;
                    await context.Response.WriteAsync("Image not found");
                  
                }

                var mimeType = imageService.GetMineType(imageName);
                context.Response.ContentType = mimeType;
                context.Response.ContentLength = imageBytes.Length;

                await context.Response.Body.WriteAsync(imageBytes, 0, imageBytes.Length);
               
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsync("An error occurred while processing your request.");
                
            }
        }

    }




}
