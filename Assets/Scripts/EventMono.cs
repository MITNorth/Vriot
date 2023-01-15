using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;

public class EventMono : MonoBehaviour
{
    public String host = "home.karatsubalabs.com";
    public int port = 80;

  #region private members 	
  private TcpClient socketConnection;
  private Thread clientReceiveThread;

  private Queue<String> event_queue = new Queue<String>();
  private object _queueLock = new object();
  #endregion

  void Start()
  {
    Task.Run(() =>
    {
      ListenForData();
    });
  }

  void Update()
  {
    lock (_queueLock) {
        foreach (String next_event in event_queue.ToArray())  {;
            Debug.Log($"event: {next_event}");
        }
        event_queue.Clear();
    }
  }

  private void ListenForData()
  {
    using TcpClient client = new TcpClient(host, port);
    Byte[] data = System.Text.Encoding.ASCII.GetBytes($"GET /v1beta/client/device HTTP/1.1\nHost: {host}\nx-api-key: API_KEY\n\n");
    NetworkStream stream = client.GetStream();
    stream.Write(data, 0, data.Length);

    byte[] buffer = new byte[4096];

    while (true) {
        int k = stream.Read(buffer, 0, 4096);
        if (k > 0) {
            var decoded = Encoding.UTF8.GetString(buffer); 
            // Debug.Log($"read {k} from stream");
            // Debug.Log($"{decoded}");
            if (decoded.StartsWith("data:")) {
                lock (_queueLock) {
                    // TODO this is kinda cringe
                    event_queue.Enqueue(decoded.Substring(5));
                }
            }
        }
    }

    client.Close();
  }
}
