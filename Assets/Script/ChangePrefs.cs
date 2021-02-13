using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangePrefs: MonoBehaviour
{
    // Start is called before the first frame update

    public Material whiteMat;
    public Material redMat;
    public Material purpleMat;
    public Material blueMat;
    public Material greenMat;
    public Material yellowMat;

    public GameObject player;
    public Dropdown dropdown;
    public Slider slider;
    public Toggle toggle;


    void Start()
    {
        if(dropdown != null)
        {
            PlayerPrefs.SetInt("color", dropdown.value);
            PlayerPrefs.SetInt("overSized", 0);
            PlayerPrefs.SetFloat("gameSpeed", slider.value) ;
        }

        if (player != null)
        {
            applyColor();
            applySpeed();
            applyOversized();
        }

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void changeColorDropdown()
    {
        PlayerPrefs.SetInt("color", dropdown.value);
        Debug.Log("color set to " + PlayerPrefs.GetInt("color"));
    }

    public void applyColor()
    {
        switch (PlayerPrefs.GetInt("color"))
        {
            case 0:
                player.GetComponent<MeshRenderer>().material = whiteMat;
                break;
            case 1:
                player.GetComponent<MeshRenderer>().material = redMat;
                break;
            case 2:
                player.GetComponent<MeshRenderer>().material = purpleMat;
                break;
            case 3:
                player.GetComponent<MeshRenderer>().material = blueMat;
                break;
            case 4:
                player.GetComponent<MeshRenderer>().material = greenMat;
                break;
            case 5:
                player.GetComponent<MeshRenderer>().material = yellowMat;
                break;
        }
    }

    public void changeSpeed()
    {
        PlayerPrefs.SetFloat("gameSpeed", slider.value);
    }

    public void applySpeed()
    {
        player.GetComponent<PlayerController>().speed = PlayerPrefs.GetFloat("gameSpeed");
    }

    public void changeOversized()
    {
        if (toggle.isOn)
        {
            PlayerPrefs.SetInt("overSized", 1);
        }else
        {
            PlayerPrefs.SetInt("overSized", 0);
        }
    }

    public void applyOversized()
    {
        if (PlayerPrefs.GetInt("overSized") == 1)
        {
            player.GetComponent<Transform>().localScale = (new Vector3(2f, 2f, 2f));
        }
        if (PlayerPrefs.GetInt("overSized") == 0)
        {
            player.GetComponent<Transform>().localScale = (new Vector3(1f, 1f, 1f));
        }
    }
}
