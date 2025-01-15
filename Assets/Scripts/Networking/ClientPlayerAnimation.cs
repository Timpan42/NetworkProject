using Unity.Netcode.Components;
using UnityEngine;

public class ClientPlayerAnimation : NetworkAnimator
{
    protected override bool OnIsServerAuthoritative() => false;
}
