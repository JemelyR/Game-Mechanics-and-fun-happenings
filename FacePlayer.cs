using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FacePlayer : MonoBehaviour{

    void Update(){
        Vector3 playerPos = GameManager.ThePlayer.transform.position;
        Vector3 npcPos = gameObject.transform.position;
        Vector3 delta = new Vector3(playerPos.x - npcPos.x, 0.0f, playerPos.z - npcPos.z);
        Quaternion rotation = Quaternion.LookRotation(delta);
        gameObject.transform.rotation = rotation;
    }
}