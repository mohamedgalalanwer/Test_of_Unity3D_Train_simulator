using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum PathDisplayMode{none,connection,Path}
public class WayPointNetwork : MonoBehaviour {
    [HideInInspector]
    public PathDisplayMode pathMode=PathDisplayMode.connection;
    [HideInInspector]
    public int UIStart=0;
    [HideInInspector]
    public int UIEnd=0;

    public List<Transform> waypoint = new List<Transform> ();
}
