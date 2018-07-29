using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trig : MonoBehaviour {

public GameObject triger;

void OnTriggerEnter(Collider other){

    triger = other.gameObject; // ячейка
    triger.GetComponent<Cell>().stoitfigura = true;
    triger.GetComponent<Cell>().figeureName = gameObject.name;
    Debug.Log(other.gameObject.name);
}

void OnTriggerExit(Collider other){

    other.gameObject.GetComponent<Cell>().stoitfigura = false;
    other.gameObject.GetComponent<Cell>().figeureName = null;
}
}
