namespace SignalRApi.DAL;

public enum ECity
{
    Berlin = 1,
    Paris = 2,
    Maldiv = 3,
    London = 4,
    Bakı = 5
}
public class Visitor
{
    public int VisitorId { get; set; }
    public ECity City { get; set; }
    public int CityVisitCount { get; set; }
    public DateTime VisitDate { get; set; }
}
