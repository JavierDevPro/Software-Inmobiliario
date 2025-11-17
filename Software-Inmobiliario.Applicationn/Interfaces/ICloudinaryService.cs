using Microsoft.AspNetCore.Http;

namespace Software_Inmobiliario.Applicationn.Interfaces;

public interface ICloudinaryService
{
    Task<string> UploadImageAsync(IFormFile file);
}