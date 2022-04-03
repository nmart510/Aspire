using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValueStorage : MonoBehaviour
{
    Player localPlayer;
    List<GameObject> playerList;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        playerList = new List<GameObject>();
    }
    string username;
    public void SetUsername(string _username){
        username = _username;
    }
    public string GetUsername(){
        return username;
    }
    public Player getLocalPlayer(){
        return localPlayer;
    }
    public void setLocalPlayer(Player p){
        localPlayer = p;
    }
    public List<GameObject> GetPlayers(){
        return playerList;
    }
    public void RecordPlayers(List<GameObject> pl){
        playerList = pl;
    }
}
