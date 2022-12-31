using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SymbolController : MonoBehaviour {

    Sprite[] sprites;
    public Button b_R;
    public Button b_L;

    public Image Symbol;

    int count = 0;

    SpriteRenderer m_SpriteRenderer;
    //The Color to be assigned to the Renderer’s Material
    Color m_NewColor;

    //These are the values that the Color Sliders return
    float m_Red, m_Blue, m_Green;

    void start()
    {
        Symbol = GetComponent<Image>();

        //Fetch the SpriteRenderer from the GameObject
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        //Set the GameObject's Color quickly to a set Color (blue)
        m_SpriteRenderer.color = Color.blue;
    }

    void OnGUI()
    {
        GUI.Label(new Rect(0, 30, 50, 30), "Red: ");
        m_Red = GUI.HorizontalSlider(new Rect(35, 25, 200, 30), m_Red, 0, 1);
        
        GUI.Label(new Rect(0, 70, 50, 30), "Green: ");
        m_Green = GUI.HorizontalSlider(new Rect(35, 60, 200, 30), m_Green, 0, 1);
        
        GUI.Label(new Rect(0, 105, 50, 30), "Blue: ");
        m_Blue = GUI.HorizontalSlider(new Rect(35, 95, 200, 30), m_Blue, 0, 1);
        
        m_NewColor = new Color(m_Red, m_Green, m_Blue);
        
        Symbol.color = m_NewColor;
    }

    void Symbols()
    {
        sprites = Resources.LoadAll<Sprite> ("Sprites");
    }
    
  
	public void On_Click_Button_R()
    {
        count++;
        if (count == sprites.Length)
        {
            count = 0;
        }

        Symbol.sprite = sprites[count];

    }
    public void On_Click_Button_L()
    {
        count--;
        if (count == sprites.Length)
        {
            count = 0;
        }

        Symbol.sprite = sprites[count];

    }
}
