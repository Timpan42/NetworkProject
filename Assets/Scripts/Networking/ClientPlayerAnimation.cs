using Unity.Netcode.Components;

public class ClientPlayerAnimation : NetworkAnimator
{
    protected override bool OnIsServerAuthoritative() => false;
}
