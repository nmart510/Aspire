using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;

public class Player : MonoBehaviour
{
    string username;
    TcpClient client;
    NetworkStream stream;
    byte[] data;

    public string getName(){
        return username;
    }
    public void setName(string _name){
        username = _name;
    }
    void Awake(){
        DontDestroyOnLoad(transform.gameObject);
    }
    public void setClient(string ip, int port){
        client = new TcpClient(ip, port);
        stream = client.GetStream();
    }
    public TcpClient GetClient(){
        return client;
    }
    public NetworkStream GetNetStream(){
        return stream;
    }
}
