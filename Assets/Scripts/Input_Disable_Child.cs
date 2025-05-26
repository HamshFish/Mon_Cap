using UnityEngine;

public class Input_Disable_Child : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKey(KeyCode.Tab))
        {
            Transform[] children = GetComponentsInChildren<Transform>(true);
            if (children.Length <= 1) return;
            bool active = !children[1].gameObject.activeSelf;
            Debug.Log(active);
            foreach (var child in children)
            { 
                if(child == transform) continue;
                child.gameObject.SetActive(active);
            }

        }
    }
}
