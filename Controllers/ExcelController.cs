// ExcelController.cs
using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging; // Tambahkan ini
using Spire.Xls;
using excel.Models;

namespace excel.Controllers // Ubah namespace ke "excel.Controllers"
{
    [Route("api/excel")]
    [ApiController]
    public class ExcelController : ControllerBase
    {
        private readonly ILogger<ExcelController> _logger; // Tambahkan ini

        public ExcelController(ILogger<ExcelController> logger) // Tambahkan ini
        {
            _logger = logger;
        }

        [HttpGet("generate")]
        public IActionResult GenerateExcel()
        {
            try
            {
                 // Buat workbook baru
                Workbook workbook = new Workbook();

                // Buat worksheet baru
                Worksheet worksheet = workbook.Worksheets.Add("test");

                // Tambahkan data ke dalam worksheet
                worksheet.Range["A1"].Text = "Nama";
                worksheet.Range["B1"].Text = "Usia";
                worksheet.Range["C1"].Text = "Testing";
                worksheet.Range["D1"].Text = "Hasil";

                // Contoh data
                var data = new List<object[]>
                {
                    new object[] { "John", 30, 2 },
                    new object[] { "Jane", 25, 3 },
                    new object[] { "Bob", 35, 4 }
                };

                int rowIdx = 2; // Mulai dari baris kedua
                foreach (var item in data)
                {
                    worksheet.Range[rowIdx, 1].Text = item[0].ToString();
                    worksheet.Range[rowIdx, 2].NumberValue = Convert.ToDouble(item[1]);
                    worksheet.Range[rowIdx, 3].NumberValue = Convert.ToDouble(item[2]);

                    // Memberi warna latar belakang sel di kolom "Nama" menjadi merah
                    worksheet.Range[rowIdx, 1].Style.Color = System.Drawing.Color.Red;

                    worksheet.Range[rowIdx, 2].Style.Locked = false;
                    // Memberi warna latar belakang sel di kolom "Usia" menjadi kuning
                    worksheet.Range[rowIdx, 2].Style.Color = System.Drawing.Color.Yellow;

                    worksheet.Range[rowIdx, 3].Style.Locked = false;
                    // Memberi warna latar belakang sel di kolom "Testing" menjadi abu-abu
                    worksheet.Range[rowIdx, 3].Style.Color = System.Drawing.Color.Gray;

                    rowIdx++;
                }

                for (int i = 2; i < rowIdx; i++)
                {
                    worksheet.Range["D" + i].Formula = "=B" + i + "*C" + i;
                }

                // Aktifkan proteksi lembar kerja
                worksheet.Protect("password");

                // Jadikan worksheet "NamaWorksheet" sebagai worksheet default
                worksheet.Activate();

                // Buat memory stream untuk menyimpan file Excel
                using (MemoryStream ms = new MemoryStream())
                {
                    // Simpan workbook ke memory stream
                    workbook.SaveToStream(ms, FileFormat.Version2013);

                    // Set nama file yang akan diunduh oleh klien
                    string fileName = "hasil.xlsx";

                    // Kembalikan file Excel ke klien
                    var fileContent = ms.ToArray();
                    return File(fileContent, "application/vnd.ms-excel", fileName);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Gagal menghasilkan file Excel"); // Log pesan kesalahan
                return StatusCode(500, "Gagal menghasilkan file Excel");
            }
        }

        [HttpGet("generate2")]
        public IActionResult GenerateExcel2()
        {
            try
            {
                // Buat workbook baru
                Workbook workbook = new Workbook();

                // Buat worksheet baru
                Worksheet worksheet = workbook.Worksheets.Add("test");

                // Tambahkan data ke dalam worksheet
                worksheet.Range["A1"].Text = "Nama";
                worksheet.Range["B1"].Text = "Usia";
                worksheet.Range["C1"].Text = "Testing";
                worksheet.Range["D1"].Text = "Hasil";

                // Contoh data
                var data = new List<object[]>
                {
                    new object[] { "John", 30, 2 },
                    new object[] { "Jane", 25, 3 },
                    new object[] { "Bob", 35, 4 }
                };

                int rowIdx = 2; // Mulai dari baris kedua
                foreach (var item in data)
                {
                    worksheet.Range[rowIdx, 1].Text = item[0].ToString();
                    worksheet.Range[rowIdx, 2].NumberValue = Convert.ToDouble(item[1]);
                    worksheet.Range[rowIdx, 3].NumberValue = Convert.ToDouble(item[2]);

                    // Memberi warna latar belakang sel di kolom "Nama" menjadi merah
                    worksheet.Range[rowIdx, 1].Style.Color = System.Drawing.Color.Red;

                    worksheet.Range[rowIdx, 2].Style.Locked = false;
                    // Memberi warna latar belakang sel di kolom "Usia" menjadi kuning
                    worksheet.Range[rowIdx, 2].Style.Color = System.Drawing.Color.Yellow;

                    worksheet.Range[rowIdx, 3].Style.Locked = false;
                    // Memberi warna latar belakang sel di kolom "Testing" menjadi abu-abu
                    worksheet.Range[rowIdx, 3].Style.Color = System.Drawing.Color.Gray;

                    rowIdx++;
                }

                for (int i = 2; i < rowIdx; i++)
                {
                    worksheet.Range["D" + i].Formula = "=B" + i + "*C" + i;
                }

                // Aktifkan proteksi lembar kerja
                worksheet.Protect("password");

                // Jadikan worksheet "NamaWorksheet" sebagai worksheet default
                worksheet.Activate();

                // Buat memory stream untuk menyimpan file Excel
                using (MemoryStream ms = new MemoryStream())
                {
                    // Simpan workbook ke memory stream
                    workbook.SaveToStream(ms, FileFormat.Version2013);

                    // Kembalikan file Excel ke klien
                    var fileContent = ms.ToArray();

                    string fileName = "hasil.xlsx";

                    // Buat model Excel
                    var excelModel = new Excel
                    {
                        FileExcel = File(fileContent, "application/vnd.ms-excel", fileName).FileContents,
                    };

                    // Kembalikan model Excel sebagai respons
                    return Ok(excelModel);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Gagal menghasilkan file Excel"); // Log pesan kesalahan

                // Kembalikan respons dengan status error (misalnya, 500) dan pesan kesalahan
                return StatusCode(500, "Gagal menghasilkan file Excel");
            }
        }

    }
}
