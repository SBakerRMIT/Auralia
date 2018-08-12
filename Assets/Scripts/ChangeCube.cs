using UnityEngine;
using System.Collections;
using UnityEngine.UI; // Required when Using UI elements.

public class ChangeCube : MonoBehaviour
{
    // Mesh renderer components
    private Renderer rend; // Mesh renderer
    private Material rendMat; // Material from renderer
    public Slider colorSlider; // Colour Slider component
    public Color altColor; // <------------------- NEEDED?

    // Value of slider
    public float SliderValue = 0.0f;

    private void Awake()
    {
        // Create renderer material object
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rendMat = rend.material;
    }

    private void Start()
    {
        colorSlider.onValueChanged.AddListener(delegate
       {
           ValueChangeCheckRed();
       });

        altColor = rend.material.color;
    }

    public void ValueChangeCheckRed()
    {
        SliderValue = GUI.HorizontalSlider(new Rect(25, 25, 100, 30), SliderValue, 0.0f, 10.0f);
        altColor.r = colorSlider.value;
        rend.material.SetColor("_Color", altColor);
    }

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
//}
