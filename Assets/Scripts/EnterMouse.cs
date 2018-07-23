using System.Collections;
using System.Collections.Generic;
using cakeslice;
using UnityEngine;

public class EnterMouse : MonoBehaviour {
    public bool entermouse = true;
	void OnMouseEnter()
    {
        if(gameObject.GetComponent<Cell>() == null){
        gameObject.GetComponent<Outline>().enabled = false;
        } 
        else if(entermouse){
        gameObject.GetComponent<Outline>().enabled = true;
    }
    }

    void OnMouseExit()
    {
        if(gameObject.GetComponent<Cell>() == null){
        gameObject.GetComponent<Outline>().enabled = false; 
        }
        else if (gameObject.GetComponent<Cell>().cell == false){
          gameObject.GetComponent<Outline>().enabled = true;
         }
        else if (gameObject.GetComponent<Cell>().cell == true){
            gameObject.GetComponent<Outline>().enabled = false;
         }

    }

    
}
