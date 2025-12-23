using System.Collections;
using System.Collections.Generic;
using DefaultNamespace.Ability;
using UnityEngine;
using XNode;

public class CreateProjectileNode : SkillNode<GameObject>
{
    [Input] public GameObject projectileTemplate;
}