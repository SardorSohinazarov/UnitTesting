namespace ProductAPI.Exceptions
{
    public class NotFoundProductException:Exception
    {
        public NotFoundProductException():base("Databaseda yo'q")
        { }
    }
}
