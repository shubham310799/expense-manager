namespace ExpenseManager_Backend.Common
{
    public class GlobalResponse<T>
    {
        public T Data { get; set; }
        public ErrorDetails? Error { get; set; }
        public bool IsSuccess => this.Error == null;
    }

    public class ErrorDetails
    {
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
    }
}
