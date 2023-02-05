using Lab12.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Xml.Serialization;
using System.Text;
using System.Text.Json;
using System.Security.Cryptography;
using System;

namespace Lab12.Controllers
{
  public class HomeController : Controller
  {
    private readonly ILogger<HomeController> _logger;
    private readonly string path = @"D:/C#/TMS/Lab12/List.xml";

    public HomeController(ILogger<HomeController> logger)
    {
      _logger = logger;
    }

    [HttpPost]
    public IActionResult SaveData([FromForm] string name, [FromForm] string sname, [FromForm] string age, [FromForm] string email, [FromForm] string pas, [FromForm] string number)
    {
      FileInfo fileInf = new FileInfo(path);
      List<BaseModel> lbase = new List<BaseModel>();      
      if (fileInf.Exists) lbase = DeserializeList();

      var b = new BaseModel(name, sname, age, email, pas, number);
      lbase.Add(b);

      SerealizeList(lbase);

      return RedirectToAction("Index");
    }

    public List<BaseModel> DeserializeList()
    {      
      List<BaseModel> l = new List<BaseModel>();      
      string s;
      XmlSerializer xml = new XmlSerializer(typeof(List<BaseModel>));
      using (Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.None))
      {
        l = (List<BaseModel>) xml.Deserialize(stream);
      }
      return l;
    }


    public void SerealizeList(List<BaseModel> l)
    {
      XmlSerializer xml = new XmlSerializer(typeof(List<BaseModel>));
      using (Stream stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
      {
        xml.Serialize(stream, l);
      }
    }

    public IActionResult Index()
    {
      return View();
    }

    public IActionResult Privacy()
    {
      return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}