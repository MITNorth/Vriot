using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Requests;
using EvtSource;

public class NetworkingTest : MonoBehaviour {
     private string[] keyCodes = {
         "0",
         "1",
         "2",
         "3",
         "4",
     };
     private bool[] lights = {
         false,
         false,
         false,
         false,
         false,
     };
    private LightsRequest Light;
    void Start() {
        Light = new LightsRequest();
        Light.setEventHandler(
            (object sender, EventSourceMessageEventArgs e) => {
                Debug.Log($"{e.Event} : {e.Message}");
            }
        );
        


    }

    void Update() {
        
        for (int i = 0; i < keyCodes.Length; i++) {
            if (Input.GetKeyDown(keyCodes[i])) {
                Debug.Log("pressed "+ keyCodes[i]);
                lights[i] = !lights[i];
                StartCoroutine(Light.UpdateRequest(i, lights[i]));
            }
        }
    }

}
