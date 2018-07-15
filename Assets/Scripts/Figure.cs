using System.Collections;
using System.Collections.Generic;
using cakeslice;
using UnityEngine;

public class Figure : MonoBehaviour {
public GameObject[] onOutline;
public bool moves = false; 
public Camera camera;
	// Use this for initialization

	private bool figureischoise = false;
	public  GameObject choisefigure;
	// Update is called once per frame
	void Update () {
		
		if(Input.GetMouseButtonDown(0)){
			Ray ray = camera.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			
			if(Physics.Raycast(ray,out hit)){
            //    if(hit.rigidbody.gameObject.name.Contains("pawn")){
				//    if(hit.collider.gameObject.name.Contains("pawn")){
					if(figureischoise == false){
				   hit.collider.gameObject.GetComponent<Outline>().enabled = true;
				   hit.collider.gameObject.GetComponent<EnterMouse>().entermouse = false;
				   figureischoise = true;
				   choisefigure = hit.collider.gameObject;
				   camera.GetComponent<Moves>().enabled = true;
				   moves = true;
					}

				   if(figureischoise == true){
                   foreach(GameObject cell in camera.GetComponent<HiddenGO>().hiddengo){
					   cell.GetComponent<Outline>().enabled = false;
				   }
				   choisefigure.GetComponent<Outline>().enabled = false;
				   choisefigure.GetComponent<EnterMouse>().entermouse = true;
				   hit.collider.gameObject.GetComponent<Outline>().enabled = true;
				   hit.collider.gameObject.GetComponent<EnterMouse>().entermouse = false;
				   choisefigure = hit.collider.gameObject;
				   choisefigure.GetComponent<Outline>().enabled = true;
				   camera.GetComponent<Moves>().enabled = true;
				   moves = true;
			
			}

			       
			}
		}
	}
}

