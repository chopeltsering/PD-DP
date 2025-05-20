//Product
public class House
{
    public string Foundation { get; set; }
    public string Structure { get; set; }
    public string Roof { get; set; }
    public bool HasGarage { get; set; }

    public override string ToString()
    {
        return $"Foundation: {Foundation}, Structure: {Structure}, Roof: {Roof}, Garage: {HasGarage}";
    }
}
