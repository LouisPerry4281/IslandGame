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
    //Will be altered later by weapon equips
    public float damage;

    private void Update()
    {
        AttackInput();
    }

    private void AttackInput()
    {
        if (Input.GetKey(KeyCode.Mouse0) && readyToAttack)
        {
            StartCoroutine(Attack());
        }
    }

    IEnumerator Attack()
    {
        readyToAttack = false;

        //Start Attack Anim + Sound

        yield return new WaitForSeconds(attackDelay);

        AttackCheck();

        yield return new WaitForSeconds(attackLag);

        ResetAttack();
    }

    private void ResetAttack()
    {
        print("AttackReady");
        readyToAttack = true;
    }

    private void AttackCheck()
    {
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit, attackDistance, attackable))
        {
            HitTarget(hit);
        }
    }

    private void HitTarget(RaycastHit hitTarget)
    {
        if (hitTarget.collider.gameObject.GetComponent<EnemyHealth>() != null)
        {
            hitTarget.collider.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
        }
    }
}
