using System;
using System.Collections;
using System.Collections.Generic;
using cakeslice;
using TMPro;
using UnityEngine;

public class Figure : MonoBehaviour {

	public GameObject[] onOutline;
	public bool moves = false;
	public bool xod = false; // выбрана ли фигура для хода;
	public bool xodincell = false; // выбрана ли фигура с ячейкой куда она должна идти
	private float Speed = 4.0f;
	public Camera camera;
	private bool figureischoise = false; //проверка была ли ранее какая либо выбрана фигура или нет
	public GameObject choisefigure;

	public GameObject xodfigure; // в какую ячейку пойдет фигура
	public bool XodIgroka1 = false;
	public bool XodIgroka2 = false;
	public String fromCell; // с какой ячейки начинает ходить фигура
	public bool fromenabled = false; // для string начальной ячейки
	public String inCell; // в какую ячейку идет фигура
	public bool inenabled = false; // для string конечной ячейки
	public int intMassivWhite;
	public int intMassivBlack;

	void Start () {
		intMassivWhite = -1;
		intMassivBlack = -1;
	}
	void Update () {

		// if(XodIgroka1 == false){
		// TextMeshProUGUI textmesh = GameObject.Find("Nadpisi").gameObject.transform.Find("Canvas").gameObject.transform.Find("Igrok").GetComponent<TextMeshProUGUI>();
		// textmesh.text = "Игрок 1";

		if (Input.GetMouseButtonDown (0)) {

			Ray ray = camera.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit)) {

				// 	if(figureischoise == false && xod == false) {

				//     if(GameObject.Find("Camera").GetComponent<Xod>().StartIndex1 == true && hit.collider.gameObject.name.Contains("white")){
				//             TextMeshProUGUI textmeshName = GameObject.Find("Nadpisi").gameObject.transform.Find("Canvas").gameObject.transform.Find("Igrok").GetComponent<TextMeshProUGUI>();
				//             textmeshName.text = GameObject.Find("Camera").GetComponent<Xod>().Igrok1Name;
				//          	hit.collider.gameObject.GetComponent<Outline>().enabled = true;
				// 			hit.collider.gameObject.GetComponent<EnterMouse>().entermouse = false;
				// 			figureischoise = true;
				// 			choisefigure = hit.collider.gameObject;
				// 			camera.GetComponent<Moves>().enabled = true;
				// 		    xod = true;
				// 			moves = true;
				//     }

				//     if(GameObject.Find("Camera").GetComponent<Xod>().StartIndex2 == true && hit.collider.gameObject.name.Contains("black")){

				// 			TextMeshProUGUI textmeshName = GameObject.Find("Nadpisi").gameObject.transform.Find("Canvas").gameObject.transform.Find("Igrok").GetComponent<TextMeshProUGUI>();
				//             textmeshName.text = GameObject.Find("Camera").GetComponent<Xod>().Igrok2Name;
				//          	hit.collider.gameObject.GetComponent<Outline>().enabled = true;
				// 			hit.collider.gameObject.GetComponent<EnterMouse>().entermouse = false;
				// 			figureischoise = true;
				// 			choisefigure = hit.collider.gameObject;
				// 			camera.GetComponent<Moves>().enabled = true;
				// 		    xod = true;
				// 			moves = true;
				//     }
				// }

				// if(figureischoise == true && xod == true) {

				// if(choisefigure != null){

				// if(GameObject.Find("Camera").GetComponent<Xod>().StartIndex1 == true && hit.collider.gameObject.name.Contains("black")){

				// xodfigure = hit.collider.gameObject;
				// fromenabled = true;
				// xodincell = true;
				// }

				// if(GameObject.Find("Camera").GetComponent<Xod>().StartIndex2 == true && hit.collider.gameObject.name.Contains("white")){

				// xodfigure = hit.collider.gameObject;
				// fromenabled = true;
				// xodincell = true; 
				// }

				// }

				if (GameObject.Find ("Camera").GetComponent<Xod> ().StartIndex1 == true && hit.collider.gameObject.name.Contains ("white")) {

					TextMeshProUGUI textmeshName = GameObject.Find ("Nadpisi").gameObject.transform.Find ("Canvas").gameObject.transform.Find ("Igrok").GetComponent<TextMeshProUGUI> ();
					textmeshName.text = GameObject.Find ("Camera").GetComponent<Xod> ().Igrok1Name;

					foreach (GameObject cell in camera.GetComponent<HiddenGO> ().hiddengo) {

						cell.GetComponent<Outline> ().enabled = false;
					}

					hit.collider.gameObject.GetComponent<Outline> ().enabled = true;
					hit.collider.gameObject.GetComponent<EnterMouse> ().entermouse = false;
					choisefigure = hit.collider.gameObject;
					choisefigure.GetComponent<Outline> ().enabled = true;
					camera.GetComponent<Moves> ().enabled = true;
					moves = true;
					xod = true;
					figureischoise = true;
				}
			}

			if (GameObject.Find ("Camera").GetComponent<Xod> ().StartIndex2 == true && hit.collider.gameObject.name.Contains ("black")) {

				TextMeshProUGUI textmeshName = GameObject.Find ("Nadpisi").gameObject.transform.Find ("Canvas").gameObject.transform.Find ("Igrok").GetComponent<TextMeshProUGUI> ();
				textmeshName.text = GameObject.Find ("Camera").GetComponent<Xod> ().Igrok2Name;

				foreach (GameObject cell in camera.GetComponent<HiddenGO> ().hiddengo) {

					cell.GetComponent<Outline> ().enabled = false;
				}

				hit.collider.gameObject.GetComponent<Outline> ().enabled = true;
				hit.collider.gameObject.GetComponent<EnterMouse> ().entermouse = false;
				choisefigure = hit.collider.gameObject;
				choisefigure.GetComponent<Outline> ().enabled = true;
				camera.GetComponent<Moves> ().enabled = true;
				moves = true;
				xod = true;
				figureischoise = true;
			}

			if ((GameObject.Find ("Camera").GetComponent<Xod> ().StartIndex2 == true && hit.collider.gameObject.name.Contains ("white")) || (GameObject.Find ("Camera").GetComponent<Xod> ().StartIndex1 == true && hit.collider.gameObject.name.Contains ("black"))) {

				if (figureischoise == true && hit.collider.gameObject.GetComponent<Trig> ().triger.GetComponent<Outline> ().enabled) {
					Debug.Log ("uuuu");
					xodfigure = hit.collider.gameObject.GetComponent<Trig> ().triger;
					fromenabled = true;
					xodincell = true;
					// }

					// choisefigure.GetComponent<Outline>().enabled = false;
					// choisefigure.GetComponent<EnterMouse>().entermouse = true;
				}
			}

			if (hit.collider.gameObject.GetComponent<Cell> () != null) {

				if (xod == true && hit.collider.gameObject.GetComponent<Cell> ().cellvibranadlaxoda == true) {

					xodfigure = hit.collider.gameObject;
					fromenabled = true;
					xodincell = true;
				}
			}
		}
	

		if (xod == true && xodincell == true) {

			if (fromenabled) {

				fromCell = choisefigure.GetComponent<Trig> ().triger.name;
				fromenabled = false;
			}

			choisefigure.transform.position = Vector3.MoveTowards (choisefigure.transform.position, xodfigure.transform.position, Time.deltaTime * Speed);

			if (choisefigure.transform.position == xodfigure.transform.position) {

				inenabled = true;

				if (inenabled) {
					inCell = choisefigure.GetComponent<Trig> ().triger.name;
					inenabled = false;
				}

				foreach (GameObject cell in camera.GetComponent<HiddenGO> ().hiddengo) {
					cell.GetComponent<Outline> ().enabled = false;
					cell.GetComponent<Cell> ().cell = true;
					cell.GetComponent<Cell> ().cellvibranadlaxoda = false;
				}

				if (GameObject.Find ("Camera").GetComponent<Xod> ().StartIndex1 == true) {

					GameObject.Find ("Camera").GetComponent<Xod> ().StartIndex2 = true;
					GameObject.Find ("Camera").GetComponent<Xod> ().StartIndex1 = false;

				} else if (GameObject.Find ("Camera").GetComponent<Xod> ().StartIndex1 == false) {

					GameObject.Find ("Camera").GetComponent<Xod> ().StartIndex2 = false;
					GameObject.Find ("Camera").GetComponent<Xod> ().StartIndex1 = true;

				}

				TextMeshProUGUI textmesh1 = GameObject.Find ("Nadpisi").gameObject.transform.Find ("Canvas").gameObject.transform.Find ("Xodi").GetComponent<TextMeshProUGUI> ();
				textmesh1.text = fromCell + " to " + inCell;
				fromCell = null;
				inCell = null;
				xod = false;
				xodincell = false;
				choisefigure.GetComponent<Outline> ().enabled = false;
				choisefigure.GetComponent<EnterMouse> ().entermouse = true;
				choisefigure = null;
				xodfigure = null;
				figureischoise = false;
			}
		}

		foreach (GameObject wob in GameObject.Find ("Camera").GetComponent<HiddenGO> ().whitefigures) {
			foreach (GameObject bob in GameObject.Find ("Camera").GetComponent<HiddenGO> ().blackfigures) {
				if (wob.transform.position == bob.transform.position) {

					intMassivWhite = GameObject.Find ("Camera").GetComponent<HiddenGO> ().whitefigures.IndexOf (wob);
					Debug.Log ("intMassivWhite =" + intMassivWhite);
				}
			}
		}

		foreach (GameObject bob in GameObject.Find ("Camera").GetComponent<HiddenGO> ().blackfigures) {
			foreach (GameObject wob in GameObject.Find ("Camera").GetComponent<HiddenGO> ().whitefigures) {
				if (bob.transform.position == wob.transform.position) {

					intMassivBlack = GameObject.Find ("Camera").GetComponent<HiddenGO> ().blackfigures.IndexOf (bob);
					Debug.Log ("intMassivBlack =" + intMassivBlack);
				}
			}
		}

		if (intMassivWhite != -1 || intMassivBlack != -1) {
			if (GameObject.Find ("Camera").GetComponent<Xod> ().StartIndex1 == true) {

				GameObject delwhite = GameObject.Find ("Camera").GetComponent<HiddenGO> ().whitefigures[intMassivWhite];
				GameObject.Find ("Camera").GetComponent<HiddenGO> ().whitefigures.RemoveAt (intMassivWhite);
				Destroy (delwhite.gameObject);
			}

			if (GameObject.Find ("Camera").GetComponent<Xod> ().StartIndex2 == true) {

				GameObject delblack = GameObject.Find ("Camera").GetComponent<HiddenGO> ().blackfigures[intMassivBlack];
				GameObject.Find ("Camera").GetComponent<HiddenGO> ().blackfigures.RemoveAt (intMassivBlack);
				Destroy (delblack.gameObject);
			}

			intMassivWhite = -1;
			intMassivBlack = -1;
		}
	}
}