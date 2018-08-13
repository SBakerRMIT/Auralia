using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelModel : MonoBehaviour
{

    // =========== Declarations ===========

    /// Random
    private bool synthMuted = false;
    private bool percMuted = false;
    private bool bassMuted = false;
    private bool[] isMuted;
    private bool pastStart = false;
    public GameObject cube;
    private const float yDiff = 0.0f; /// Current y-postion off zero

    /// Audio components
    public AudioClip MusicClip_synth;
    public AudioClip MusicClip_bass;
    public AudioClip MusicClip_perc;
    public AudioSource[] MusicSources;
    private Boolean isPaused;

    /// Component objects
    public Toggle toggleBass; /// Checkbox for bass
    public Toggle togglePerc; /// Checkbox for percussion
    private Renderer rend; /// Mesh renderer
    private Material rendMat; /// Material from renderer
    public Color cubeColour; /// Color object for cube

    // =========== Awake / Start / Update ===========

    private void Awake() { }

    /// Use this for initialization
    void Start()
    {
        Debug.Log("** LOG: STARTED **");
        pastStart = true;

        /// Toggle stuff
        Toggle toggle = GetComponent<Toggle>();

        /// Create renderer material object
        rend = cube.GetComponent<Renderer>();
        rend.enabled = true;
        rendMat = rend.material;
        cubeColour = rendMat.color;

        /// Assign audio values
        isPaused = false;
        MusicSources[0].clip = MusicClip_synth;
        MusicSources[1].clip = MusicClip_bass;
        MusicSources[2].clip = MusicClip_perc;

        for(int i = 0; i < MusicSources.Length; i++ )
        {
            MusicSources[i].volume = 50;
        }
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
        for (int i = 0; i < MusicSources.Length; i++)
        {
            if (MusicSources[i].isPlaying)
            {
                MusicSources[i].Pause();
                isPaused = true;
                Debug.Log("<Paused>");
            }
            else
            {
                if (isPaused)
                {
                    MusicSources[i].UnPause();
                    Debug.Log("<Unpaused>");
                    isPaused = false;
                }
                else
                {
                    MusicSources[i].Play();
                    Debug.Log("<Played>");
                }
            }
        }
    }

    public void ChangeVolume(float sliderValue)
    {
        if (!pastStart) return;
        for (int i = 0; i < MusicSources.Length; i++)
        {
            {
                MusicSources[i].volume = sliderValue / 100;
            }
        }
    }

    public void ToggleSound(int musicSource)
    {
        if (MusicSources[musicSource].mute == false)
        {
            MusicSources[musicSource].mute = true;
        }
        else
        {
            MusicSources[musicSource].mute = false;
        }
    }

}
