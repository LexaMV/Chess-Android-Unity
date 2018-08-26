using System.Collections;
using System.Collections.Generic;
using Photon;
using UnityEngine;


public class Turn : PunBehaviour,IPunTurnManagerCallbacks {
    
	private PunTurnManager turnManager;
	
    public void OnPlayerFinished(PhotonPlayer player, int turn, object move) // когда игрок делает послдений шаг в очереди
    
    {
        throw new System.NotImplementedException();
    }

    public void OnPlayerMove(PhotonPlayer player, int turn, object move)     //когда игрок ходит но не заершает очередь
    {
        throw new System.NotImplementedException();
    }

    public void OnTurnBegins(int turn) // Мероприятие начинается
    {
        throw new System.NotImplementedException();
    }

    public void OnTurnCompleted(int turn) // Вызывается когда очередь завершена (завершается у всех игроков)
    {
        throw new System.NotImplementedException();
    }

    public void OnTurnTimeEnds(int turn)//Вызывается, когда завершается очередь из-за ограничения по времени (таймаут для очереди)
    {
        throw new System.NotImplementedException();
    }

    // Use this for initialization

    void Awake(){
		PhotonNetwork.autoJoinLobby = false;
		PhotonNetwork.automaticallySyncScene = true;
	}
    
    void Start () {
		this.turnManager = this.gameObject.AddComponent<PunTurnManager>(); // добавили компанент
        this.turnManager.TurnManagerListener = this; // добавили слушетеля
        this.turnManager.TurnDuration = 5f; // время ожидания между очередями
        PhotonNetwork.ConnectUsingSettings(null); //подключаемся
        PhotonHandler.StopFallbackSendAckThread(); // заморозил соединение
        }
	
	
	// Update is called once per frame
	void Update () {
		
	}
}
