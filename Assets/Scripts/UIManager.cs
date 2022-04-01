using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public Button exit;
    public Button join;
    public GameObject networkManager;
    public InputField username;
    void Start()
    {
        join.onClick.AddListener(JoinOnClick);
        exit.onClick.AddListener(ExitOnClick);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void ExitOnClick(){
        Application.Quit();
    }
    void JoinOnClick(){
        if (username.text !=""){
            networkManager.GetComponent<ValueStorage>().SetUsername(username.text);
            SceneManager.LoadScene("Lobby");
        }
    }
}
