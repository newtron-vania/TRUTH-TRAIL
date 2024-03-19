using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class AIController : MonoBehaviour
{
    public Transform[] patrolPoints; // AI�� �̵��� ��ġ��
    private int currentPatrolIndex = 0; // ���� ��ǥ ��ġ �ε���

    private NavMeshAgent navMeshAgent;

    private bool isMoving = false; // AI�� �̵� ������ ����
    private bool isPatternActive = false; // ���� ���� ������ ����

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        // �ʱ� ��ġ ����
        SetDestinationToNextPatrolPoint();
    }

    private void Update()
    {
        // AI�� ���� ��ġ�� ��ǥ ��ġ�� ���� ��ġ�ϴ��� Ȯ��
        if (isMoving && !navMeshAgent.pathPending && navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
        {
            // �̵��� �Ϸ�Ǹ� ���� ����
            ExecutePattern();
        }
    }

    private void ExecutePattern()
    {
        // ���� ������ ���� ����ġ�� �߰�
        switch (currentPatrolIndex)
        {
            case 0:
                StartCoroutine(Pattern0());
                break;
            case 1:
                StartCoroutine(Pattern1());
                break;
            case 2:
                StartCoroutine(Pattern2());
                break;
                // ������ ���ϵ� �߰��� �� �ֽ��ϴ�.
        }
    }

    // ���� 0
    private IEnumerator Pattern0()
    {
        isMoving = false;
        isPatternActive = true;

        Debug.Log("���� 0 ���� ��...");

        yield return new WaitForSeconds(2.0f);

        isPatternActive = false;
        SetDestinationToNextPatrolPoint();
    }

    // ���� 1
    private IEnumerator Pattern1()
    {
        isMoving = false;
        isPatternActive = true;

        Debug.Log("���� 1 ���� ��...");

        yield return new WaitForSeconds(3.0f);

        isPatternActive = false;
        SetDestinationToNextPatrolPoint();
    }

    // ���� 2
    private IEnumerator Pattern2()
    {
        isMoving = false;
        isPatternActive = true;

        Debug.Log("���� 2 ���� ��...");

        yield return new WaitForSeconds(4.0f);

        isPatternActive = false;
        SetDestinationToNextPatrolPoint();
    }

    // ������ ���ϵ� �߰��� �� �ֽ��ϴ�.

    private void SetDestinationToNextPatrolPoint()
    {
        if (patrolPoints.Length == 0) return;

        currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
        navMeshAgent.SetDestination(patrolPoints[currentPatrolIndex].position);

        isMoving = true;
    }
}