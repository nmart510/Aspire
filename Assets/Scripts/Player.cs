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
    bool ready = false;
    int maxHP = 8;
    int currentHP = 8;
    int gold = 7;
    int victoryPoints = 0;
    List<Equipment> arsenal = new List<Equipment>();
    List<Ability> deck = new List<Ability>();
    List<Ability> hand = new List<Ability>();
    List<Ability> discard = new List<Ability>();
    List<Ability> defenses = new List<Ability>();
    List<Ability> inPlay = new List<Ability>();
    Equipment equipBody = null;
    Equipment equipMain = null;
    Equipment equipOff = null;
    Equipment equipExtra = null;
    Equipment aux1 = null;
    Equipment aux2 = null;
    Equipment aux3 = null;


    public string GetName(){
        return username;
    }
    public void SetName(string _name){
        username = _name;
    }
    void Awake(){
        DontDestroyOnLoad(transform.gameObject);
    }
    public void SetClient(string ip, int port){
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
    public bool IsReady(){
        return ready;
    }
    public void IsReady(bool _ready){
        ready = _ready;
    }
    public int[] getHealth(){
        int[] hp = new int[2];
        hp[0] = currentHP; hp[1] = maxHP; 
        return hp;
    }
    public void takeDamage(int amount){
        currentHP -= amount;
        if (currentHP < 0) currentHP = 0;
    }
}
