using System.Collections;
using System.Collections.Generic;
using DefaultNamespace.Ability;
using UnityEngine;
using XNode;

public class PlayAnimationNode : SkillNode<GameObject>
{
    [Input] public string animationName;
    [Input] public float waitSeconds;
}