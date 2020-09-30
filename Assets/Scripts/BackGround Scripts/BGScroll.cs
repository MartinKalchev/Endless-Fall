using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroll : MonoBehaviour
{

    public float scroll_speed = 0.3f;

    private MeshRenderer mesh_Renderer;


    private void Awake()
    {
        mesh_Renderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Scroll();
    }

    //Function that scrolls the background
    void Scroll()
    {
        Vector2 offset = mesh_Renderer.sharedMaterial.GetTextureOffset("_MainTex");
        offset.y += Time.deltaTime * scroll_speed;

        mesh_Renderer.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }
}
