using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    // Mesh renderer components
    private Renderer rend; // Mesh renderer
    private Material rendMat; // Material from renderer
    private Color mainColor; // Colour whene started
    public Color32 touchColor; // Colour when collided

    // Audio components
    public AudioSource AudioSource; // audio object
    public AudioClip AudioClip; // audio track

    private void Awake()
    {
        // Assign mesh renderer component and enable
        rend = GetComponent<Renderer>();
        rend.enabled = true;
    }

    // Use this for initialization
    void Start()
    {
        // Assign Material and colour variables
        rend = GetComponent<Renderer>();
        rendMat = rend.material;
        mainColor = rendMat.GetColor("_Color"); 
        touchColor = new Color32(255, 200, 255, 255);

        // Assign audio clip and volume
        AudioSource.clip = AudioClip;
        AudioSource.volume = 0.02f;
    }

    // Update is called once per frame
    void Update() { }

    // Actions when hand enters
    public void ObjectTouched()
    {
        // set colour to 'touchColor' 
        rendMat.SetColor("_Color", touchColor);
        AudioSource.Play();
    }

    // Actions when hand exits
    public void ObjectReturn()
    {
        // Return color to original/main colour
        rendMat.SetColor("_Color", mainColor);
    }

    // Actions when touches another rigidbody
    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Stick")
        {
            AudioSource.Play();
        }
    }
}
