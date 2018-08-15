using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelModel : MonoBehaviour
{

    // =========== Declarations ===========

    /// Random
    private bool pastStart = false;
    public GameObject cube;
    public GameObject xylophone;


    /// Audio components
    public AudioClip MusicClip_synth;
    public AudioClip MusicClip_wobble;
    public AudioClip MusicClip_darkfuzz;
    public AudioClip MusicClip_xyloBacking;
    public AudioSource[] MusicSources;
    public AudioSource XyloSource;
    private Boolean isPaused;


    /// Component objects
    private Vector3 pos;
    public Toggle toggleBass; /// Checkbox for bass
    public Toggle togglePerc; /// Checkbox for percussion
    private Renderer rend; /// Mesh renderer
    private Material rendMat; /// Material from renderer
    public Color cubeColour; /// Color object for cube
    private float currentY; /// Y-coordinates of cube
    public float diffY; /// Y-coordinate variance with slider



    // =========== Awake / Start / Update ===========

    private void Awake() { }


    /// Use this for initialization
    void Start()
    {
        /// Random Stuff
        Debug.Log("** LOG: STARTED **");
        pastStart = true;

        /// Transform component
        pos = cube.transform.position;
        currentY = pos.y;
        Debug.Log("Initial currentY: " + currentY);
        Debug.Log("Initial cube.transform.position.x: " + cube.transform.position.x);
        Debug.Log("Initial cube.transform.position.y: " + cube.transform.position.y);
        Debug.Log("Initial cube.transform.position.z: " + cube.transform.position.z);


        /// Create renderer material object
        rend = cube.GetComponent<Renderer>();
        rend.enabled = true;
        rendMat = rend.material;
        cubeColour = rendMat.color;

        /// Assign audio values
        isPaused = false;
        MusicSources[0].clip = MusicClip_synth;
        MusicSources[1].clip = MusicClip_wobble;
        MusicSources[2].clip = MusicClip_darkfuzz;
        XyloSource.clip = MusicClip_xyloBacking;

        for (int i = 0; i < MusicSources.Length; i++ )
        {
            MusicSources[i].volume = 1;
        }
    }
    	

	/// Update is called once per frame
	void Update () { }



    // =========== Regular Methods ===========


    public void Slider_ChangeHeight(float sliderValue)
    {
        Vector3 pos = cube.transform.position; /// assign position of the cube to temp variable
        pos.y = sliderValue + 0.0f; /// Set 'y' value to be slider value
        cube.transform.position = pos; /// Reassign back to transformations position

        //Debug.Log("METH: currentY: " + currentY + " | sliderValue: " + sliderValue);
        //diffY = currentY - sliderValue;
        //float x = cube.transform.position.x;
        //float y = currentY - diffY;
        //float z = cube.transform.position.z;
        //Debug.Log("x: " + x + " | y: " + y + " | z: " + z);
        //currentY = sliderValue;
        //cube.transform.position = new Vector3(x, y, z);
    }


    public void Slider_PullXylophone(float sliderValue)
    {
        Vector3 xyloPos = xylophone.transform.position; /// assign position of the cube to temp variable
        xyloPos.z = sliderValue + 0; /// Set 'y' value to be slider value
        xylophone.transform.position = xyloPos; /// Reassign back to transformations position
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

    public void PlayPauseXylo()
    {
        {
            if (XyloSource.isPlaying)
            {
                XyloSource.Pause();
                isPaused = true;
                Debug.Log("<Paused>");
            }
            else
            {
                if (isPaused)
                {
                    XyloSource.UnPause();
                    Debug.Log("<Unpaused>");
                    isPaused = false;
                }
                else
                {
                    XyloSource.Play();
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


    public void WhenReleased()
    {
        if (!pastStart) return;
        pos = cube.transform.position;
        currentY = pos.y;
    }

}
