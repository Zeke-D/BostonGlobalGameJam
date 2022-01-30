using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{

    private Vector3 initialPos;
    private Quaternion initialRot;
    private float updateCallsSinceStart = 0;
    private float totalUpdateCallAnimationLength = 30;
    public static bool inShadowRealm = false;
    public static bool lightAxisIsZ = true;


    // Start is called before the first frame update
    void Start()
    {
      this.initialPos = this.transform.position;
      this.initialRot = this.transform.rotation;
    }

    void Update()
    {
      float animationProgress = updateCallsSinceStart / totalUpdateCallAnimationLength; // from 0 to 1 based on progress from animation to new quaternion
      if (Input.GetKeyDown(KeyCode.Space)) {
        StartCoroutine(this.Transition(.3f, !CameraMover.inShadowRealm));
        CameraMover.inShadowRealm = !CameraMover.inShadowRealm;
      }
    }

    IEnumerator Transition (float duration, bool playForwards) {
      float elapsed = 0;
      Quaternion topView = Quaternion.Euler(90, 0, 0);
      Quaternion fromRot = playForwards ? this.initialRot : topView;
      Quaternion toRot = playForwards ? topView : this.initialRot;

      Vector3 topPos = new Vector3(0, 20, 0);
      Vector3 fromPos = playForwards ? this.initialPos : topPos;
      Vector3 toPos = playForwards ? topPos : this.initialPos;

      while (elapsed < duration) {
        this.transform.rotation = Quaternion.Lerp(fromRot, toRot, elapsed / duration);
        this.transform.position = Vector3.Lerp(fromPos, toPos, elapsed / duration);
        elapsed += Time.deltaTime;
        yield return null;
      }
    }
}
