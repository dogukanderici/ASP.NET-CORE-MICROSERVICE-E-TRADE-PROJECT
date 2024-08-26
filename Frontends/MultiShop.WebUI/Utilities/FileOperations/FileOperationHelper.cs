
namespace MultiShop.WebUI.Utilities.FileOperations
{
    public class FileOperationHelper : IFileOperationHelper
    {
        public async Task<string> CopyFileToFoler(FileProperty fileProperty)
        {
            var resource = Directory.GetCurrentDirectory();
            var extension = Path.GetExtension(fileProperty.LoadedFile.FileName);
            var userFileName = Guid.NewGuid().ToString() + extension;
            var saveLocation = resource + fileProperty.FilePath + userFileName;
            var stream = new FileStream(saveLocation, FileMode.Create);

            await fileProperty.LoadedFile.CopyToAsync(stream);

            return userFileName;
        }
    }
}
