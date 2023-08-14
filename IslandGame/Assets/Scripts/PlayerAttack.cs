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

    public Animator animator;
    [SerializeField] GameObject visualEffect;

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

    public void SetAnimatorTarget()
    {

    }

    IEnumerator Attack()
    {
        readyToAttack = false;

        //Start Attack Anim + Sound
        //Maybe set this to default "Swing" the just swap out the animator reference with new equips
        if (animator != null)
            animator.Play("SpearAttack");

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
        print("check");
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit, attackDistance, attackable))
        {
            HitTarget(hit);
        }
    }

    private void HitTarget(RaycastHit hitTarget)
    {
        GameObject hitMark = Instantiate(visualEffect, hitTarget.point, Quaternion.identity);
        Destroy(hitMark, 5);

        if (hitTarget.collider.gameObject.GetComponent<EnemyHealth>() != null)
        {
            hitTarget.collider.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
        }
    }
}
