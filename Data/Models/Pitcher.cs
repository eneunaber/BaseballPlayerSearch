using CsvHelper.Configuration.Attributes;


public class Pitcher
{
    //","ERA","xERA","FIP","xFIP","WAR","playerid"
    public string Name { get; set; }
    public string Team { get; set; }
    public int W { get; set; }
    public int L { get; set; }
    public int SV { get; set; }
    public int G { get; set; }
    public decimal IP { get; set; }
    [Name("K/9")]
    public string KPer9 { get; set; }
    [Name("BB/9")]
    public string BallsPer9 { get; set; }
    [Name("HR/9")]
    public string HRPer9 { get; set; }
    public decimal BABIP { get; set; }
    [Name("LOB%")]
    public string LOBPercentage { get; set; }
    [Name("GB%")]
    public string GBPercentage { get; set; }
    [Name("HR/FB")]
    public string HonmeRunToFlyBall { get; set; }
    [Name("vFA (pi)")]
    public string AvgFourSeamerVelocity { get; set; }
    public decimal ERA { get; set; }
    public decimal xERA { get; set; }
    public decimal WAR { get; set; }
    [Name("playerid")]
    public int PlayerID { get; set; }
}
