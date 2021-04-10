namespace AquaShop.IO.Contracts
{
    public interface IWriter
    {
        abstract void WriteLine(string message);

        void Write(string message);
    }
}