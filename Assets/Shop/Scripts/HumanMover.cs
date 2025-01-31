using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class HumanMover : MonoBehaviour
{
    private NavMeshAgent agent;
    private float distanceToGoal = 0.3f;

    public UnityEvent onCollide;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        SetNewTarget();
    }

    private void Update()
    {
        if (agent.remainingDistance < distanceToGoal)
        {
            SetNewTarget();
        }
    }

    private void SetNewTarget()
    {
        Vector3 randomDirection = Random.insideUnitSphere * 4f;
        randomDirection += transform.position;
        NavMesh.SamplePosition(randomDirection, out NavMeshHit hit, 4f, 1);
        agent.SetDestination(hit.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GetComponent<AudioSource>().Play();
            onCollide?.Invoke();
        }
    }
}
