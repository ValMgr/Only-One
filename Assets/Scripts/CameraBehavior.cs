using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraBehavior : MonoBehaviour {

    private Transform target;

    private bool followingTarget;

    public float speedRot;

    private void FixedUpdate() {
        if(followingTarget){
            transform.LookAt(target);
            if(Input.GetAxis("rotRight") > 0){
                transform.Translate(Vector3.right * Time.deltaTime * speedRot);
            }
            if(Input.GetAxis("rotLeft") > 0){
                transform.Translate(Vector3.left * Time.deltaTime * speedRot);
            }

            if(Input.GetMouseButton(1)){
                if(Input.GetAxis("Mouse X") < 0){
                    transform.Translate(Vector3.right * Time.deltaTime * speedRot * 2);
                }
                 if(Input.GetAxis("Mouse X") > 0){
                    transform.Translate(Vector3.left * Time.deltaTime * speedRot * 2);
                }
            }
        }

        if(Input.GetKeyDown("n")){
            StopFollowTarget();
        }
    }

    private void FollowTarget(){
        this.transform.position = new Vector3(target.position.x, target.position.y + 20f, target.position.z -30f);
        followingTarget = true;
        this.transform.parent = target;
    }
    public void NewTarget(Transform newTarget){
        target = newTarget;
        FollowTarget();
    }

    public void StopFollowTarget(){
        followingTarget = false;
        target = null;
        this.transform.parent = null;
    }
    
}