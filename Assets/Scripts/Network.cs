using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;

public class Network : MonoBehaviour
{
    private static SocketIOComponent socket;

    public GameObject playerPrefab;
    // Start is called before the first frame update
    void Start()
    {
        socket = GetComponent<SocketIOComponent>();
        socket.On("open", OnConnected);
        socket.On("spawn", OnSpawned);
        socket.On("move", OnMove);
    }

    private void OnSpawned(SocketIOEvent e)
    {
        Debug.Log("spawned");
        Instantiate(playerPrefab);
    }

    private void OnConnected(SocketIOEvent e)
    {
        Debug.Log("connected");
        
        PlayerPosition pPosition = new PlayerPosition();
        pPosition.x = 1f;
        pPosition.y = 2f;
        string json = JsonUtility.ToJson(pPosition);
        
        socket.Emit("move", new JSONObject(json));
    }

    public void IMove(string json)
    {
        socket.Emit("move", new JSONObject(json));
    }
    void OnMove(SocketIOEvent e)
    {
        Debug.Log("player is moving " + e.data);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
