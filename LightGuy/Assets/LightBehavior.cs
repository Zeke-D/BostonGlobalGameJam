using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBehavior : MonoBehaviour
{
    private Vector3 initialPos;
    // Start is called before the first frame update
    void Start()
    {
      this.initialPos = this.transform.position;
    }

    // Update is called once per frame
    public Vector3 getInitPos() {
      return this.initialPos;
    }


    void FixedUpdate()
    {
      this.transform.position = new Vector3(this.transform.position.x, this.initialPos.y - (Mathf.Sin(Time.time) + 1) / 2, this.transform.position.z);
    }
}
