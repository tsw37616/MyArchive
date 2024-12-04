using Microsoft.AspNetCore.Http.HttpResults;
using MyArchive.ApiService.Services;

namespace MyArchive.ApiService.Endpoints
{
    public static class ImageEndpoints
    {
        public static void MapImageEndpoints(this WebApplication app)
        {
            var image = app.MapGroup("/api/image");
            image.MapGet("/", () => "this is a image api");
            image.MapGet("/{imageName}",GetImageAsync);
        }


        private static async Task<Results<Ok,NotFound>> GetImageAsync(string imageName,ImageService imageservice,HttpContext context)
        {
            var imageBytes=imageservice.GetImageBytes(imageName);
            if (imageBytes == null)
            {
                return TypedResults.NotFound();
            }
            var mineType=imageservice.GetMineType(imageName);
            context.Response.ContentType=mineType.ToString();
            await context.Response.Body.WriteAsync(imageBytes);

            return TypedResults.Ok();
        }
    }
}
