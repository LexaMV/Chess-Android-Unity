using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Photon.MonoBehaviour {


	void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info){
		Vector3 pos = transform.position;
		Quaternion rot = transform.rotation;
		stream.Serialize(ref pos);
		stream.Serialize(ref rot);

		if(stream.isReading){
			transform.position = pos;
			transform.rotation = rot;
		}
	}

}
