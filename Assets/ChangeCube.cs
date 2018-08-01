using UnityEngine;
using System.Collections;
using UnityEngine.UI; // Required when Using UI elements.

public class ChangeCube : MonoBehaviour
{
    Renderer rend;
    public Color altColor;

    public Slider colorSliderRed;

    float red;

    private void Awake()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
    }

    private void Start()
    {
        colorSliderRed.onValueChanged.AddListener( delegate
        {
            ValueChangeCheckRed();
        });

        altColor = rend.material.color;
    }

    public void ValueChangeCheckRed()
    {
        altColor.r = colorSliderRed.value;
        rend.material.SetColor("_Color", altColor);
    }



    //public Slider redSlider;
    //private Color ballColor;
    //private Renderer myRenderer;
    //private Material myMaterial;
    //private bool pastStart = false;
    //private int launchCount;


    //public void Start()
    //{
    //    myRenderer = GetComponent<Renderer>();
    //    myMaterial = myRenderer.material;
    //    ballColor = myMaterial.color;
    //    ballColor.r = 0;
    //    ballColor.g = 0;
    //    ballColor.b = 0;
    //    redSlider.value = ballColor.r;
    //    pastStart = true;
    //}

    //public void Update() { }

    //// Handle slider changes
    //public void UpdateSliders()
    //{
    //    if (!pastStart) { return; }

    //    ballColor.r = redSlider.value;
    //    myMaterial.color = ballColor;
    //}
}
