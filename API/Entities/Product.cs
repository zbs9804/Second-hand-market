namespace API.Entities
{
    public class Product
    {
        public int Id { get; set; }
        //it's an int and name is id, so sqlite will automatically set this as primary key

        public string Name { get; set; }

        public string Description { get; set; }

        public long Price { get; set; }//use extra space of long to parse price 100.00 -> 10000

        public string PictureUrl { get; set; }

        public string Type { get; set; }

        public string Brand { get; set; }

        public int QuantityInStock { get; set; }
    }
}