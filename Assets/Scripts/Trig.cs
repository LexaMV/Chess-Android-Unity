using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trig : MonoBehaviour {

public GameObject triger;

void OnTriggerEnter(Collider other){
    triger = other.gameObject;
    Debug.Log(triger.name);
}
}
