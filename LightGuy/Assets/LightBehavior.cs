using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
      this.transform.position = new Vector3(this.transform.position.x, 5 - (Mathf.Sin(Time.time) + 1) / 2, this.transform.position.z);
    }
}
