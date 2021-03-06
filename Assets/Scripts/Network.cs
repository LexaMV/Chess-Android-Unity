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
    int i = 0;
    public GameObject RedGO;
    public GameObject RedGOText;
    public GameObject WhiteGO;
    public GameObject Background;
    public GameObject CameraViboraXoda;
    public GameObject GameCamera;
    public GameObject CanvasViboraXoda;
    public GameObject WhiteGOText;
    public string RedGOString;
    public string WhiteGOString;

    public int VibralRed;
    public int VibralWhite;

    // public PunTurnManager turnManager;

	// Use this for initialization

	string gameVersion = "0.1"; 
	void Awake(){
        Background = GameObject.Find("Background");
        RedGO = GameObject.Find("Red");
        RedGOText = GameObject.Find("RedText");
        WhiteGO = GameObject.Find("White");
        WhiteGOText = GameObject.Find("WhiteText");
        CanvasViboraXoda = GameObject.Find("CanvasViboraXoda");
        CameraViboraXoda = GameObject.Find("CameraViboraXoda");
        GameCamera = GameObject.Find("GameCamera");
        Instance = this;
		PhotonNetwork.autoJoinLobby = false;
		PhotonNetwork.automaticallySyncScene = true;
	}
	void Start ()
    {   
        GameCamera.SetActive(false);
        Background.SetActive(false);
        RedGO.GetComponent<Button>().enabled = false;
        WhiteGO.GetComponent<Button>().enabled = false;
        // this.turnManager = this.gameObject.AddComponent<PunTurnManager>(); // �������� ���������  
        // this.turnManager.TurnManagerListener = this; // �������� ���������
        // this.turnManager.TurnDuration = 5f; // ����� �������� ����� ���������
        PhotonNetwork.ConnectUsingSettings(gameVersion); //������������
        PhotonHandler.StopFallbackSendAckThread(); // ��������� ����������
	}

    void Update(){
        
        if(RedGOString == "RedGO" &&  i == 1){
            RedGO.SetActive(false);
            RedGOText.SetActive(false);
             RedGOString = null;
             i = 0;
             
  }
        
    else if(WhiteGOString == "WhiteGO" &&  i == 1){
     WhiteGO.SetActive(false);
    WhiteGOText.SetActive(false);
    WhiteGOString = null;
    i = 0;
     Debug.LogWarning("Yes");
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
    int a = 1;
    VibralRed = 0;
    VibralWhite = 1;
    object[] content = new object[] {RedGOString, a,VibralWhite, VibralRed};
   
			//  Debug.Log(RaiseEventMassiv.Count);
	         RaiseEventOptions raiseEventOptions = new RaiseEventOptions { Receivers = ReceiverGroup.Others };
            //  PhotonNetwork.RaiseEvent(RaiseEventClient,RaiseEventMassiv,true, raiseEventOptions);
			PhotonNetwork.RaiseEvent(RedGOPlay,content,true, raiseEventOptions);
             VibralRed = 1;
    VibralWhite = 0;
              RedGOString = null;
            Background.SetActive(true);
            CanvasViboraXoda.SetActive(false);
            CameraViboraXoda.SetActive(false);
            GameCamera.SetActive(true);
            GameCamera.GetComponent<Xod>().enabled = true;
            GameCamera.GetComponent<HiddenGO>().enabled = true;
           
    }

    public void WhiteGOButton(){
          
     WhiteGOString = "WhiteGO";
     int a = 1;
     VibralWhite = 0;
     VibralRed  = 1;

     object[] content = new object[] {WhiteGOString, a, VibralWhite, VibralRed};
    
			//  Debug.Log(RaiseEventMassiv.Count);
	         RaiseEventOptions raiseEventOptions = new RaiseEventOptions { Receivers = ReceiverGroup.Others };
            //  PhotonNetwork.RaiseEvent(RaiseEventClient,RaiseEventMassiv,true, raiseEventOptions);
			PhotonNetwork.RaiseEvent(WhiteGOPlay,content,true, raiseEventOptions);
             VibralWhite = 1;
     VibralRed  = 0;
            // WhiteGO.SetActive(false);
            WhiteGOString = null;
            Background.SetActive(true);
            CanvasViboraXoda.SetActive(false);
            CameraViboraXoda.SetActive(false);
            GameCamera.SetActive(true);
            GameCamera.GetComponent<Xod>().enabled = true;
            GameCamera.GetComponent<HiddenGO>().enabled = true;
            
    }



    // public void StartTurn() //����� ������ �������(������ �� ������ ������� ����� ���� ��������)
    // {
    //     if (PhotonNetwork.isMasterClient)
    //     {
    //         Debug.LogWarning("BeginTurn");
    //         this.turnManager.BeginTurn();
    //     }
    // }
    // public void OnTurnBegins(int turn) // ����������� ����������
    // {
    //     Debug.LogWarning(turn);
    //    Figure.Instance.idetfigurakvectory = new Vector3(0,0,0);
    //    Figure.Instance.vibranafiguranamefirst = null;
	//    Figure.Instance.vibranacellfirst = null;
    // }
    // public void OnPlayerFinished(PhotonPlayer photonPlayer, int turn, object move) // ����� ����� ������ ��������� ��� � �������
    
    // {
    //     Debug.Log("OnPlayerMove: " + photonPlayer + " turn: " + turn + " action: " + move);
    //     throw new System.NotImplementedException();
    // }

    // public void OnPlayerMove(PhotonPlayer player, int turn, object move)     //����� ����� ����� �� �� �������� �������
    // {
    //     throw new System.NotImplementedException();
    // }

    

    // public void OnTurnCompleted(int turn) // ���������� ����� ������� ��������� (����������� � ���� �������)
    // {
    //     GameObject.Find(Figure.Instance.vibranafiguranamefirst).transform.position = new Vector3(Figure.Instance.idetfigurakvectory.x,Figure.Instance.idetfigurakvectory.y,Figure.Instance.idetfigurakvectory.z);
    //     OnEndTurn();
    // }

    // public void OnTurnTimeEnds(int turn)//����������, ����� ����������� ������� ��-�� ����������� �� ������� (������� ��� �������)
    // {
    //     throw new System.NotImplementedException();
    // }

//   public void OnPlayerFinished(PhotonPlayer photonPlayer, int turn, object move) // ����� ����� ������ ��������� ��� � �������
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
    i = (int)data[1];
    VibralWhite = (int)data[2];
    VibralRed = (int)data[3];
	Debug.LogWarning("RedGo");
			// Do something
	}

    if (eventCode == WhiteGOPlay){
	object[] data = (object[])content;
    WhiteGOString = (string)data[0];
    i = (int)data[1];
    VibralWhite = (int)data[2];
    VibralRed = (int)data[3];
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


