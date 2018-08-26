using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Photon.MonoBehaviour {

      public Vector3 pos;
	  public Quaternion rot;

	  void Start(){
		  pos = transform.position;
		  rot = transform.rotation;
	  }

	void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info){
		pos = transform.position;
		rot = transform.rotation;
		stream.Serialize(ref pos);
		stream.Serialize(ref rot);

		if(stream.isReading){
			transform.position = pos;
			transform.rotation = rot;
		}
	}

}
