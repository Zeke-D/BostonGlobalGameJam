using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class piviot_door : MonoBehaviour
{
     private Vector3 initialPos;
    private Quaternion initialRot;
    void Start()
    {
        this.initialPos = this.transform.position;
        this.initialRot = this.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E)) {
        this.initialRot = Quaternion.Euler(0, -90, 0);
      }
    }
}
