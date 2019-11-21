using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Characters : MonoBehaviour {
    public Rigidbody rb;
    public Animator animator;

    public float PM; // Movement Point
    public float PA; // Action Point

    public bool canMove = false;
    protected bool canPlay = false;
    

    protected void Update() {
        if(canMove && Input.GetKeyDown("m")){
            Moove();
        }
    }

    protected void Moove() {
        MooveRange(PM);

    }

    protected void MooveRange(float radius) {

        Collider[] hitColliders = Physics.OverlapSphere(new Vector3(0f, 0f, 0f), radius * 4);
        int i = 0;
        while (i < hitColliders.Length)
        {
            if(hitColliders[i].gameObject.tag == "Cells"){
                hitColliders[i].gameObject.GetComponent<Renderer>().material.SetColor("_Color", new Color(0.25f, 0.25f, 0.5f, 0.45f));
                hitColliders[i].gameObject.GetComponent<cellChoice>().canClick = true;
            }
            i++;
        }
    }


}