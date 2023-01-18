using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanControll : MonoBehaviour
{
    public static HumanControll Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    //COMP
    [SerializeField]private CharacterController _chacontrol;
    public Animator _animator;
    //MOVE
    private float inputX;
    private float inputZ;
    private Vector3 v_movement;
    public float gravity;
    public float speed;
    public float jumpforce;
    private float nextAttacktime;
    public bool checkat;

    public bool inRoom = false;
    void Start()
    {
        checkat = false;
        _chacontrol = gameObject.GetComponent<CharacterController>();
    }

    void Update()
    {
        if (inRoom)
        {
            if (checkat == false)
            {
                inputX = Input.GetAxis("Horizontal");//Keyboard input
                inputZ = Input.GetAxis("Vertical");//Keyboard input
            }

            if (inputX == 0 && inputZ == 0)
            {
                _animator.SetBool("isRunning", false);
            }
            else
            {
                _animator.SetBool("isRunning", true);
            }
        }           
        
    }

    private void FixedUpdate()
    {
        //Gravity
        if (_chacontrol.isGrounded)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                v_movement.y = jumpforce;
            }
            else
            {
                v_movement.y = 0f;
            }
        }
        else
        {
            v_movement.y -= gravity * Time.deltaTime;
        }

        //Moving
        if (checkat == false)
        {
            v_movement = new Vector3(inputX * speed, v_movement.y, inputZ * speed);
            _chacontrol.Move(v_movement);
        }
        else if (checkat == true)
        {
            //Debug.Log("dash");
            if (!_chacontrol.isGrounded)
            {
                while (true)
                {
                    if (_chacontrol.isGrounded)
                    {
                        break;
                    }
                    _chacontrol.Move(transform.TransformDirection(Vector3.forward) * 2.0f * Time.deltaTime);
                    _chacontrol.Move(transform.TransformDirection(Vector3.down) * gravity * Time.deltaTime);
                }
            }
            else
            {
                _chacontrol.Move(transform.TransformDirection(Vector3.forward) * speed * Time.deltaTime);
            }
        }        

        //facing
        if ((inputZ != 0 || inputX != 0) && checkat == false)
        {
            Vector3 facing = new Vector3(v_movement.x, 0, v_movement.z);
            transform.rotation = Quaternion.LookRotation(facing);
        }
    }

}
