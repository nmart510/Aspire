using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossManager : MonoBehaviour
{
    ValueStorage vs;
    Player localUser;
    List<Player> players;
    // Start is called before the first frame update
    void Start(){
        //Instantiating variables
        vs = GameObject.Find("NetworkManager").GetComponent<ValueStorage>();
        localUser = vs.getLocalPlayer();
        players = vs.GetPlayers();
        localUser.Write("*SETUP");
    }
    // Update is called once per frame
    void Update(){
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
                if (message[0].CompareTo("*ENDOFDAY") == 0) {
                    foreach (Player p in players) p.setHealth(p.getHealth()[1]);
                    localUser.Write("*SETUP");
                }
                if (message[0].CompareTo("*DUNGEON") == 0) {
                    vs.isInitialShop(false);
                    Debug.Log("Proceed to dungeon!");
                    SceneManager.LoadScene("Dungeon");
                }
            }
        }
    }
}
