using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    ValueStorage vs;
    Player localUser;
    List<Player> players;
    public Text txtScore1, txtScore2, txtScore3, txtScore4;
    public Button btnMain, btnExit;
    // Start is called before the first frame update
    void Start()
    {
                //Instantiating variables
        vs = GameObject.Find("NetworkManager").GetComponent<ValueStorage>();
        localUser = vs.getLocalPlayer();
        players = vs.GetPlayers();

        btnExit.onClick.AddListener(delegate{Application.Quit();});
        btnMain.onClick.AddListener(delegate{SceneManager.LoadScene("Main");});
        localUser.Write("*SCORE,"+localUser.getVP());
    }

    // Update is called once per frame
    void Update()
    {
        if(localUser.GetNetStream().DataAvailable){
            //By using a loop for received, any messages that arrive too close 
            //      together are broken up to be processed separately.
            string received = localUser.Read();
            Debug.Log(received);
            string[] result = received.Split('/');
            for (int r = 0; r < result.Length; r++){
                if (result[r].CompareTo("")==0) break;
                string[] message = result[r].Split(',');
                if (message[0].CompareTo("*SCORE")==0){
                    foreach (Player p in players){
                        for (int m = 1; m < message.Length; m++){
                            if (message[m].Split(':')[0].CompareTo(p.GetName())==0){
                                int.TryParse(message[1], out int score);
                                p.setVP(score);
                            }
                        }
                    }
                    DisplayScores();
                }

            }
        }
    }
    void DisplayScores(){
        List<Player> temp = new List<Player>();
        List<Player> order = new List<Player>();
        foreach (Player p in players){
            temp.Add(p);
        }
        while(temp.Count > 0){
            int score = -1;
            Player top = null;
            foreach (Player t in temp){
                if (t.getVP() > score) {
                    score = t.getVP();
                    top = t;
                }
            }
            order.Add(top);
            temp.Remove(top);
        }
        txtScore1.text = order[0].GetName()+": "+order[0].getVP();
        if (order[0]==localUser) txtScore1.color = Color.green;
        txtScore2.text = order[1].GetName()+": "+order[1].getVP();
        if (order[1]==localUser) txtScore2.color = Color.green;
        if (order.Count >= 3){            
            txtScore3.text = order[2].GetName()+": "+order[2].getVP();
            if (order[2]==localUser) txtScore3.color = Color.green;
        }
        if (order.Count >= 4){            
            txtScore4.text = order[3].GetName()+": "+order[3].getVP();
            if (order[3]==localUser) txtScore4.color = Color.green;
        }
    }
}
