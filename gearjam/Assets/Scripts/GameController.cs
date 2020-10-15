using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private int position;
    private int speed;

    public Text velocityText;
    public Text positionText;

    void Start(){
        position = PlayerPrefs.GetInt("position", 8);
        BeginGame();
    }

    void Update(){
        if (Input.GetKey("escape"))
            Application.Quit();
    }

    void BeginGame(){
        speed = 0;

        velocityText.text = speed;
    }
}