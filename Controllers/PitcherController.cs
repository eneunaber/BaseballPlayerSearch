using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BaseballPlayerSearch.Models;
using CsvHelper;
using System.Globalization;
using AutoMapper;

namespace BaseballPlayerSearch.Controllers;

public class PitcherController : Controller
{
    private readonly ILogger<PitcherController> _logger;
    private readonly IMapper _mapper;

    public PitcherController(ILogger<PitcherController> logger, IMapper mapper)
    {
        _logger = logger;
        _mapper = mapper;
    }

    public IActionResult Index()
    {
        List<Pitcher> pitchers;
        var fileInfo = new FileInfo(System.Reflection.Assembly.GetExecutingAssembly().Location);
        using (var reader = new StreamReader(Path.Combine(fileInfo.DirectoryName, "Data/FanGraphs-Leaderboard-Pitchers.csv")))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            pitchers = csv.GetRecords<Pitcher>().ToList();
        }

        List<PitcherSimpleViewModel> viewPitchers = new List<PitcherSimpleViewModel>();
        pitchers.ForEach(x =>
        {
            viewPitchers.Add(_mapper.Map<PitcherSimpleViewModel>(x));
        });
        ViewBag.Pitchers = viewPitchers;
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
