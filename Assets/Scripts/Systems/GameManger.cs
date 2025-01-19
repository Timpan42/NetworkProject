using System;
using System.Collections;
using UnityEngine;
using Unity.Netcode;
using System.Threading.Tasks;

public class GameManger : NetworkBehaviour
{
    public enum GameState
    {
        GameRunning,
        PlayerWon
    }
    private GameState gameState;
    public GameState GetGameState() => gameState;
    public static GameManger Instance { get; private set; }
    public event Action OnPlayerWin;
    private bool isTimerOn = false;
    public NetworkVariable<float> currentTime;
    public bool HasHost = false;
    public NetworkVariable<ulong> playerWonId;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Transform joinButtonHoler;
    [SerializeField] private GoalPost goalPost;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        goalPost.OnPlayerWin += PlayerWinRpc;
    }
    [Rpc(SendTo.Server)]
    private void PlayerWinRpc(ulong playerClientId)
    {
        NetworkObject networkObject = NetworkManager.Singleton.ConnectedClients[playerClientId].PlayerObject;
        ClientPlayerManager playerManager = networkObject.GetComponent<ClientPlayerManager>();
        playerWonId.Value = playerManager.OwnerClientId;
        isTimerOn = false;
        WaitForVariable();
    }

    private async void WaitForVariable()
    {
        await Task.Delay(500);
        gameState = GameState.PlayerWon;
        PlayerWinInvokeRpc();
    }

    [Rpc(SendTo.ClientsAndHost)]
    private void PlayerWinInvokeRpc()
    {
        OnPlayerWin?.Invoke();
    }

    public void StartHost()
    {
        NetworkManager.Singleton.StartHost();
        HasHost = true;
        WhenJoin();
        StartCoroutine(Timer());
    }

    public void StartClient()
    {
        NetworkManager.Singleton.StartClient();
        WhenJoin();
    }

    private void WhenJoin()
    {
        mainCamera.enabled = false;
        mainCamera.GetComponent<AudioListener>().enabled = false;
        joinButtonHoler.gameObject.SetActive(false);
    }

    private IEnumerator Timer()
    {
        isTimerOn = true;
        while (isTimerOn)
        {
            currentTime.Value += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }

}

