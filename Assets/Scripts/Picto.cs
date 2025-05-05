using UnityEngine;

public class Picto : MonoBehaviour, Trapped
{
    Vector3 originalScale;
    float timer = 1;
    public bool isBeingTrapped { get; set; } = false;
    void Awake()
    {
        originalScale = transform.localScale;
    }
    // Update is called once per frame
    
    public bool CaptureAnim()
    {
        isBeingTrapped = true;
        timer -= Time.deltaTime * 1f;
        transform.localScale = Vector3.Lerp(Vector3.zero, originalScale, timer);
        if(timer <= 0) { return false; }
        return true;
    }

    public int Points()
    {
        return 1;
    }
    void Update()
    {
        if (isBeingTrapped) return;
        float jiggle = Mathf.Sin(Time.time * 20f) * 0.1f;
        transform.localScale = new Vector3(jiggle, jiggle, jiggle) + originalScale;
    }
}
