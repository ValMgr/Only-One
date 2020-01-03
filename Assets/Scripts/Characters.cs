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

    //Temporaire
    public GameObject Camera;
    

    protected void Update() {
        if(canMove && Input.GetKeyDown("m") && !mooving){
            mooving = true;
            MooveRange(PM);
            Camera.GetComponent<CameraBehavior>().NewTarget(this.GetComponent<Transform>());

        }
        if(canMove && Input.GetKeyDown("l") && mooving){
            mooving = false;
            MooveRange(PM);
        }
    }

    public void Moove(Vector3 target){
        IEnumerator moove = MooveToTarget(target);
        StartCoroutine(moove);
    }

    protected IEnumerator MooveToTarget(Vector3 target) {

        Vector3 correctTarget = new Vector3(target.x, transform.position.y, target.z);
        float distance = Mathf.Floor(Vector3.Distance(target, transform.position));

        if(mooving && distance <= (PM * 4 + 1)){
            while (Mathf.Round(transform.position.x) != Mathf.Round(correctTarget.x) || Mathf.Round(transform.position.z) != Mathf.Round(correctTarget.z)){
                transform.position = Vector3.Lerp(transform.position, correctTarget, speed * Time.deltaTime);
                yield return null;               
            }

            transform.position = new Vector3(Mathf.Round(transform.position.x), transform.position.y, Mathf.Round(transform.position.z));
            Debug.Log(distance);
            PM -= Mathf.Floor(distance / 4);



            if(PM > 0){
                ResetRange();
                MooveRange(PM);
            }
            else{
                ResetRange();
                mooving = false;
            }
        }

        yield return null;               

    }


    protected void MooveRange(float radius) {

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius * 4 - 0.5f);
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

    protected void ResetRange(){
        foreach (var cells in GameObject.FindGameObjectsWithTag("Cells")){
            if(cells.gameObject.GetComponent<Renderer>().material.color != new Color(0.45f, 0.45f, 0.45f, 1f)){
                cells.gameObject.GetComponent<Renderer>().material.SetColor("_Color", new Color(0.45f, 0.45f, 0.45f, 1f));
            }
        }
    }

}