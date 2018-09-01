using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Road : MonoBehaviour {

	public BoxCollider2D boxcol;

	void Awake() {
		boxcol = this.GetComponent<BoxCollider2D>();
		boxcol.isTrigger = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
