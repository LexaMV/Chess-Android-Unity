using System.Collections;
using System.Collections.Generic;
using Photon;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// public class Network : PunBehaviour, IPunTurnManagerCallbacks {
public class Network : PunBehaviour {
    private readonly byte RedGOPlay = 0;
    private readonly byte WhiteGOPlay = 0;
    public static Network Instance;

    public GameObject RedGO;
    public GameObject RedGOText;
    public GameObject WhiteGO;
    public GameObject WhiteGOText;
    public string RedGOString;
    public string WhiteGOString;

    // public PunTurnManager turnManager;

	// Use this for initialization

	string gameVersion = "0.1"; 
	void Awake(){
        RedGO = GameObject.Find("Red");
        RedGOText = GameObject.Find("RedText");
        WhiteGO = GameObject.Find("White");
        WhiteGOText = GameObject.Find("WhiteText");
        Instance = this;
		PhotonNetwork.autoJoinLobby = false;
		PhotonNetwork.automaticallySyncScene = true;
	}
	void Start ()
    {     
        RedGO.GetComponent<Button>().enabled = false;
        WhiteGO.GetComponent<Button>().enabled = false;
        // this.turnManager = this.gameObject.AddComponent<PunTurnManager>(); // добавили компанент  
        // this.turnManager.TurnManagerListener = this; // добавили слушетел€
        // this.turnManager.TurnDuration = 5f; // врем€ ожидани€ между очеред€ми
        PhotonNetwork.ConnectUsingSettings(gameVersion); //подключаемс€
        PhotonHandler.StopFallbackSendAckThread(); // заморозил соединение
	}

    void Update(){
        
        if(RedGOString == "RedGO"){
            RedGO.SetActive(false);
            RedGOText.SetActive(false);
            RedGOString = null;
        }
        
        else if(WhiteGOString == "WhiteGO"){
            WhiteGO.SetActive(false);
            WhiteGOText.SetActive(false);
            Debug.LogWarning("Yes");
            
            WhiteGOString = null;
        }
    }
    public virtual void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    public virtual void OnJoinedLobby()
    {
        
         PhotonNetwork.JoinOrCreateRoom("test", new RoomOptions(), TypedLobby.Default);
    }

    public void OnJoinedRoom()
    {
             RedGO.GetComponent<Button>().enabled = true;
             WhiteGO.GetComponent<Button>().enabled = true;
    //      {

    //     // if (PhotonNetwork.room.PlayerCount != 2)
    //     // {
    //     //      Debug.LogWarning("yes1");
    //     //     if (this.turnManager.Turn == 0)
    //     //     {
    //     //         // when the room has two players, start the first turn (later on, joining players won't trigger a turn)
    //     //         this.StartTurn();
    //     //     }
    //     // }
    //     // else
    //     // {
    //     //     Debug.Log("Waiting for another player");
    //     // }
    // }
    }

    public void RedGOButton(){
        
    RedGOString = "RedGO";
    object[] content = new object[] {RedGOString};
			//  Debug.Log(RaiseEventMassiv.Count);
	         RaiseEventOptions raiseEventOptions = new RaiseEventOptions { Receivers = ReceiverGroup.Others };
            //  PhotonNetwork.RaiseEvent(RaiseEventClient,RaiseEventMassiv,true, raiseEventOptions);
			PhotonNetwork.RaiseEvent(RedGOPlay,content,true, raiseEventOptions);
            // SceneManager.LoadScene("2");
    }

    public void WhiteGOButton(){
          
     WhiteGOString = "WhiteGO";
    object[] content = new object[] {WhiteGOString};
			//  Debug.Log(RaiseEventMassiv.Count);
	         RaiseEventOptions raiseEventOptions = new RaiseEventOptions { Receivers = ReceiverGroup.Others };
            //  PhotonNetwork.RaiseEvent(RaiseEventClient,RaiseEventMassiv,true, raiseEventOptions);
			PhotonNetwork.RaiseEvent(WhiteGOPlay,content,true, raiseEventOptions);
            // WhiteGO.SetActive(false);
    // SceneManager.LoadScene("2");
    }



    // public void StartTurn() //¬ызов старта очереди(только на мастер клиенте может быть запущено)
    // {
    //     if (PhotonNetwork.isMasterClient)
    //     {
    //         Debug.LogWarning("BeginTurn");
    //         this.turnManager.BeginTurn();
    //     }
    // }
    // public void OnTurnBegins(int turn) // ћеропри€тие начинаетс€
    // {
    //     Debug.LogWarning(turn);
    //    Figure.Instance.idetfigurakvectory = new Vector3(0,0,0);
    //    Figure.Instance.vibranafiguranamefirst = null;
	//    Figure.Instance.vibranacellfirst = null;
    // }
    // public void OnPlayerFinished(PhotonPlayer photonPlayer, int turn, object move) // когда игрок делает послдений шаг в очереди
    
    // {
    //     Debug.Log("OnPlayerMove: " + photonPlayer + " turn: " + turn + " action: " + move);
    //     throw new System.NotImplementedException();
    // }

    // public void OnPlayerMove(PhotonPlayer player, int turn, object move)     //когда игрок ходит но не заершает очередь
    // {
    //     throw new System.NotImplementedException();
    // }

    

    // public void OnTurnCompleted(int turn) // ¬ызываетс€ когда очередь завершена (завершаетс€ у всех игроков)
    // {
    //     GameObject.Find(Figure.Instance.vibranafiguranamefirst).transform.position = new Vector3(Figure.Instance.idetfigurakvectory.x,Figure.Instance.idetfigurakvectory.y,Figure.Instance.idetfigurakvectory.z);
    //     OnEndTurn();
    // }

    // public void OnTurnTimeEnds(int turn)//¬ызываетс€, когда завершаетс€ очередь из-за ограничени€ по времени (таймаут дл€ очереди)
    // {
    //     throw new System.NotImplementedException();
    // }

//   public void OnPlayerFinished(PhotonPlayer photonPlayer, int turn, object move) // когда игрок делает послдений шаг в очереди
//     {
//         Debug.Log("OnTurnFinished: " + photonPlayer + " turn: " + turn + " action: " + move);

//         if (photonPlayer.IsLocal)
//         {
//             this.localSelection = (Hand)(byte)move;
//         }
//         else
//         {
//             this.remoteSelection = (Hand)(byte)move;
//         }
//     }

    // public void OnEndTurn()
    // {
    //     Debug.LogWarning("The end");
    //     this.StartTurn();
    // }







//  public void OnJoinedRoom()
//   {
     
//  PhotonPlayer[] igrokov = PhotonNetwork.playerList;
    
// if(igrokov.Length == 1){
// GameObject.Find("Camera").GetComponent<HiddenGO>().enabled = true;
// //     int c = gameObject.GetComponent<PhotonView>().viewID;
    

// //     photonView.RPC("MasterRPC",PhotonTargets.All,c);
    
// }

// else if(igrokov.Length == 2){
//     // PhotonNetwork.LoadLevel(0);
// GameObject.Find("Camera").GetComponent<HiddenGO>().enabled = true;
//     // PhotonView photonView = PhotonView.Get(this);
    
//     // GameObject.Find("Camera").GetComponent<Figure>().enabled = true;
// }
// }


	public void OnEvent(byte eventCode, object content, int senderId)
{
	
    if (eventCode == RedGOPlay){
		object[] data = (object[])content;
    RedGOString = (string)data[0];
	Debug.LogWarning("RedGo");
			// Do something
	}

    if (eventCode == WhiteGOPlay){
	object[] data = (object[])content;
    WhiteGOString = (string)data[0];
	Debug.LogWarning("WhiteGo");
			// Do something
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


}


