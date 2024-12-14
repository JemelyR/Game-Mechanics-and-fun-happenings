using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Follow : MonoBehaviour
{
    [SerializeField] public float speed = 20.0f;
    [SerializeField] private Animator animator;
    public float minDist = 1f;
    public Transform target;
    private bool collided = false;

    // Use this for initialization
    void Start()
    {
        // if no target specified, assume the player
        if (target == null)
        {

            if (GameObject.FindWithTag("Player") != null)
            {
                target = GameObject.FindWithTag("Player").GetComponent<Transform>();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
       

        // face the target
        transform.LookAt(target);

        //get the distance between the chaser and the target
        float distance = Vector3.Distance(transform.position, target.position);

        //so long as the chaser is farther away than the minimum distance, move towards it at rate speed.
        if (this.tag == "Helper")
        {
            if (collided == true)
            {
                if (distance > minDist)
                {
                    animator.SetTrigger("beep");
                    transform.position += transform.forward * speed * Time.deltaTime;
                    animator.SetFloat("walk", speed);
              

                }
                else if (distance < minDist)
                {
                    animator.SetFloat("walk", 0f);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            collided = true;
        }
    }

    // Set the target of the chaser
    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }


}
