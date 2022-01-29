using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : AnimatableGameObject
{

    // Start is called before the first frame update
    public ShadowBehavior shadow;

    void Start () {
    }
    void Update() {
      if (Input.GetKeyDown(KeyCode.W)) {
        StartCoroutine(this.AnimateToNewPos(.3f, this.transform.position + Vector3.forward));
      }
      else if (Input.GetKeyDown(KeyCode.A)) {
        StartCoroutine(this.AnimateToNewPos(.3f, this.transform.position + Vector3.left));
      }
      else if (Input.GetKeyDown(KeyCode.S)) {
        StartCoroutine(this.AnimateToNewPos(.3f, this.transform.position + Vector3.back));
      }
      else if (Input.GetKeyDown(KeyCode.D)) {
        StartCoroutine(this.AnimateToNewPos(.3f, this.transform.position + Vector3.right));
      }
      else if (Input.GetKeyDown(KeyCode.C)) {
        if (CameraMover.inShadowRealm) {
          this.switchSides();
        }
      }
    }

  public void switchSides() {
    Vector3 newPos = this.transform.position;
    newPos.z += this.shadow.selfSize.z;
    StartCoroutine(this.AnimateToNewPos(1f, newPos));
  }

}
