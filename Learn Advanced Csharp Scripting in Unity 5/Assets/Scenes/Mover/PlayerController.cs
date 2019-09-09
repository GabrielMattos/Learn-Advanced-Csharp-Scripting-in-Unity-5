using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{

    public float maxSpeed = 10f;
    public float rotateSpeed = 5f;
    private Transform thisTransform = null;
    private CharacterController thisController = null;
    public float jumpForce = 50f;
    public float groundDist = 0.1f;
    public bool isGrounded = false;
    private Vector3 velocity = Vector3.zero;
    public LayerMask groundLayer;

    // Start is called before the first frame update
    void Start()
    {
        thisTransform = this.gameObject.GetComponent<Transform>();
        thisController = this.gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horz = CrossPlatformInputManager.GetAxis("Horizontal");
        float vert = CrossPlatformInputManager.GetAxis("Vertical");

        thisTransform.rotation *= Quaternion.Euler(new Vector3(0f, rotateSpeed * horz * Time.deltaTime, 0f));

        //CALCULATE MOVE DIR
        velocity.z = vert * maxSpeed;

        //ARE WE GROUNDED?
        isGrounded = (DistanceToGround() < groundDist) ? true : false;

        //SHOULD WE JUMP?
        if(CrossPlatformInputManager.GetAxisRaw("Jump")!=0 && isGrounded)
            velocity.y = jumpForce;

        //APPLY GRAVITY
        velocity.y += Physics.gravity.y * Time.deltaTime;

        //thisTranform.position += thisTranform.forward * maxSpeed * vert * Time.deltaTime;
        //thisController.SimpleMove(thisTransform.forward * maxSpeed * vert);
        //MOVE
        thisController.Move(thisTransform.TransformDirection(velocity) * Time.deltaTime);
    }

    public float DistanceToGround() {

        RaycastHit hit;
        float distanceToGround = 0f;
        if(Physics.Raycast(thisTransform.position, -Vector3.up, out hit, Mathf.Infinity, groundLayer))
            distanceToGround = hit.distance;
        return distanceToGround;
    }
}
