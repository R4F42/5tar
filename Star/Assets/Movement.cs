using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Movement : NetworkBehaviour {

    Animator animator;

    public GameObject playerCamera;

    public float x;

    public float y;

    public Vector3 rota;

    public LayerMask Arena;

    public Rigidbody rb;

    public float jump = 7;

    public BoxCollider bc;


    #region MonoBehavior API

    void Start () {
        animator = GetComponent<Animator>();

        rb = GetComponent<Rigidbody>();

        bc = GetComponent<BoxCollider>();

		if(isLocalPlayer == true)
        {
            playerCamera.SetActive(true);
        }
        else
        {
            playerCamera.SetActive(false);
        }
    }

    void Update () {

		if(isLocalPlayer == true)
        {            
            if (Input.GetKey(KeyCode.A))
            {
                

                this.transform.Translate(Vector3.left * Time.deltaTime * 7f);
            }
            if (Input.GetKey(KeyCode.D))
            {
                this.transform.Translate(Vector3.right * Time.deltaTime * 7f);
            }
            if (Input.GetKey(KeyCode.W))
            {
                animator.SetInteger("speedP", 1);
                this.transform.Translate(Vector3.forward * Time.deltaTime * 7f);
            }
            if (Input.GetKeyUp(KeyCode.W))
            {
                animator.SetInteger("speedP", 0);
            }
            if (Input.GetKey(KeyCode.S))
            {
                this.transform.Translate(Vector3.back * Time.deltaTime * 7f);
            }
            if (isGrounded() && Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(Vector3.up * jump, ForceMode.Impulse);
            }

            x = Input.GetAxis("Mouse X");

            y = Input.GetAxis("Mouse Y");

            this.transform.Rotate(y, x, 0);

            

        }
	}

    private bool isGrounded()
    {

        return Physics.CheckCapsule(bc.bounds.center, new Vector3(bc.bounds.center.x, bc.bounds.min.y, bc.bounds.center.z), bc.size.y, Arena);

    }


    #endregion
}
