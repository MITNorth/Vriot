using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        Debug.Log(other.gameObject.layer);
        if (other.gameObject.layer == LayerMask.NameToLayer("Finger")) {
            Debug.Log(transform.gameObject.name);
            rend.material = initialState ? mat_secondary : mat_primary;
            if (transform.gameObject.name == "Sphere A") { // Edit Custom Command

            } else if (transform.gameObject.name == "Sphere B") { // Do Custom Command
                initialState = !initialState;
            } else if (transform.gameObject.name == "Sphere C") { // Home Security

            } else if (transform.gameObject.name == "Sphere D") { // Temperature

            } else { // Statistics

            }
            initialState = !initialState;
        }
    }
}
