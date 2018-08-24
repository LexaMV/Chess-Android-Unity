using System.Collections;
using System.Collections.Generic;
using cakeslice;
using UnityEngine;

public class EnterMouse : Photon.MonoBehaviour {
    public bool entermouse = true;
    void OnMouseEnter () {
     
        if (gameObject.name.Contains ("white") || gameObject.name.Contains ("black")) {

            if (GameObject.Find ("Camera").GetComponent<Xod> ().StartIndex1 == false && gameObject.name.Contains ("white")) {

                gameObject.GetComponent<Outline> ().enabled = false;
            }

            if (GameObject.Find ("Camera").GetComponent<Xod> ().StartIndex2 == false && gameObject.name.Contains ("black")) {

                gameObject.GetComponent<Outline> ().enabled = false;
            }

            if (GameObject.Find ("Camera").GetComponent<Xod> ().StartIndex1 == true && gameObject.name.Contains ("white")) {

                gameObject.GetComponent<Outline> ().enabled = true;
            }

            if (GameObject.Find ("Camera").GetComponent<Xod> ().StartIndex2 == true && gameObject.name.Contains ("black")) {

                gameObject.GetComponent<Outline> ().enabled = true;
            }
        } else if (gameObject.GetComponent<Cell> ().cellvibranadlaxoda == true) {

            gameObject.GetComponent<Outline> ().enabled = true;
        } else if (gameObject.GetComponent<Cell> ().stoitfigura == false) {

            gameObject.GetComponent<Outline> ().enabled = false;
        } else if (gameObject.GetComponent<Cell> ().stoitfigura == false) {

            gameObject.GetComponent<Outline> ().enabled = false;
        } else if (entermouse) {

            gameObject.GetComponent<Outline> ().enabled = true;
        }
    }
    

    void OnMouseExit () {
       
        if (gameObject.GetComponent<Cell> () == null) {

            gameObject.GetComponent<Outline> ().enabled = false;
        } else if (gameObject.GetComponent<Cell> ().cell == false) {

            gameObject.GetComponent<Outline> ().enabled = true;
        } else if (gameObject.GetComponent<Cell> ().cell == true) {

            gameObject.GetComponent<Outline> ().enabled = false;
        }
    }
    }
