using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject playerObject;

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
    public Text winText;

    void Start(){ //pegar a posição do jogador, ter que colocar ja posições para todos os oponentes, e na pista tbm
        position = PlayerPrefs.GetInt("position", 8);
        BeginGame();
    }

    void Update(){
        if (Input.GetKey("escape")){
            Application.Quit();
        }

        Position();
    }

    void BeginGame(){

        CountDown();

        speed = 0;
        velocityText.text = speed;
  
    }

    void accelerate(){ //função de aceleração, ta funcionando, só precisa adicionar como isso vai fazer efeito com o cenario
        if(Input.GetKeyDown(UpArrow)){
            currentVelocity = currentVelocity + (accelerationRate * Time.deltaTime);
        }
        else{
            currentVelocity = currentVelocity - (decelerationRate * Time.deltaTime);
        }

        currentVelocity = Mathf.Clamp(currentVelocity, initialVelocity, finalVelocity);

        transform.Translate(0,0,power);
    }

    void CountDown(){ //contador de 3 a 0, e depois GO pra começar a corrida, coloquei ja na variavel de countdownText, pra ficar mais facil de mudar na UI

        for(int i = 0; i < countdown;i++){
            countdownText.text = i;
        }

        countdownText.text = "GO";
    }

    void Position(){
        if (playerObject.position > opponentObject.position){
            position--;
        } else if(opponentObject.position > playerObject.position){
            position++;
        }
    }

    void end(){ //função para o final da corrida, determinar se o jogador venceu ou não (ainda a programar posições)
        if(positionText <= 3){
            winText = "You Win!";
        } else if(positionText > 3){
            winText = "You Lose";
        }
    }
}