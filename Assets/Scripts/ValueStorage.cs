using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValueStorage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    string username;
    public void SetUsername(string _username){
        username = _username;
    }
    public string GetUsername(){
        return username;
    }
}
