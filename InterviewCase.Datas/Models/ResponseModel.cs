namespace InterviewCase.Datas.Models;
public class ResponseModel<T> where T  : class
{
    public ResponseModel(string message, bool isSucess, T? data = null)
    {
        Message = message;
        IsSucess = isSucess;
        Data = data;
    }
    public static ResponseModel<T> GetSucess(string? message) => new ResponseModel<T>(message,true);
    public static ResponseModel<T> GetSucess(T data,string? message = "") => new ResponseModel<T>(message, true, data);
    public static ResponseModel<T> GetFailed(string? message) => new ResponseModel<T>(message, false);
    public static ResponseModel<T> GetFailed(T data, string? message) => new ResponseModel<T>(message, false,data);
    public T? Data { get; set; }
    public string Message { get; set; }
    public bool IsSucess { get; set; }
}
