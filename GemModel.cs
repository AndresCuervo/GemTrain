﻿/* GemModel.cs
 * Display a gem
 * John Burnett, Andres Cuervo, Sage Jenson
 * Gem Train
 * 2015-01-17
 */

using UnityEngine;
using System.Collections;

public class GemModel : MonoBehaviour
{
	private int gem_type;		
	private float clock;		// Keep track of time since creation for animation.
	private Gem owner;			// Pointer to the parent object.
	private Material mat;		// Material for setting/changing texture and color.

	public void init(Gem owner) {
		this.owner = owner;
		this.gem_type = Random.Range(0, 4)+ 1;

		transform.parent = owner.transform;					// Set the model's parent to the gem.
		transform.localPosition = new Vector3(0,0,0);		// Center the model on the parent.
		name = "Gem Model";									// Name the object.

		mat = GetComponent<Renderer>().material;								// Get the material component of this quad object.
		mat.mainTexture = Resources.Load<Texture2D>("Textures/gem"+gem_type);	// Set the texture.  Must be in Resources folder.
		mat.color = new Color(1,1,1);											// Set the color (easy way to tint things).
		mat.shader = Shader.Find ("Transparent/Diffuse");						// Tell the renderer that our textures have transparency. 
	}
		
	void Start () {
		clock = 0f;
	}

	void Update () {
		
		// Incrememnt the clock based on how much time has elapsed since the previous update.
		// Using deltaTime is critical for animation and movement, since the time between each call
		// to Update is unpredictable.
		clock = clock + Time.deltaTime;

		// A more serious project would probably use subclasses for gem types, or at least enums instead of 
		// this silly gem_type int plus a bunch of if statements.  But it'll do for here.  

		if (gem_type == 1) { // set rotation around z for spin effect
			transform.eulerAngles = new Vector3(0,0,360*clock);
		}
		if (gem_type == 2) { // set position y for bounce effect
			transform.localPosition = new Vector3(0,Mathf.Sin(5*clock)/5,0);	
		}	
		if (gem_type == 3) { // set scale in x and y for pulse effect
			transform.localScale = new Vector3(1+Mathf.Sin(3*clock)/2,1+Mathf.Sin(3*clock)/2,1);
		}
		if (gem_type == 4) { // set color for twinkle effect
			mat.color = new Color(1+0.5f*Mathf.Sin(8*clock),1+0.5f*Mathf.Sin(8*clock),1+0.5f*Mathf.Sin(8*clock));
		}
	}
}

