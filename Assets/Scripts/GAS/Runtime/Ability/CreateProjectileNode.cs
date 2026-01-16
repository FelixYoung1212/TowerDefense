using System.Collections;
using System.Collections.Generic;
using DefaultNamespace.Ability;
using UnityEngine;
using XNode;

public class CreateProjectileNode : AbilityNode<GameObject>
{
    [Input] public GameObject projectileTemplate;
}