using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vive_Input_Behav : MonoBehaviour {


    private GameObject collidingObject;
    private GameObject objectInHand;

    private Song_Swap linkin;
    private Song_Swap2 rick;
    private GameObject Temp;
    //public Camera myCam;
    public bool val = false;
    public bool val2 = false;


    // Use this for initialization

    private SteamVR_TrackedObject trackedObj;
 
    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

    private void SetCollidingObject(Collider col)
    {
        // 1
        if (collidingObject || !col.GetComponent<Rigidbody>())
        {
            return;
        }
        // 2
        collidingObject = col.gameObject;
    }

    public void OnTriggerEnter(Collider other)
    {
        SetCollidingObject(other);
        if (Controller.GetHairTriggerDown())
        {

            val = true;
            runfunc(other);


        }

    }
    public void OnTriggerStay(Collider other)
    {
        SetCollidingObject(other);
        if (Controller.GetHairTriggerDown())
        {

            val = true;
            runfunc(other);


 
        }
   

    }





    public void runfunc(Collider hit)
    {
        linkin = GameObject.FindWithTag("Linkin").GetComponent<Song_Swap>();
        rick = GameObject.FindWithTag("Rick").GetComponent<Song_Swap2>();

        //RaycastHit hit;
       
        //   Ray ray = myCam.ScreenPointToRay(Input.mousePosition);
        //   Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);

        //if (Physics.Raycast(Cardboard.SDK.GetComponentInChildren<CardboardHead>().Gaze, out hit))
        
        {

            if (hit.name.Contains("Linkin"))
            {
                val2 = true;
                linkin.trigger(); //this make the cards flip, no problem with this              
            }

            else if (hit.name.Contains("Rick"))
            {
                val2 = true;
                rick.trigger(); //this make the cards flip, no problem with this              
            }
            //Vocals
            else if (hit.name.Contains("Vocals"))
            {
                val2 = true;

                GameObject.Find("Vocals").GetComponent<Volume_Control>().trigger();
            }
            else if (hit.name.Contains("Actual"))        //Guitar
            {
                val2 = true;
                GameObject.Find("Actual Guitar").GetComponent<Volume_Control>().trigger();
            }

            else if (hit.name.Contains("Electric"))        //Bass
            {
                val2 = true;
                GameObject.Find("Electric Guitar").GetComponent<Volume_Control>().trigger();
            }

            else if (hit.name.Contains("Kick"))        //Kick
            {
                val2 = true;
                GameObject.Find("Kick Drum").GetComponent<Volume_Control>().trigger();
            }
            else if (hit.name.Contains("Snare"))        //Bass
            {
                val2 = true;
                GameObject.Find("Snare Drum").GetComponent<Volume_Control>().trigger();
            }
            else if (hit.name.Contains("Cymbals"))        //Bass
            {
                val2 = true;
                GameObject.Find("Cymbals").GetComponent<Volume_Control>().trigger();
            }
            else if (hit.name.Contains("Synthesizer"))        //Bass
            {
                val2 = true;
                GameObject.Find("Synthesizer").GetComponent<Volume_Control>().trigger();
            }
            else if (hit.name.Contains("Concert"))        //Bass
            {
                val2 = true;
                GameObject.Find("Concert Hall").GetComponent<Swap_From_3D>().trigger();
            }
        }
    }

    // Update is called once per frame
    void Update () {

        // 3	
    }
}


