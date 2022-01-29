using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowBehavior : MonoBehaviour
{
  public LightBehavior lightSource;
  public GameObject parentPlayer;
  public float growthLimitFactor = 1;

  // Start is called before the first frame update
  void Start() { }

  // Update is called once per frame
  void Update()
  {
    float lightDiff = Vector3.Distance(this.lightSource.getInitPos(), this.lightSource.transform.position);
    Debug.Log(lightDiff);
    float zScaleAmt = (lightDiff) / this.growthLimitFactor;

    Vector3 parentSize = this.parentPlayer.GetComponent<Collider>().bounds.size;
    Vector3 parentPos = this.parentPlayer.transform.position;
    Vector3 selfSize = this.GetComponent<Collider>().bounds.size;

    this.transform.position = new Vector3(parentPos.x, parentPos.y - parentSize.y / 2, parentPos.z + parentSize.z / 2 + selfSize.z / 2);
    this.transform.localScale = new Vector3(.09f, 1, zScaleAmt);
  }
}
