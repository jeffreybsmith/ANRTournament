namespace ANRTournament.Models
{
    public class Identity
    {
        public int Id { get; set; }

    
        public string Name { get; set; }

        public Identity(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}