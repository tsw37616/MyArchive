public class ShipData
{
    public string? Param0 { get; set; }
    public string? Param1 { get; set; }
    public string? Param2 { get; set; }
    public string? Param3 { get; set; }
    public string? Param4 { get; set; }
}

public class Ship
{
    public string? Key { get; set; }
    public string? Name { get; set; }
    public string? Alias { get; set; }
    public string? Nickname { get; set; }
    public string? Avatar { get; set; }
    public ShipData? Data { get; set; }
}
