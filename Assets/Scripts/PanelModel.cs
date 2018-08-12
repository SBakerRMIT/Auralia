using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelModel : MonoBehaviour
{

    // =========== Declarations ===========

    private bool pastStart = false; 
    public GameObject cube;
    private const float yDiff = 0.0f; /// Current y-postion off zero
    public Slider colourSlider;

    /// Audio components
    public AudioClip MusicClip;
    public AudioSource MusicSource;
    private Boolean isPaused;

    /// Mesh renderer components
    private Renderer rend; /// Mesh renderer
    private Material rendMat; /// Material from renderer
    public Color cubeColour; /// Color object for cube

    // =========== Awake / Start / Update ===========

    private void Awake() { }

    /// Use this for initialization
    void Start()
    {
        Debug.Log("** LOG: STARTED **");
        /// Create renderer material object
        rend = cube.GetComponent<Renderer>();
        rend.enabled = true;
        rendMat = rend.material;
        cubeColour = rendMat.color;
        pastStart = true;
        MusicSource.clip = MusicClip;
        isPaused = false;
    }
    	
	/// Update is called once per frame
	void Update () { }

    // =========== Regular Methods ===========

    public void Slider_ChangeHeight(float sliderValue)
    {
        Vector3 pos = cube.transform.position; /// assign position of the cube to temp variable
        pos.y = sliderValue + yDiff; /// Set 'y' value to be slider value
        cube.transform.position = pos; /// Reassign back to transformations position
    }

    public void Slider_ChangeColour(float sliderValue)
    {
        if (!pastStart) return;
        cubeColour.r = sliderValue / 255;
        cubeColour.b = (255 - sliderValue) / 255;
        rendMat.color = cubeColour;
    }

    public void PlayPause()
    {
        if (MusicSource.isPlaying)
        {
            MusicSource.Pause();
            isPaused = true;
            Debug.Log("<Paused>");
        }
        else
        {
            if(isPaused)
            {
                MusicSource.UnPause();
                Debug.Log("<Unpaused>");
                isPaused = false;
            }
            else
            {
                MusicSource.Play();
                Debug.Log("<Played>");
            }
        }
    }
}
