using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

[Route("api/[controller]")]
[ApiController]
public class DataController : ControllerBase
{
    private readonly List<string> dataArray = new List<string>
    {
        "Data1",
        "Data2",
        "Data3"
    };

    [HttpGet]
    public IActionResult GetData()
    {
        return Ok(dataArray);
    }
}
