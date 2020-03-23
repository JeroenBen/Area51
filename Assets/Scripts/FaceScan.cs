using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceScan : MonoBehaviour {
	public HandUIItem hand;
	public Movable movable;
	bool done;
	// Use this for initialization
	void Start() {
		done = false;
	}
	private bool TrumpInHand() {
		return (hand.item.id == 2);
	}
	
	// Update is called once per frame
	public void ActivateScan() { 
		if(TrumpInHand()&&!done) {
			done = true;
			print("Moving Door");
			movable.MoveToY(-4);
			GetComponent<Interactable>();
		}
	}
}
