using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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

public GameObject[,] hiddengo;
public float x = 9f;
private float y = 1.0f;
public float z = 9f;
public string[] digit = {"1","2","3","4","5","6","7","8"};  
public int digitint = 7;
public int lettersint = 0;
public string[] letters = {"A","B","C","D","E","F","G","H"};
public bool black;
public GameObject PrefabCell;
	// Use this for initialization
	void Start () {
		GameObject field = GameObject.Find("Field");
		GameObject figures = GameObject.Find("Figures");
		hiddengo = new GameObject[8,8];
		for(int i = 0; i < 8; i++){
            
			if ( i == 0){
			black = false;	
			}
			else if(i%2 == 0){
				black = false;
			}
			else if(i%2 != 0){
				black = true;
			}

			for(int j = 0; j < 8; j++){
				GameObject cell = Instantiate(PrefabCell, new Vector3(x,y,z), Quaternion.identity, field.transform);
			    cell.name = (letters[lettersint] + digit[digitint]);
				if(black == false){
                cell.GetComponent<Renderer>().material.color = Color.white;
				black = true;
				}
				else{
				cell.GetComponent<Renderer>().material.color = Color.black;
				black = false;
				}
				z = z - 2.50f;
				lettersint += 1;
				hiddengo[j,i] = cell;
			}
			lettersint = 0;
			digitint -= 1;
			black = true;
			x = x - 2.50f;
			z = 9f;
		}

		 foreach(GameObject go in hiddengo){
		 	if(go.name.Contains("2")){
                 GameObject pawnblack = Instantiate(whitepawn,go.transform.position,Quaternion.identity,figures.transform);
		 	}
			if(go.name.Contains("7")){
                 GameObject pawnblack = Instantiate(blackpawn,go.transform.position,Quaternion.identity,figures.transform);
		 	}
			if(go.name.Contains("A1") || go.name.Contains("H1")){
                 GameObject rookwhite = Instantiate(whiterook,go.transform.position,Quaternion.identity,figures.transform);
		 	}
			if(go.name.Contains("A8") || go.name.Contains("H8")){
                 GameObject rookblack = Instantiate(blackrook,go.transform.position,Quaternion.identity,figures.transform);
		 	}
			if(go.name.Contains("B1") || go.name.Contains("G1")){
                 GameObject horsewhite = Instantiate(whitehorse,go.transform.position,Quaternion.identity,figures.transform);
				 horsewhite.transform.Rotate(0,90,0);
		 	}
			if(go.name.Contains("B8") || go.name.Contains("G8")){
                 GameObject horseblack = Instantiate(blackhorse,go.transform.position,Quaternion.identity,figures.transform);
				 horseblack.transform.Rotate(0,-90,0);
		 	}
			if(go.name.Contains("C1") || go.name.Contains("F1")){
                 GameObject bishopwhite = Instantiate(whitebishop,go.transform.position,Quaternion.identity,figures.transform);
		 	}
			if(go.name.Contains("C8") || go.name.Contains("F8")){
                 GameObject bishopblack = Instantiate(blackbishop,go.transform.position,Quaternion.identity,figures.transform);
		 	}
			 if(go.name.Contains("D1")){
                 GameObject queenwhite = Instantiate(whitequeen,go.transform.position,Quaternion.identity,figures.transform);
		    }
			if(go.name.Contains("D8")){
                   GameObject kingblack = Instantiate(blackking,go.transform.position,Quaternion.identity,figures.transform);
		    }
			 if(go.name.Contains("E1")){
                 GameObject kingwhite = Instantiate(whiteking,go.transform.position,Quaternion.identity,figures.transform);
		    }
			if(go.name.Contains("E8")){
                   GameObject queenblack = Instantiate(blackqueen,go.transform.position,Quaternion.identity,figures.transform);
		    }
			 
		 }
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
