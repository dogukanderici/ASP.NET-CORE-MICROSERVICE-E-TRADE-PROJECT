namespace MultiShop.WebUI.Utilities.FileOperations
{
    public interface IFileOperationHelper
    {
        Task<string> CopyFileToFoler(FileProperty fileProperty);
    }
}
