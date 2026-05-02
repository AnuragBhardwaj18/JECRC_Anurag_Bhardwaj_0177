using EMS.Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace EMS.Mvc.Controllers;

public class EmployeeController : Controller
{
    private readonly string apiUrl = "https://localhost:7051/api/employee";

    public async Task<IActionResult> Index()
    {
        using HttpClient client = new HttpClient();

        var response = await client.GetAsync(apiUrl);
        var jsonData = await response.Content.ReadAsStringAsync();

        var employees = JsonConvert.DeserializeObject<List<Employee>>(jsonData);

        return View(employees);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Employee employee)
    {
        using HttpClient client = new HttpClient();

        var json = JsonConvert.SerializeObject(employee);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        await client.PostAsync(apiUrl, content);

        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Edit(int id)
    {
        using HttpClient client = new HttpClient();

        var response = await client.GetAsync($"{apiUrl}/{id}");
        var jsonData = await response.Content.ReadAsStringAsync();

        var employee = JsonConvert.DeserializeObject<Employee>(jsonData);

        return View(employee);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Employee employee)
    {
        using HttpClient client = new HttpClient();

        var json = JsonConvert.SerializeObject(employee);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        await client.PutAsync($"{apiUrl}/{employee.Id}", content);

        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Delete(int id)
    {
        using HttpClient client = new HttpClient();

        await client.DeleteAsync($"{apiUrl}/{id}");

        return RedirectToAction("Index");
    }
}