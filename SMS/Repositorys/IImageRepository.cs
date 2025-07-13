namespace SMS.Repositorys
{
    public interface IImageRepository
    {
        Task<string> UploadAsync(IFormFile file);
    }
}
