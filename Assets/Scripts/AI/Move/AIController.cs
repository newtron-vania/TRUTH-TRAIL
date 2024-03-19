using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class AIController : MonoBehaviour
{
    public Transform[] patrolPoints; // AI가 이동할 위치들
    private int currentPatrolIndex = 0; // 현재 목표 위치 인덱스

    private NavMeshAgent navMeshAgent;

    private bool isMoving = false; // AI가 이동 중인지 여부
    private bool isPatternActive = false; // 패턴 실행 중인지 여부

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        // 초기 위치 설정
        SetDestinationToNextPatrolPoint();
    }

    private void Update()
    {
        // AI의 현재 위치와 목표 위치가 거의 일치하는지 확인
        if (isMoving && !navMeshAgent.pathPending && navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
        {
            // 이동이 완료되면 패턴 실행
            ExecutePattern();
        }
    }

    private void ExecutePattern()
    {
        // 패턴 실행을 위한 스위치문 추가
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
                // 나머지 패턴도 추가할 수 있습니다.
        }
    }

    // 패턴 0
    private IEnumerator Pattern0()
    {
        isMoving = false;
        isPatternActive = true;

        Debug.Log("패턴 0 실행 중...");

        yield return new WaitForSeconds(2.0f);

        isPatternActive = false;
        SetDestinationToNextPatrolPoint();
    }

    // 패턴 1
    private IEnumerator Pattern1()
    {
        isMoving = false;
        isPatternActive = true;

        Debug.Log("패턴 1 실행 중...");

        yield return new WaitForSeconds(3.0f);

        isPatternActive = false;
        SetDestinationToNextPatrolPoint();
    }

    // 패턴 2
    private IEnumerator Pattern2()
    {
        isMoving = false;
        isPatternActive = true;

        Debug.Log("패턴 2 실행 중...");

        yield return new WaitForSeconds(4.0f);

        isPatternActive = false;
        SetDestinationToNextPatrolPoint();
    }

    // 나머지 패턴도 추가할 수 있습니다.

    private void SetDestinationToNextPatrolPoint()
    {
        if (patrolPoints.Length == 0) return;

        currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
        navMeshAgent.SetDestination(patrolPoints[currentPatrolIndex].position);

        isMoving = true;
    }
}