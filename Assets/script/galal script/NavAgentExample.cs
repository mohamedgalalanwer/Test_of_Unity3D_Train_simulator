using UnityEngine;
using System.Collections;

// ----------------------------------------------------------
// CLASS	:	NavAgentExample
// DESC		:	Behaviour to test Unity's NavMeshAgent
// ----------------------------------------------------------
[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
public class NavAgentExample : MonoBehaviour 
{
	// Inspector Assigned Variable
    public WayPointNetwork WaypointNetwork = null;
	public   int				 CurrentIndex	 = 0;
	public bool				 HasPath		 = false;
	public bool				 PathPending	 = false;
	public bool				 PathStale		 = false;
	public UnityEngine.AI.NavMeshPathStatus PathStatus      = UnityEngine.AI.NavMeshPathStatus.PathInvalid;

   
    
	// Private Members
	private UnityEngine.AI.NavMeshAgent _navAgent = null;

	// -----------------------------------------------------
	// Name :	Start
	// Desc	:	Cache MavMeshAgent and set initial 
	//			destination.
	// -----------------------------------------------------
	void Start () 
	{
      
		// Cache NavMeshAgent Reference
		_navAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
       
		// Turn off auto-update
		/*_navAgent.updatePosition = false;
		_navAgent.updateRotation = false;*/


		// If not valid Waypoint Network has been assigned then return
		if (WaypointNetwork==null) return;

		SetNextDestination ( false );
   
	}
   


  
	// -----------------------------------------------------
	// Name	:	SetNextDestination
	// Desc	:	Optionally increments the current waypoint
	//			index and then sets the next destination
	//			for the agent to head towards.
	// -----------------------------------------------------
	void SetNextDestination ( bool increment )
	{
		// If no network return
		if (!WaypointNetwork) return;

		// Calculatehow much the current waypoint index needs to be incremented
		int incStep = increment?1:0;

		// Calculate index of next waypoint factoring in the increment with wrap-around and fetch waypoint 
        int nextWaypoint = (CurrentIndex + incStep >= WaypointNetwork.waypoint.Count) ? 0 : CurrentIndex;
        Transform nextWaypointTransform = WaypointNetwork.waypoint[CurrentIndex];

		// Assuming we have a valid waypoint transform
		if (nextWaypointTransform!=null)
		{
			// Update the current waypoint index, assign its position as the NavMeshAgents
			// Destination and then return
			CurrentIndex = nextWaypoint;
			_navAgent.destination = nextWaypointTransform.position;
          
			return;
		}

		// We did not find a valid waypoint in the list for this iteration
		//CurrentIndex++;
	}

	// ---------------------------------------------------------
	// Name	:	Update
	// Desc	:	Called each frame by Unity
	// ---------------------------------------------------------
	void Update () 
	{
		// Copy NavMeshAgents state into inspector visible variables
		HasPath 	= _navAgent.hasPath;
		PathPending = _navAgent.pathPending;
		PathStale	= _navAgent.isPathStale;
		PathStatus	= _navAgent.pathStatus;

		// If we don't have a path and one isn't pending then set the next
		// waypoint as the target, otherwise if path is stale regenerate path
		if ( (!HasPath && !PathPending) || PathStatus==UnityEngine.AI.NavMeshPathStatus.PathInvalid /*|| PathStatus==NavMeshPathStatus.PathPartial*/)
			SetNextDestination ( true );
		else
		if (_navAgent.isPathStale)
			SetNextDestination ( false );

	}
    //void OnDrawGizmosSelected()
    //{

    //   // var nav = GetComponent<NavMeshAgent>();
    //    if (_navAgent == null || _navAgent.path == null)
    //        return;

    //    var line = this.GetComponent<LineRenderer>();
    //    if (line == null)
    //    {
    //        line = this.gameObject.AddComponent<LineRenderer>();
    //        line.material = new Material(Shader.Find("Sprites/Default")) { color = Color.yellow };
    //        line.SetWidth(0.5f, 0.5f);
    //        line.SetColors(Color.yellow, Color.yellow);
    //    }

    //    var path = _navAgent.path;

    //    line.SetVertexCount(path.corners.Length);

    //    for (int i = 0; i < path.corners.Length; i++)
    //    {
    //        line.SetPosition(i, path.corners[i]);
    //    }

    //}
}
