using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationLineDebuger : MonoBehaviour {

    [SerializeField]
    private UnityEngine.AI.NavMeshAgent agent;
    
    private LineRenderer line;
    public Transform cam;
	void Start () {
        line = GetComponent<LineRenderer>();

	}
	
	// Update is called once per frame
	void Update () {
        if (agent.hasPath)
        {
            line.positionCount = agent.path.corners.Length;
            line.SetPositions(agent.path.corners);
            line.enabled = true;
        }
        else
        {
            line.enabled = false;
            cam.rotation = Quaternion.Euler(0, 90, 0);
        }
	}
}
