using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    

    private const int GRID_WIDTH = 8;
    private const int GRID_HEIGHT = 8;

    public bool isWhiteKingShahed;
    public bool isBlackKingShahed;

    [Header("Lists")]
    public List<Node> nodesList = new();
    public List<FakeMark> allTheNodesListTheOpponentCanGoTo = new ();
    public List<Vector2> nodesListTheWhiteCanGoTo = new();
    public List<Vector2> nodesListTheBlackCanGoTo = new();
    public List<OccupiedMark> occupiedRockList = new ();
    public List<Vector2> nodesListBetweenTheKingAndTheThreatenerRock = new();
    public List<FakeMark> nodesListTheCanGoToShahedState = new();


    [Header("NodePrefabs")]
    [SerializeField] private Node whiteNodePrefab;
    [SerializeField] private Node blackNodePrefab;

    [Header("RockPrefabs")]
    [SerializeField] private Pawn whitePawnPrefab;
    [SerializeField] private Knight whiteKnightPrefab;
    [SerializeField] private Bishoop whiteBishopPrefab;
    [SerializeField] private Rook whiteRookPrefab;
    [SerializeField] private Queen whiteQueenPrefab;
    [SerializeField] private Pawn blackPawnPrefab;
    [SerializeField] private Knight blackKnightPrefab;
    [SerializeField] private Bishoop blackBishopPrefab;
    [SerializeField] private Rook blackRookPrefab;
    [SerializeField] private Queen blackQueenPrefab;
    [SerializeField] private King whiteKingPrefab;
    [SerializeField] private King blackKingPrefab;

    [Header("WonPanels")]
    [SerializeField] private GameObject whiteWonPanel;
    [SerializeField] private GameObject blackWonPanel;


    [Header("Rocks")]
    public King whiteKing;
    public King blackKing;
    public Rook whiteRookLeft;
    public Rook whiteRookRight;
    public Rook blackRookLeft;
    public Rook blackRookRight;


    public BaseRock selectedRock;
    public BaseRock threateningRock;
    public GameStates state;

    
    private void Start()
    {
        ChangeState(GameStates.Start);
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            GameObject.FindGameObjectsWithTag("Mark").Select(m => m.GetComponent<Mark>()).ToList().ForEach(MarkPool.Instance.ReturnToPool);
        }
    }



    private void GenereteGrid()
    {

        for (int i = 0; i < GRID_WIDTH; i++)
        {
            for (int j = 0; j < GRID_HEIGHT; j++)
            {
                if ((i + j) % 2 == 0)
                {

                    var whiteNode = Instantiate(blackNodePrefab, new Vector2(i, j), Quaternion.identity);
                    nodesList.Add(whiteNode);
                }
                else
                {

                    var blackNode = Instantiate(whiteNodePrefab, new Vector2(i, j), Quaternion.identity);
                    nodesList.Add(blackNode);
                }
            }
        }
    }

    private void SetCameraPosition()
    {
        var center = new Vector2(GRID_WIDTH / 2 - 0.5f, GRID_HEIGHT / 2 - 0.5f);

        Camera.main.transform.position = new Vector3(center.x, center.y, -10);
    }

    private void SpawnRocks()
    {
        for (int i = 0; i < 8; i++)
        {
            Instantiate(whitePawnPrefab, new Vector2(i, 1), Quaternion.identity);
     
            Instantiate(blackPawnPrefab, new Vector2(i, 6), Quaternion.identity);
        }

        whiteRookLeft = Instantiate(whiteRookPrefab, new Vector2(0, 0), Quaternion.identity);
        Instantiate(whiteKnightPrefab, new Vector2(1, 0), Quaternion.identity);
        Instantiate(whiteBishopPrefab, new Vector2(2, 0), Quaternion.identity);
        Instantiate(whiteQueenPrefab, new Vector2(3, 0), Quaternion.identity);
        whiteKing = Instantiate(whiteKingPrefab, new Vector2(4, 0), Quaternion.identity);
        Instantiate(whiteBishopPrefab, new Vector2(5, 0), Quaternion.identity);
        Instantiate(whiteKnightPrefab, new Vector2(6, 0), Quaternion.identity);
        whiteRookRight = Instantiate(whiteRookPrefab, new Vector2(7, 0), Quaternion.identity);

        blackRookLeft = Instantiate(blackRookPrefab, new Vector2(0, 7), Quaternion.identity);
        Instantiate(blackKnightPrefab, new Vector2(1, 7), Quaternion.identity);
        Instantiate(blackBishopPrefab, new Vector2(2, 7), Quaternion.identity);
        Instantiate(blackQueenPrefab, new Vector2(3, 7), Quaternion.identity);
        blackKing = Instantiate(blackKingPrefab, new Vector2(4, 7), Quaternion.identity);
        Instantiate(blackBishopPrefab, new Vector2(5, 7), Quaternion.identity);
        Instantiate(blackKnightPrefab, new Vector2(6, 7), Quaternion.identity);
        blackRookRight = Instantiate(blackRookPrefab, new Vector2(7, 7), Quaternion.identity);

    }

    public void ChangeState(GameStates newState)
    {
        state = newState;

        switch (state)
        {
            case GameStates.Start:
                
                HandlerStartState();
                break;
            case GameStates.WaitingForWhiteInput:
                
                ShahStateRestart();
                ReturnToPoolAllMarks();
                BaseRock.LoadDetermineAllTheNodesItCanGo();
                ShahControl();
                break;
            case GameStates.WaitingForBlackInput:
               
                ShahStateRestart();
                ReturnToPoolAllMarks();    
                BaseRock.LoadDetermineAllTheNodesItCanGo();
                ShahControl();
                break;
            case GameStates.WhiteWon:
                HandlerWhiteWonState();
                break;
            case GameStates.BlackWon:
                HandlerBlackWonState();
                break;
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }

    }

    private void HandlerStartState()
    {
        GenereteGrid();
        SetCameraPosition();
        SpawnRocks();
        ChangeState(GameStates.WaitingForWhiteInput);
    }

    private void HandlerWhiteWonState()
    {
        
        whiteWonPanel.SetActive(true);
        AudioManager.Instance.PlaySound(AudioManager.Instance.wonSound, 1f);
    }

    private void HandlerBlackWonState()
    {
        
        blackWonPanel.SetActive(true);
        AudioManager.Instance.PlaySound(AudioManager.Instance.wonSound, 1f);
    }

    private void ReturnToPoolAllMarks()
    {
        GameObject.FindGameObjectsWithTag("Mark").Select(m => m.GetComponent<Mark>()).ToList().ForEach(MarkPool.Instance.ReturnToPool);
        GameObject.FindGameObjectsWithTag("FakeMark").Select(m => m.GetComponent<FakeMark>()).ToList().ForEach(FakeMarkPool.Instance.ReturnToPool);
        GameObject.FindGameObjectsWithTag("OccupiedMark").Select(m => m.GetComponent<OccupiedMark>()).ToList().ForEach(OccupiedMarkPool.Instance.ReturnToPool);
        nodesListBetweenTheKingAndTheThreatenerRock.Clear();
        occupiedRockList.Clear();
        allTheNodesListTheOpponentCanGoTo.Clear();
        nodesListTheCanGoToShahedState.Clear();
    }

    public void ToggleState()
    {
        var newState = state = state == GameStates.WaitingForWhiteInput ? GameStates.WaitingForBlackInput : GameStates.WaitingForWhiteInput;
        ChangeState(newState);
    }

    private void ShahStateRestart()
    {
        isBlackKingShahed = false;
        isWhiteKingShahed = false;
    }


    public void CalculateThreatenedNodes(Vector2 kingPos)
    {

        Vector2 direction = (Vector2)threateningRock.transform.position - kingPos;
        float distance = Mathf.Max(Mathf.Abs(direction.x), Mathf.Abs(direction.y));

        for (int i = 1; i < distance; i++)
        {
            Vector2 square = new Vector2Int(Mathf.RoundToInt(kingPos.x + (direction.x / distance) * i),
                                               Mathf.RoundToInt(kingPos.y + (direction.y / distance) * i));

            nodesListBetweenTheKingAndTheThreatenerRock.Add(square);
            
        }

        nodesListBetweenTheKingAndTheThreatenerRock.Add(threateningRock.transform.position);


    }

    public async void ShahControl()
    {
        await Task.Delay(650);

        if (nodesListTheWhiteCanGoTo.Any(x => x == (Vector2)blackKing.transform.position))
        {
            isBlackKingShahed = true;
            threateningRock = selectedRock;

            CalculateThreatenedNodes(blackKing.transform.position);
            BaseRock.LoadDetermineShahStateMoveForBlack();

            if (nodesListTheCanGoToShahedState.Count == 0)
            {
                ChangeState(GameStates.WhiteWon);
            }
        }

    

        if (nodesListTheBlackCanGoTo.Any(x => x == (Vector2)whiteKing.transform.position))
        {
            isWhiteKingShahed = true;
            threateningRock = selectedRock;

            CalculateThreatenedNodes(whiteKing.transform.position);
            BaseRock.LoadDetermineShahStateMoveForWhite();


            if (nodesListTheCanGoToShahedState.Count == 0)
            {
                ChangeState(GameStates.BlackWon);
            }

            

        }

    }

}



public enum GameStates
{
    Start,
    WaitingForWhiteInput,
    WaitingForBlackInput,
    WhiteWon,
    BlackWon
}




