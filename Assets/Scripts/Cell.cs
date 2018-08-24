using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour {


	 
	public string figeureName;
	public bool cell = true;
	public bool cellvibranadlaxoda = false;
	public bool stoitfigura = false;

	void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info){
		String s = figeureName;
		var e = cell;
		var a = cellvibranadlaxoda;
		var f = stoitfigura;
		stream.Serialize(ref s);
		stream.Serialize(ref e);
		stream.Serialize(ref a);
		stream.Serialize(ref f);
		


		if(stream.isReading){
			figeureName = s;
			cell = e;
			cellvibranadlaxoda = a;
			stoitfigura = f;
		}
	}
	
}