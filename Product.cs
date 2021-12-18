namespace CSHARPSQLCRUD
{
    public class Proudct
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string outline
        {
            get
            {
                return $"{name} {description}";
            }
        }
    }
}