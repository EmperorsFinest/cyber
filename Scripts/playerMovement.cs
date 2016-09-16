using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour
{

    public float strafeSpeed = 3.5f;
    public float forwardSpeed = 4.5f;
    public float backwardSpeed = 4f;
    public Vector3 positionMouse;
    float speed;                        // The speed that the player will move at.
    Vector3 movement;                   // The vector to store the direction of the player's movement.
    Animator anim;                      // Reference to the animator component.
    Rigidbody playerRigidbody;          // Reference to the player's rigidbody.
    int floorMask;                      // A layer mask so that a ray can be cast just at gameobjects on the floor layer.
    float camRayLength = 100f;          // The length of the ray from the camera into the scene.
    bool walkForward;
    bool walkBackward;
    bool idle;
    Vector3 forward;
    float headingAngle;
    Vector3 playerTransform;

    void Awake() //wird auch aktiviert wenn das Skript deaktiviert ist
    {
        // Create a layer mask for the floor layer.
        floorMask = LayerMask.GetMask("Ground");

        // Set up references.
        anim = GetComponent<Animator>();

        playerRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        
        playerTransform = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);
        // Get a copy of your forward vector
        forward = transform.forward;
        // Zero out the y component of your forward vector to only get the direction in the X,Z plane
        forward.y = 0;
        //headingAngle = Quaternion.LookRotation(forward).eulerAngles.y;
        //Debug.Log(headingAngle);
        //Debug.Log("speed:"+speed);

        // Store the input axes.
        float h = Input.GetAxisRaw("Horizontal");
        
        float v = Input.GetAxisRaw("Vertical");
        

        // Move the player around the scene.
        Move(h, v);
    
        // Turn the player to face the mouse cursor.
        Turning();
        MovePlayerWithAnimations(h, v);
        //AnimatePlayer(h, v);
    }

    void Move(float h, float v)
    {


        //playerRigidbody.velocity.Set(h, 0f, v);

        // Set the movement vector based on the axis input.
        movement.Set(h, 0f, v);

        // Normalise the movement vector and make it proportional to the speed per second.
        movement = movement.normalized * speed * Time.deltaTime;

        // Move the player to it's current position plus the movement.
        playerRigidbody.MovePosition(transform.position + movement);
    }

   



    void MovePlayerWithAnimations(float h, float v)
    {

        anim.SetFloat("SpeedH", h);
        anim.SetFloat("SpeedV", v);
        anim.SetFloat("headingAngle", headingAngle);
        if (v > 0 && headingAngle >= 315f && headingAngle <= 360f){
            //Play Forward Walking Animation
            speed = v*forwardSpeed;

        }
        else if (v > 0 && headingAngle >= 0f && headingAngle <= 45f)
        {
            speed = v * forwardSpeed;
            //Play Forward Walking Animation

        }

        else if ( v > 0 && headingAngle > 45f && headingAngle < 135f)
        {
            speed = v* strafeSpeed;
            //Play Strafe Left        

        }
        else if (v > 0 && headingAngle >= 135f && headingAngle <= 225f)
        {
            speed = v* backwardSpeed;
            //Play Walk Backwards

        }
        else if (v > 0 && headingAngle > 225f && headingAngle < 315f)
        {
            speed =v* strafeSpeed;
            //Play Strafe Right

        }
        //Press Backwards S
        else if (v < 0 && headingAngle >= 315f && headingAngle <= 360f)
        {
            speed = v*-backwardSpeed;
            //Play Backward Animation

        }
        else if (v < 0 && headingAngle >= 0f && headingAngle <= 45f)
        {
            speed = v*-backwardSpeed;
            //Play Backward Animation

        }
        else if (v < 0 && headingAngle > 45f && headingAngle < 135f)
        {
            speed = v*-strafeSpeed;
            //Play Strafe Right

        }
        else if (v < 0 && headingAngle >= 135f && headingAngle <= 225f)
        {
            speed = v * -forwardSpeed;
            //Play Forward Walking Animation
        }
        else if (v < 0 && headingAngle > 225f && headingAngle < 315f)
        {
            speed = v*-strafeSpeed;
            //Play Strafe Left

        }
        if (v > 0 && headingAngle >= 315f && headingAngle <= 360f){
            //Play Forward Walking Animation
            speed = v* forwardSpeed;

        }
        else if (v > 0 && headingAngle >= 0f && headingAngle <= 45f)
        {
            speed = v * forwardSpeed;
            //Play Forward Walking Animation

        }

        else if ( v > 0 && headingAngle > 45f && headingAngle < 135f)
        {
            speed = v* strafeSpeed;
            //Play Strafe Left        

        }
        else if (v > 0 && headingAngle >= 135f && headingAngle <= 225f)
        {
            speed = v* backwardSpeed;
            //Play Walk Backwards

        }
        else if (v > 0 && headingAngle > 225f && headingAngle < 315f)
        {
            speed =v* strafeSpeed;
            //Play Strafe Right

        }
        //Press Backwards S
        else if (v < 0 && headingAngle >= 315f && headingAngle <= 360f)
        {
            speed = v*-backwardSpeed;
            //Play Backward Animation

        }
        else if (v < 0 && headingAngle >= 0f && headingAngle <= 45f)
        {
            speed = v*-backwardSpeed;
            //Play Backward Animation

        }
        else if (v < 0 && headingAngle > 45f && headingAngle < 135f)
        {
            speed = v*-strafeSpeed;
            //Play Strafe Right

        }
        else if (v < 0 && headingAngle >= 135f && headingAngle <= 225f)
        {
            speed = v * -forwardSpeed;
            //Play Forward Walking Animation
        }
        else if (v < 0 && headingAngle > 225f && headingAngle < 315f)
        {
            speed = v*-strafeSpeed;
            //Play Strafe Left

        }

        // h greater Zero Press D
        if (h > 0 && headingAngle >= 315f && headingAngle <= 360f)
        {
            //Play Strafe Right
            speed = h * strafeSpeed;

        }
        else if (h > 0 && headingAngle >= 0f && headingAngle <= 45f)
        {
            speed = h * strafeSpeed;
            //Play Strafe Right

        }

        else if (h > 0 && headingAngle > 45f && headingAngle < 135f)
        {
            speed = h * forwardSpeed;
            //Play Forward Running       

        }
        else if (h > 0 && headingAngle >= 135f && headingAngle <= 225f)
        {
            speed = h * strafeSpeed;
            //Play Strafe Left

        }
        else if (h > 0 && headingAngle > 225f && headingAngle < 315f)
        {
            speed = h * backwardSpeed;
            //Play Backward Walking

        }
        //Press Left A 
        else if (h < 0 && headingAngle >= 315f && headingAngle <= 360f)
        {
            speed = h * -strafeSpeed;
            //Play Strafe Left

        }
        else if (h < 0 && headingAngle >= 0f && headingAngle <= 45f)
        {
            speed = h * -strafeSpeed;
            //Play Strafe Left

        }
        else if (h < 0 && headingAngle > 45f && headingAngle < 135f)
        {
            speed = h * -backwardSpeed;
            //Play Backward Run

        }
        else if (h < 0 && headingAngle >= 135f && headingAngle <= 225f)
        {
            speed = h * -strafeSpeed;
            //Play Strafe Right
        }
        else if (h < 0 && headingAngle > 225f && headingAngle < 315f)
        {
            speed = h * -forwardSpeed;
            //Play Forward Run

        }




        // Press W plus D
        if (h > 0 && v > 0 && headingAngle >= 0 && headingAngle <= 90f)
        {
            //Play Forward Running   
            speed = h * forwardSpeed;

        }
        else if (h > 0 && v > 0 && headingAngle > 90f && headingAngle < 180f)
        {
            speed = h * strafeSpeed;
            //Play Strafe 

        }

        else if (h > 0 && v > 0 && headingAngle >= 180f && headingAngle <= 270f)
        {
            speed = h * backwardSpeed;
            //Play Backward 

        }
        else if (h > 0 && v > 0 && headingAngle > 270f && headingAngle <= 360f)
        {
            speed = h * strafeSpeed;
            //Play Strafe
        }


        // Press S plus D
        if (h > 0 && v < 0 && headingAngle >= 0 && headingAngle <= 90f)
        {
            //Play Strafe  
            speed = h * strafeSpeed;

        }
        else if (h > 0 && v < 0 && headingAngle > 90f && headingAngle < 180f)
        {
            speed = h * forwardSpeed;
            //Play Forward Running 

        }

        else if (h > 0 && v < 0 && headingAngle >= 180f && headingAngle <= 270f)
        {
            speed = h * strafeSpeed;
            //Play Strafe 

        }
        else if (h > 0 && v < 0 && headingAngle > 270f && headingAngle <= 360f)
        {
            speed = h * backwardSpeed;
            //Play Backward 
        }

        // Press S plus A
        if (h < 0 && v < 0 && headingAngle >= 0 && headingAngle <= 90f)
        {
            //Play Backward   
            speed = h * -backwardSpeed;

        }
        else if (h < 0 && v < 0 && headingAngle > 90f && headingAngle < 180f)
        {
            speed = h * -strafeSpeed;
            //Play Strafe

        }

        else if (h < 0 && v < 0 && headingAngle >= 180f && headingAngle <= 270f)
        {
            speed = h * -forwardSpeed;
            //Play Forward Running 

        }
        else if (h < 0 && v < 0 && headingAngle > 270f && headingAngle <= 360f)
        {
            speed = h * -strafeSpeed;
            //Play Strafe
        }

        // Press W plus A
        if (h < 0 && v > 0 && headingAngle >= 0 && headingAngle <= 90f)
        {
            //Play Strafe  
            speed = h * -strafeSpeed;

        }
        else if (h < 0 && v > 0 && headingAngle > 90f && headingAngle < 180f)
        {
            speed = h * -backwardSpeed;
            //Play Backward

        }

        else if (h < 0 && v > 0 && headingAngle >= 180f && headingAngle <= 270f)
        {
            speed = h * -strafeSpeed;
            //Play Strafe

        }
        else if (h < 0 && v > 0 && headingAngle > 270f && headingAngle <= 360f)
        {
            speed = h * -forwardSpeed;
            //Play Forward Running 
        }


        // Idle Mode both zero
        else if (v == 0 && h == 0)
        {
            speed = 0;
            //Play Idle

        }

    }
    


    void Turning()
    {


        // Create a ray from the mouse cursor on screen in the direction of the camera.
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Create a RaycastHit variable to store information about what was hit by the ray.
        RaycastHit floorHit;

        // Perform the raycast and if it hits something on the floor layer...
        if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
        {
            positionMouse = floorHit.point;
            // Create a vector from the player to the point on the floor the raycast from the mouse hit.
            Debug.Log(positionMouse);

            Vector3 playerToMouse = floorHit.point - playerTransform;
            //Debug.Log(playerToMouse);
            // Ensure the vector is entirely along the floor plane.
            playerToMouse.y = 0f;
           
            // Create a quaternion (rotation) based on looking down the vector from the player to the mouse.
            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            headingAngle = Quaternion.LookRotation(playerToMouse).eulerAngles.y;
            // Set the player's rotation to this new rotation.
            playerRigidbody.MoveRotation(newRotation);
        }
    }



}

