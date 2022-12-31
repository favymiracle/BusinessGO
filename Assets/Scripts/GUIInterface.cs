using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GUIInterface : MonoBehaviour
{
    public string text = "Unity";
    public bool isTextSet = false;

    public void Start()
    {
        //this is here because I was too lazy to create another class
        Camera.main.GetComponent<Animation>().clip.SampleAnimation(Camera.main.gameObject, 0);
    }

    public void OnGUI()
    {
        if (!isTextSet)
        {
            GUILayout.BeginArea(new Rect((Screen.width / 2) - 75, (Screen.height / 2) - 100, 150, 100));
            GUI.color = Color.black;
            GUILayout.Label("Mug fits roughly 6 letters");
            GUI.color = Color.white;
            text = GUILayout.TextField(text, 15);

            if (GUILayout.Button("Apply Text To Texture"))
            {
                isTextSet = true;
            }
            GUILayout.EndArea();
        }
        else
        {
            if (!Camera.main.GetComponent<Animation>().isPlaying)
            {
                GUILayout.BeginArea(new Rect(10,10, 100, 100));
                if (GUILayout.Button("Reset"))
                {
                    Camera.main.GetComponent<Animation>().clip.SampleAnimation(Camera.main.gameObject, 0);
                    isTextSet = false;
                }
                GUILayout.EndArea();
            }
        }
    }

}