using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowDice : MonoBehaviour
{
    public GameObject[] Dice;

    public static bool IsPause = false;
    // Start is called before the first frame update
    void Start()
    {
        ComThrowDieButton();
    }

    // Update is called once per frame
    void Update()
    {
        ComThrowDieButton();
    }

    public void ThrowDieButton() {
        if ((Score.MyTurn) && (Score.ThrowEnd) && (!IsPause))
        {
            ThrowDie();
            Score.MyTurn = false;
            Score.ThrowEnd = false;
        }
    }   
    public void ComThrowDieButton() {
        if ((!Score.MyTurn) && (Score.ThrowEnd) && (!IsPause))
        {
            ThrowDie();
            Score.MyTurn = true;
            Score.ThrowEnd = false;
        }
    }
    public void ThrowDie() {
        Score.Count = 0;
        int RArrow = Random.Range(1, 5);
        switch (RArrow)
        {
            case 1:
                Dice[0].GetComponent<Rigidbody>().AddForce(new Vector3(0, 0.5f, 1) * 1000);
                Dice[1].GetComponent<Rigidbody>().AddForce(new Vector3(0, 0.5f, 1) * 1000);
                break;
            case 2:
                Dice[0].GetComponent<Rigidbody>().AddForce(new Vector3(0, 0.5f, -1) * 1000);
                Dice[1].GetComponent<Rigidbody>().AddForce(new Vector3(0, 0.5f, -1) * 1000);
                break;
            case 3:
                Dice[0].GetComponent<Rigidbody>().AddForce(new Vector3(1, 0.5f, 0) * 1000);
                Dice[1].GetComponent<Rigidbody>().AddForce(new Vector3(1, 0.5f, 0) * 1000);
                break;
            case 4:
                Dice[0].GetComponent<Rigidbody>().AddForce(new Vector3(-1, 0.5f, 0) * 1000);
                Dice[1].GetComponent<Rigidbody>().AddForce(new Vector3(-1, 0.5f, 0) * 1000);
                break;
            default:
                break;
        }
    }
}
