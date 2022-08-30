using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BaseballPlayerSearch.Models;
using CsvHelper;
using System.Globalization;
using AutoMapper;
using BaseballPlayerSearch.Services;

namespace BaseballPlayerSearch.Controllers;

public class BatterController : Controller
{
    private readonly ILogger<BatterController> _logger;
    private readonly IMapper _mapper;
    private readonly ILaunchDarklyService _ldService;

    public BatterController(ILogger<BatterController> logger, IMapper mapper, ILaunchDarklyService ldService)
    {
        _logger = logger;
        _mapper = mapper;
        _ldService = ldService;
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

        var flagValue = _ldService.GetLdClient().BoolVariation("EnhancedStatistics", _ldService.GetLdUser(), false);
        ViewBag.EnhancedStatistics = flagValue;
        if (flagValue)
        {
            List<BatterEnhancedViewModel> viewBatters = new List<BatterEnhancedViewModel>();
            batters.ForEach(x =>
            {
                viewBatters.Add(_mapper.Map<BatterEnhancedViewModel>(x));
            });
            ViewBag.Batters = viewBatters;
        }
        else
        {
            List<BatterSimpleViewModel> viewBatters = new List<BatterSimpleViewModel>();
            batters.ForEach(x =>
            {
                viewBatters.Add(_mapper.Map<BatterSimpleViewModel>(x));
            });
            ViewBag.Batters = viewBatters;
        }
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
