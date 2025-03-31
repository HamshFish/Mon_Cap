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
        Color currentColor = propertyBlock.GetColor("_BaseColor");
        yield return new WaitForSeconds(1f);
        float a = 1;
        
        
        
        while (true)
        {
            a = Mathf.Lerp(a, 0, Time.deltaTime * 1f);
            currentColor.a = a;
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
