using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroll : MonoBehaviour
{

    // Set speed of background scroll
    public float scroll_speed = 0.1f;

    // Create new instance of a mesh renderer for background
    private MeshRenderer mesh_renderer;

    private float y_scroll;


    void Awake() {
        mesh_renderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Scroll();
    }

    void Scroll(){
        y_scroll = Time.time * scroll_speed;

        Vector2 offset = new Vector2(0f, y_scroll);
        mesh_renderer.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }
}
