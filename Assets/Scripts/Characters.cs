using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Characters : MonoBehaviour {
    public Rigidbody rb;
    public Animator animator;
    public float speed = 1.0f;

    public float PM; // Movement Point
    public float PA; // Action Point

    public bool canMove = false;
    [System.NonSerialized]
    public bool mooving = false;
    protected bool canPlay = false;
    

    protected void Update() {
        if(canMove && Input.GetKeyDown("m") && !mooving){
            mooving = true;
            MooveRange(PM);
        }
        if(canMove && Input.GetKeyDown("l") && mooving){
            mooving = false;
            MooveRange(PM);
        }
    }

    protected void Moove(Vector3 target) {
        if(mooving){
            float step =  speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target, step);
        }
    }

    protected void MooveRange(float radius) {

        Collider[] hitColliders = Physics.OverlapSphere(new Vector3(0f, 0f, 0f), radius * 4);
        int i = 0;
        while (i < hitColliders.Length)
        {
            if(hitColliders[i].gameObject.tag == "Cells"){
                if(mooving){
                    hitColliders[i].gameObject.GetComponent<Renderer>().material.SetColor("_Color", new Color(0.25f, 0.25f, 0.5f, 0.45f));
                }
                if(!mooving){
                    hitColliders[i].gameObject.GetComponent<Renderer>().material.SetColor("_Color", new Color(0.45f, 0.45f, 0.45f, 1f));

                }
            }
            i++;
        }
    }


}