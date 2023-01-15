using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Requests;

public class MenuSelect : MonoBehaviour {
    private bool initialState = true;
    private MeshRenderer rend;

    public Material mat_primary, mat_secondary;

    private void Start() {
        rend = GetComponent<MeshRenderer>();
    }
    //Upon collision with another GameObject, this GameObject will reverse direction
    private void OnTriggerEnter(Collider other)
    {
        GlobalContainer.instance.tempPanel.SetActive(false);
        GlobalContainer.instance.statsPanel.SetActive(false);
        Debug.Log(other.gameObject.layer);
        if (other.gameObject.layer == LayerMask.NameToLayer("Finger")) {
            Debug.Log(transform.gameObject.name);
            rend.material = initialState ? mat_secondary : mat_primary;
            if (transform.gameObject.name == "Sphere A") { // Edit Custom Command
                DoorRequest d = new DoorRequest();
                StartCoroutine(d.ToggleDoor(!initialState));

            } else if (transform.gameObject.name == "Sphere B") { // Do Custom Command
                initialState = !initialState;

                Debug.Log("Good night!");
                Debug.Log("Turning off lights...");
                LightsRequest l = new LightsRequest();
                for (int i = 0; i < 6; i++) {
                    StartCoroutine(l.UpdateRequest(i, false));
                }

                Debug.Log("Turning on alarm");
                AlarmRequest a = new AlarmRequest();
                StartCoroutine(a.ToggleAlarm(true));
            } else if (transform.gameObject.name == "Sphere C") { // Home Security
                AlarmRequest alarmRequest = new AlarmRequest(); 
                StartCoroutine(alarmRequest.ToggleAlarm(initialState));

            } else if (transform.gameObject.name == "Sphere D") { // Temperature
                GlobalContainer.instance.tempPanel.SetActive(initialState);

            } else { // Statistics
                GlobalContainer.instance.statsPanel.SetActive(initialState);


            }
            initialState = !initialState;
        }
    }
}
