using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButonClick : MonoBehaviour
{
    public Slot checkbox;
    public Button myButton;
    public Button reload;
    public int click;
    [SerializeField] Transform slots;
    public Image win;
    public Image lose;
    public GameObject Player;
    public WayPoint mozzarella;
    public WayPoint tomate;
    int[] myAlgoOrder;
    int cpt;
    int goodAlgo;
    Scene scene;
    // Start is called before the first frame update
    void Start()
    {
        
        Button btn = myButton.GetComponent<Button>();
        Button btnRe = reload.GetComponent<Button>();
        Image imgWIn = win.GetComponent<Image>();
        Image imgLose = lose.GetComponent<Image>();
        imgLose.enabled = false;
        imgWIn.enabled = false;

        btn.onClick.AddListener(TaskOnClick);
        btnRe.onClick.AddListener(TaskReload);
        myAlgoOrder = new int[5];
        cpt = 0;
        goodAlgo = 0;
        scene = SceneManager.GetActiveScene();
        
    }

    private void TaskReload()
    {


        SceneManager.LoadScene(scene.name);
    }

    void TaskOnClick()
    {
        
        Debug.Log(checkbox.Item.tag);
        switch (checkbox.Item.tag){
            case "num1":
                myAlgoOrder[cpt] = 1;
                break;
            case "num2":
                myAlgoOrder[cpt] = 2;
                break;
            case "num3":
                myAlgoOrder[cpt] = 3;
                break;
            case "num4":
                myAlgoOrder[cpt] = 4;
                break;
            case "num5":
                myAlgoOrder[cpt] = 5;
                break;
            default:
                myAlgoOrder[cpt] = 0;
                break;

        }
           
        if(checkbox.Item.tag.Contains("etoile"))
        {
            Player.GetComponent<MovementPlayer2>().patrolPoints.Add(mozzarella);
            Player.GetComponent<MovementPlayer2>().anotherWait = true;
        }
        if (checkbox.Item.tag.Contains("dollar"))
        {
            Player.GetComponent<MovementPlayer2>().patrolPoints.Add(tomate);
            Player.GetComponent<MovementPlayer2>().anotherWait = true;
        }
        //mettre les conditions selon item =>action
        cpt++;
        if (cpt == 5)
        {
            for(int i =0; i < 5; i++)
            {
                if (myAlgoOrder[i] != i+1)
                {
                    goodAlgo = 1;
                }
            }
            if (goodAlgo == 1)
            {
                //evnt echec
                lose.enabled = true;
                Debug.Log("lose");
            }
            if(goodAlgo == 0)
            {
                //event reussite
                win.enabled = true;
                Debug.Log("win");
            }
        }
    }

   

}
