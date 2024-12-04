namespace MyArchive.ApiService.Services
{
    public class ImageService
    {
        private readonly string _imagePath;

        public ImageService(string imagePath)
        {
            _imagePath = imagePath;
        }

        public byte[]? GetImageBytes(string imageName)
        {
            var filePath=Path.Combine(_imagePath, imageName);
            if (File.Exists(filePath))
            {
                return File.ReadAllBytes(filePath);
            }
            return null;
        }

        public string GetMineType(string imageName) {
            var extension = Path.GetExtension(imageName).ToLower();
            return extension switch
            {
                ".jpg" or ".jpeg" => "image/jpeg",
                "png" => "image/png",
                _=>"application/octet-stream"
            };
            }
    }
}
