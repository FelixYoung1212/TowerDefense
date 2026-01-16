using System.Collections;
using System.Collections.Generic;
using DefaultNamespace.Ability;
using UnityEngine;
using XNode;

public class PlayAnimationNode : AbilityNode<GameObject>
{
    [Input] public string animationName;
}