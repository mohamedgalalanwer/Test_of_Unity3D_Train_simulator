using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SWS;
using UnityEngine.UI;

public class SpeedScript : MonoBehaviour {

   public  splineMove[] move;
    public Text speed1, speed2, speed3;

    private void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
       
       if (other.gameObject.tag == "train2")
        {
            move[1].GetComponent<splineMove>().ChangeSpeed(10);
            speed2.text = "Train speed 2 :10";
        }
        else if (other.gameObject.tag == "train3")
        {
            move[2].GetComponent<splineMove>().ChangeSpeed(20);
            speed3.text = "Train speed 3 : 20";
        }
    }
   
}
