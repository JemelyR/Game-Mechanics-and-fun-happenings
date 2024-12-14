using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //    [SerializeField] private float WalkSpeed = 2;
    //    [SerializeField] private float TurnSpeed = 45;
    //    private Animator animator;

    //    // Start is called before the first frame update
    //    void Start()
    //    {
    //        animator = GetComponent<Animator>();
    //    }

    //    // Update is called once per frame
    //    void Update()
    //    {
    //        Vector3 direction = transform.rotation;
    //        var velocity = direction * Input.GetAxis("Vertical") * WalkSpeed;
    //        transform.Translate(velocity * Time.deltaTime);
    //        transform.Rotate(Vector3.up, Input.GetAxis("Horizontal") * Time.deltaTime * TurnSpeed);
    //        animator.SetFloat("Speed", velocity.z);
    //    }
    //}
    public float Speed = 5f;
    public float JumpHeight = 2f;
    public float GroundDistance = 0.2f;
    public float DashDistance = 5f;
    public LayerMask Ground;

    private Rigidbody _body;
    private Vector3 _inputs = Vector3.zero;
    private bool _isGrounded = true;
    private Transform _groundChecker;
    private Animator animator;

    void Start()
    {
        _body = GetComponent<Rigidbody>();
        _groundChecker = transform.GetChild(0);
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        _isGrounded = Physics.CheckSphere(_groundChecker.position, GroundDistance, Ground, QueryTriggerInteraction.Ignore);


        _inputs = Vector3.zero;
        _inputs.x = Input.GetAxis("Horizontal");
        _inputs.z = Input.GetAxis("Vertical");
        if (_inputs != Vector3.zero)
            transform.forward = _inputs;
        float avg = (_inputs.x + _inputs.z + _inputs.y) / 3;

        animator.SetFloat("Speed", avg);
    }


    void FixedUpdate()
    {
        _body.MovePosition(_body.position + _inputs * Speed * Time.fixedDeltaTime);
    }
}
