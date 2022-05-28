using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using parish_bookstore.Utilities;

namespace parish_bookstore.Models
{
    public class ImageModel : PageModel
    {
        private readonly long _fileSizeLimit = 2097152;
        private readonly string[] _permittedExtensions = { ".txt" };
        private readonly string _targetFilePath = "c:\\users\\chris\\Repos\\Web Pages and Applications\\Dynamic Projects\\parish-bookstore\\wwwroot\\media\\images";

        [BindProperty]
        public Image FileUpload { get; set; }

        public string Result { get; private set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostUploadAsync()
        {
            if (!ModelState.IsValid)
            {
                Result = "Please correct the form.";

                return Page();
            }

            var formFileContent = 
                await FileHelpers.ProcessFormFile<Image>(
                    FileUpload.FormFile, ModelState, _permittedExtensions, 
                    _fileSizeLimit);

            if (!ModelState.IsValid)
            {
                Result = "Please correct the form.";

                return Page();
            }

            // For the file name of the uploaded file stored
            // server-side, use Path.GetRandomFileName to generate a safe
            // random file name.
            var trustedFileNameForFileStorage = Path.GetRandomFileName();
            var filePath = Path.Combine(
                _targetFilePath, trustedFileNameForFileStorage);
            FileUpload.FileName = trustedFileNameForFileStorage;
            // **WARNING!**
            // In the following example, the file is saved without
            // scanning the file's contents. In most production
            // scenarios, an anti-virus/anti-malware scanner API
            // is used on the file before making the file available
            // for download or for use by other systems. 
            // For more information, see the topic that accompanies 
            // this sample.

            using (var fileStream = System.IO.File.Create(filePath))
            {
                await fileStream.WriteAsync(formFileContent);

                // To work directly with a FormFile, use the following
                // instead:
                //await FileUpload.FormFile.CopyToAsync(fileStream);
            }

            return RedirectToPage("./Index");
        }
    }

    public class Image
    {
        [Required]
        [Display(Name="File")]
        public IFormFile FormFile { get; set; }

        public string FileName {get; set;}

    }
}