using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    GameManager instance;
    // Start is called before the first frame update
    void Start()
    {
        if(instance == null){
            instance = this;
        } else{
            Debug.LogWarning($"Two instances of {this.GetType().Name}, destroying this one", this);
            Destroy(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
