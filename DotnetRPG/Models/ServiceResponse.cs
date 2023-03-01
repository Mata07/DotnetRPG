namespace DotnetRPG.Models
{
    // Wrapper za slanje dodatnih informacija ili poruka za exception
    // ili za frontend poruke
    public class ServiceResponse<T>
    {
        // Body data tipa T
        public T Data { get; set; }
        public bool Success { get; set; } = true;
        public string Message { get; set; } = null;
    }
}
