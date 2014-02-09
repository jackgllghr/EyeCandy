using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
	
		public	Transform[] 	patrolWayPoints;
		private	int				wayPointIndex;
	
		private	NavMeshAgent	nav;
	
		public	float			patrolSpeed = 1.0f;
	
		// Use this for initialization
		void Start ()
		{
				//nav = GameObject.Find ("EnemyNavModel").GetComponent<NavMeshAgent> ();
				nav = GetComponent<NavMeshAgent> ();
				wayPointIndex = 0;
		}
	
		// Update is called once per frame
		void Update ()
		{
		
				Patrolling ();
		
		}
	
		void Patrolling ()
		{
				// Set an appropriate speed for the NavMeshAgent.
				nav.speed = patrolSpeed;
		
				// If near the next waypoint or there is no destination...
				if (nav.remainingDistance < nav.stoppingDistance) {
						//			// ... increment the timer.
						//			patrolTimer += Time.deltaTime;
						//			
						//			// If the timer exceeds the wait time...
						//			if(patrolTimer >= patrolWaitTime)
						//			{
						//				// ... increment the wayPointIndex.
						if (wayPointIndex == patrolWayPoints.Length - 1)
								wayPointIndex = 0;
						else
								wayPointIndex++;
			
						//				// Reset the timer.
						//				patrolTimer = 0;
						//			}
				}
				//		else
				//			// If not near a destination, reset the timer.
				//			patrolTimer = 0;
		
				// Set the destination to the patrolWayPoint.
				nav.destination = patrolWayPoints [wayPointIndex].position;
		}
}
