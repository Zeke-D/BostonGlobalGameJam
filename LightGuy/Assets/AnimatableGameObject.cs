using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatableGameObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator AnimateToNewPos(float duration, Vector3 newPos) {

      float elapsed = 0;

      while (elapsed < duration) {
        float customProgress = Mathf.SmoothStep(0, 1, Mathf.SmoothStep(0, 1, Mathf.SmoothStep(0, 1, (elapsed / duration))));
        this.transform.position = Vector3.Lerp(this.transform.position, newPos, customProgress);
        elapsed += Time.deltaTime;
        yield return null;
      }
    }
}
