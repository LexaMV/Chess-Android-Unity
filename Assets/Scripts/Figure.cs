using System.Collections;
using System.Collections.Generic;
using cakeslice;
using UnityEngine;
public class Figure: MonoBehaviour {
	public GameObject[] onOutline;
	public bool moves = false; 
	public bool xod = false;
	public bool xodincell =false;
	private float Speed = 4.0f;
	public Camera camera; 
	private bool figureischoise=false;
	public GameObject choisefigure; 
	public GameObject xodfigure;
	void Update () {
		if(Input.GetMouseButtonDown(0)) {
			Ray ray=camera.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if(Physics.Raycast(ray, out hit)) {
				//    if(hit.rigidbody.gameObject.name.Contains("pawn")){
				//    if(hit.collider.gameObject.name.Contains("pawn")){
				if(figureischoise == false && xod == false) {
					hit.collider.gameObject.GetComponent<Outline>().enabled=true;
					hit.collider.gameObject.GetComponent<EnterMouse>().entermouse=false;
					figureischoise=true;
					choisefigure=hit.collider.gameObject;
					camera.GetComponent<Moves>().enabled=true;
				    xod = true;
					moves=true;
				}
				if(figureischoise == true && xod == false) {
					foreach(GameObject cell in camera.GetComponent<HiddenGO>().hiddengo) {
						cell.GetComponent<Outline>().enabled=false;
					}

					if(choisefigure != null){
					choisefigure.GetComponent<Outline>().enabled=false;
					choisefigure.GetComponent<EnterMouse>().entermouse=true;
					}
					hit.collider.gameObject.GetComponent<Outline>().enabled=true;
					hit.collider.gameObject.GetComponent<EnterMouse>().entermouse=false;
					choisefigure=hit.collider.gameObject;
					choisefigure.GetComponent<Outline>().enabled=true;
					camera.GetComponent<Moves>().enabled=true;
					moves=true;
					xod = true;
				}

                if(hit.collider.gameObject.GetComponent<Cell>() != null){
			      if(xod == true && 	hit.collider.gameObject.GetComponent<Cell>().cellvibranadlaxoda ==true){
                //     Debug.Log(choisefigure);
				xodfigure = hit.collider.gameObject;
				
				Debug.Log(xodfigure);
				// 	// choisefigure.transform.position = Vector3.MoveTowards(choisefigure.transform.position, hit.collider.gameObject.transform.position, Time.deltaTime*Speed);
				// 	//choisefigure.transform.position = new Vector3(hit.collider.gameObject.transform.position.x, hit.collider.gameObject.transform.position.y,hit.collider.gameObject.transform.position.z);
                xodincell = true;
				// }
			}
				}
			}
		}
		
			
		
	


        if (xod == true &&  xodincell == true ){
        choisefigure.transform.position = Vector3.MoveTowards(choisefigure.transform.position, xodfigure.transform.position, Time.deltaTime*Speed);
        if(choisefigure.transform.position == xodfigure.transform.position){
			foreach(GameObject cell in camera.GetComponent<HiddenGO>().hiddengo) {
						cell.GetComponent<Outline>().enabled=false;
						cell.GetComponent<Cell>().cell=true;
						cell.GetComponent<Cell>().cellvibranadlaxoda = false;

					}
					xod = false;
					xodincell = false;
					choisefigure.GetComponent<Outline>().enabled=false;
					choisefigure.GetComponent<EnterMouse>().entermouse=true;
					choisefigure = null;

					xodfigure = null;
		}

	}
}
}
		
