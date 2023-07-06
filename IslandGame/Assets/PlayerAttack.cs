using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] float attackDelay;
    [SerializeField] float attackDistance;
    [SerializeField] float attackLag;
    [SerializeField] LayerMask attackable;

    bool readyToAttack = true;

    private void Update()
    {
        AttackInput();
    }

    private void AttackInput()
    {
        if (Input.GetKey(KeyCode.Mouse0) && readyToAttack)
        {
            print("Start Attack");
            StartCoroutine(Attack());
        }
    }

    IEnumerator Attack()
    {
        readyToAttack = false;

        //Start Attack Anim + Sound
        print("Wait");
        yield return new WaitForSeconds(attackDelay);

        AttackCheck();

        yield return new WaitForSeconds(attackLag);

        ResetAttack();
    }

    private void ResetAttack()
    {
        print("Attack Ready");
        readyToAttack = true;
    }

    private void AttackCheck()
    {
        print("Check");
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit, attackDistance, attackable))
        {
            print("CheckPassed");
            HitTarget(hit.point);
        }
    }

    private void HitTarget(Vector3 hitPoint)
    {
        print("Slap");
    }
}
