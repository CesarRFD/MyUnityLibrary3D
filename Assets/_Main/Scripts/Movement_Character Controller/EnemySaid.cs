using UnityEngine;
using UnityEngine.AI;

public class EnemyAIFSM : MonoBehaviour
{
    private enum EnemyState {Patrol, Chase, Attack}
    private EnemyState currentState;

    [SerializeField] private Transform[] patrolPoint;
    [SerializeField] private Transform player;
    private NavMeshAgent agent;

    [SerializeField] private float visionRange = 10f;
    [SerializeField] private float attackRange = 2f;
    [SerializeField] private float attackCooldown = 1.5f;

    private int patrollIndex = 0;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        currentState = EnemyState.Patrol;
    }

    void Update()
    {
        switch (currentState)
        {
            case EnemyState.Patrol:
                Patrol ();
                break;

            //case EnemyState.Chase
        }
    }
    //Estados
    void Patrol()
    {
        if(!agent.pathPending && agent.remainingDistance < 0.5)
            GoToNextPatrolPoint();
    }

    //Condicionales
    void GoToNextPatrolPoint()
    {
        agent.destination = patrolPoint[patrollIndex].position;
        patrollIndex++;

        if (patrollIndex >= patrolPoint.Length) patrollIndex = 0;
    }

}