namespace Demo
{
    public class Product
    {
        public int ProductId { get; set; }

        public string Name { get; set; }

        public int Cost { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is Product)
            {
                var that = obj as Product;
                return this.ProductId == that.ProductId && this.Name == that.Name && this.Cost == that.Cost;
            }
            return false;
        }
    }

}