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
        currentColor.a = 0;
        propertyBlock.SetColor("_BaseColor", currentColor);
        yield return new WaitForSeconds(3f);
        foreach (MeshRenderer renderer in mRenderer)
        {
            renderer.SetPropertyBlock(propertyBlock);
        }
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
