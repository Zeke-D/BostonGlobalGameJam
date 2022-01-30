using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowBehavior : MonoBehaviour
{
  public LightBehavior zAxisLightSource;
  public LightBehavior xAxisLightSource;
  public GameObject player;
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
      //float lightDiff = Vector3.Distance(this.zAxisLightSource.getInitPos(), this.zAxisLightSource.transform.position);
      Vector3 parentSize = this.player.GetComponent<Collider>().bounds.size;
      Vector3 parentPos = this.player.transform.position;
      this.selfSize = this.GetComponent<Collider>().bounds.size;
      Vector3 playerPos = this.player.transform.position + new Vector3(parentSize.x / 2, 0, parentSize.z / 2);

      Vector3 zLightPos = this.zAxisLightSource.transform.position;
      float d = parentSize.y;
      float f = zLightPos.y - d;
      float e = parentPos.z - zLightPos.z;
      float zShadowLength = d * e / f;
      float zDir = zShadowLength > 0 ? 1 : -1;
      Debug.Log(zShadowLength);

      Vector3 xLightPos = this.xAxisLightSource.transform.position;
      float x_d = parentSize.y;
      float x_f = xLightPos.y - x_d;
      float x_e = parentPos.x - xLightPos.x;
      float xShadowLength = x_d * x_e / x_f;
      float xDir = xShadowLength > 0 ? 1 : -1;

      this.transform.position = new Vector3(
        !CameraMover.lightAxisIsZ ? parentPos.x + xDir * (parentSize.x / 2) + (xShadowLength / 2) : parentPos.x,
        .01f,
        CameraMover.lightAxisIsZ ? parentPos.z + zDir * (parentSize.z / 2) + (zShadowLength / 2) : parentPos.z
      );

      this.transform.localScale = new Vector3(
        !CameraMover.lightAxisIsZ ? xShadowLength : 1,
        .01f,
        CameraMover.lightAxisIsZ ? zShadowLength : 1
      );
    }
  }

  public void pause() {
    this.paused = true;
  }
  public void play() {
    this.paused = false;
  }

}
