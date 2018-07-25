using System.Collections;
using UnityEngine;
using Meta;

/// An example Monobehaviour which uses the gaze events to change the color
/// of the game object it is assigned to.

// Subclass of Meta objects
public class LeftField : MetaBehaviour, IGazeStartEvent, IGazeEndEvent
{  
    /// Material for object which will be changed
    public Material _renderMaterial;

    /// Colour state when not viewed - i.e. dull
    private Color _colorDull = new Color(0.05f, 0.05f, 0.05f, 0.0f);

    /// Colour state when is viewed - i.e. variable-colour
    private Color _colorHighlighted;
    
    /// Interpolation variable which defines colour
    private float _lambda = 0f;

    /// Value of '_lambda' change with every 'update frame'
    private float _delta = 0.05f;

    /// Boolean for if object is being viewed.
    private bool _bIsGazing;


    /// Reference to background organ clip
    public AudioClip AudioClip;
    public AudioSource AudioSource;
    //RightField ThisRightField = new RightField();
    //A_Ball ThisA_Ball = new A_Ball();

    /// Play AudioClip if not already playing
    public void PlayTheme()
    {
        if (!AudioSource.isPlaying)
        {
            AudioSource.Play();
        }

        //if (ThisRightField.AudioSource.isPlaying)
        //{
        //    ThisA_Ball._renderMaterial.SetColor("_Color", Color.cyan);
        //    ThisRightField.AudioSource.Pause();
        //}
        //else
        //{
        //    ThisA_Ball._renderMaterial.SetColor("_Color", Color.black);
        //}
    }

    /// Sets conditions when game starts
    private void Start()
    {
        /// Reference to this object's material
        Renderer renderer = GetComponent<Renderer>();
        _renderMaterial = renderer.material;

        /// Random colour for when viewed
        _colorHighlighted = _renderMaterial.GetColor("_Color");

        /// Assign audio track;
        AudioSource.clip = AudioClip;
        AudioSource.volume = 0.05f;
    }

    /// Sets conditions when game updates
    private void Update()
    {
        ChangeColour();
    }


    /// Sets conditions when object is being viewed
    public void OnGazeStart()
    {
        _bIsGazing = true;
        PlayTheme();
    }

    /// Sets conditions when object is being viewed
    public void OnGazeEnd()
    {
        /// Boolean indicatation of not being looked at
        _bIsGazing = false;
    }

    /// Changes colour every frame
    private void ChangeColour()
    {
        /// Liniar Interpolation (LERP) bias, higher means higlights quicker
        float lerpBias = 0.3f;

        /// Vibrance increases if object is being gazed at
        float sign = _bIsGazing ? 1 : -1;

        /// Modifies lambda, incrementally changing the vibrance of the object. 
        _lambda += (sign + lerpBias) * _delta;
        
        /// Allows lambda beyond 1 to glow longer. 
        _lambda = Mathf.Clamp(_lambda, 0f, 2f); 

        /// Calculate the color of the object. Lambda greater than 1 are clamped to 1.
        Color color = Color.Lerp(
            _colorDull, // colour A
            _colorHighlighted, // colour B
            Mathf.Clamp(_lambda, 0f, 1f) // float
        );
        _renderMaterial.color = color;
    }
}
