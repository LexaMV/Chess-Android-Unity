using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour {


	//   [SerializeField]
	public string figeureName;
	//  [SerializeField]
	public bool cell = true;
	//  [SerializeField]
	public bool cellvibranadlaxoda = false;
	//  [SerializeField]
	public bool stoitfigura = false;
	public bool dlaproverki  = false;

	void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info){
		String s = figeureName;
		var e = cell;
		var a = cellvibranadlaxoda;
		var f = stoitfigura;
	    var n = dlaproverki;
		stream.Serialize(ref s);
		stream.Serialize(ref e);
		stream.Serialize(ref a);
		stream.Serialize(ref f);
		stream.Serialize(ref n);		


		if(stream.isReading){
			dlaproverki = n;
			figeureName = s;
			cell = e;
			cellvibranadlaxoda = a;
			stoitfigura = f;
		}
	}
	
}