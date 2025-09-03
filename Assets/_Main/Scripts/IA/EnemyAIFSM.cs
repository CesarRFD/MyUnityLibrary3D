using UnityEngine;
using UnityEngine.AI;

namespace _Main.Scripts.IA
{
    public class EnemyAIFSM : MonoBehaviour
    {
        private enum EnemyState {Patrol, Chase, Attack}
        private EnemyState _currentState;

        [SerializeField] private Transform[] waypoints;
        [SerializeField] private Transform player;
        private NavMeshAgent _navMeshAgent;

        [SerializeField] private float chaseDistance = 10f;
        [SerializeField] private float attackDistance = 2f;
        [SerializeField] private float attackCooldown = 1.5f;

        private int _patrollIndex;
        void Start()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _currentState = EnemyState.Patrol;
        }

        void Update()
        {
            switch (_currentState)
            {
                case EnemyState.Attack:
                    break;
                case EnemyState.Chase:
                    break;
                case EnemyState.Patrol:
                    Patrol();
                    break;
            }
        }

        void Patrol()
        {
            if (!_navMeshAgent.pathPending && _navMeshAgent.remainingDistance <= 1f) GoToNextPatrolPoint();
        }

        void GoToNextPatrolPoint()
        {
            _navMeshAgent.destination = waypoints[_patrollIndex].position;
            _patrollIndex++;

            if(_patrollIndex >= waypoints.Length) _patrollIndex = 0;
        }
    }
}