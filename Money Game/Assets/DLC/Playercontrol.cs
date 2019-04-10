using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput; //added this for the mobile controller functionality

public class Playercontrol : MonoBehaviour
{
    private Animation anime;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        // creating reference, so we don't have to call it in the update function
        rb = GetComponent<Rigidbody>(); 
        anime = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        // following float get the joystick working
        //float x and float y give us the value of the joystick from -1 to 1
        float x = CrossPlatformInputManager.GetAxis("Horizontal"); 
        float y = CrossPlatformInputManager.GetAxis("Vertical");
        Vector3 movement = new Vector3(x, 0, y); //y=0 coz we don't move in de y-axis
        rb.velocity = movement * 4f; //changing the multiplied value will change speed of player

        if(x != 0 && y != 0) // makes the player face in the direction the joystick is triggered.
        {
            //mathf.atan2 funtion returns the value of rad in degree and causes the player to rotate.
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, Mathf.Atan2(x, y) * Mathf.Rad2Deg, transform.eulerAngles.z);

            if(x !=0 || y != 0)
            {
                anime.Play("Walk");
            }
            else
            {
                anime.Play("Idle");
            }
        }
    }
}
