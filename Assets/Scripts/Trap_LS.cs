using System.Collections;
using UnityEngine;

public class Trap_LS : MonoBehaviour
{
    MeshRenderer mRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<MeshRenderer>();
        StartCoroutine(LifeSpan());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator LifeSpan()
    {
        MaterialPropertyBlock propertyBlock = new MaterialPropertyBlock();
        propertyBlock.SetColor("_Color", Random.ColorHSV());
        yield return new WaitForSeconds(3f);
        mRenderer.SetPropertyBlock(propertyBlock);
    }
}
