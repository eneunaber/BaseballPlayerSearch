using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BaseballPlayerSearch.Models;
using CsvHelper;
using System.Globalization;
using AutoMapper;

namespace BaseballPlayerSearch.Controllers;

public class BatterController : Controller
{
    private readonly ILogger<BatterController> _logger;
    private readonly IMapper _mapper;

    public BatterController(ILogger<BatterController> logger, IMapper mapper)
    {
        _logger = logger;
        _mapper = mapper;
    }

    public IActionResult Index()
    {
        List<Batter> batters;
        var fileInfo = new FileInfo(System.Reflection.Assembly.GetExecutingAssembly().Location);
        using (var reader = new StreamReader(Path.Combine(fileInfo.DirectoryName, "Data/FanGraphs-Leaderboard-Batters.csv")))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            batters = csv.GetRecords<Batter>().ToList();
        }


        List<BatterSimpleViewModel> viewBatters = new List<BatterSimpleViewModel>();
        batters.ForEach(x =>
        {
            viewBatters.Add(_mapper.Map<BatterSimpleViewModel>(x));
        });
        // var viewBatters = _mapper.Map<List<BatterSimpleViewModel>>(batters);
        ViewBag.Batters = viewBatters;
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
