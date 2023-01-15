using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Clock : MonoBehaviour {
    TMP_Text tmp;
    void Start() {
        tmp = GetComponent<TMP_Text>();
    }

    void Update() {
        tmp.text = $"{System.DateTime.Now.Hour}:{System.DateTime.Now.Minute:00}"; 
    }
}
