using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopManager : MonoBehaviour
{
    public Button finished;
    public Image rdy1;
    public Image rdy2;
    public Image rdy3;
    public Image rdy4;
    Player localUser;
    List<Player> players;
    // Start is called before the first frame update
    void Start()
    {
        //Instantiating variables
        ValueStorage vs = GameObject.Find("NetworkManager").GetComponent<ValueStorage>();
        localUser = vs.getLocalPlayer();
        players = vs.GetPlayers();
        finished.onClick.AddListener(ReadyPlayer);
        for (int i = 0; i < players.Count; i++)
            players[i].IsReady(false);
        if (players.Count < 4)
            rdy4.enabled = false;
        if (players.Count < 3)
            rdy3.enabled = false;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        //Displays checks for cennected players and makes them green when ready
        if (players[0].IsReady())
            rdy1.color = Color.green; else rdy1.color = Color.black;
        if (players[1].IsReady())
            rdy2.color = Color.green; else rdy2.color = Color.black;
        if (players.Count > 2 && players[2].IsReady())
            rdy3.color = Color.green; else rdy3.color = Color.black;
        if (players.Count > 3 && players[3].IsReady())
            rdy4.color = Color.green; else rdy4.color = Color.black;

        //Checks for receipt of message
        if(localUser.GetNetStream().DataAvailable){
            //By using a loop for received, any messages that arrive too close 
            //      together are broken up to be processed separately.
            string received = localUser.Read();
            Debug.Log(received);
            string[] result = received.Split('/');
            for (int r = 0; r < result.Length; r++){
                if (result[r].CompareTo("")==0) break;
                string[] message = result[r].Split(',');

                //For recieving the ready call, meaning a player is finished shopping.
                if (message[0].CompareTo("*READY") == 0) {
                    for (int i = 0; i < players.Count; i++){
                        if (players[i] != null){
                            players[i].IsReady(false);
                            for (int j = 1; j < message.Length; j++){
                                if (players[i].GetName().CompareTo(message[j])==0)
                                    players[i].IsReady(true);
                            }
                        }
                    }
                } else if (message[0].CompareTo("*START") == 0) {
                    Debug.Log("Proceed to dungeon!");
                    SceneManager.LoadScene("Dungeon");
                }
            }
        }
    }
    void ReadyPlayer(){
        localUser.Write("*READY");
    }
}
