using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpin : MonoBehaviour
{

    [SerializeField] private float SpinSpeed = 200f;
    private float speed = 200f;
    [SerializeField] private float height = 0.2f;
    Vector3 pos;
    // Update is called once per frame
    private void Start()
    {
        pos = transform.position;
    }
    void Update()
    {
        this.transform.Rotate(Vector3.up, SpinSpeed * Time.deltaTime, Space.World);
        float newY = Mathf.Sin(Time.time * (speed/40)) * height/4 + pos.y;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
        

    }
  


}

