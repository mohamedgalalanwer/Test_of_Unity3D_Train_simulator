using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {
    public CameraMove rail;

    private int currentSeg;
    private float transition;
    private bool isCompleted;
   
    public PlayMode mode;

    public float speed = 2.5f;
    public bool isReversed;
    public bool islooping;
    public bool pingpong;

    Mover move;
    public GameObject UIsearch,player,waypointVideo,Skipcanvas;
    public GameObject photo360, mall,navcanv,lights;
	// Use this for initialization
	void Start(){
           move= GetComponent<Mover>();
       	}
	
	// Update is called once per frame
	void Update () {
        if (!rail)
            return;
        if (!isCompleted)
            Play(!isReversed);



        if (Input.GetButtonDown("Fire1"))
        {
            SkipVideo();
        }


	}

    private void Play(bool forward=true)
    {
        float m = (rail.nodes[currentSeg + 1].position - rail.nodes[currentSeg].position).magnitude;
        float s = (Time.deltaTime * 1 / m) * speed;
        transition += (forward)?s:-s;

        if (transition > 1)
          
        {
            transition = 0;
            currentSeg++;
            if (currentSeg==rail.nodes.Length-1)
            {
                if (islooping)
                {
                    if (pingpong) {
                        transition = 1;
                        currentSeg = rail.nodes.Length - 2;
                        isReversed = !isReversed;
                    }
                    else
                    {
                        currentSeg = 0;
                    }
                    

                }
                else
                {
                    isCompleted = true;
                    SkipVideo();
                    return;
                }
            }
        }
        else if (transition<0)
        {
            transition = 1;
            currentSeg--;

            if (currentSeg ==  - 1)
            {
                if (islooping)
                {
                    if (pingpong)
                    {
                        transition = 0;
                        currentSeg =0;
                        isReversed = !isReversed;
                    }
                    else
                    {
                        currentSeg = rail.nodes.Length - 2;
                    }


                }
                else
                {
                    isCompleted = true;
                    return;
                }
            }

        }
        transform.position = rail.PostionOnReail(currentSeg, transition,mode);
        transform.rotation = rail.Orientation(currentSeg, transition);

    }

    public void SkipVideo()
    {
        mall.SetActive(true);
        photo360.SetActive(false);
        
        UIsearch.SetActive(true);
        move.enabled = false;
        Skipcanvas.SetActive(false);
        waypointVideo.SetActive(false);
        player.SetActive(true);
        gameObject.SetActive(false);
        navcanv.SetActive(true);
        lights.SetActive(true);
       // transform.position = new Vector3(-270f, 1, 9);


    }

   
}
