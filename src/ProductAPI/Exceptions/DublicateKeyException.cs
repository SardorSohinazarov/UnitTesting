namespace ProductAPI.Exceptions
{
    public class DublicateKeyException:Exception
    {
        public DublicateKeyException():base("Key cannot be dublicate")
        { }
    }
}
