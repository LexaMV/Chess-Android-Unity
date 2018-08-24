using System;
using System.Collections;
using System.Collections.Generic;
using cakeslice;
using TMPro;
using UnityEngine;

public class Xod : MonoBehaviour {

	public String Igrok1Name;
	public String Igrok2Name;
	public bool StartIndex1; // белые
	public bool StartIndex2; // черные

	void Start () {
    //  if(PhotonNetwork.isMasterClient){
	    Igrok1Name = "Кот";
		Igrok2Name = "Собака";
		StartIndex1 = false;
		StartIndex2 = true;
	//  }
	}

		void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info){
		String s = Igrok1Name;
		String d = Igrok2Name;
		var a = StartIndex1;
		var f = StartIndex2;
		stream.Serialize(ref s);
		stream.Serialize(ref d);
		stream.Serialize(ref a);
		stream.Serialize(ref f);
		


		if(stream.isReading){
			Igrok1Name = s;
			Igrok2Name = d;
			StartIndex1 = a;
			StartIndex2 = f;
		}
	}

    // void Update(){

    //  if(!PhotonNetwork.isMasterClient){
 

	// 	Igrok1Name = PhotonView.Find(867).GetComponent<Xod>().Igrok1Name;
		    
	// Igrok2Name = PhotonView.Find(867).GetComponent<Xod>().Igrok2Name;
	
	// 	StartIndex1 = PhotonView.Find(867).GetComponent<Xod>().StartIndex1;

	// StartIndex2 = PhotonView.Find(867).GetComponent<Xod>().StartIndex2;

	// }

		
	// }
}