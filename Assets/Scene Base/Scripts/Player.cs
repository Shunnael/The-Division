using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    // Start is called before the first frame update
    Animation animations;

    // Vitesse de déplacement
    public float walkSpeed;
    public float runSpeed;
    public float turnSpeed;

    // Imputs
    public string inputFront;
    public string inputBack;
    public string inputLeft;
    public string inputRight;
    

    public Vector3 jumpSpeed;
    CapsuleCollider playerCollider;




    void Start()
    {
        animations = gameObject.GetComponent<Animation>();
        playerCollider = gameObject.GetComponent<CapsuleCollider>();
    }

    bool IsGrounded()

    {
        return Physics.CheckCapsule(playerCollider.bounds.center, new Vector3(playerCollider.bounds.center.x, playerCollider.bounds.min.y - 0.1f, playerCollider.bounds.center.z), 0.086f);
    }

    void Update()
    {

        // Si on court
        if (Input.GetKey(inputFront) && Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(0, 0, runSpeed * Time.deltaTime);
            animations.Play("run");
        }
        //Si on avance 
        if (Input.GetKey(inputFront) && !Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(0, 0, walkSpeed * Time.deltaTime);
            animations.Play("walk");
        }
        // Si on recule
        if (Input.GetKey(inputBack))
        {
            transform.Translate(0, 0, -(walkSpeed / 2) * Time.deltaTime);
            animations.Play("walk");
        }
        //Si on tourne a gauche
        if (Input.GetKey(inputLeft))
        {
            transform.Rotate(0, -turnSpeed * Time.deltaTime, 0);

        }
        //Si on tourne a droite
        if (Input.GetKey(inputRight))
        {
            transform.Rotate(0, turnSpeed * Time.deltaTime, 0);
        }
        //Si on avance paset qu'on ne recule pas
        if (!Input.GetKey(inputFront) && !Input.GetKey(inputBack))
        {
            animations.Play("idle");
        
    }
        }
}