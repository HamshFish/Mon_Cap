using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Trap_Gun : MonoBehaviour
{
    public float shootSpeed = 10f;
    public GameObject trapPrefab;
    public List<GameObject> traps;
    public Vector3 trapOffset;
    public Vector3 trapRot;

    public Camera cam;

    private void Awake()
    {
        if (cam == null) { cam = Camera.main; }
        if (cam == null) { cam = FindFirstObjectByType<Camera>(); }
    }

    void OnAttack()
    {
        Vector3 spawnPos = transform.position + (cam.transform.forward * trapOffset.z);
        spawnPos.y += trapOffset.y;
        spawnPos += cam.transform.right * trapOffset.x;
        GameObject trap = Instantiate(trapPrefab, spawnPos, Quaternion.Euler(trapRot));
        trap.GetComponent<Rigidbody>()?.AddForce(cam.transform.forward * shootSpeed);
        traps.Add(trap);
    }
}
