using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class Trap : MonoBehaviour
{
    Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trapped");
        if(other.TryGetComponent<Trapped>(out Trapped critters))
        {
            if (critters.isBeingTrapped) return;
            Score_Mngr.instance?.IncreaseScore(1);
            Debug.Log("Component syphoned");
            StartCoroutine(Capture(critters, other.gameObject));
        }
    }
    IEnumerator Capture(Trapped critters, GameObject go)
    {
        bool isAnimationPlaying = true;
        while(isAnimationPlaying)
        {
            rb.isKinematic = true;
            transform.rotation = Quaternion.AngleAxis(Time.deltaTime, Vector3.up);
            isAnimationPlaying = critters.CaptureAnim();
            yield return null;
        }
        Destroy(go);
    }
}
