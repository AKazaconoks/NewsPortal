namespace ForTEsts.Services
{
    public class AvatarService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AvatarService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public string UploadPhoto(IFormFile file)
        {
            if (file == null)
            {
                return "nofile.png";
            }

            var fileName = Path.GetFileName(file.FileName);
            var random = Guid.NewGuid() + fileName;
            var path = Path.Combine(_webHostEnvironment.WebRootPath, "Content/Images/UserImages");
            var filePath = Path.Combine(path, random);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }

            return random;
        }
    }
}
