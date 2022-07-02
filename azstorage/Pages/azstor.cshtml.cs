using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace azstorage.Pages;

public class azstorModel : PageModel

{
    private readonly IConfiguration _configuration;
    public azstorModel(IConfiguration configuration)
    {
        _configuration = configuration;

    }

    public async Task OnGet()
    {
        int dog = 0;
        string StoCnString = _configuration["AZURE_STORAGE_CONNECTION_STRING"];
        string StoContainerString = _configuration["ImageContainer"];
        dog++;


        // Create the container and return a container client object
        BlobContainerClient containerClient = new BlobContainerClient(StoCnString, StoContainerString);


        string fileName = "./images/empress.jpg";


        BlobClient blobClient = containerClient.GetBlobClient(fileName);
        await blobClient.UploadAsync(fileName, true);
    }
}