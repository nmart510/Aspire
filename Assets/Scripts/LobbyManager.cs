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
            ph1.enabled = false;
        }
        if (players[1] != null){
            player2.text = players[1].GetComponent<Player>().GetName();
            ph2.enabled = false;
        }
        if (players[2] != null){
            player3.text = players[2].GetComponent<Player>().GetName();
            ph3.enabled = false;
        }
        if (players[3] != null){
            player4.text = players[3].GetComponent<Player>().GetName();
            ph4.enabled = false;
        }
        //Instead of using a while loop, taking advantage of Unity's built in Update function.
        //This does, however, mean I need to include a timeout for if no message is sent.
        //Essentially, this portion is to listen for more people joining the lobby, and whether or
        //not they are ready to start. READY NOT YET IMPLEMENTED
        if(connected){
            byte[] data = new byte[256];
            try{
                string result = localUser.Read();
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
                        players[pCount].GetComponent<Player>().SetName(users[i]);
                        pCount++;
                    }
                }
            } catch(IOException e){
                //This is solely to ignore a IOException set up to occur on purpose
            }
        }
    }
    void goBack(){
        if (connected){
            localUser.Write("*EXIT");
            localUser.GetClient().Close();
        }
        GameObject[] temp = Object.FindObjectsOfType<GameObject>();
        for (int i = 0; i < temp.Length; i++){
            Destroy(temp[i]);
        }
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
