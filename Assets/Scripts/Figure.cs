using System;
using System.Collections;
using System.Collections.Generic;
using cakeslice;
using TMPro;
using UnityEngine;

public class Figure : Photon.MonoBehaviour {
	// private PunTurnManager turnManager;
	private readonly byte RaiseEventMaster = 0;
	private readonly byte RaiseEventClient = 0;
    static public Figure Instance;
    public Vector3 idetfigurakvectory;

	public bool moves = false;

	public bool xod = false; // выбрана ли фигура для хода;

	public bool xodincell = false; // выбрана ли фигура с ячейкой куда она должна идти

	private float Speed = 4.0f;
	public Camera camera;
	 
	private bool figureischoise = false; //проверка была ли ранее какая либо выбрана фигура или нет

	public GameObject choisefigure;

	public GameObject xodfigure; // в какую ячейку пойдет фигура

	public String fromCell; // с какой ячейки начинает ходить фигура

	public bool fromenabled = false; // для string начальной ячейки

	public String inCell; // в какую ячейку идет фигура

	public bool inenabled = false; // для string конечной ячейки

	public int intMassivWhite;

	public int intMassivBlack;
    public List<String> RaiseEventMassiv;

	public List<GameObject> NyjniiMassiv;
	public List<GameObject> whitefigures;
	public List<GameObject> blackfigures;

	public String vibranafiguranamefirst;
	public String vibranacellfirst;



	// public Component NyjniiScript;

void Awake(){
	Instance = this;
}

	void Start () {
	    RaiseEventMassiv = new List<String>();
        PhotonView photonView = PhotonView.Get(gameObject);
		idetfigurakvectory.x = 1;
				idetfigurakvectory.y = 1;
				idetfigurakvectory.z = 1;
		
		intMassivWhite = -1;
		intMassivBlack = -1;

    // if(PhotonNetwork.isMasterClient){
		Debug.Log("///////////////////////////////////////");
	    NyjniiMassiv = HiddenGO.Instance.hiddengo;
		Debug.LogWarning(NyjniiMassiv.Count);
		whitefigures = HiddenGO.Instance.whitefigures;
		Debug.LogWarning(whitefigures.Count);
		blackfigures = HiddenGO.Instance.blackfigures;
		Debug.LogWarning(blackfigures.Count);
	// }

	// else if(!PhotonNetwork.isMasterClient){
	// Debug.Log("+++++++++++++++++++++++++++++++++++++++++++");
	// // //  PhotonView view = PhotonView.Find(PhotonNetwork.masterClient.ID);
	// // // // Debug.LogWarning(view.gameObject.name);
	// // // Debug.LogWarning("Master1 = " + view.gameObject.GetComponent<HiddenGO>().Master1);
	// // // Debug.LogWarning("Master2 = " + view.gameObject.GetComponent<HiddenGO>().Master2);
	// NyjniiMassiv = HiddenGO.Instance.hiddengoPtonon;
	// Debug.LogWarning(NyjniiMassiv.Count);
	// whitefigures = HiddenGO.Instance.whitefiguresPhoton;
	// Debug.LogWarning(whitefigures.Count);
	// blackfigures = HiddenGO.Instance.blackfiguresPhoton;
	// Debug.LogWarning(blackfigures.Count);
	// }

   

	}
	void Update () {
		
		// if(XodIgroka1 == false){
		// TextMeshProUGUI textmesh = GameObject.Find("Nadpisi").gameObject.transform.Find("Canvas").gameObject.transform.Find("Igrok").GetComponent<TextMeshProUGUI>();
		// textmesh.text = "Игрок 1";

		if (Input.GetMouseButtonDown (0)) {
			//  if(!photonView.isMine){

			Ray ray = camera.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit)) {

				// 	if(figureischoise == false && xod == false) {

				//     if(GameObject.Find("Camera").GetComponent<Xod>().StartIndex1 == true && hit.collider.gameObject.name.Contains("white")){
				//             TextMeshProUGUI textmeshName = GameObject.Find("Nadpisi").gameObject.transform.Find("Canvas").gameObject.transform.Find("Igrok").GetComponent<TextMeshProUGUI>();
				//             textmeshName.text = GameObject.Find("Camera").GetComponent<Xod>().Igrok1Name;
				//          	hit.collider.gameObject.GetComponent<Outline>().enabled = true;
				// 			hit.collider.gameObject.GetComponent<EnterMouse>().entermouse = false;
				// 			figureischoise = true;
				// 			choisefigure = hit.collider.gameObject;
				// 			camera.GetComponent<Moves>().enabled = true;
				// 		    xod = true;
				// 			moves = true;
				//     }

				//     if(GameObject.Find("Camera").GetComponent<Xod>().StartIndex2 == true && hit.collider.gameObject.name.Contains("black")){

				// 			TextMeshProUGUI textmeshName = GameObject.Find("Nadpisi").gameObject.transform.Find("Canvas").gameObject.transform.Find("Igrok").GetComponent<TextMeshProUGUI>();
				//             textmeshName.text = GameObject.Find("Camera").GetComponent<Xod>().Igrok2Name;
				//          	hit.collider.gameObject.GetComponent<Outline>().enabled = true;
				// 			hit.collider.gameObject.GetComponent<EnterMouse>().entermouse = false;
				// 			figureischoise = true;
				// 			choisefigure = hit.collider.gameObject;
				// 			camera.GetComponent<Moves>().enabled = true;
				// 		    xod = true;
				// 			moves = true;
				//     }
				// }

				// if(figureischoise == true && xod == true) {

				// if(choisefigure != null){

				// if(GameObject.Find("Camera").GetComponent<Xod>().StartIndex1 == true && hit.collider.gameObject.name.Contains("black")){

				// xodfigure = hit.collider.gameObject;
				// fromenabled = true;
				// xodincell = true;
				// }

				// if(GameObject.Find("Camera").GetComponent<Xod>().StartIndex2 == true && hit.collider.gameObject.name.Contains("white")){

				// xodfigure = hit.collider.gameObject;
				// fromenabled = true;
				// xodincell = true; 
				// }

				// }

				if (GameObject.Find ("Camera").GetComponent<Xod> ().StartIndex1 == true && hit.collider.gameObject.name.Contains ("white")) {

					TextMeshProUGUI textmeshName = GameObject.Find ("Nadpisi").gameObject.transform.Find ("Canvas").gameObject.transform.Find ("Igrok").GetComponent<TextMeshProUGUI> ();
					textmeshName.text = GameObject.Find ("Camera").GetComponent<Xod> ().Igrok1Name;

					foreach (GameObject cell in NyjniiMassiv) {

						cell.GetComponent<Outline> ().enabled = false;
					}
                    Debug.LogWarning(hit.collider.gameObject.name);
					vibranafiguranamefirst = hit.collider.gameObject.name;
					hit.collider.gameObject.GetComponent<Outline> ().enabled = true;
					hit.collider.gameObject.GetComponent<EnterMouse> ().entermouse = false;
					choisefigure = hit.collider.gameObject;
					choisefigure.GetComponent<Outline> ().enabled = true;
					camera.GetComponent<Moves> ().enabled = true;
					moves = true;
					xod = true;
					figureischoise = true;
				}
			}

			if (GameObject.Find ("Camera").GetComponent<Xod> ().StartIndex2 == true && hit.collider.gameObject.name.Contains ("black")) {

				TextMeshProUGUI textmeshName = GameObject.Find ("Nadpisi").gameObject.transform.Find ("Canvas").gameObject.transform.Find ("Igrok").GetComponent<TextMeshProUGUI> ();
				textmeshName.text = GameObject.Find ("Camera").GetComponent<Xod> ().Igrok2Name;

				foreach (GameObject cell in NyjniiMassiv) {

					cell.GetComponent<Outline> ().enabled = false;
				}
                // Debug.LogWarning(hit.collider.gameObject.name);
				vibranafiguranamefirst = hit.collider.gameObject.name;
				hit.collider.gameObject.GetComponent<Outline> ().enabled = true;
				hit.collider.gameObject.GetComponent<EnterMouse> ().entermouse = false;
				choisefigure = hit.collider.gameObject;
				choisefigure.GetComponent<Outline> ().enabled = true;
				camera.GetComponent<Moves> ().enabled = true;
				moves = true;
				xod = true;
				figureischoise = true;
			}

			if ((GameObject.Find ("Camera").GetComponent<Xod> ().StartIndex2 == true && hit.collider.gameObject.name.Contains ("white")) || (GameObject.Find ("Camera").GetComponent<Xod> ().StartIndex1 == true && hit.collider.gameObject.name.Contains ("black"))) {

				if (figureischoise == true && hit.collider.gameObject.GetComponent<Trig> ().triger.GetComponent<Outline> ().enabled) {
					Debug.Log ("uuuu");
					xodfigure = hit.collider.gameObject.GetComponent<Trig> ().triger;
					
					fromenabled = true;
					xodincell = true;
					// }

					// choisefigure.GetComponent<Outline>().enabled = false;
					// choisefigure.GetComponent<EnterMouse>().entermouse = true;
				}
			}

			if (hit.collider.gameObject.GetComponent<Cell> () != null) {

				if (xod == true && hit.collider.gameObject.GetComponent<Cell> ().cellvibranadlaxoda == true) {

					xodfigure = hit.collider.gameObject;
					vibranacellfirst = xodfigure.gameObject.name;
					fromenabled = true;
					xodincell = true;
					hit.collider.gameObject.GetComponent<Cell> ().dlaproverki = true;
				}
			}
		}
		
	

		if (xod == true && xodincell == true) {

			if (fromenabled) {

				fromCell = choisefigure.GetComponent<Trig> ().triger.name;
				fromenabled = false;
			}

		    idetfigurakvectory = xodfigure.transform.position;
	
			choisefigure.transform.position = Vector3.MoveTowards (choisefigure.transform.position, xodfigure.transform.position, Time.deltaTime * Speed);
			
		


			if (choisefigure.transform.position == xodfigure.transform.position) {
            // photonView.RPC("XodNaNote()",PhotonTargets.All, PhotonNetwork.playerList as object);
			//  String a = idetfigurakvectory.x.ToString();
			//  String b = idetfigurakvectory.y.ToString();
			//  String c = idetfigurakvectory.z.ToString();
            //  RaiseEventMassiv.Add(a);
			//  RaiseEventMassiv.Add(b);
			//  RaiseEventMassiv.Add(c);
			//  RaiseEventMassiv.Add(vibranafiguranamefirst);

			object[] content = new object[] {idetfigurakvectory,vibranafiguranamefirst};
			//  Debug.Log(RaiseEventMassiv.Count);
	         RaiseEventOptions raiseEventOptions = new RaiseEventOptions { Receivers = ReceiverGroup.Others };
            //  PhotonNetwork.RaiseEvent(RaiseEventClient,RaiseEventMassiv,true, raiseEventOptions);
			PhotonNetwork.RaiseEvent(RaiseEventClient,content,true, raiseEventOptions);
			PhotonNetwork.RaiseEvent(RaiseEventMaster,content,true, raiseEventOptions);
			// photonView.RPC("XodNaNote",PhotonTargets.Others, null);
				inenabled = true;

				if (inenabled) {
					inCell = choisefigure.GetComponent<Trig> ().triger.name;
					inenabled = false;
				}

				foreach (GameObject cell in NyjniiMassiv) {
					cell.GetComponent<Outline> ().enabled = false;
					cell.GetComponent<Cell> ().cell = true;
					cell.GetComponent<Cell> ().cellvibranadlaxoda = false;
				}

				if (GameObject.Find ("Camera").GetComponent<Xod> ().StartIndex1 == true) {

					GameObject.Find ("Camera").GetComponent<Xod> ().StartIndex2 = true;
					GameObject.Find ("Camera").GetComponent<Xod> ().StartIndex1 = false;

				} else if (GameObject.Find ("Camera").GetComponent<Xod> ().StartIndex1 == false) {

					GameObject.Find ("Camera").GetComponent<Xod> ().StartIndex2 = false;
					GameObject.Find ("Camera").GetComponent<Xod> ().StartIndex1 = true;

				}
                 
				
               

				TextMeshProUGUI textmesh1 = GameObject.Find ("Nadpisi").gameObject.transform.Find ("Canvas").gameObject.transform.Find ("Xodi").GetComponent<TextMeshProUGUI> ();
				textmesh1.text = fromCell + " to " + inCell;
				fromCell = null;
				inCell = null;
				xod = false;
				xodincell = false;
				choisefigure.GetComponent<Outline> ().enabled = false;
				choisefigure.GetComponent<EnterMouse> ().entermouse = true;

				choisefigure = null;
				xodfigure = null;
				figureischoise = false;
                // var[] digit = { "1", "2", "3", "4", "5", "6", "7", "8" };
				// Network.Instance.turnManager.SendMove([idetfigurakvectory,vibranafiguranamefirst,vibranacellfirst], true);
				// Debug.LogWarning("1");
				// Network.Instance.turnManager.SendMove(vibranafiguranamefirst, false);
				// Debug.LogWarning("2");
				// Network.Instance.turnManager.SendMove(vibranacellfirst, true);
				// Debug.LogWarning("3");
				// Network.Instance.OnTurnCompleted(-1);

			}
		}

		foreach (GameObject wob in whitefigures) {
			foreach (GameObject bob in blackfigures) {
				if (wob.transform.position == bob.transform.position) {

					intMassivWhite = whitefigures.IndexOf (wob);
					Debug.Log ("intMassivWhite =" + intMassivWhite);
				}
			}
		}

		foreach (GameObject bob in blackfigures) {
			foreach (GameObject wob in whitefigures) {
				if (bob.transform.position == wob.transform.position) {

					intMassivBlack = blackfigures.IndexOf (bob);
					Debug.Log ("intMassivBlack =" + intMassivBlack);
				}
			}
		}

		if (intMassivWhite != -1 || intMassivBlack != -1) {
			if (GameObject.Find ("Camera").GetComponent<Xod> ().StartIndex1 == true) {

				GameObject delwhite = whitefigures[intMassivWhite];
				whitefigures.RemoveAt (intMassivWhite);
				Destroy (delwhite.gameObject);
			}

			if (GameObject.Find ("Camera").GetComponent<Xod> ().StartIndex2 == true) {

				GameObject delblack = blackfigures[intMassivBlack];
				blackfigures.RemoveAt (intMassivBlack);
				Destroy (delblack.gameObject);
			}

			intMassivWhite = -1;
			intMassivBlack = -1;
			
		}


  


		
	// if(idetfigurakvectory.x != 1 && idetfigurakvectory.y != 1 && idetfigurakvectory.z != 1 && vibranafiguranamefirst !=null && vibranacellfirst != null){
	if(idetfigurakvectory.z != 1 && vibranafiguranamefirst !=null){
			

			

	if(GameObject.Find(vibranafiguranamefirst).gameObject.transform.position.x != idetfigurakvectory.x){
	GameObject.Find(vibranafiguranamefirst).gameObject.transform.position = Vector3.MoveTowards(GameObject.Find(vibranafiguranamefirst).gameObject.transform.position,idetfigurakvectory,Time.deltaTime*Speed); 
				
	}

	else if(GameObject.Find(vibranafiguranamefirst).gameObject.transform.position.x == idetfigurakvectory.x){
			
	idetfigurakvectory = new Vector3(1,1,1);
	vibranafiguranamefirst = null;
	}
	}
	}
	// }

	public void OnEvent(byte eventCode, object content, int senderId)
{
	if(PhotonNetwork.isMasterClient){
    if (eventCode == RaiseEventMaster){
		object[] data = (object[])content;
    idetfigurakvectory = (Vector3)data[0];
	vibranafiguranamefirst = (String)data[1];
	Debug.LogWarning("Vse1");
			// Do something
	}
}

  if(!PhotonNetwork.isMasterClient){
  if (eventCode == RaiseEventClient){
		object[] data = (object[])content;
    idetfigurakvectory = (Vector3)data[0];
	vibranafiguranamefirst = (String)data[1];
	Debug.LogWarning("Vse2");
			// Do something
}
  }
}

public void OnEnable()
{
    PhotonNetwork.OnEventCall += OnEvent;
}

public void OnDisable()
{
    PhotonNetwork.OnEventCall -= OnEvent;
}

// [PunRPC]
// void XodikiNaCompe(){
// // if(idetfigurakvectory.z != 1 && vibranafiguranamefirst !=null){
// 	Debug.LogWarning("Vizval na kompe");		

			

// 			// if(GameObject.Find(vibranafiguranamefirst).gameObject.transform.position.x != idetfigurakvectory.x){
// 			// GameObject.Find(vibranafiguranamefirst).gameObject.transform.position = Vector3.MoveTowards(GameObject.Find(vibranafiguranamefirst).gameObject.transform.position,idetfigurakvectory,Time.deltaTime*Speed); 
// 				GameObject.Find(vibranafiguranamefirst).gameObject.transform.position = new Vector3(idetfigurakvectory.x, idetfigurakvectory.y, idetfigurakvectory.z);
// 				// GameObject.Find(vibranafiguranamefirst).gameObject.transform.position = Vector3.MoveTowards(GameObject.Find(vibranafiguranamefirst).gameObject.transform.position,idetfigurakvectory,Time.deltaTime*Speed); 
// 			// }

// 			// else if(GameObject.Find(vibranafiguranamefirst).gameObject.transform.position.x == idetfigurakvectory.x){
			
// 			// 	idetfigurakvectory = new Vector3(1,1,1);
// 			// 	vibranafiguranamefirst = null;
// 			// }
// 		// }
// 	// }
// }



// 	void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info){

//           Vector3 k = idetfigurakvectory; 
//            String i = vibranafiguranamefirst;
//            String q = vibranacellfirst;
				



//     // var moves1 = moves;
// 	// var xod1 = xod; // выбрана ли фигура для хода;
// 	// var xodincell1 = xodincell; // выбрана ли фигура с ячейкой куда она должна идти
// 	// float Speed1 = Speed;
// 	// var figureischoise1 = figureischoise; //проверка была ли ранее какая либо выбрана фигура или нет
// 	// String vibranafiguraname1 = vibranafiguranamefirst;
// 	// String vibranacellfirst1 = vibranacellfirst;
// 	// // String vibrana = choisefigure.gameObject.name;
// 	// // Debug.LogWarning(vibrana);
// 	// // String xodfigure1 = xodfigure.name; // в какую ячейку пойдет фигура
// 	// // String fromCell1 = fromCell; // с какой ячейки начинает ходить фигура
//     // bool j = fromenabled; // для string начальной ячейки
// 	// Debug.Log(j);
// 	// String inCell1 = inCell; // в какую ячейку идет фигура
// 	// bool n = inenabled; // для string конечной ячейки
// 	// int intMassivWhite1 = intMassivWhite;
// 	// int intMassivBlack1 = intMassivBlack;

// 	stream.Serialize(ref k);
// 	stream.Serialize(ref i);
// 	stream.Serialize(ref q);
// 	// 	stream.Serialize(ref Speed1);
// 	// 	stream.Serialize(ref figureischoise1);
// 	// 	stream.Serialize(ref vibranafiguraname1);
// 	// 	stream.Serialize(ref vibranacellfirst1);

// 	// 	// stream.Serialize(ref xodfigure1);
// 	// 	// stream.Serialize(ref fromCell1);
// 	// 	stream.Serialize(ref j);
// 	// 	stream.Serialize(ref inCell1);
// 	// 	stream.Serialize(ref n);
// 	// 	stream.Serialize(ref intMassivWhite1);
// 	// 	stream.Serialize(ref intMassivBlack1);
// 	// 	// stream.Serialize(ref vibrana);

// 	if(stream.isReading){

// 		 idetfigurakvectory = k; 
//            vibranafiguranamefirst = i;
//            vibranacellfirst = q;
// 	// 		moves = moves1;
// 	// 	    xod = xod1;
// 	// 	xodincell = xodincell1;
// 	// 	Speed = Speed1;
// 	// 	figureischoise = figureischoise1;
// 	// 	vibranafiguranamefirst = vibranafiguraname1;
// 	// 	vibranacellfirst = vibranacellfirst1;
// 	// 	// choisefigure.gameObject.name =  vibranafiguraname1;
// 	// 	// xodfigure = GameObject.Find(xodfigure1).gameObject;
// 	// 	// fromCell = fromCell1;
// 	// 	fromenabled = j;
// 	// 	inCell = inCell1;
// 	// 	inenabled = n;
// 	// 	intMassivWhite = intMassivWhite1;
// 	// 	intMassivBlack = intMassivBlack1;
// 	// 	}
// 	// }
// }
// 	}
}