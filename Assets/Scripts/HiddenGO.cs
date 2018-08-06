using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HiddenGO : MonoBehaviour {

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
	public GameObject[, ] hiddengo;
	public List<GameObject> whitefigures;
	public List<GameObject> blackfigures;
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

	void Start () {

		// этот код для расстановки ячеек ввиде квадрата

		digitint = -1;
		x = 10.0f;
		y = 1.0f;
		z = 10.0f;
		GameObject field = GameObject.Find ("Field");
		GameObject figures = GameObject.Find ("Figures");
		hiddengo = new GameObject[8, 8];

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
					GameObject cell = Instantiate (PrefabCell1, new Vector3 (x, y, z), Quaternion.identity, field.transform);
					cell.name = letters[7 - j] + digit[digitint];
					black = true;
					hiddengo[j, i] = cell;
				} else {
					GameObject cell = Instantiate (PrefabCell2, new Vector3 (x, y, z), Quaternion.identity, field.transform);
					cell.name = letters[7 - j] + digit[digitint];
					black = false;
					hiddengo[j, i] = cell;
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
			GameObject half = Instantiate (HalfCell, new Vector3 (x, y, z), Quaternion.identity, field.transform);
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
			GameObject half = Instantiate (HalfCell, new Vector3 (x, y, z), Quaternion.identity, field.transform);
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
			GameObject half = Instantiate (HalfCell, new Vector3 (x, y, z), Quaternion.Euler (new Vector3 (0, 90f, 0)), field.transform);
			half.GetComponent<Renderer> ().material.color = Color.black;
			RectTransform rectTextMesh = half.transform.Find ("Canvas").gameObject.transform.Find ("TextMesh").GetComponent<RectTransform> ();
			rectTextMesh.Rotate (new Vector3 (0, 0, 0));
			TextMeshProUGUI textMesh = half.transform.Find ("Canvas").gameObject.transform.Find ("TextMesh").GetComponent<TextMeshProUGUI> ();
			textMesh.text = digit[7 - i];
			x = x + 2.50f;
		}

		x = -7.5f;
		y = 1.0f;
		z = -9.375f;

		for (int i = 0; i < 8; i++) {
			GameObject half = Instantiate (HalfCell, new Vector3 (x, y, z), Quaternion.Euler (new Vector3 (0, 90f, 0)), field.transform);
			half.GetComponent<Renderer> ().material.color = Color.black;
			RectTransform rectTextMesh = half.transform.Find ("Canvas").gameObject.transform.Find ("TextMesh").GetComponent<RectTransform> ();
			rectTextMesh.Rotate (new Vector3 (0, 0, 180));
			TextMeshProUGUI textMesh = half.transform.Find ("Canvas").gameObject.transform.Find ("TextMesh").GetComponent<TextMeshProUGUI> ();
			textMesh.text = digit[7 - i];
			x = x + 2.50f;
		}

		GameObject fourth1 = Instantiate (FourthCell, new Vector3 (-9.375f, 1.0f, -9.375f), Quaternion.identity, field.transform);
		fourth1.GetComponent<Renderer> ().material.color = Color.black;
		GameObject fourth2 = Instantiate (FourthCell, new Vector3 (-9.375f, 1.0f, 11.875f), Quaternion.identity, field.transform);
		fourth2.GetComponent<Renderer> ().material.color = Color.black;
		GameObject fourth3 = Instantiate (FourthCell, new Vector3 (11.875f, 1.0f, 11.875f), Quaternion.identity, field.transform);
		fourth3.GetComponent<Renderer> ().material.color = Color.black;
		GameObject fourth4 = Instantiate (FourthCell, new Vector3 (11.875f, 1.0f, -9.375f), Quaternion.identity, field.transform);
		fourth4.GetComponent<Renderer> ().material.color = Color.black;

		// расстановка фигур на поле боя

		foreach (GameObject go in hiddengo) {

			if (go.name.Contains ("2")) {

				GameObject pawnwhite = Instantiate (whitepawn, go.transform.position, Quaternion.identity, figures.transform);
				whitefigures.Add (pawnwhite);
			}

			if (go.name.Contains ("7")) {

				GameObject pawnblack = Instantiate (blackpawn, go.transform.position, Quaternion.identity, figures.transform);
				blackfigures.Add (pawnblack);
			}

			if (go.name.Contains ("A1") || go.name.Contains ("H1")) {

				GameObject rookwhite = Instantiate (whiterook, go.transform.position, Quaternion.identity, figures.transform);
				whitefigures.Add (rookwhite);
			}

			if (go.name.Contains ("A8") || go.name.Contains ("H8")) {

				GameObject rookblack = Instantiate (blackrook, go.transform.position, Quaternion.identity, figures.transform);
				blackfigures.Add (rookblack);
			}

			if (go.name.Contains ("B1") || go.name.Contains ("G1")) {

				GameObject horsewhite = Instantiate (whitehorse, go.transform.position, Quaternion.identity, figures.transform);
				whitefigures.Add (horsewhite);
				horsewhite.transform.Rotate (0, -90, 0);
			}

			if (go.name.Contains ("B8") || go.name.Contains ("G8")) {

				GameObject horseblack = Instantiate (blackhorse, go.transform.position, Quaternion.identity, figures.transform);
				blackfigures.Add (horseblack);
				horseblack.transform.Rotate (0, 90, 0);
			}
			if (go.name.Contains ("C1") || go.name.Contains ("F1")) {

				GameObject bishopwhite = Instantiate (whitebishop, go.transform.position, Quaternion.identity, figures.transform);
				whitefigures.Add (bishopwhite);
			}
			if (go.name.Contains ("C8") || go.name.Contains ("F8")) {

				GameObject bishopblack = Instantiate (blackbishop, go.transform.position, Quaternion.identity, figures.transform);
				blackfigures.Add (bishopblack);
			}
			if (go.name.Contains ("D1")) {

				GameObject queenwhite = Instantiate (whitequeen, go.transform.position, Quaternion.identity, figures.transform);
				whitefigures.Add (queenwhite);
			}
			if (go.name.Contains ("D8")) {

				GameObject kingblack = Instantiate (blackking, go.transform.position, Quaternion.identity, figures.transform);
				blackfigures.Add (kingblack);
			}
			if (go.name.Contains ("E1")) {

				GameObject kingwhite = Instantiate (whiteking, go.transform.position, Quaternion.identity, figures.transform);
				whitefigures.Add (kingwhite);
			}
			if (go.name.Contains ("E8")) {

				GameObject queenblack = Instantiate (blackqueen, go.transform.position, Quaternion.identity, figures.transform);
				blackfigures.Add (queenblack);
			}
		}
	}
}