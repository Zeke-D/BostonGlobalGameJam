using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{

    private Vector3 initialPos;
    private Quaternion initialRot;
    private float animationProgress = 0; // from 0 to 1 based on progress from animation to new quaternion

    public bool inShadowRealm = false;
    // Start is called before the first frame update
    void Start()
    {
      this.initialPos = this.transform.position;
      this.initialRot = this.transform.rotation;
    }

    void Update()
    {
      if (Input.GetKeyDown(KeyCode.Space)) {
        if (inShadowRealm) {
          this.transform.position = this.initialPos;
          this.transform.rotation = this.initialRot;
        }
        else {
          this.transform.position = new Vector3(0, 20, 0);
          this.transform.rotation = Quaternion.Euler(90, 0, 0);
        }
        this.inShadowRealm = !this.inShadowRealm;
      }
    }
}
