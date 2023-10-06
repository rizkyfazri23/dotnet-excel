// ExcelController.cs
using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Spire.Xls;
using excel.Models;
using System.Net;



namespace excel.Controllers 
{
    [Route("api/excel")]
    [ApiController]
    public class ExcelController : ControllerBase
    {
        private readonly ILogger<ExcelController> _logger;

        public ExcelController(ILogger<ExcelController> logger)
        {
            _logger = logger;
        }

        [HttpGet("generate")]
        [ProducesResponseType(typeof(Excel), (int)HttpStatusCode.OK)]

        public IActionResult GenerateExcel()
        {
            try
            {
                Workbook workbook = new Workbook();

                Worksheet worksheet = workbook.Worksheets.Add("test");

                worksheet.Range["A1"].Text = "Nama";
                worksheet.Range["B1"].Text = "Usia";
                worksheet.Range["C1"].Text = "Testing";
                worksheet.Range["D1"].Text = "Hasil";

                var data = new List<object[]>
                {
                    new object[] { "John", 30, 2 },
                    new object[] { "Jane", 25, 3 },
                    new object[] { "Bob", 35, 4 }
                };

                int rowIdx = 2; 
                foreach (var item in data)
                {
                    worksheet.Range[rowIdx, 1].Text = item[0].ToString();
                    worksheet.Range[rowIdx, 2].NumberValue = Convert.ToDouble(item[1]);
                    worksheet.Range[rowIdx, 3].NumberValue = Convert.ToDouble(item[2]);

                    worksheet.Range[rowIdx, 1].Style.Color = System.Drawing.Color.Red;

                    worksheet.Range[rowIdx, 2].Style.Locked = false;
                    worksheet.Range[rowIdx, 2].Style.Color = System.Drawing.Color.Yellow;

                    worksheet.Range[rowIdx, 3].Style.Locked = false;
                    worksheet.Range[rowIdx, 3].Style.Color = System.Drawing.Color.Gray;

                    rowIdx++;
                }

                for (int i = 2; i < rowIdx; i++)
                {
                    worksheet.Range["D" + i].Formula = "=B" + i + "*C" + i;
                }

                worksheet.Protect("password");

                worksheet.Activate();

                using (MemoryStream ms = new MemoryStream())
                {
                    workbook.SaveToStream(ms, FileFormat.Version2013);

                    var fileContent = ms.ToArray();

                    string fileName = "hasil.xlsx";

                    var excelModel = new Excel
                    {
                        FileExcel = ConvertHelper.fileToString(fileName, fileContent)
                    };

                    return Ok(excelModel);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Gagal menghasilkan file Excel"); 

                return StatusCode(500, "Gagal menghasilkan file Excel");
            }
        }

    }
}
