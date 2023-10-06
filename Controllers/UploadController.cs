using APIMDEmployee.Data;
using APIMDEmployee.Models;
using APIMDEmployee.Utils;

using Microsoft.AspNetCore.Mvc;

using NPOI.SS.UserModel;

using System.Net;

namespace APIMDEmployee.Controllers
{
    [ApiController]
    [Route("api/UploadMDEmployee")]
    public class UploadController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ePaymentContext _context;
        private readonly ILogger<UploadController> _logger;

        public UploadController(IConfiguration configuration, ePaymentContext context, ILogger<UploadController> logger)
        {
            _configuration = configuration;
            _context = context;
            _logger = logger;
        }

        [HttpPost]
        [ProducesResponseType(typeof(List<UploadResponseDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UploadFile(IFormFile fileData)
        {
            try
            {
                List<UploadResponseDto> response = new List<UploadResponseDto>();

                if (fileData.Length > 0)
                {

                    string? folderPath = _configuration.GetSection("FolderPath").Value;
                    if (folderPath != null)
                    {
                        if (!Directory.Exists(folderPath))
                        {
                            Directory.CreateDirectory(folderPath);
                        }

                        string filePath = Path.Combine(folderPath, Guid.NewGuid().ToString() + "-" + fileData.FileName);
                        using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await fileData.CopyToAsync(fileStream);
                            fileStream.Close();
                        }

                        // Read excel file
                        ISheet excelSheet = filePath.GetFirstSheet();

                        ReadExcelDataManager excelDataManager = new ReadExcelDataManager(_context);
                        response = excelDataManager.GetDataFromExcel(excelSheet);
                    }
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }


        }
    }
}
