using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Lifebar : MonoBehaviour {

    private Characters character; // Get Scripts from characters

    private void Start() {
        character = transform.parent.gameObject.GetComponent<Characters>();
    }
    private void Update() {
        this.transform.LookAt(GameObject.Find("Main Camera").transform);
    }
    
}