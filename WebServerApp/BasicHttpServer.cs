namespace WebServerApp
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Text;

    public class BasicHttpServer
    {
        private readonly HttpListener _httpListener;

        public BasicHttpServer()
        {
            _httpListener = new HttpListener();
        }

        private async void Listen()
        {

            _httpListener.Prefixes.Add("http://localhost:51189/basicserver/");
            _httpListener.Start();

            // await a client request
            HttpListenerContext context = await _httpListener.GetContextAsync();

            // 
            string message = $"you asked for document: {context.Request.RawUrl}";
            context.Response.ContentLength64 = Encoding.UTF8.GetByteCount(message);
            context.Response.StatusCode = (int)HttpStatusCode.OK;

            using (Stream stream = context.Response.OutputStream)
            {
                using (StreamWriter writer = new StreamWriter(stream)) 
                {
                    await writer.WriteAsync(message);
                }
            }
        }

        public void Dispose()
        {
            _httpListener.Close();
        }
    }
}
