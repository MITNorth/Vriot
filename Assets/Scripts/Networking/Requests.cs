using System;
using System.Collections;
using System.Collections.Generic;
using EvtSource;
using UnityEngine;
using UnityEngine.Networking;

public static class Globals
{
    public const string API_URL = "http://home.karatsubalabs.com";
    public const string VERSION = "v1beta";
    public const string PREAMBLE = "event/device";

}

namespace Requests
{
    public class LightsRequest
    {
        private EventSourceReader source;
        private string url;
        public delegate void EventHandler(object sender, EventSourceMessageEventArgs e);
        public bool isNetworkError = false;
        public class LightUpdateData
        {
            public string state;
        }

        public LightsRequest()
        {
            url = Globals.API_URL + "/" + Globals.VERSION + "/" + Globals.PREAMBLE + "/" + "led_module_event";
            source = new EventSourceReader(new Uri(url));
            source.Disconnected += async (object sender, DisconnectEventArgs e) => {
                Debug.Log($"Retry: {e.ReconnectDelay} - Error: {e.Exception}");
                source.Start(); // Reconnect to the same URL
            };
            source.Start();

            Debug.Log("Lights Request Started");
        }

        public LightsRequest setEventHandler(EventHandler evtHandler)
        {
            source.MessageReceived += (object sender, EventSourceMessageEventArgs e) => evtHandler(sender, e);

            return this;
        }

        private IEnumerator Post(UnityWebRequest req)
        {
            yield return req.SendWebRequest();

            if (req.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.Log("Error");
            }
            else
            {
                Debug.Log("Updated light");
            }
            req.Dispose();
            
        }

        public IEnumerator UpdateRequest(int light, bool state)
        {
            // form.AddField("state", light);
            var lightData = new LightUpdateData();
            lightData.state = state ? "on" : "off";
            string json = JsonUtility.ToJson(lightData);
            byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);

            var request = UnityWebRequest.Post(url, new WWWForm());
            Debug.Log(url);
            request.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
            request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            request.SetRequestHeader("x-api-key", "API_KEY");
            request.SetRequestHeader("Content-Type", "application/json");

            return Post(request);
            // return this;
        }

    }

    public class TempSensor
    {

    }
}