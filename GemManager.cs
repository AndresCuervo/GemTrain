/* GemModel.cs
 * Display a gem
 * John Burnett, Andres Cuervo, Sage Jenson
 * Gem Train
 * 2015-01-17
 */

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GemManager : MonoBehaviour {
	
	GameObject gem_folder;	// This will be an empty game object used for organizing objects in the Hierarchy pane.
	public List<Gem> gems;	// This list will hold the gem objects that are created.
	int[,] gem_field;

	public int num_tiles_w;
	public int num_tiles_h;

	// Custom initialization function
	public void init(int w, int h){
		gem_folder = new GameObject();  
		gem_folder.name = "Gems";		// The name of a game object is visible in the hierarchy pane.
		gems = new List<Gem>();
		num_tiles_w = w;
		num_tiles_h = h;
		gem_field = new int[num_tiles_h,num_tiles_w];
	}

	//Add a new gem
	public void addGem() {
		GameObject gemObject = new GameObject();			// Create a new empty game object that will hold a gem.
		Gem gem = gemObject.AddComponent<Gem>();			// Add the Gem.cs script to the object.
		gem.transform.parent = gem_folder.transform;			// Set the gem's parent object to be the gem folder.

		int x, y;
		do {
			x = Random.Range (0, num_tiles_w);
			y = Random.Range (0, num_tiles_h);
		} while (gem_field [y, x] == 1);

		gem_field [y, x] = 1;

		gem.init (x, y, this);

		gems.Add(gem);										// Add the gem to the Gems list for future access.
		gem.name = "Gem "+gems.Count;						// Give the gem object a name in the Hierarchy pane.
	}

	public void removeGem(int[] gem_coords){
		;
	}

}