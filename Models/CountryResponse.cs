public class CountryResponse
{
    public Name Name { get; set; }
    public List<string> Capital { get; set; }
    public string Region { get; set; }
    public long Population { get; set; }
}

public class Name
{
    public string Common { get; set; }
    public string Official { get; set; }
}