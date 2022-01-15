using System.Net;
using System.Net.Sockets;
using System.Text;

IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
int port = 8080;

TcpListener serverListener = new TcpListener(ipAddress, port);
serverListener.Start();

Console.WriteLine($"Server started on port ${port}.");
Console.WriteLine("Listening for requests...");

while (true)
{
    TcpClient connection = serverListener.AcceptTcpClient();

    NetworkStream networkStream = connection.GetStream();

    string content = "Hello from the server!";
    int contentLength = Encoding.UTF8.GetByteCount(content);

    string response = $@"HTTP/1.1 200 OK
Content-Type: text/plain; charset=UTF-8
Content-Length: {contentLength}

{content}";

    byte[] responseBytes = Encoding.UTF8.GetBytes(response, 0, response.Length);

    networkStream.Write(responseBytes);

    connection.Close();
}