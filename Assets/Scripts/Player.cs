using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.Text;

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
    public void Write(string message){
            byte[] data = System.Text.Encoding.ASCII.GetBytes(message);
            stream.Write(data,0,data.Length);
    }
    public string Read(){
        byte[] data = new byte[256];
        stream.Read(data,0,data.Length);
        return Encoding.ASCII.GetString(data).Trim();
    }
}
