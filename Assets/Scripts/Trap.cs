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
        if(other.TryGetComponent<Trapped>(out Trapped critters))
        {
            StartCoroutine(Capture(critters));
        }
    }
    IEnumerator Capture(Trapped critters)
    {

        while(true)
        {
            rb.isKinematic = true;
            transform.rotation = Quaternion.AngleAxis(Time.deltaTime, Vector3.up);
            critters.CaptureAnim();
            yield return null;
        }
    }
}
