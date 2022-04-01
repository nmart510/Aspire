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
    // Start is called before the first frame update
    void Start()
    {
        ValueStorage vs = GameObject.Find("NetworkManager").GetComponent<ValueStorage>();
        GameObject g = Instantiate(playerPrefab);
        g.GetComponent<Player>().setName(vs.GetUsername());
        g.name = vs.GetUsername();
        players[0] = g;
        join.onClick.AddListener(joinServer);
        back.onClick.AddListener(goBack);
        ready.onClick.AddListener(readyUp);
    }

    // Update is called once per frame
    void Update()
    {
        if (players[0] != null){
            player1.text = players[0].GetComponent<Player>().getName();
            ph1.enabled = false;
        }
        if (players[1] != null){
            player2.text = players[1].GetComponent<Player>().getName();
            ph2.enabled = false;
        }
        if (players[2] != null){
            player3.text = players[2].GetComponent<Player>().getName();
            ph3.enabled = false;
        }
        if (players[3] != null){
            player4.text = players[3].GetComponent<Player>().getName();
            ph4.enabled = false;
        }
        //Need code to listen for messages
        if(connected){
            byte[] data = new byte[256];
            try{
                players[0].GetComponent<Player>().GetNetStream().Read(data,0,data.Length);
                string result = Encoding.ASCII.GetString(data).Trim();
                if (result.CompareTo("") != 0)
                    Debug.Log(result);
                string[] users = result.Split(',');
                for (int i = 0; i < users.Length; i ++){
                    bool match = false;
                    for (int j = 0; j < 4; j++){
                        if (players[j] != null)
                        if (players[j].name.CompareTo(users[i])==0){
                            match = true;
                            break;
                        }
                    }
                    if (match == false){
                        players[pCount] = Instantiate(playerPrefab);
                        players[pCount].name = users[i];
                        players[pCount].GetComponent<Player>().setName(users[i]);
                        pCount++;
                    }
                }
            } catch(IOException e){
                //This is solely to ignore a IOException set up to occur on purpose
            }
        }
    }
    void goBack(){
        GameObject[] temp = Object.FindObjectsOfType<GameObject>();
        for (int i = 0; i < temp.Length; i++){
            Destroy(temp[i]);
        }
        SceneManager.LoadScene("Main");
    }
    void joinServer(){
        if (connected == false){
            Debug.Log("Attempting connection: " + IPField.text);
            players[0].GetComponent<Player>().setClient(IPField.text, port);
            players[0].GetComponent<Player>().GetClient().ReceiveTimeout = 100;
            byte[] data = System.Text.Encoding.ASCII.GetBytes(players[0].name);
            players[0].GetComponent<Player>().GetNetStream().Write(data,0,data.Length);
            Debug.Log("Sent name to server");
            connected = true;
        }
    }
    void readyUp(){

    }
    void startGame(){

    }
}
