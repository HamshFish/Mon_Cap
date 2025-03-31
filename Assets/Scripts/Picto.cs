using UnityEngine;

public class Picto : MonoBehaviour, Trapped
{
    // Update is called once per frame
    void Update()
    {
        float jiggle = Mathf.Sin(Time.time * 20f) * 0.1f + 1f;
        transform.localScale = new Vector3(jiggle, jiggle, jiggle);
    }
    public void CaptureAnim()
    {
        transform.localScale *= Time.deltaTime * 1f;
    }

    public int Points()
    {
        return 1;
    }
}
