using System.Collections;
using System.Collections.Generic;
using SocketIO;
using UnityEngine;

public class NetworkMove : MonoBehaviour
{
    public SocketIOComponent socket;
    public void OnMove(Vector3 position)
    {
        PlayerPosition pPosition = new PlayerPosition();
        pPosition.x = position.x;
        pPosition.y = position.z;
        print(pPosition.x + pPosition.y);
        string json = JsonUtility.ToJson(pPosition);
        Debug.Log("Sending position to Node: " + json);
        
        GameObject.FindObjectOfType<Network>().IMove(json);
    }
}
