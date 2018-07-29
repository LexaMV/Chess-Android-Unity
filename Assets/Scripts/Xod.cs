using System;
using System.Collections;
using System.Collections.Generic;
using cakeslice;
using TMPro;
using UnityEngine;

public class Xod: MonoBehaviour {
	
	public String Igrok1Name;
	public String Igrok2Name;
	public bool StartIndex1; // белые
    public bool StartIndex2; // черные
	
	void Start(){
		
		Igrok1Name = "Кот";
		Igrok2Name = "Собака";
		StartIndex1 = false; 
        StartIndex2 = true;
	}
}
