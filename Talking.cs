using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talking : MonoBehaviour
{
    [SerializeField] private Animator animator1;
    [SerializeField] private Animator animator2;
    [SerializeField] private string trigger;
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();
        int stars = playerInventory.NumOfStars;
        if (playerInventory != null)
        {
            if (this.tag == "Helper")
            {
                if (other.tag == "Player")
                {
                    animator1.SetTrigger(trigger);
                }
            }
            else { 
                if (other.tag == "Player")
                {
                    animator1.SetFloat("starNum", stars);
                    animator1.SetBool(trigger, true);
                    animator2.SetFloat("starNum", stars);
                    animator2.SetBool(trigger, true);
                }
            }
        }
    }
}
