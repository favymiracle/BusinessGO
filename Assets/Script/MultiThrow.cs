using System.Collections.Generic;
using UnityEngine;

using ExitGames.Client.Photon;
using Photon.Realtime;
using Photon.Pun.UtilityScripts;
namespace Photon.Pun.Demo.Asteroids
{
    public class MultiThrow : MonoBehaviour
    {
        public static bool ClientFuc = false;
        public static bool IsPause = false;
        public List<GameObject> Dice = new List<GameObject>();
        // Start is called before the first frame update
        void Start()
        {
            if (PhotonNetwork.IsMasterClient){
                First[] Die = FindObjectsOfType<First>();
                for (int i = 0; i <= (Die.Length - 1); i++)
                {
                    Dice.Add(Die[i].gameObject);
                }
            }
        }

        // Update is called once per frame
        void Update()
        {
            if ((!PhotonNetwork.IsMasterClient) && (Dice.Count != 2)) {
                First[] Die = FindObjectsOfType<First>();
                for (int i = 0; i <= (Die.Length - 1); i++)
                {
                    Dice.Add(Die[i].gameObject);
                }
            }
            if (ClientFuc) {
                ComThrowDieButton();
                ClientFuc = false;
            }
        }

        public void ThrowDieButton()
        {
            if ((MultiScore.MyTurn) && (MultiScore.ThrowEnd))
            {
                ThrowDie();
                MultiScore.MyTurn = false;
                MultiScore.ThrowEnd = false;

                Hashtable ChangePros = new Hashtable() {
                    { AsteroidsGame.ROOM_TURN,  false},
                    { AsteroidsGame.ROOM_THROW_END, false},
                    { AsteroidsGame.ROOM_COUNT, 0},
                };
                PhotonNetwork.CurrentRoom.SetCustomProperties(ChangePros);
                Hashtable ChangePros1 = new Hashtable() {
                    { AsteroidsGame.CLIENT_FUC,  false}
                };
                PhotonNetwork.CurrentRoom.SetCustomProperties(ChangePros);
            }
        }
        public void RPCCall()
        {
            Hashtable ChangePros = new Hashtable() {
                    { AsteroidsGame.CLIENT_FUC,  true}
                };
            PhotonNetwork.CurrentRoom.SetCustomProperties(ChangePros);
        }
        public void ComThrowDieButton()
        {
            if ((!MultiScore.MyTurn) && (MultiScore.ThrowEnd))
            {
                ThrowDie();
                MultiScore.MyTurn = true;
                MultiScore.ThrowEnd = false;

                Hashtable ChangePros = new Hashtable() {
                    { AsteroidsGame.ROOM_TURN,  true},
                    { AsteroidsGame.ROOM_THROW_END, false},
                    { AsteroidsGame.ROOM_COUNT, 0}
                };
                PhotonNetwork.CurrentRoom.SetCustomProperties(ChangePros);
                Debug.Log("Here");
            }
        }

        
        public void ThrowDie()
        {
            MultiScore.Count = 0;
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
}
