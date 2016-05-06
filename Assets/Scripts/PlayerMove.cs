using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

    private Rigidbody rbody = null;                                                     //Rigidbody component of the player

    private Vector3 velocity = Vector3.zero;                                            //Temp velocity for moving the player
    private float speed = 3.5f;                                                         //Speed the player moves

    private float jumpHeight = 5.0f;                                                    //Max jump height
    private float timeToReachHighestPoint = 2.0f;                                       //Time to reach highest jump point
    private float gravity = 0.0f;                                                       //Gravity

    private bool isGrounded = false;                                                    //To prevent jumping infinitely many times

    public bool facingRight = true;                                                     //Which way the character is facing, used for Flip method

    private Player player;                                                              //Reference to player script, needed for shop implementation to freeze player when in shop

	// Use this for initialization
	void Start () {

        gravity = -(2 * jumpHeight) / Mathf.Pow(timeToReachHighestPoint, 2);            //Calculate gravity with physics equation
        rbody = GetComponent<Rigidbody>();                                              //Get the rigidbody
        player = GetComponent<Player>();                                                //Get the player

    }
	
	// Update is called once per frame
	void FixedUpdate () {
        Move();                                                                         //Call Move (better performance in FixedUpdate)
    }

    void Update() {
        PerformJump();                                                                  //Call PeformJump (better performance in Update)
    }

    private void Move() {

        float xMov = Input.GetAxisRaw("Horizontal");                                    //Get (1, 0, 0) or (-1, 0, 0)

        velocity = transform.position;                                                  //Temp to change pos
        velocity.x = velocity.x + (xMov * speed * Time.deltaTime);                      //(1, 0, 0) * (3.5, 0, 0) = 3.5, 0, 0
        transform.position = velocity;                                                  //Set transform position to changed temp vel

        if(xMov < 0f && facingRight) {
            Flip();
        } else if(xMov > 0f && !facingRight) {
            Flip();
        }
    }

    private void PerformJump() {

        if((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && isGrounded == true && PauseMenuManager.gamePaused == false) {
            rbody.velocity = new Vector3(rbody.velocity.x, Mathf.Abs(gravity * timeToReachHighestPoint), 0);            //Jump using rigidbody with gravity
            isGrounded = false;                                                                                         //In air, not grounded
        }

    }

    //Pulled from Unity tutorials, flips the player
    private void Flip() {

        facingRight = !facingRight;

        Vector3 theScale = transform.localScale;
        theScale.x = theScale.x * -1;
        transform.localScale = theScale;

    }

    void OnCollisionEnter(Collision other) {

        if(other.gameObject.tag.Equals("Ground")) {                                     //If player is in contact with the ground, set isGrounded to true
            isGrounded = true;
        }

    }

}
