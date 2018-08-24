using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trig : Photon.MonoBehaviour {

    public GameObject triger;

    void OnTriggerEnter (Collider other) {
        // Debug.Log("////////////////////" + other.name);
        // if(other.gameObject.GetComponent<Trig>() != null && other.gameObject.GetComponent<Trig>().triger.name == triger.name){
        //     Debug.Log("хе-хе");
        //     if(other.gameObject.name.Contains("white") && GameObject.Find("Camera").GetComponent<Xod>().StartIndex1 == true){

        //     Destroy(other);   
        //     }

        //    if(other.gameObject.name.Contains("white") && GameObject.Find("Camera").GetComponent<Xod>().StartIndex1 == false){

        //     Destroy(gameObject);   
        //     }

        //     if(other.gameObject.name.Contains("black") && GameObject.Find("Camera").GetComponent<Xod>().StartIndex2 == true){

        //     Destroy(other);   
        //     }

        //     if(other.gameObject.name.Contains("black") && GameObject.Find("Camera").GetComponent<Xod>().StartIndex2 == false){

        //     Destroy(gameObject);   
        //     }
        // }

        // if(PhotonNetwork.isMasterClient){
        triger = other.gameObject; // ячейка
        triger.GetComponent<Cell> ().stoitfigura = true;
        triger.GetComponent<Cell> ().figeureName = gameObject.name;
        // Debug.LogError (other.gameObject.name);
        // }

        // else if(!PhotonNetwork.isMasterClient){
        //     int a = other.gameObject.GetComponent<PhotonView>().ownerId;
        //     triger = PhotonView.Find(a).gameObject;
        //     triger.GetComponent<Cell> ().stoitfigura = true;
        //     triger.GetComponent<Cell> ().figeureName = gameObject.name;
        //     Debug.Log (other.gameObject.name);
        // }
    

    }

    void OnTriggerExit (Collider other) {
        // if(PhotonNetwork.isMasterClient){
        other.gameObject.GetComponent<Cell> ().stoitfigura = false;
        other.gameObject.GetComponent<Cell> ().figeureName = null;
    // }

    // else if(!PhotonNetwork.isMasterClient){
    //   int a = other.gameObject.GetComponent<PhotonView>().ownerId;
    //   triger.GetComponent<Cell> ().stoitfigura = false;
    //         triger.GetComponent<Cell> ().figeureName = null;
    // }
}


	void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info){
        string s = triger.name;
        // Debug.Log("/////////////////////////////////////////////");
        // Debug.LogError(triger.name);
		stream.Serialize(ref s);
		


		if(stream.isReading){
			string b = s;
            triger = GameObject.Find("b").gameObject;
          
		}
	}
}
