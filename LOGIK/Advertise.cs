public class advertise
{
    //Publik klass för att skapa annonser
    public int id { get; set; }
    public string rubric { get; set; }
    public string description { get; set; }
    public float price { get; set; }
    public string location { get; set; }
    public string municipality { get; set; }
    public int postalNumber { get; set; }

    public int userId {get; set;}

    public advertise(string rubric, string description, float price, string location, string municipality, int postalNumber, int userId)
    {
      this.rubric = rubric;
        this.description = description;
        this.price = price;
        this.location = location;
        this.municipality = municipality;
        this.postalNumber = postalNumber;
        this.userId = userId;
    }
    public advertise()
    {

    }

}