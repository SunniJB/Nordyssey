using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class MoveTo : MonoBehaviour
{
    public NavMeshPath path; //current calculated path
    public LineRenderer line; //linerenderer to display path
    public Transform goal;

    void Start()
    {
        path = new NavMeshPath();
        line = transform.GetComponent<LineRenderer>();
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        NavMesh.CalculatePath(transform.position, goal.position, NavMesh.AllAreas, path);

        line.positionCount = path.corners.Length;
        line.SetPositions(path.corners);
        agent.destination = goal.position;
    }
}