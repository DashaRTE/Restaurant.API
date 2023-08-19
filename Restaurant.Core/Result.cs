using System.Net;

namespace Restaurant.Core;
public class Result<T>
{
	public HttpStatusCode StatusCode { get; set; }
	public string? Message { get; set; }
	public T Data { get; set; }
}

public class Result
{
	public HttpStatusCode StatusCode { get; set; }
	public string? Message { get; set; }
}
