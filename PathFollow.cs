using System.Numerics;
using System.Threading.Tasks.Dataflow;
using System.Net.NetworkInformation;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PathFollow : MonoBehaviour{

    public GameObject player;
    public float TargetDistance;
    public float AllowedDistance = 5;
    public GameObject NPC;
    public float FollowSpeed;
    public RaycastHit Shot;

    void Update() {
        transform.LookAt(player.transform);
        if(PhysicalAddress.Raycast(transform.position, transform.TransformDirection(Vector3.foward), out Shot)){
            TargetDistance = Shot.distance;
            if(TargetDistance >= AllowedDistance){
                FollowSpeed = 0.1f;
                NPC.GetComponent<Animation>().Play("running");
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, FollowSpeed);
            }
            else{
                FollowSpeed = 0;
                NPC.GetComponent<Animation>().Play("idle");
            }
        }
        
    }
    
}