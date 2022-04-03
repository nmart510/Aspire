using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class ShopManager : MonoBehaviour
{
    public Button finished;
    public Image rdy1;
    public Image rdy2;
    public Image rdy3;
    public Image rdy4;
    Player localUser;
    List<GameObject> players;
    // Start is called before the first frame update
    void Start()
    {
        //Instantiating variables
        ValueStorage vs = GameObject.Find("NetworkManager").GetComponent<ValueStorage>();
        localUser = vs.getLocalPlayer();
        players = vs.GetPlayers();
        finished.onClick.AddListener(ReadyPlayer);
        if (players.Count < 4)
            rdy4.enabled = false;
        if (players.Count < 3)
            rdy3.enabled = false;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        //Displays checks for cennected players and makes them green when ready
        if (players[0].GetComponent<Player>().IsReady())
            rdy1.color = Color.green; else rdy1.color = Color.black;
        if (players[1].GetComponent<Player>().IsReady())
            rdy2.color = Color.green; else rdy2.color = Color.black;
        if (players.Count > 2 && players[2].GetComponent<Player>().IsReady())
            rdy3.color = Color.green; else rdy3.color = Color.black;
        if (players.Count > 3 && players[3].GetComponent<Player>().IsReady())
            rdy4.color = Color.green; else rdy4.color = Color.black;

        //Checks for receipt of message
        byte[] data = new byte[256];
        try{
            string result = localUser.Read();
            Debug.Log(result);
            string[] message = result.Split(',');

            //For recieving the ready call, meaning a player is finished shopping.
            if (message[0].CompareTo("*READY") == 0) {
                for (int i = 0; i < players.Count; i++){
                    if (players[i] != null){
                        players[i].GetComponent<Player>().IsReady(false);
                        for (int j = 1; j < message.Length; j++){
                            if (players[i].name.CompareTo(message[j])==0)
                                players[i].GetComponent<Player>().IsReady(true);
                        }
                    }
                }
            } else if (message[0].CompareTo("*START") == 0) {
                Debug.Log("Proceed to dungeon!");
                SceneManager.LoadScene("Dungeon");
            }


        } catch(IOException e){
            //This is solely to ignore a IOException set up to occur on purpose
        }
    }
    void ReadyPlayer(){

    }
}
