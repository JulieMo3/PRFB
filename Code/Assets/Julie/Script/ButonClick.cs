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
    public Image lose;
    public Image win;
    public Button myButton;
    public Button reload;
    public int click;
    [SerializeField] Transform slots;

    public GameObject Player;
    public WayPoint mozzarella;
    public WayPoint tomate;
    public WayPoint water;
    public WayPoint prepare;

    public GameObject knife;
    public GameObject lavabo;
    public GameObject ensembleTomateMozza;
    public GameObject mozzaUp;
    public GameObject groupeTomate;
    public float waitTimer;
    
    int[] myAlgoOrder;
    int cpt;
    int goodAlgo;
    Scene scene;
    // Start is called before the first frame update
    void Start()
    {
        Image imgwin = win.GetComponent<Image>();
        Image imgLose = lose.GetComponent<Image>();
        Button btn = myButton.GetComponent<Button>();
        Button btnRe = reload.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        btnRe.onClick.AddListener(TaskReload);
        myAlgoOrder = new int[5];
        cpt = 0;
        goodAlgo = 2;
        scene = SceneManager.GetActiveScene();
        imgLose.enabled = false;
        imgwin.enabled = false;
        
    }

    private void Update()
    {
        if(goodAlgo == 0)
        {
            waitTimer += Time.deltaTime;
        }
        if (waitTimer >= 5)
        {
            win.enabled = true;
        }
    }

    private void TaskReload()
    {


        SceneManager.LoadScene(scene.name);
    }

    void TaskOnClick()
    {
        switch (checkbox.Item.tag){
            case "num1":
                myAlgoOrder[cpt] = 1;
                Player.GetComponent<MovementPlayer2>().patrolPoints.Add(tomate);
                Player.GetComponent<MovementPlayer2>().anotherWait = true;
                groupeTomate.SetActive(false);
                break;
            case "num2":
                myAlgoOrder[cpt] = 2;
                Player.GetComponent<MovementPlayer2>().patrolPoints.Add(water);
                Player.GetComponent<MovementPlayer2>().anotherWait = true;
                lavabo.SetActive(true);
                break;
            case "num3":
                myAlgoOrder[cpt] = 3;
                Player.GetComponent<MovementPlayer2>().patrolPoints.Add(tomate);
                knife.GetComponent<Animator>().enabled = true;
                groupeTomate.SetActive(true);
                break;
            case "num4":
                myAlgoOrder[cpt] = 4;
                Player.GetComponent<MovementPlayer2>().patrolPoints.Add(mozzarella);
                Player.GetComponent<MovementPlayer2>().anotherWait = true;
                mozzaUp.SetActive(true);
                break;
            case "num5":
                myAlgoOrder[cpt] = 5;
                Player.GetComponent<MovementPlayer2>().patrolPoints.Add(prepare);
                Player.GetComponent<MovementPlayer2>().anotherWait = true;
                ensembleTomateMozza.SetActive(true);
                break;
            default:
                myAlgoOrder[cpt] = 0;
                break;

        }
            
        //mettre les conditions selon item =>action
        cpt++;
        if (cpt == 5)
        {
            for(int i =0; i < 5; i++)
            {
                if (myAlgoOrder[i] != i + 1)
                {
                    goodAlgo = 1;
                }
                else
                    goodAlgo = 0;
            }
            if (goodAlgo == 1)
            {
                //evnt echec
                lose.enabled = true;
                Debug.Log("lose");
            }
        }
    }



}
