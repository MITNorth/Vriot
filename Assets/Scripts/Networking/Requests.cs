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
        private string url;
        private Dictionary<int, string> roomMap = new Dictionary<int, string>(){
            {0, "master bedroom south"},
            {1, "bathroom"},
            {2, "kids bedroom"},
            {3, "living room"},
            {4, "kitchen"},
            {5, "master bedroom north"}
};
        public class LightUpdateData
        {
            public string room;
            public string state;
        }

        public LightsRequest()
        {
            url = Globals.API_URL + "/" + Globals.VERSION + "/" + Globals.PREAMBLE + "/" + "led_module_event";
            Debug.Log("Lights Request Started");
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
            lightData.room = roomMap[light];
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

    // lgiths, doorbell, alarm, open door, 

    public class AlarmRequest
    {
        private string url;
        public class AlarmUpdateData
        {
            public string state;
        }

        public AlarmRequest()
        {
            url = Globals.API_URL + "/" + Globals.VERSION + "/" + Globals.PREAMBLE + "/" + "alarm_module_event";
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
                Debug.Log("Updated alarm");
            }
            req.Dispose();
            
        }

        public IEnumerator ToggleAlarm(bool state)
        {
            Debug.Log("Alarm Request Started");
            var alarmData = new AlarmUpdateData();
            alarmData.state = state ? "on" : "off";
            string json = JsonUtility.ToJson(alarmData);
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

    public class DoorRequest
    {
        private string url;
        public class DoorUpdateData
        {
            public string state;
        }

        public DoorRequest()
        {
            url = Globals.API_URL + "/" + Globals.VERSION + "/" + Globals.PREAMBLE + "/" + "door_module_event";
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
                Debug.Log("Updated door");
            }
            req.Dispose();
            
        }

        public IEnumerator ToggleDoor(bool state)
        {
            Debug.Log("Door Request Started");
            var doorData = new DoorUpdateData();
            doorData.state = state ? "open" : "closed";
            string json = JsonUtility.ToJson(doorData);
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