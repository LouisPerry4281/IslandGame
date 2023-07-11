using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolItem : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] float damage;
    [SerializeField] float attackDistance;
    [SerializeField] LayerMask attackLayers;
    [SerializeField] Animator animator;
}
