using System.Collections;
using UnityEngine;

public class State_Machine_Flee : MonoBehaviour, Trapped
{
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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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
                StartCoroutine(AlertState());
                break;
            case States.Flee:
                StartCoroutine(FleeState());
                break;
            default:
                break;
        }
    }
    bool isFacingGrimm()
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
            transform.rotation *= Quaternion.Euler(0f, 50f * Time.deltaTime, 0f);
            if (isFacingGrimm())
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

        }
        Debug.Log("Exiting Alerted State");
        NextState();
    }
    IEnumerator FleeState()
    {
        Debug.Log("Entering Flee State");
        while(states == States.Flee)
        {
            float wave = Mathf.Sin(Time.time * 20f) * 0.1f + 1f;
            float wave2 = Mathf.Cos(Time.time * 20f) * 0.1f + 1f;
            transform.localScale = new Vector3(wave, wave2, wave);
            Vector3 direction = player.transform.position + transform.position;
            rb.AddForce(direction.normalized * (800f * Time.deltaTime));
        }
    }
}
