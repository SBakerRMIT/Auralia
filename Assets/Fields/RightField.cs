using System.Collections;
using UnityEngine;
using Meta;

/// An example Monobehaviour which uses the gaze events to change the color
/// of the game object it is assigned to.

// Subclass of Meta objects
public class RightField : MetaBehaviour, IGazeStartEvent, IGazeEndEvent
{
    /// Material for object which will be changed
    private Material _renderMaterial;

    /// Colour state when not viewed - i.e. dull
    private Color _colorDull = new Color(0.5f, 0.5f, 0.5f, 0.5f);

    /// Colour state when is viewed - i.e. variable-colour
    private Color _colorHighlighted;
    
    /// Interpolation variable which defines colour
    private float _lambda = 0f;

    /// Value of '_lambda' change with every 'update frame'
    private float _delta = 0.05f;

    /// Boolean for if object is being viewed.
    private bool _bIsGazing;


    /// Sets conditions when game starts
    private void Start()
    {
        /// Reference to this object's material
        Renderer renderer = GetComponent<Renderer>();
        _renderMaterial = renderer.material;

        /// Random colour for when viewed
        _colorHighlighted = _renderMaterial.GetColor("_Color");
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
    }


    /// Sets conditions when object is being viewed
    public void OnGazeEnd()
    {
        _bIsGazing = false;
    }


    /// Changes colour every frame
    private void ChangeColour()
    {
        /// Liniar Interpolation (LERP) bias,  higlights quicker, dull longer
        /// Speed of colour in/out
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
