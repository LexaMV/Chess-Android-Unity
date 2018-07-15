﻿using System.Collections;
using System.Collections.Generic;
using cakeslice;
using UnityEngine;

public class EnterMouse : MonoBehaviour {
    public bool entermouse = true;
	void OnMouseEnter()
    {
        if(entermouse){
        gameObject.GetComponent<Outline>().enabled = true;
    }
    }

    void OnMouseExit()
    {
        if(gameObject.GetComponent<Cell>() == null && entermouse){
        gameObject.GetComponent<Outline>().enabled = false;
        }
        else if (gameObject.GetComponent<Cell>().cell == true && entermouse){
            gameObject.GetComponent<Outline>().enabled = false;
        }

    }

    
}
