namespace TaskWebAPI.Entities
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Car? Car { get; set; }
    }
}
