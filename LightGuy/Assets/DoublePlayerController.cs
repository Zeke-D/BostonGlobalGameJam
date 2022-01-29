using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoublePlayerController : MonoBehaviour
{
    [SerializeField]
    private GameObject body;
    [SerializeField]
    private GameObject shadow;

    private CharacterController controllerP, controllerS;
    private Vector3 playerVelocity;

    [SerializeField]
    private float playerSpeed = 2.0f;

    private bool sunk = false;

    private float sinkSpeed = 2.0f;

    private void Start()
    {
        controllerP = body.GetComponent<CharacterController>();
        controllerS = shadow.GetComponent<CharacterController>();
    }

    void Update()
    {
        Vector3 target = shadow.transform.position;
        
        // sink player
        if (Input.GetKeyDown("space"))
        {
            sunk = !sunk;
        }

        if (sunk)
        {
            target.y -= 2;

        }
        else
        {
            //bad
            target.y += 2;
        }


        if (Mathf.Abs((target - body.transform.position).y) > .05f)
        {

            controllerP.enabled = false;
            controllerS.enabled = false;
            float step = sinkSpeed * Time.deltaTime;
            Vector3 MT = Vector3.MoveTowards(body.transform.position, target, step);
            MT.x = target.x;
            MT.z = target.z;
            body.transform.position = MT;
            
        }
        else if (sunk)
        {
            controllerP.enabled = false;
            controllerS.enabled = true;
        }
        else
        {
            controllerP.enabled = true;
            controllerS.enabled = true;
        }



        if (controllerS.enabled)
        {
            Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            controllerS.Move(move * Time.deltaTime * playerSpeed);

            if (!sunk)
            {
                controllerP.Move(move * Time.deltaTime * playerSpeed);
                if (move != Vector3.zero)
                {
                    //shadow doesnt rotate.
                    //shadow.transform.forward = move;
                    body.transform.forward = move;
                }

                controllerP.Move(playerVelocity * Time.deltaTime);
            }
            controllerS.Move(playerVelocity * Time.deltaTime);
        }
    }
}
