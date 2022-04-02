using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.IO;

public class LobbyManager : MonoBehaviour
{
    int port = 11011;
    public InputField IPField;
    public Text player1;
    public Text ph1;
    public Text player2;
    public Text ph2;
    public Text player3;
    public Text ph3;
    public Text player4;
    public Text ph4;
    public Button join;
    public Button back;
    public Button ready;
    public GameObject playerPrefab;
    bool connected = false;
    int pCount = 1;
    GameObject[] players = new GameObject[4];
    Player localUser;
    // Start is called before the first frame update
    void Start()
    {
        //Instantiating variables
        ValueStorage vs = GameObject.Find("NetworkManager").GetComponent<ValueStorage>();
        GameObject g = Instantiate(playerPrefab);
        localUser = g.GetComponent<Player>();
        localUser.SetName(vs.GetUsername());
        g.name = vs.GetUsername();
        players[0] = g;
        //Set listenners for the buttons
        join.onClick.AddListener(joinServer);
        back.onClick.AddListener(goBack);
        ready.onClick.AddListener(readyUp);
    }

    // Update is called once per frame
    void Update()
    {
        //Updates the lobby UI
        if (players[0] != null){
            player1.text = players[0].GetComponent<Player>().GetName();
            if (players[0].GetComponent<Player>().IsReady())
                player1.color = Color.green;
            else if (connected == false) player1.color = new Color(.4f,.4f,.4f,1);
            else player1.color = Color.black;
            ph1.enabled = false;
        } else { player1.text = ""; ph1.enabled = true; }
        if (players[1] != null){
            player2.text = players[1].GetComponent<Player>().GetName();
            if (players[1].GetComponent<Player>().IsReady())
                player2.color = Color.green;
            else player2.color = Color.black;
            ph2.enabled = false;
        } else { player2.text = ""; ph2.enabled = true; }
        if (players[2] != null){
            player3.text = players[2].GetComponent<Player>().GetName();
            if (players[2].GetComponent<Player>().IsReady())
                player3.color = Color.green;
            else player3.color = Color.black;
            ph3.enabled = false;
        } else { player3.text = ""; ph3.enabled = true; }
        if (players[3] != null){
            player4.text = players[3].GetComponent<Player>().GetName();
            if (players[3].GetComponent<Player>().IsReady())
                player4.color = Color.green;
            else player4.color = Color.black;
            ph4.enabled = false;
        } else { player4.text = ""; ph4.enabled = true; }
        //Instead of using a while loop, taking advantage of Unity's built in Update function.
        //This does, however, mean I need to include a timeout for if no message is sent.
        //Essentially, this portion is to listen for more people joining the lobby, and whether or
        //not they are ready to start. READY NOT YET IMPLEMENTED
        if(connected){
            byte[] data = new byte[256];
            try{
                string result = localUser.Read();
                Debug.Log(result);
                string[] message = result.Split(',');
                //for when a player leaves the lobby
                if (message[0].CompareTo("*LIST") == 0){
                    for (int i = 1; i < message.Length; i++){
                        bool match = false;
                        for (int j = 0; j < 4; j++){
                            if (players[j] != null)
                            if (players[j].name.CompareTo(message[i])==0){
                                match = true;
                                break;
                            }
                        }
                        if (match == false){
                            players[pCount] = Instantiate(playerPrefab);
                            players[pCount].name = message[i];
                            players[pCount].GetComponent<Player>().SetName(message[i]);
                            pCount++;
                        }
                    }
                    Debug.Log(pCount);
                } else if (message[0].CompareTo("*REMOVE") == 0) {
                    for (int i = 0; i < pCount; i++){
                        if (players[i] != null)
                        if (players[i].name.CompareTo(message[1]) == 0){
                            Destroy(players[i]);
                            players[i] = null;
                            for(int k = i; k < pCount - 1; k++){
                                if (players[k] == null && players[k+1] != null){
                                    players[k] = players[k+1];
                                    players[k+1] = null;
                                }
                            }
                        }
                    }
                    pCount--;
                    Debug.Log(pCount);
                } else if (message[0].CompareTo("*READY") == 0) {
                    for (int i = 0; i < pCount; i++){
                        if (players[i] != null){
                            players[i].GetComponent<Player>().IsReady(false);
                            for (int j = 1; j < message.Length; j++){
                                if (players[i].name.CompareTo(message[j])==0)
                                    players[i].GetComponent<Player>().IsReady(true);
                            }
                        }
                    }
                } else if (message[0].CompareTo("*START") == 0) {
                    Debug.Log("Start game!");
                    //Load scene Game
                }
            } catch(IOException e){
                //This is solely to ignore a IOException set up to occur on purpose
            }
        }
    }
    void goBack(){
        try{
            if (connected){
                localUser.Write("*EXIT");
                localUser.GetClient().Close();
            }
            GameObject[] temp = Object.FindObjectsOfType<GameObject>();
            for (int i = 0; i < temp.Length; i++){
                Destroy(temp[i]);
            }
        } catch (IOException e){}
        SceneManager.LoadScene("Main");
    }
    void joinServer(){
        if (connected == false){
            Debug.Log("Attempting connection: " + IPField.text);
            localUser.SetClient(IPField.text, port);
            localUser.GetClient().ReceiveTimeout = 100;
            localUser.Write(players[0].name);
            Debug.Log("Sent name to server");
            connected = true;
        }
    }
    void readyUp(){
        if (connected){
            localUser.Write("*READY");
        }
    }
    void startGame(){

    }
}
