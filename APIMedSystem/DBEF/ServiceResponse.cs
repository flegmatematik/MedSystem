namespace APIMedSystem.DBEF
{
    /// <summary>
    /// Trieda ktorá slúži ako odpoveď servicu pre controller ale aj pre koncovu aplikáciu,
    /// kde Data predstavuju hlavny payload transakcie, Success oznacuje, ci bola operácia úspešná, a
    /// Message správu, či už chybovú hlášku alebo doplňujúcu informáciu
    /// </summary>
    /// <typeparam name="T"></typeparam>

    public class ServiceResponse<T>
    {
        public T Data { get; set; }
        public bool Success { get; set; } = true;
        public string Message { get; set; } = null;
    }
}
