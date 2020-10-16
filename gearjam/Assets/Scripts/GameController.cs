using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private int position;
    private int speed;
    private float power = 500.0;
    private int countdown = 3;

    private float initialVelocity = 0.0;
    private float finalVelocity = 500.0;
    private float currentVelocity = 0.0;
    private float accelerationRate = 10.0;
    private float decelerationRate = 50.0;

    public Text velocityText;
    public Text positionText;
    public Text countdownText;

    void Start(){
        position = PlayerPrefs.GetInt("position", 8);
        BeginGame();
    }

    void Update(){
        if (Input.GetKey("escape"))
            Application.Quit();
    }

    void BeginGame(){

        CountDown();

        speed = 0;
        velocityText.text = speed;
  
    }

    void accelerate(){
        if(Input.GetKeyDown(UpArrow)){
            currentVelocity = currentVelocity + (accelerationRate * Time.deltaTime);
        }
        else{
            currentVelocity = currentVelocity - (decelerationRate * Time.deltaTime);
        }

        currentVelocity = Mathf.Clamp(currentVelocity, initialVelocity, finalVelocity);

        transform.Translate(0,0,power);
    }

    void CountDown(){

        for(int i = 0; i < countdown;i++){
            countdownText.text = i;
        }

        countdownText.text = "GO";
    }

    
}