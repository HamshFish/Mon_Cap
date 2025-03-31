using System;
using System.Collections;
using UnityEngine;

public class Trap_LS : MonoBehaviour
{
    MeshRenderer[] mRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<MeshRenderer>();
        mRenderer = GetComponentsInChildren<MeshRenderer>();
        StartCoroutine(LifeSpan());
    }


    IEnumerator LifeSpan()
    {
        MaterialPropertyBlock propertyBlock = new MaterialPropertyBlock();
        Color currentColor = mRenderer[0].material.color;
        yield return new WaitForSeconds(1f);
        float startTime = Time.time;
        float endTime = startTime + 3f;
        while (Time.time < endTime)
        {
            float t = 1 - Mathf.InverseLerp(startTime, endTime, Time.time);
            currentColor.a = t;
            propertyBlock.SetColor("_BaseColor", currentColor);
            foreach (MeshRenderer renderer in mRenderer)
            {
                renderer.SetPropertyBlock(propertyBlock);
            }
            yield return null;
        }
        
        
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
