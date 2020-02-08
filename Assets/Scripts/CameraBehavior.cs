using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraBehavior : MonoBehaviour {

    private Transform target;

    private bool followingTarget;

    public float speed;


    // Need to fix: - Remove when player rotate to Lookat destination the camera rotate with it
    // 
    //
    // ==========================================================

    private void FixedUpdate() {


        // Command to moove target when camera is following a Character
        if(followingTarget){
            if(Input.GetAxis("CameraRotation") > 0){
                transform.RotateAround(target.position, Vector3.up, Time.deltaTime * speed * 2);
            }
            if(Input.GetAxis("CameraRotation") < 0){
                transform.RotateAround(target.position, Vector3.down, Time.deltaTime * speed * 2);
            }

            if(Input.GetMouseButton(1)){
                if(Input.GetAxis("Mouse X") < 0){
                    transform.RotateAround(target.position, Vector3.up, Time.deltaTime * speed * 4);
                }
                    if(Input.GetAxis("Mouse X") > 0){
                    transform.RotateAround(target.position, Vector3.down, Time.deltaTime * speed * 4);
                }
            }
        }

        // Then, other commands when camera is free
        if(!followingTarget){
            if(Input.GetAxis("CameraRotation") > 0){
                transform.RotateAround(new Vector3(0, 0, 0), Vector3.up, Time.deltaTime * speed * 2);
            }
            if(Input.GetAxis("CameraRotation") < 0){
                transform.RotateAround(new Vector3(0, 0, 0), Vector3.down, Time.deltaTime * speed * 2);

            }

            if(Input.GetMouseButton(1)){
                if(Input.GetAxis("Mouse X") < 0){
                    transform.RotateAround(new Vector3(0, 0, 0), Vector3.up, Time.deltaTime * speed * 4);
                }
                    if(Input.GetAxis("Mouse X") > 0){
                    transform.RotateAround(new Vector3(0, 0, 0), Vector3.down, Time.deltaTime * speed * 4);
                }
            }
        }

        // Other command working for both case
        // Vertical Axis
        if(Input.GetAxis("CameraVertical") > 0){
            transform.Translate((Vector3.forward + Vector3.up) * Time.deltaTime * speed);
        }
        if(Input.GetAxis("CameraVertical") < 0){
            transform.Translate((Vector3.back + Vector3.down) * Time.deltaTime * speed);

        }

        // Horizontal Axis
        if(Input.GetAxis("CameraHorizontal") < 0){
            transform.Translate(Vector3.left * Time.deltaTime * speed);

        }
        if(Input.GetAxis("CameraHorizontal") > 0){
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }

        // Zoom
        if(Input.GetAxis("CameraZoom") > 0){
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        if(Input.GetAxis("CameraZoom") < 0){
            transform.Translate(Vector3.back * Time.deltaTime * speed);
        }
        if(Input.GetAxis("CameraZoomScroll") > 0){
            Debug.Log(Input.GetAxis("CameraZoomScroll"));
            transform.Translate(Vector3.forward * Time.deltaTime * speed * Input.GetAxis("CameraZoomScroll"));
        }
        if(Input.GetAxis("CameraZoomScroll") < 0){
            transform.Translate(Vector3.back * Time.deltaTime * speed * - Input.GetAxis("CameraZoomScroll"));
        }


        // - - Temporaire - - Stop following target
        if(Input.GetKeyDown("n")){
            StopFollowTarget();
        }
    }

    // Get target and looking at it
    private void FollowTarget(){
        this.transform.position = new Vector3(target.position.x, target.position.y + 20f, target.position.z -30f);
        followingTarget = true;
        this.transform.parent = target;
        transform.LookAt(target);
    }
    
    // Get a new target
    public void NewTarget(Transform newTarget){
        target = newTarget;
        FollowTarget();
    }

    // Stop following the target
    public void StopFollowTarget(){
        followingTarget = false;
        target = null;
        this.transform.parent = null;
    }
    
}