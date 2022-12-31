using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;


using ExitGames.Client.Photon;
using Photon.Realtime;
using Photon.Pun.UtilityScripts;
namespace Photon.Pun.Demo.Asteroids
{
    public class MultiScore : MonoBehaviourPunCallbacks
    {
        private int Num1 = 0;
        private int Num2 = 0;

        private int Sum1 = 0;
        private int Sum1TMP = 0;

        private int Sum2 = 0;
        private int Sum2TMP = 0;
        [SerializeField]
        public bool StartCount = false;
        public static int Count = 0;

        public Text Mytxt;
        public Text Comtxt;
        public Text MTurn;
        public Text CTurn;

        public Text MPoint;
        public Text CPoint;

        public GameObject Menu;
        public GameObject Pause;
        public GameObject Win;
        public GameObject Lose;

        [SerializeField]
        public static bool MyTurn = true;
        [SerializeField]
        public static bool ThrowEnd = true;

        private bool Initial = true;

        public static bool IsThrow = false;

        public Button[] ThrowBTN = new Button[2];

        private int MeTurn = 3;
        private int ComTurn = 3;

        public Button StartBTN;
        // Start is called before the first frame update
        void Start()
        {
            if (PhotonNetwork.IsMasterClient)
            {
                PhotonNetwork.InstantiateRoomObject("Die1", new Vector3(0.0f, 5f, 0.0f), Quaternion.identity);
                PhotonNetwork.InstantiateRoomObject("Die2", new Vector3(0.0f, 4.65f, 1.96f), Quaternion.identity);
                ThrowBTN[1].gameObject.SetActive(false);
            }
            else {
                ThrowBTN[0].gameObject.SetActive(false);
            }
        }

        // Update is called once per frame
        void Update()
        {
            //Debug.Log(Sum1 + Sum2);
        }

        private void OnTriggerEnter(Collider other)
        {

        }
        private void OnTriggerStay(Collider other)
        {
            if (other.transform.parent)
            {
                if (other.transform.parent.name == "Die1(Clone)")
                {
                    Num1 = int.Parse(other.gameObject.name);
                    switch (Num1)
                    {
                        case 1:
                            Sum1 = 6;
                            break;
                        case 2:
                            Sum1 = 5;
                            break;
                        case 3:
                            Sum1 = 4;
                            break;
                        case 4:
                            Sum1 = 3;
                            break;
                        case 5:
                            Sum1 = 2;
                            break;
                        case 6:
                            Sum1 = 1;
                            break;
                        default:
                            break;
                    }
                }
                if (other.transform.parent.name == "Die2(Clone)")
                {
                    Num2 = int.Parse(other.gameObject.name);
                    switch (Num2)
                    {
                        case 1:
                            Sum2 = 6;
                            break;
                        case 2:
                            Sum2 = 5;
                            break;
                        case 3:
                            Sum2 = 4;
                            break;
                        case 4:
                            Sum2 = 3;
                            break;
                        case 5:
                            Sum2 = 2;
                            break;
                        case 6:
                            Sum2 = 1;
                            break;
                        default:
                            break;
                    }
                }
            }
//             Debug.Log(Sum1 + ":" + Sum2);
//             Debug.Log(Sum1 + Sum2);
            if ((Sum1 == Sum1TMP) && (Sum2 == Sum2TMP))
            {
                StartCount = true;
            }
            else
            {
                StartCount = false;
                Count = 0;
            }
            if (StartCount == true)
            {
                Count++;
                if (Count > 300)
                {
                    if (Initial == true)
                    {
                        Initial = false;
                    }
                    else
                    {
                        if ((!MyTurn) && (!ThrowEnd))
                        {
                            //Mytxt.text = "Score\n" + (Sum1 + Sum2).ToString();
                            EffectSound();
                            if (MeTurn == 0)
                            {
                                SetInvisible();
                                Menu.SetActive(true);
                                if (PhotonNetwork.IsMasterClient)
                                {
                                    Lose.SetActive(true);
                                }
                                else {
                                    Win.SetActive(true);
                                }
                                MultiThrow.IsPause = true;
                                StartBTN.enabled = false;
                            }
                            if (int.Parse(MPoint.text) >= 2000)
                            {
                                SetInvisible();
                                Menu.SetActive(true);
                                if (PhotonNetwork.IsMasterClient)
                                {
                                    Win.SetActive(true);
                                }
                                else {
                                    Lose.SetActive(true);
                                }
                                MultiThrow.IsPause = true;
                                StartBTN.enabled = false;
                            }
                            MTurn.text = MeTurn.ToString();
                            ThrowEnd = true;
                        }
                        else if ((MyTurn) && (!ThrowEnd))
                        {
                            //Comtxt.text = "Score\n" + (Sum1 + Sum2).ToString();
                            EffectSound();
                            if (ComTurn == 0)
                            {
                                SetInvisible();
                                Menu.SetActive(true);
                                if (PhotonNetwork.IsMasterClient)
                                {
                                    Win.SetActive(true);
                                }
                                else {
                                    Lose.SetActive(false);
                                }
                                MultiThrow.IsPause = true;
                                StartBTN.enabled = false;
                            }
                            if (int.Parse(CPoint.text) >= 2000)
                            {
                                SetInvisible();
                                Menu.SetActive(true);
                                if (PhotonNetwork.IsMasterClient)
                                {
                                    Lose.SetActive(true);
                                }
                                else {
                                    Win.SetActive(true);
                                }
                                MultiThrow.IsPause = true;
                                StartBTN.enabled = false;
                            }
                            CTurn.text = ComTurn.ToString();
                            ThrowEnd = true;
                        }
                        Count = 0;
                    }
                }
            }
            Sum1TMP = Sum1;
            Sum2TMP = Sum2;
        }
        private void OnTriggerExit(Collider other)
        {
            //         if (other.transform.parent) {
            //             if (other.transform.parent.name == "Die1")
            //             {
            //                 Num1 = 0;
            //                 Sum1 = 0;
            //             }
            //             else if (other.transform.parent.name == "Die2") {
            //                 Num2 = 0;
            //                 Sum2 = 0;
            //             }
            //         }
        }

        private void EffectSound()
        {
            if ((Sum1 + Sum2) % 2 == 1)
            {
                SetTxt(MyTurn, "ODD");
            }
            if ((Sum1 + Sum2) % 2 == 0)
            {
                if (Sum1 == Sum2)
                {
                    SetTxt(MyTurn, "DUBLET");
                }
                else
                {
                    SetTxt(MyTurn, "EVEN");
                }
            }
        }

        private void SetTxt(bool turn, string txt)
        {
            if (!turn)
            {
                Mytxt.text = txt;
                switch (txt)
                {
                    case "ODD":
                        MPoint.text = (int.Parse(MPoint.text) + 200).ToString();
                        MeTurn--;
                        break;
                    case "EVEN":
                        MPoint.text = (int.Parse(MPoint.text) + 300).ToString();
                        break;
                    case "DUBLET":
                        MPoint.text = (int.Parse(MPoint.text) + 500).ToString();
                        break;
                }
            }
            else
            {
                Comtxt.text = txt;
                switch (txt)
                {
                    case "ODD":
                        CPoint.text = (int.Parse(CPoint.text) + 200).ToString();
                        ComTurn--;
                        break;
                    case "EVEN":
                        CPoint.text = (int.Parse(CPoint.text) + 300).ToString();
                        break;
                    case "DUBLET":
                        CPoint.text = (int.Parse(CPoint.text) + 500).ToString();
                        break;
                }
            }
        }

        public void Replay()
        {
            Sum1 = 0;
            Sum1TMP = 0;
            Sum2 = 0;
            Sum2TMP = 0;
            StartCount = false;
            Count = 0;
            Mytxt.text = "ODD";
            Comtxt.text = "ODD";
            MPoint.text = "0";
            MPoint.text = "0";
            MTurn.text = "3";
            CTurn.text = "3";
            MyTurn = true;
            ThrowEnd = true;
            Initial = true;
            IsThrow = false;
            MeTurn = 3;
            ComTurn = 3;
            Menu.SetActive(false);
            MultiThrow.IsPause = false;
        }

        private void SetInvisible()
        {
            Menu.SetActive(false);
            Pause.SetActive(false);
            Win.SetActive(false);
            Lose.SetActive(false);
        }

        public void MenuButton()
        {
            SceneManager.LoadScene("Loading");
            Loadding.NextScene = "Start";
        }

        public void PlayButton()
        {
            Menu.SetActive(false);
            MultiThrow.IsPause = false;
            StartBTN.enabled = true;
        }

        public void PauseButton()
        {
            SetInvisible();
            Menu.SetActive(true);
            Pause.SetActive(true);
            MultiThrow.IsPause = true;
            //PauseSet(true);
        }

        private void PauseSet(bool value) {
            Hashtable ChangePros = new Hashtable() {
                { AsteroidsGame.PAUSE_BTN,  value}
            };
            PhotonNetwork.CurrentRoom.SetCustomProperties(ChangePros);
            //Debug.Log("123123");
        }

        public override void OnRoomPropertiesUpdate(Hashtable propertiesThatChanged)
        {
            //Debug.Log(propertiesThatChanged.Count);
            if (propertiesThatChanged.Count == 3)
            {
                object turn, throwend, count;
                propertiesThatChanged.TryGetValue(AsteroidsGame.ROOM_TURN, out turn);
                propertiesThatChanged.TryGetValue(AsteroidsGame.ROOM_THROW_END, out throwend);
                propertiesThatChanged.TryGetValue(AsteroidsGame.ROOM_COUNT, out count);
                MyTurn = (bool)turn;
                Debug.Log("KIDDD" + (bool)turn + MyTurn);
                ThrowEnd = (bool)throwend;
                Count = (int)count;
            }
            if (propertiesThatChanged.Count == 1) {
                object Client, IPause;
                propertiesThatChanged.TryGetValue(AsteroidsGame.CLIENT_FUC, out Client);
                propertiesThatChanged.TryGetValue(AsteroidsGame.PAUSE_BTN, out IPause);
                if (((bool)Client) && (Client != null))
                {
                    MultiThrow.ClientFuc = (bool)Client;
                }
//                 if ((bool)IPause)
//                 {
//                     SetInvisible();
//                     Menu.SetActive(true);
//                     Pause.SetActive(true);
//                     MultiThrow.IsPause = (bool)IPause;
//                 }
            }
        }
    }
}
