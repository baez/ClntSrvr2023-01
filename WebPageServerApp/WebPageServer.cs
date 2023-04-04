namespace WebPageServerApp
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Text;
    using System.Threading.Tasks;

    public class WebPageServer
    {
        private readonly HttpListener _httpListener;
        private readonly string _urlPrefix;
        private readonly string _folder;

        public WebPageServer(string uriPrefix, string folder)
        {
            this._httpListener = new HttpListener();
            this._urlPrefix = uriPrefix;
            this._folder = folder;
        }

        public async void Start()
        {
            _httpListener.Prefixes.Add(this._urlPrefix);
            _httpListener.Start();
            while (true)
            {
                try
                {
                    // awaits a new client request
                    HttpListenerContext context = await _httpListener.GetContextAsync();
                    Task.Run(() => ProcessRequest(context));
                }
                catch (HttpListenerException he)
                {
                    Console.WriteLine(he.ToString());
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.ToString());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

        private async void ProcessRequest(HttpListenerContext context)
        {
            try
            {
                string filename = Path.GetFileName(context.Request.RawUrl);
                string filePath = Path.Combine(this._folder, filename);
                
                byte[] data;
                if(!File.Exists(filePath))
                {
                    Console.WriteLine($"Resource filePath not found: {filePath}");
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    data = Encoding.UTF8.GetBytes("The requested page does not exist");
                }
                else
                {
                    data = File.ReadAllBytes(filePath);
                    context.Response.StatusCode = (int )HttpStatusCode.OK;
                }

                context.Response.ContentLength64 = data.Length;

                using (Stream stream = context.Response.OutputStream)
                {
                    await stream.WriteAsync(data, 0, data.Length);
                }

            }
            catch(Exception e) 
            {
                Console.WriteLine($"{e.Message} - {e.ToString()}");
            }
        }

        public void Stop()
        {
            this._httpListener.Stop();
        }

        public void Dispose()
        {
            _httpListener.Close();
        }
    }
}
