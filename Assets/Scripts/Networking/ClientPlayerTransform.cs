using Unity.Netcode.Components;
using UnityEngine;

public class ClientPlayerTransform : NetworkTransform
{
    protected override bool OnIsServerAuthoritative() => false;
}
