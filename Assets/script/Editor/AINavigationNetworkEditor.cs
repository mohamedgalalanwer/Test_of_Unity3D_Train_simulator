using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.AI;


[CustomEditor(typeof(WayPointNetwork))]
public class AINavigationNetworkEditor : Editor {
    public override void OnInspectorGUI()
    {
        WayPointNetwork network = (WayPointNetwork)target;
        network.pathMode = (PathDisplayMode)EditorGUILayout.EnumPopup("Display Mode ", network.pathMode);

        if (network.pathMode == PathDisplayMode.Path)
        {
            network.UIStart = EditorGUILayout.IntSlider("Start waypoint ", network.UIStart, 0, network.waypoint.Count - 1);
            network.UIEnd = EditorGUILayout.IntSlider("End waypoint ", network.UIEnd, 0, network.waypoint.Count - 1);
        }
        DrawDefaultInspector();
    }




    void OnSceneGUI( ){
        WayPointNetwork network = (WayPointNetwork)target;
        for (int i = 0; i < network.waypoint.Count; i++) {
            if (network.waypoint [i] != null)
                Handles.Label (network.waypoint [i].position, "Waypoint " + i.ToString ());
        }

        if (network.pathMode ==PathDisplayMode.connection) {

            Vector3[] linePoint = new Vector3[network.waypoint.Count + 1];

            for (int i = 0; i < network.waypoint.Count; i++) {

                int index = i != network.waypoint.Count ? i : 0;
                if (network.waypoint [i] != null)
                    linePoint [i] = network.waypoint [index].position;
                else
                    linePoint [i] = new Vector3 (Mathf.Infinity, Mathf.Infinity, Mathf.Infinity);


            }
            Handles.color = Color.cyan;
            Handles.DrawPolyLine (linePoint);
        } else  if (network.pathMode == PathDisplayMode.Path) {
              
            NavMeshPath path = new NavMeshPath ();
            Vector3 from = network.waypoint [network.UIStart].position;  
            Vector3 to = network.waypoint [network.UIEnd].position;  
            NavMesh.CalculatePath (from, to,NavMesh.AllAreas, path);
            Handles.color = Color.yellow;
            Handles.DrawPolyLine (path.corners);
        }
    
    
    }
}
