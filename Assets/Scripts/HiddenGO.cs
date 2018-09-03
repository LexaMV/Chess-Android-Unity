using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HiddenGO : Photon.MonoBehaviour {

	public GameObject blackpawn;
	public GameObject whitepawn;
	public GameObject blackrook;
	public GameObject whiterook;
	public GameObject blackhorse;
	public GameObject whitehorse;
	public GameObject blackbishop;
	public GameObject whitebishop;
	public GameObject blackking;
	public GameObject whitequeen;
	public GameObject blackqueen;
	public GameObject whiteking;
	// public GameObject[,] hiddengo;
	public List<GameObject> hiddengo;
	public List<GameObject> whitefigures;
	public List<GameObject> whitefiguresPhoton;
	public List<GameObject> blackfigures;
	public List<GameObject> blackfiguresPhoton;
	public List<GameObject> hiddengoPtonon;
	public bool Master1 = true;
	public bool Master2 = true;
	private float x;
	private float y;
	private float z;
	public string[] digit = { "1", "2", "3", "4", "5", "6", "7", "8" };
	public int digitint;
	public int lettersint;
	public string[] letters = { "A", "B", "C", "D", "E", "F", "G", "H" };
	public bool black;
	public GameObject PrefabCell1;
	public GameObject PrefabCell2;
	public GameObject HalfCell;
	public GameObject FourthCell;

	public int tag;

    static public HiddenGO Instance;
	public int ahidden;
	void Start () {
		tag = 0;
	
		Instance = this;
		// этот код для расстановки ячеек ввиде квадрата
        // if(PhotonNetwork.isMasterClient){ 
			

		digitint = -1;
		x = 10.0f;
		y = 1.0f;
		z = 10.0f;
		GameObject field = GameObject.Find ("Field");
		GameObject figures = GameObject.Find ("Figures");
		// hiddengo = new GameObject[8, 8];

		for (int i = 0; i < 8; i++) {
			digitint += 1;
			if (i == 0) {
				black = false;
			} 
			
			else if (i % 2 == 0) {
				black = false;
			} 
			
			else if (i % 2 != 0) {
				black = true;
			}
			
			for (int j = 0; j < 8; j++) {

				if (black == false) {
					// GameObject cell = PhotonNetwork.Instantiate (PrefabCell1.name, new Vector3 (x, y, z), Quaternion.identity, 0);
					GameObject cell = GameObject.Instantiate (PrefabCell1, new Vector3 (x, y, z), Quaternion.identity);
					// cell.transform.SetParent(field.transform);
					cell.name = letters[7 - j] + digit[digitint];
					black = true;
					
					cell.tag = cell.name;
					// hidengoIDviewID = hidengoIDviewID + 1;
					// cell.GetComponent<PhotonView>().viewID = hidengoIDviewID;
					// PhotonNetwork.RaiseEvent(hidengoIDviewID);
					hiddengo.Add(cell);
					// hiddengo[j, i] = cell;
				} else {
					// GameObject cell = PhotonNetwork.Instantiate (PrefabCell2.name, new Vector3 (x, y, z), Quaternion.identity, 0);
					GameObject cell = GameObject.Instantiate (PrefabCell2, new Vector3 (x, y, z), Quaternion.identity);
					cell.name = letters[7 - j] + digit[digitint];
					tag = tag + 1;
						cell.tag = cell.name;
					// cell.transform.SetParent(field.transform);
					// hidengoIDviewID = hidengoIDviewID + 1;
					// cell.GetComponent<PhotonView>().viewID = hidengoIDviewID;
					// PhotonNetwork.AllocateViewID();
					black = false;
					hiddengo.Add(cell);
					// hiddengo[j, i] = cell;
				}
				z = z - 2.50f;
			}

			black = true;
			x = x - 2.50f;
			z = 10f;
		}

		// этот код для расстановки ячеек с разных сторон квадрата

		x = 11.878f;
		y = 1.0f;
		z = 10.002f;

		for (int i = 0; i < 8; i++) {
			// GameObject half = PhotonNetwork.Instantiate (HalfCell.name, new Vector3 (x, y, z), Quaternion.identity,0);
			GameObject half = GameObject.Instantiate (HalfCell, new Vector3 (x, y, z), Quaternion.identity);
			// half.transform.SetParent(field.transform);
			half.GetComponent<Renderer> ().material.color = Color.black;
			RectTransform rectTextMesh = half.transform.Find ("Canvas").gameObject.transform.Find ("TextMesh").GetComponent<RectTransform> ();
			rectTextMesh.Rotate (new Vector3 (0, 0, 90));
			TextMeshProUGUI textMesh = half.transform.Find ("Canvas").gameObject.transform.Find ("TextMesh").GetComponent<TextMeshProUGUI> ();
			textMesh.text = letters[7 - i];
			z = z - 2.50f;
		}

		x = -9.375f;
		y = 1.0f;
		z = 10.002f;

		for (int i = 0; i < 8; i++) {
			// GameObject half = PhotonNetwork.Instantiate (HalfCell.name, new Vector3 (x, y, z), Quaternion.identity,0);
			GameObject half = GameObject.Instantiate (HalfCell, new Vector3 (x, y, z), Quaternion.identity);
			// half.transform.SetParent(field.transform);
			half.GetComponent<Renderer> ().material.color = Color.black;
			RectTransform rectTextMesh = half.transform.Find ("Canvas").gameObject.transform.Find ("TextMesh").GetComponent<RectTransform> ();
			rectTextMesh.Rotate (new Vector3 (0, 0, -90));
			TextMeshProUGUI textMesh = half.transform.Find ("Canvas").gameObject.transform.Find ("TextMesh").GetComponent<TextMeshProUGUI> ();
			textMesh.text = letters[7 - i];
			z = z - 2.50f;
		}

		x = -7.5f;
		y = 1.0f;
		z = 11.875f;

		for (int i = 0; i < 8; i++) {
			// GameObject half = PhotonNetwork.Instantiate (HalfCell.name, new Vector3 (x, y, z), Quaternion.identity,0);
			GameObject half = GameObject.Instantiate (HalfCell, new Vector3 (x, y, z), Quaternion.identity);
			// half.transform.SetParent(field.transform);
			half.GetComponent<Renderer> ().material.color = Color.black;
			RectTransform rectTextMesh = half.transform.Find ("Canvas").gameObject.transform.Find ("TextMesh").GetComponent<RectTransform> ();
			rectTextMesh.Rotate (new Vector3 (0, 0, 0));
			half.transform.Rotate (new Vector3 (0, 90, 0));
			TextMeshProUGUI textMesh = half.transform.Find ("Canvas").gameObject.transform.Find ("TextMesh").GetComponent<TextMeshProUGUI> ();
			textMesh.text = digit[7 - i];
			x = x + 2.50f;
		}

		x = -7.5f;
		y = 1.0f;
		z = -9.375f;

		for (int i = 0; i < 8; i++) {
			// GameObject half = PhotonNetwork.Instantiate (HalfCell.name, new Vector3 (x, y, z), Quaternion.identity,0);
			GameObject half = GameObject.Instantiate (HalfCell, new Vector3 (x, y, z), Quaternion.identity);
			// half.transform.SetParent(field.transform);
			half.GetComponent<Renderer> ().material.color = Color.black;
			RectTransform rectTextMesh = half.transform.Find ("Canvas").gameObject.transform.Find ("TextMesh").GetComponent<RectTransform> ();
			rectTextMesh.Rotate (new Vector3 (0, 0, 180));
			half.transform.Rotate (new Vector3 (0, 90, 0));
			TextMeshProUGUI textMesh = half.transform.Find ("Canvas").gameObject.transform.Find ("TextMesh").GetComponent<TextMeshProUGUI> ();
			textMesh.text = digit[7 - i];
			x = x + 2.50f;
		}

		// GameObject fourth1 = PhotonNetwork.Instantiate (FourthCell.name, new Vector3 (-9.375f, 1.0f, -9.375f), Quaternion.identity,0);
		GameObject fourth1 = GameObject.Instantiate (FourthCell, new Vector3 (-9.375f, 1.0f, -9.375f), Quaternion.identity);
		// fourth1.transform.SetParent(field.transform);
		fourth1.GetComponent<Renderer> ().material.color = Color.black;
		// GameObject fourth2 = PhotonNetwork.Instantiate (FourthCell.name, new Vector3 (-9.375f, 1.0f, 11.875f), Quaternion.identity, 0);
		GameObject fourth2 = GameObject.Instantiate (FourthCell, new Vector3 (-9.375f, 1.0f, 11.875f), Quaternion.identity);
		// fourth2.transform.SetParent(field.transform);
		fourth2.GetComponent<Renderer> ().material.color = Color.black;
		// GameObject fourth3 = PhotonNetwork.Instantiate (FourthCell.name, new Vector3 (11.875f, 1.0f, 11.875f), Quaternion.identity, 0);
		GameObject fourth3 = GameObject.Instantiate (FourthCell, new Vector3 (11.875f, 1.0f, 11.875f), Quaternion.identity);
		// fourth3.transform.SetParent(field.transform);
		fourth3.GetComponent<Renderer> ().material.color = Color.black;
		// GameObject fourth4 = PhotonNetwork.Instantiate (FourthCell.name, new Vector3 (11.875f, 1.0f, -9.375f), Quaternion.identity, 0);
		GameObject fourth4 = GameObject.Instantiate (FourthCell, new Vector3 (11.875f, 1.0f, -9.375f), Quaternion.identity);
		// fourth4.transform.SetParent(field.transform);
		fourth4.GetComponent<Renderer> ().material.color = Color.black;

		// расстановка фигур на поле боя

		foreach (GameObject go in hiddengo) {

			if (go.name.Contains ("2") && Network.Instance.VibralWhite == 1) {

				// GameObject pawnwhite = Instantiate (whitepawn, go.transform.position, Quaternion.identity, figures.transform);
				// GameObject pawnwhite = PhotonNetwork.Instantiate(whitepawn.name, go.transform.position, Quaternion.identity, 0);
				GameObject pawnwhite = GameObject.Instantiate(whitepawn, go.transform.position, Quaternion.identity);
				tag = tag + 1;
				pawnwhite.name = "pawnwhite" + tag.ToString();
				// whitefiguresIDviewID = whitefiguresIDviewID +1; 
				// pawnwhite.GetComponent<PhotonView>().viewID = whitefiguresIDviewID;
				// pawnwhite.transform.SetParent(figures.transform);
				whitefigures.Add (pawnwhite);
			}

			if (go.name.Contains ("2") && Network.Instance.VibralRed == 1) {

				GameObject pawnwblack = GameObject.Instantiate(blackpawn, go.transform.position, Quaternion.identity);
				tag = tag + 1;
				pawnwblack.name = "pawnwblack" + tag.ToString();
				whitefigures.Add (pawnwblack);
			}


			if (go.name.Contains ("7") && Network.Instance.VibralRed == 1) {

				 GameObject pawnwhite = GameObject.Instantiate(whitepawn, go.transform.position, Quaternion.identity);
				tag = tag + 1;
				pawnwhite.name = "pawnwhite" + tag.ToString();
				whitefigures.Add (pawnwhite);
			}
			

			if (go.name.Contains ("7") && Network.Instance.VibralWhite == 1) {
	           	GameObject pawnwblack = GameObject.Instantiate(blackpawn, go.transform.position, Quaternion.identity);
				tag = tag + 1;
				pawnwblack.name = "pawnwblack" + tag.ToString();
				whitefigures.Add (pawnwblack);
			}

			if ((go.name.Contains ("A1") || go.name.Contains ("H1")) && Network.Instance.VibralWhite == 1) {

				// GameObject rookwhite = PhotonNetwork.Instantiate (whiterook.name, go.transform.position, Quaternion.identity, 0);
				GameObject rookwhite = GameObject.Instantiate (whiterook, go.transform.position, Quaternion.identity);
				tag = tag + 1;
				rookwhite.name = "rookwhite" + tag.ToString();
				// whitefiguresIDviewID = whitefiguresIDviewID +1; 
				// rookwhite.GetComponent<PhotonView>().viewID = whitefiguresIDviewID;
				// rookwhite.transform.SetParent(figures.transform);
				whitefigures.Add (rookwhite);
			}

			if ((go.name.Contains ("A1") || go.name.Contains ("H1")) && Network.Instance.VibralRed == 1) {
				// GameObject rookblack = PhotonNetwork.Instantiate (blackrook.name, go.transform.position, Quaternion.identity, 0);
				GameObject rookblack = GameObject.Instantiate (blackrook, go.transform.position, Quaternion.identity);
				tag = tag + 1;
				rookblack.name = "rookblack" + tag.ToString();
				// blackfiguresIDviewID = blackfiguresIDviewID +1;  
				// rookblack.GetComponent<PhotonView>().viewID = blackfiguresIDviewID;
				// rookblack.transform.SetParent(figures.transform);
				blackfigures.Add (rookblack);
				
			}

			if ((go.name.Contains ("A8") || go.name.Contains ("H8")) && Network.Instance.VibralWhite == 1)  {
 
				// GameObject rookblack = PhotonNetwork.Instantiate (blackrook.name, go.transform.position, Quaternion.identity, 0);
				GameObject rookblack = GameObject.Instantiate (blackrook, go.transform.position, Quaternion.identity);
				tag = tag + 1;
				rookblack.name = "rookblack" + tag.ToString();
				// blackfiguresIDviewID = blackfiguresIDviewID +1;  
				// rookblack.GetComponent<PhotonView>().viewID = blackfiguresIDviewID;
				// rookblack.transform.SetParent(figures.transform);
				blackfigures.Add (rookblack);
			}

			if ((go.name.Contains ("A8") || go.name.Contains ("H8")) && Network.Instance.VibralRed == 1)  {
 
				
				// GameObject rookwhite = PhotonNetwork.Instantiate (whiterook.name, go.transform.position, Quaternion.identity, 0);
				GameObject rookwhite = GameObject.Instantiate (whiterook, go.transform.position, Quaternion.identity);
				tag = tag + 1;
				rookwhite.name = "rookwhite" + tag.ToString();
				// whitefiguresIDviewID = whitefiguresIDviewID +1; 
				// rookwhite.GetComponent<PhotonView>().viewID = whitefiguresIDviewID;
				// rookwhite.transform.SetParent(figures.transform);
				whitefigures.Add (rookwhite);
			}

			if ((go.name.Contains ("B1") || go.name.Contains ("G1")) && Network.Instance.VibralWhite == 1) {

				// GameObject horsewhite = PhotonNetwork.Instantiate (whitehorse.name, go.transform.position, Quaternion.identity, 0);
				GameObject horsewhite = GameObject.Instantiate (whitehorse, go.transform.position, Quaternion.identity);
				tag = tag + 1;
				horsewhite.name = "horsewhite" + tag.ToString();
				// whitefiguresIDviewID = whitefiguresIDviewID +1; 
				// horsewhite.GetComponent<PhotonView>().viewID = whitefiguresIDviewID;
				// horsewhite.transform.SetParent(figures.transform);
				whitefigures.Add (horsewhite);
				 horsewhite.transform.Rotate (0, -90, 0);
			}

			if ((go.name.Contains ("B1") || go.name.Contains ("G1")) && Network.Instance.VibralRed == 1) {

// GameObject horseblack = PhotonNetwork.Instantiate (blackhorse.name, go.transform.position, Quaternion.identity, 0);
			    GameObject horseblack = GameObject.Instantiate (blackhorse, go.transform.position, Quaternion.identity);
				tag = tag + 1;
				horseblack.name = "horseblack" + tag.ToString();
				// blackfiguresIDviewID = blackfiguresIDviewID +1; 
				// horseblack.GetComponent<PhotonView>().viewID = blackfiguresIDviewID;
				// horseblack.transform.SetParent(figures.transform);
				blackfigures.Add (horseblack);
				 horseblack.transform.Rotate (0, -90, 0);
			}

			if ((go.name.Contains ("B8") || go.name.Contains ("G8")) && Network.Instance.VibralWhite == 1) {

				// GameObject horseblack = PhotonNetwork.Instantiate (blackhorse.name, go.transform.position, Quaternion.identity, 0);
			    GameObject horseblack = GameObject.Instantiate (blackhorse, go.transform.position, Quaternion.identity);
				tag = tag + 1;
				horseblack.name = "horseblack" + tag.ToString();
				// blackfiguresIDviewID = blackfiguresIDviewID +1; 
				// horseblack.GetComponent<PhotonView>().viewID = blackfiguresIDviewID;
				// horseblack.transform.SetParent(figures.transform);
				blackfigures.Add (horseblack);
				horseblack.transform.Rotate (0, 90, 0);
			}

			
			if ((go.name.Contains ("B8") || go.name.Contains ("G8")) && Network.Instance.VibralRed == 1) {

		// GameObject horsewhite = PhotonNetwork.Instantiate (whitehorse.name, go.transform.position, Quaternion.identity, 0);
				GameObject horsewhite = GameObject.Instantiate (whitehorse, go.transform.position, Quaternion.identity);
				tag = tag + 1;
				horsewhite.name = "horsewhite" + tag.ToString();
				// whitefiguresIDviewID = whitefiguresIDviewID +1; 
				// horsewhite.GetComponent<PhotonView>().viewID = whitefiguresIDviewID;
				// horsewhite.transform.SetParent(figures.transform);
				whitefigures.Add (horsewhite);
				horsewhite.transform.Rotate (0, 90, 0);
			}



			if ((go.name.Contains ("C1") || go.name.Contains ("F1"))  && Network.Instance.VibralWhite == 1) {

				// GameObject bishopwhite = PhotonNetwork.Instantiate (whitebishop.name, go.transform.position, Quaternion.identity, 0);
				GameObject bishopwhite = GameObject.Instantiate (whitebishop, go.transform.position, Quaternion.identity);
				tag = tag + 1;
				bishopwhite.name = "bishopwhite" + tag.ToString();
				// whitefiguresIDviewID = whitefiguresIDviewID +1; 
				// bishopwhite.GetComponent<PhotonView>().viewID = whitefiguresIDviewID;
				// bishopwhite.transform.SetParent(figures.transform);
				whitefigures.Add (bishopwhite);
			}

if ((go.name.Contains ("C1") || go.name.Contains ("F1"))  && Network.Instance.VibralRed == 1) {

				GameObject bishopblack = GameObject.Instantiate (blackbishop, go.transform.position, Quaternion.identity);
			
				tag = tag + 1;
				bishopblack.name = "bishopblack" + tag.ToString();
				// blackfiguresIDviewID = blackfiguresIDviewID +1; 
				// bishopblack.GetComponent<PhotonView>().viewID = blackfiguresIDviewID;
				// bishopblack.transform.SetParent(figures.transform);
				blackfigures.Add (bishopblack);
			}



			if ((go.name.Contains ("C8") || go.name.Contains ("F8")) && Network.Instance.VibralWhite == 1) {

			 // GameObject bishopblack = PhotonNetwork.Instantiate (blackbishop.name, go.transform.position, Quaternion.identity, 0);
				GameObject bishopblack = GameObject.Instantiate (blackbishop, go.transform.position, Quaternion.identity);
			
				tag = tag + 1;
				bishopblack.name = "bishopblack" + tag.ToString();
				// blackfiguresIDviewID = blackfiguresIDviewID +1; 
				// bishopblack.GetComponent<PhotonView>().viewID = blackfiguresIDviewID;
				// bishopblack.transform.SetParent(figures.transform);
				blackfigures.Add (bishopblack);
			}

				if ((go.name.Contains ("C8") || go.name.Contains ("F8")) && Network.Instance.VibralRed == 1) {

				// GameObject bishopwhite = PhotonNetwork.Instantiate (whitebishop.name, go.transform.position, Quaternion.identity, 0);
				GameObject bishopwhite = GameObject.Instantiate (whitebishop, go.transform.position, Quaternion.identity);
				tag = tag + 1;
				bishopwhite.name = "bishopwhite" + tag.ToString();
				// whitefiguresIDviewID = whitefiguresIDviewID +1; 
				// bishopwhite.GetComponent<PhotonView>().viewID = whitefiguresIDviewID;
				// bishopwhite.transform.SetParent(figures.transform);
				whitefigures.Add (bishopwhite);
			}




			if (go.name.Contains ("D1") && Network.Instance.VibralWhite == 1) {

				// GameObject queenwhite = PhotonNetwork.Instantiate (whitequeen.name, go.transform.position, Quaternion.identity, 0);
				GameObject queenwhite = GameObject.Instantiate (whitequeen, go.transform.position, Quaternion.identity);
				queenwhite.name = "queenwhite";
				// whitefiguresIDviewID = whitefiguresIDviewID +1;  
				// queenwhite.GetComponent<PhotonView>().viewID = whitefiguresIDviewID;
				// queenwhite.transform.SetParent(figures.transform);
				whitefigures.Add (queenwhite);
			}

			if (go.name.Contains ("D1") && Network.Instance.VibralRed == 1) {

		// GameObject kingblack =PhotonNetwork.Instantiate (blackking.name, go.transform.position, Quaternion.identity, 0);
				GameObject kingblack = GameObject.Instantiate (blackking, go.transform.position, Quaternion.identity);
				kingblack.name = "kingblack";
				// blackfiguresIDviewID = blackfiguresIDviewID +1; 
				// kingblack.GetComponent<PhotonView>().viewID = blackfiguresIDviewID;
				// kingblack.transform.SetParent(figures.transform);
				blackfigures.Add (kingblack);
			}



			if (go.name.Contains ("D8")  && Network.Instance.VibralWhite == 1) {

				GameObject queenblack = GameObject.Instantiate (blackqueen, go.transform.position, Quaternion.identity);
				queenblack.name = "queenblack";
				// blackfiguresIDviewID = blackfiguresIDviewID +1; 
				// queenblack.GetComponent<PhotonView>().viewID = blackfiguresIDviewID;
				// queenblack.transform.SetParent(figures.transform);
				blackfigures.Add (queenblack);
			}

			
			if (go.name.Contains ("D8")  && Network.Instance.VibralRed == 1) {

			// // GameObject kingblack =PhotonNetwork.Instantiate (blackking.name, go.transform.position, Quaternion.identity, 0);
			// 	GameObject kingblack = GameObject.Instantiate (blackking, go.transform.position, Quaternion.identity);
			// 	kingblack.name = "kingblack";
			// 	// blackfiguresIDviewID = blackfiguresIDviewID +1; 
			// 	// kingblack.GetComponent<PhotonView>().viewID = blackfiguresIDviewID;
			// 	// kingblack.transform.SetParent(figures.transform);
			// 	blackfigures.Add (kingblack);

			// GameObject kingwhite = PhotonNetwork.Instantiate (whiteking.name, go.transform.position, Quaternion.identity, 0);
				GameObject kingwhite = GameObject.Instantiate (whiteking, go.transform.position, Quaternion.identity);
				kingwhite.name = "kingwhite";
			    // whitefiguresIDviewID = whitefiguresIDviewID +1;  
				// kingwhite.GetComponent<PhotonView>().viewID = whitefiguresIDviewID;
				// kingwhite.transform.SetParent(figures.transform);
				whitefigures.Add (kingwhite);
			}


			if (go.name.Contains ("E1") && Network.Instance.VibralWhite == 1) {

				// GameObject kingwhite = PhotonNetwork.Instantiate (whiteking.name, go.transform.position, Quaternion.identity, 0);
				GameObject kingwhite = GameObject.Instantiate (whiteking, go.transform.position, Quaternion.identity);
				kingwhite.name = "kingwhite";
			    // whitefiguresIDviewID = whitefiguresIDviewID +1;  
				// kingwhite.GetComponent<PhotonView>().viewID = whitefiguresIDviewID;
				// kingwhite.transform.SetParent(figures.transform);
				whitefigures.Add (kingwhite);
			}

if (go.name.Contains ("E1") && Network.Instance.VibralRed == 1) {

				// // GameObject kingwhite = PhotonNetwork.Instantiate (whiteking.name, go.transform.position, Quaternion.identity, 0);
				// GameObject kingwhite = GameObject.Instantiate (whiteking, go.transform.position, Quaternion.identity);
				// kingwhite.name = "kingwhite";
			    // // whitefiguresIDviewID = whitefiguresIDviewID +1;  
				// // kingwhite.GetComponent<PhotonView>().viewID = whitefiguresIDviewID;
				// // kingwhite.transform.SetParent(figures.transform);
				// whitefigures.Add (kingwhite);

				// GameObject queenblack = PhotonNetwork.Instantiate (blackqueen.name, go.transform.position, Quaternion.identity,0);
				GameObject queenblack = GameObject.Instantiate (blackqueen, go.transform.position, Quaternion.identity);
				queenblack.name = "queenblack";
				// blackfiguresIDviewID = blackfiguresIDviewID +1; 
				// queenblack.GetComponent<PhotonView>().viewID = blackfiguresIDviewID;
				// queenblack.transform.SetParent(figures.transform);
				blackfigures.Add (queenblack);
			}

			if (go.name.Contains ("E8") && Network.Instance.VibralRed == 1) {

				// // GameObject queenblack = PhotonNetwork.Instantiate (blackqueen.name, go.transform.position, Quaternion.identity,0);
				// GameObject queenblack = GameObject.Instantiate (blackqueen, go.transform.position, Quaternion.identity);
				// queenblack.name = "queenblack";
				// // blackfiguresIDviewID = blackfiguresIDviewID +1; 
				// // queenblack.GetComponent<PhotonView>().viewID = blackfiguresIDviewID;
				// // queenblack.transform.SetParent(figures.transform);
				// blackfigures.Add (queenblack);

				GameObject queenwhite = GameObject.Instantiate (whitequeen, go.transform.position, Quaternion.identity);
				queenwhite.name = "queenwhite";
				// whitefiguresIDviewID = whitefiguresIDviewID +1;  
				// queenwhite.GetComponent<PhotonView>().viewID = whitefiguresIDviewID;
				// queenwhite.transform.SetParent(figures.transform);
				whitefigures.Add (queenwhite);
			}

				if (go.name.Contains ("E8") && Network.Instance.VibralWhite == 1) {
					GameObject kingblack = GameObject.Instantiate (blackking, go.transform.position, Quaternion.identity);
				kingblack.name = "kingblack";
				// blackfiguresIDviewID = blackfiguresIDviewID +1; 
				// kingblack.GetComponent<PhotonView>().viewID = blackfiguresIDviewID;
				// kingblack.transform.SetParent(figures.transform);
				blackfigures.Add (kingblack);
				}
  		}

      GameObject.Find("GameCamera").GetComponent<Figure>().enabled = true;
	//   GameObject.Find("Camera").GetComponent<Network>().enabled = true;
	//   Master1 = true;
	//   }
	  
	//   PhotonPlayer[] igrokov = PhotonNetwork.playerList;
    
//        else if(!PhotonNetwork.isMasterClient){
// 		   Master2 = false;
		 
//        GameObject.Find("Camera").GetComponent<Figure>().enabled = true;
// 		}
// }


        //   else if(!PhotonNetwork.isMasterClient){ 

		// // for(int i = 101; i < 165; i++){
        // // hiddengoPtonon.Add(PhotonView.Find(i).gameObject);
		// //   }

		// //   for(int i = 201; i < 217; i++){
		// // 	  whitefiguresPhoton.Add(PhotonView.Find(i).gameObject);
		// //   }

		// //   for(int i = 301; i < 317; i++){
		// // 	  blackfiguresPhoton.Add(PhotonView.Find(i).gameObject);
		// //   }

		//   GameObject.Find("Camera").GetComponent<Figure>().enabled = true;
		//   }





// void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info){
//     int b = a;

// 		stream.Serialize(ref b);
		
// 		if(stream.isReading){
// 			a = b;
// }
// }
	

	// else if(!PhotonNetwork.isMasterClient){
    // GameObject.Find("Camera").GetComponent<Figure>().enabled = true;

	}
	

// [PunRPC]
// public void MasterRPC(int a){
//        ahidden = a;
// 	   Debug.Log(a);

//  }

}