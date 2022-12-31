using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loadding : MonoBehaviour
{
    public Transform AlphaImg;
    private Vector3 TMP;
    public static string NextScene;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        TMP = AlphaImg.localScale;
        TMP.x -= Time.deltaTime / 5;
        AlphaImg.localScale = TMP;
        if (TMP.x < -0.1) {
            SceneManager.LoadScene(NextScene);
        }
    }
}
