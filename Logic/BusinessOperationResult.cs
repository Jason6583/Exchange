namespace Logic
{
    public class BusinessOperationResult<T>
    {
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public int? Id { get; set; }
        public T Entity { get; set; }
    }
}
