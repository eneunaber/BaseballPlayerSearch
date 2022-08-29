using CsvHelper.Configuration.Attributes;


public class PitcherSimpleViewModel
{
    public string Name { get; set; }
    public string Team { get; set; }
    public int W { get; set; }
    public int L { get; set; }
    public int SV { get; set; }
    public int G { get; set; }
    public decimal IP { get; set; }
    public string KPer9 { get; set; }
    public string BallsPer9 { get; set; }
    public string HRPer9 { get; set; }
    public decimal BABIP { get; set; }
    public decimal ERA { get; set; }
    public int PlayerID { get; set; }
}
