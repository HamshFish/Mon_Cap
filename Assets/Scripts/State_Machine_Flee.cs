using System.Collections;
using UnityEngine;

public class State_Machine_Flee : MonoBehaviour, Trapped
{
    private Color flee = Color.cyan;
    private Color alert = Color.magenta;
    private Color patrol = Color.green;
    private Renderer rendition;
    Rigidbody rb;
    float timer = 1;
    public enum States
    {
        Patrol,
        Alerted,
        Flee
    }
    public States states;
    public GameObject player;
    Vector3 originScale;
    public bool isBeingTrapped { get; set; }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rendition = GetComponent<Renderer>();
        rb = GetComponent<Rigidbody>();
        originScale = transform.localScale;
        NextState();
    }
    void NextState()
    {
        switch (states)
        {
            case States.Patrol:
                StartCoroutine(PatrolState());
                break;
            case States.Alerted:
                StartCoroutine(AlertedState());
                break;
            case States.Flee:
                StartCoroutine(FleeState());
                break;
            default:
                break;
        }
    }
    bool IsFacingGrimm()
    {
        Vector3 directionToPlayer = player.transform.position - transform.position;
        directionToPlayer.Normalize();
        float dotResult = Vector3.Dot(directionToPlayer, transform.forward);
        return dotResult >= 0.95f;
    }
    IEnumerator PatrolState()
    {
        Debug.Log("Entering Patrol State");
        while (states == States.Patrol)
        {
            float visualRange = Vector3.Distance(transform.position, player.transform.position);

            rendition.material.color = patrol;
            transform.rotation *= Quaternion.Euler(0f, 50f * Time.deltaTime, 0f);
            if (IsFacingGrimm() && visualRange <= 30f)
            {
                states = States.Alerted;
            }
            yield return null;
        }
        Debug.Log("Exiting Patrol State");
        NextState();
    }
    IEnumerator AlertedState()
    {
        Debug.Log("Entering Alerted State");
        while (states == States.Alerted)
        {
            rendition.material.color = alert;
            if (player.transform.position.magnitude < 3f)
            { states = States.Flee; }
            yield return null;
        }
        Debug.Log("Exiting Alerted State");
        NextState();
    }
    IEnumerator FleeState()
    {
        Debug.Log("Entering Flee State");
        while(states == States.Flee)
        {
            float visualRange = Vector3.Distance(transform.position, player.transform.position);
            rendition.material.color = flee;
            float wave = Mathf.Sin(Time.time * 20f) * 0.1f + 1f;
            float wave2 = Mathf.Cos(Time.time * 20f) * 0.1f + 1f;
            transform.localScale = new Vector3(wave, wave2, wave);
            Vector3 direction = player.transform.position - transform.position;
            rb.AddForce(direction.normalized * (-800f * Time.deltaTime));
            if (visualRange > 60f)
            {
                states = States.Patrol;
            }
            yield return null;
        }
        Debug.Log("In A Safe Spot.");
        NextState();
    }
    public bool CaptureAnim()
    {
        isBeingTrapped = true;
        timer -= Time.deltaTime * 1f;
        transform.localScale = Vector3.Lerp(Vector3.zero, originScale, timer);
        if (timer <= 0) { return false; }
        return true;
    }
    public int Points()
    {
        return 3;
    }
}
