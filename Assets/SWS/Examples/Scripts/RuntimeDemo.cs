/*  This file is part of the "Simple Waypoint System" project by Rebound Games.
 *  You are only allowed to use these resources if you've bought them from the Unity Asset Store.
 * 	You shall not license, sublicense, sell, resell, transfer, assign, distribute or
 * 	otherwise make available to any third party the Service or the Content. */

using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using DG.Tweening;
using SWS;
using UnityEngine.UI;

/// <summary>
/// Example: demonstrates the programmatic use at runtime.
/// <summary>
public class RuntimeDemo : MonoBehaviour
{
    
    public ExampleClass5 example5,example1;
    public Text speed1, speed2,txtbtn1,txtbtn2;

    //draw buttons for each example
    void OnGUI()
    {

        DrawExample4();
        DrawExample1();
    }


   

    //Example 5: Change Speed
  public  void ChangeSpeed1()
    {
      //  GUI.Label(new Rect(10, 110, 20, 20), "5:");

        //if (GUI.Button(new Rect(30, 110, 100, 20), " change train 1 Speed"))
       // {
            //get current speed and increase/decrease new speed
            float currentSpeed = example5.moveRef.speed;
            float newSpeed = 50f;
            if (currentSpeed == newSpeed) newSpeed = 10f;
            
            example5.moveRef.ChangeSpeed(newSpeed);
        speed1.text = "Train speed 1 :"+newSpeed;
        // }
    }
    public void ChangeSpeed2()
    {
        //  GUI.Label(new Rect(10, 110, 20, 20), "5:");

        //if (GUI.Button(new Rect(30, 110, 100, 20), " change train 1 Speed"))
        // {
        //get current speed and increase/decrease new speed
        float currentSpeed = example1.moveRef.speed;
        float newSpeed = 100f;
        if (currentSpeed == newSpeed) newSpeed = 30f;

        example1.moveRef.ChangeSpeed(newSpeed);
        speed2.text = "Train speed 2 :" + newSpeed;
        // }
    }


    void DrawExample4()
    {
        GUI.Label(new Rect(1200, 445, 140, 40), "4:");

        if (example5.moveRef.tween != null && example5.moveRef.tween.IsPlaying()
            && GUI.Button(new Rect(1200, 445, 140, 40), "Pause 1"))
        {
            example5.moveRef.Pause();
        }

        if (example5.moveRef.tween != null && !example5.moveRef.tween.IsPlaying()
            && GUI.Button(new Rect(1200, 445, 140, 40), "Resume 1"))
        {
            example5.moveRef.Resume();
        }
    }
    void DrawExample1()
    {
        GUI.Label(new Rect(1200, 490, 140, 40), "4:");

        if (example1.moveRef.tween != null && example1.moveRef.tween.IsPlaying()
            && GUI.Button(new Rect(1200, 490, 140, 40), "Pause 2"))
        {
            example1.moveRef.Pause();
        }

        if (example1.moveRef.tween != null && !example1.moveRef.tween.IsPlaying()
            && GUI.Button(new Rect(1200, 490, 140, 40), "Resume 2"))
        {
            example1.moveRef.Resume();
        }
    }
    public void Stop2()
    {
        if ( example1.moveRef.tween.IsPlaying())

        {
            example1.moveRef.Pause();
            txtbtn2.text = "Pause";
        }

        if (!example1.moveRef.tween.IsPlaying())
        {
            example1.moveRef.Resume();
            txtbtn2.text = "Resume";
        }
        // }
    }




    [System.Serializable]
    public class ExampleClass1
    {
        public GameObject walkerPrefab;
        public GameObject pathPrefab;
        public bool done = false;
    }

    [System.Serializable]
    public class ExampleClass2
    {
        public splineMove moveRef;
        public string pathName1;
        public string pathName2;
    }

    [System.Serializable]
    public class ExampleClass3
    {
        public splineMove moveRef;
    }

    [System.Serializable]
    public class ExampleClass4
    {
        public splineMove moveRef;
    }

    [System.Serializable]
    public class ExampleClass5
    {
        public splineMove moveRef;
    }

    [System.Serializable]
    public class ExampleClass6
    {
        public splineMove moveRef;
        public GameObject target;
        public bool done = false;
    }
}
