using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Meta;


public class Notes : MonoBehaviour {

    /// Material for object which will be changed
    private Material _renderMaterial;

    /// Audio called when object triggered
    public AudioClip AudioClip;
    public AudioSource AudioSource;

    /// Use this for initialization
    void Start ()
    {
        /// Assign audio clip and volume
        AudioSource.clip = AudioClip;
        AudioSource.volume = 0.05f;
        /// Reference to this object's material
        Renderer renderer = GetComponent<Renderer>();
        _renderMaterial = renderer.material;
    }
	
	/// Update is called once per frame
	void Update () {}

    /// Actions taken when object is 'touched'
    public void OneHandTouch ()
    {
        if (_renderMaterial.GetColor("_Color").Equals(Color.red))
        {
            _renderMaterial.SetColor("_Color", Color.green);
        }
        else
        {
            _renderMaterial.SetColor("_Color", Color.red);
        }
        AudioSource.Play();
    }
}

