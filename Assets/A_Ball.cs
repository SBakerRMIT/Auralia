using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_Ball : MonoBehaviour {

    public Material _renderMaterial;
        
	void Start () {
        Renderer _renderer = GetComponent<Renderer>();
        _renderMaterial = _renderer.material;
        _renderMaterial.SetColor("_Color", Color.red);
    }
	
	void Update () {
		
	}
}
