using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Billboarding : MonoBehaviour {

    public Camera a_camera;


    void Update() {
        transform.LookAt(transform.position + a_camera.transform.rotation * Vector3.back, a_camera.transform.rotation * Vector3.down);
        
    }
    
}