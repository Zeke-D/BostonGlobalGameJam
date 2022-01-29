using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoublePlayerController : MonoBehaviour
{
    [SerializeField]
    private GameObject body;

    [SerializeField]
    private ShadowBehavior shadow;



    private Vector3 playerVelocity;
    [SerializeField]
    private float playerSpeed = 20.0f;

    public static bool sunk = false;
    private float sinkSpeed = 2.0f;
    private float floorY = 0.3f;
    private float raiseHeight = .5f;
    private float lowerHeight = .3f;

    Vector3 preSinkShadow;

    private void Start()
    {
    }

    void Update()
    {
        // sink player
        if (Input.GetKeyDown(KeyCode.LeftShift)) sunk = !sunk;


        Vector3 target = shadow.transform.position + new Vector3(0, .01f, 0);
        // Sets the y for sinking
        if (sunk)
            target.y -= lowerHeight;
        else
            target.y = raiseHeight;

        // could be a coroutine tbh idk
        if (Mathf.Abs((target - body.transform.position).y) > .05f)
        {
            this.shadow.pause();
            // Corrects y value to make sure no float and sink correctly
            body.GetComponent<Rigidbody>().isKinematic = true;
            body.GetComponent<BoxCollider>().enabled = false;
            float step = sinkSpeed * Time.deltaTime;
            Vector3 MT = Vector3.MoveTowards(body.transform.position, target, step);
            MT.x = target.x;
            MT.z = target.z;
            body.transform.position = MT;

        }
        else if(!sunk)
        {
            this.shadow.play();
            body.GetComponent<Rigidbody>().isKinematic = false;
            body.GetComponent<BoxCollider>().enabled = true;

            // Player movement
            Vector3 m_Input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

            body.GetComponent<Rigidbody>().AddForce(m_Input * Time.deltaTime * playerSpeed);
            shadow.transform.position = new Vector3( body.transform.position.x, floorY, body.transform.position.z);



        }
        else
        {
            // SHADOW PLAYER ENABLED ?
            // HERE SHADOW CAN INTERACT WITH THINGS
        }
    }
}
