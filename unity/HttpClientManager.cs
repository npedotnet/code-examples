/* 
 * HttpClientをシングルトン化したUnity用のサンプルプログラムです。
 * SingletonMonoBehaviour.csと一緒にお使い下さい。
 * 詳細は https://unixo-lab.com/unity/http_client_manager.html をご覧下さい。
 */
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

public class HttpClientManager : SingletonMonoBehaviour<HttpClientManager>
{
	private HttpClient client;

	new void Awake()
	{
		base.Awake();
		client = new HttpClient();
	}

	public Task<HttpResponseMessage> GetAsync(string requestUri)
		=> client.GetAsync(requestUri);

	public Task<byte[]> GetByteArrayAsync(string requestUri)
		=> client.GetByteArrayAsync(requestUri);

	public Task<Stream> GetStreamAsync(string requestUri)
		=> client.GetStreamAsync(requestUri);

	public Task<string> GetStringAsync(string requestUri)
		=> client.GetStringAsync(requestUri);

	public Task<HttpResponseMessage> PostAsync(string requestUri, HttpContent content = null)
		=> client.PostAsync(requestUri, content);

	public Task<HttpResponseMessage> SendAsync(HttpRequestMessage request)
		=> client.SendAsync(request);
}
