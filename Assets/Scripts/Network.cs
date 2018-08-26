using System.Collections;
using System.Collections.Generic;
using Photon;
using UnityEngine;

public class Network : PunBehaviour, IPunTurnManagerCallbacks {
    public static Network Instance;
    private PunTurnManager turnManager;

	// Use this for initialization
    public int c;
	string gameVersion = "0.1"; 
	void Awake(){
        Instance = this;
		PhotonNetwork.autoJoinLobby = false;
		PhotonNetwork.automaticallySyncScene = true;
	}

    public void OnTurnBegins(int turn) // ����������� ����������
    {
       Figure.Instance.idetfigurakvectory = new Vector3(0,0,0);
       Figure.Instance.vibranafiguranamefirst = null;
	   Figure.Instance.vibranacellfirst = null;
    }
    public void OnPlayerFinished(PhotonPlayer player, int turn, object move) // ����� ����� ������ ��������� ��� � �������
    
    {
        throw new System.NotImplementedException();
    }

    public void OnPlayerMove(PhotonPlayer player, int turn, object move)     //����� ����� ����� �� �� �������� �������
    {
        throw new System.NotImplementedException();
    }

    

    public void OnTurnCompleted(int turn) // ���������� ����� ������� ��������� (����������� � ���� �������)
    {
        GameObject.Find(Figure.Instance.vibranafiguranamefirst).transform.position = new Vector3(Figure.Instance.idetfigurakvectory.x,Figure.Instance.idetfigurakvectory.y,Figure.Instance.idetfigurakvectory.z);
        OnEndTurn();
    }

    public void OnTurnTimeEnds(int turn)//����������, ����� ����������� ������� ��-�� ����������� �� ������� (������� ��� �������)
    {
        throw new System.NotImplementedException();
    }

    public void OnEndTurn()
    {
        Debug.LogWarning("The end");
    }

	void Start ()
    {
        this.turnManager = this.gameObject.AddComponent<PunTurnManager>(); // �������� ���������  
        this.turnManager.TurnManagerListener = this; // �������� ���������
        this.turnManager.TurnDuration = 5f; // ����� �������� ����� ���������
        PhotonNetwork.ConnectUsingSettings(gameVersion); //������������
        // PhotonHandler.StopFallbackSendAckThread(); // ��������� ����������
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
}
}


