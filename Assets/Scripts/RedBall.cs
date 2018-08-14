using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Meta;

public class RedBall: MonoBehaviour {

    /// Material for object which will be changed
    private Material _renderMaterial;

    private Color _currentColor;


    /// Audio called when object triggered
    public AudioClip AudioClip;
    public AudioSource AudioSource;


    /// Use this for initialization
    void Start ()
    {
        /// Assign audio clip and volume
        AudioSource.clip = AudioClip;
        AudioSource.volume = 0.35f;

        /// Reference to this object's material
        Renderer renderer = GetComponent<Renderer>();
        _renderMaterial = renderer.material;
    }
	

	/// Update is called once per frame
	void Update () {}


    /// Actions taken when object is 'touched'
    public void ChangeColorDirect ()
    {
        if (_renderMaterial.GetColor("_Color").Equals(Color.red))
        {
            _renderMaterial.SetColor("_Color", Color.green);
        }
        else if (_renderMaterial.GetColor("_Color").Equals(Color.green))
        {
            _renderMaterial.SetColor("_Color", Color.cyan);
        }
        else
        {
            _renderMaterial.SetColor("_Color", Color.red);
        }
    }


    public void ChangeColorIndirect ()
    {
        _renderMaterial.SetColor("_Color", Color.magenta);
    }


    public void PlayThisSound ()
    {
        AudioSource.Play();
    }
}

