using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowBehavior : MonoBehaviour
{
  public LightBehavior lightSource;
  public PlayerController parentPlayer;
  public float growthLimitFactor = 1;
  public Vector3 selfSize;
  private bool paused;

  // Start is called before the first frame update
  void Start() {
  }

  // Update is called once per frame
  void Update()
  {
    if (!paused) {
      float lightDiff = Vector3.Distance(this.lightSource.getInitPos(), this.lightSource.transform.position);
      float zScaleAmt = (lightDiff) / this.growthLimitFactor;

      Debug.Log(zScaleAmt);

      Vector3 parentSize = this.parentPlayer.GetComponent<Collider>().bounds.size;
      Vector3 parentPos = this.parentPlayer.transform.position;
      this.selfSize = this.GetComponent<Collider>().bounds.size;

      this.transform.position = new Vector3(parentPos.x, .01f, parentPos.z + selfSize.z / 2);
      this.transform.localScale = new Vector3(1, .01f, zScaleAmt);
    }
  }

  public void pause() {
    this.paused = true;
  }
  public void play() {
    this.paused = false;
  }

}
