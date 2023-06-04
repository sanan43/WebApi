namespace TaskWebAPI.Entities
{
    public class Color
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Car? Car { get; set; }
    }
}
