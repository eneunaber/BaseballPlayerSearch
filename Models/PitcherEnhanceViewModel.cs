using CsvHelper.Configuration.Attributes;


public class PitcherEnhanceViewModel
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
    public string LOBPercentage { get; set; }
    public string GBPercentage { get; set; }
    public string HonmeRunToFlyBall { get; set; }
    public string AvgFourSeamerVelocity { get; set; }
    public decimal ERA { get; set; }
    public decimal xERA { get; set; }
    public decimal WAR { get; set; }
    public int PlayerID { get; set; }
}
