public class advertise
{
    //Publik klass för att skapa annonser
    //Properties some annons ska innehålla
    public int Id { get; set; }
    public string Rubric { get; set; }
    public string Description { get; set; }
    public float Price { get; set; }
    public string County { get; set; }
    public string Municipality { get; set; }
    public int PostalNumber { get; set; }
    public int UserId {get; set;}

    //Konstruktor då annons är tvunget att hålla alla dessa egenskaper för att användas

    public advertise(string rubric, string description, float price, string county, string municipality, int postalNumber, int userId)
    {
        this.Rubric = rubric;
        this.Description = description;
        this.Price = price;
        this.County = county;
        this.Municipality = municipality;
        this.PostalNumber = postalNumber;
        this.UserId = userId;
    }
    public advertise() //Tom konstruktor
    {

    }
    public override string ToString()
    {
      return  $"{Rubric}\n\r{Description}\n\r//{Price}\n\r{County}";
    }

}