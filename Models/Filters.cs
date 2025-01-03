namespace TODO.Models;

public class Filters
{
    public Filters(string filterstring)
    {
        Filterstring = filterstring ?? "all-all-all";
        var filters = Filterstring.Split('-');
        CategoryID = filters[0];
        Due = filters[1];
        StatusID = filters[2];
    }

    public string Filterstring { get; }
    public string CategoryID { get; }
    public string Due { get; }
    public string StatusID { get; }
    public bool HasCategory => CategoryID.ToLower() != "all";
    public bool HasDue => Due.ToLower() != "all";
    public bool HasStatus => StatusID.ToLower() != "all";

    public static Dictionary<string, string> DueFilterValuse =>
        new()
        {
            {"future", "Future"},
            {"past", "Past"},
            {"today", "Today"}
        };

    public bool IsPast => Due.ToLower() == "past";
    public bool IsFuture => Due.ToLower() == "future";
    public bool IsToday => Due.ToLower() == "today";
}