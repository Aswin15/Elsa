using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elsa.Infrastructure.DocumentService
{
    public class ModifyDocument
    {
        public async Task UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                throw new Exception();

            var path = Path.Combine(
                        Directory.GetCurrentDirectory(), "uploadedDocs",
                        file.FileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
        }

        public void CreateFileAsync()
        {
            // Create a string array with the lines of text
            string[] lines = { "First line", "Second line", "Third line" };

            // Set a variable to the Documents path.
            string docPath = Path.Combine(
                        Directory.GetCurrentDirectory(), "uploadedDocs",
                        "New_File");

            // Write the string array to a new file named "WriteLines.txt".
            using (StreamWriter outputFile = new(docPath))
            {
                foreach (string line in lines)
                    outputFile.WriteLine(line);
            }
        }
    }
}
