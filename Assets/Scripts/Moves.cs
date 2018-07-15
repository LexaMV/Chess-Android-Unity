using System;
using System.Collections;
using System.Collections.Generic;
using cakeslice;
using UnityEngine;

public class Moves : MonoBehaviour {

	 void Update () {
		 if(gameObject.GetComponent<Figure>().moves){


     if(gameObject.GetComponent<Figure>().choisefigure.name.Contains("pawn")){
	        String s = gameObject.GetComponent<Figure>().choisefigure.GetComponent<Trig>().triger.name;
            String first = s.Substring(0,1); 
			Debug.Log("////////////////////////////////////////////////");
			Debug.Log(first);
			String stringsecond = s.Substring(1,1); 
			Debug.Log("////////////////////////////////////////////////");
			Debug.Log(stringsecond);
			int intsecond = Int32.Parse(stringsecond);

			int intsecond1 = 0;
            int intsecond2 = 0;

		    	if(intsecond < 4){
				intsecond1 = intsecond + 1;
				intsecond2 = intsecond + 2;
				}
				else if(intsecond > 4){
				intsecond1 = intsecond - 1;
				intsecond2 = intsecond - 2;
				}
				
			String final1 = first + intsecond1.ToString();
			Debug.Log("////////////////////////////////////////////////");
			Debug.Log(final1);
			String final2 = first + intsecond2.ToString();
			Debug.Log("////////////////////////////////////////////////");
			Debug.Log(final2);
			GameObject.Find(s).GetComponent<Outline>().enabled = true;
            GameObject.Find(s).GetComponent<Cell>().cell = false;   
            GameObject.Find(final1).GetComponent<Outline>().enabled = true;
			GameObject.Find(final1).GetComponent<Cell>().cell = false; 
			GameObject.Find(final2).GetComponent<Outline>().enabled = true;
			GameObject.Find(final2).GetComponent<Cell>().cell = false; 
			gameObject.GetComponent<Figure>().camera.GetComponent<Moves>().enabled = false;
			gameObject.GetComponent<Figure>().moves = false;
	 }		
	 }
}
}
