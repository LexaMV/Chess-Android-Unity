using System.Collections;
using System.Collections.Generic;
using Photon;
using UnityEngine;

// public class Network : PunBehaviour, IPunTurnManagerCallbacks {
    public class Network : PunBehaviour {
    public static Network Instance;
    // public PunTurnManager turnManager;

	// Use this for initialization
    public int c;
	string gameVersion = "0.1"; 
	void Awake(){
        Instance = this;
		PhotonNetwork.autoJoinLobby = false;
		PhotonNetwork.automaticallySyncScene = true;
	}
	void Start ()
    {
        // this.turnManager = this.gameObject.AddComponent<PunTurnManager>(); // �������� ���������  
        // this.turnManager.TurnManagerListener = this; // �������� ���������
        // this.turnManager.TurnDuration = 5f; // ����� �������� ����� ���������
        PhotonNetwork.ConnectUsingSettings(gameVersion); //������������
        PhotonHandler.StopFallbackSendAckThread(); // ��������� ����������
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



}


