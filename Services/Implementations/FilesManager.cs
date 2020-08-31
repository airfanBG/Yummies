using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementations
{
    public class FilesManager
    {
        public async Task<List<string>> AddFile(List<IFormFile> files,string path,string folder)
        {
            List<string> paths = new List<string>();
            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    Directory.CreateDirectory(Path.Combine(path, folder));

                    using (var stream = System.IO.File.Create(Path.Combine(path, folder + "\\" + formFile.FileName)))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                    paths.Add(Path.Combine(path, folder + "\\" + formFile.FileName));
                }
            }
            return paths;
        }
       
    }
}
