using System.Linq;
using UnityEngine;



public class Pawn : BaseRock
{
    private Vector2 startPos;

    protected override void Start()
    {
        base.Start();
        startPos = transform.position;
    }

    public override void ShowNodesItCanGo()
    {
        if (GameManager.Instance.occupiedRockList.Any(x => x.transform.position == transform.position))
        {
            OccupiedMove();
            return;
        }


        if (GameManager.Instance.isWhiteKingShahed || GameManager.Instance.isBlackKingShahed)
        {
            ShahStateMove();
            return;
        }

        

        if (rockColor == RockColor.White)
        {
            ForwardRightCrossMoveControl();
            ForwardLeftCrossMoveControl();

            if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x, transform.position.y + 1) && x.isOccupied == true)) return;

            if ((Vector2)transform.position == startPos)
            {
                ForwardMoveControlForStartPos();

            }

            else
            {
                ForwardMoveControlForNotStartPos();
            }
        }



        if (rockColor == RockColor.Black)
        {
            BackRightCrossMoveControl();
            BackLeftCrossMoveControl();

            if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x, transform.position.y - 1) && x.isOccupied == true)) return;

            if ((Vector2)transform.position == startPos)
            {
                BackMoveControlForStartPos();

            }

            else
            {
                BackMoveControlForNotStartPos();

            }
        }

    }

    void BackMoveControlForStartPos()
    {

        newPos = new Vector2(transform.position.x, transform.position.y - 1);
        

        if (IsNodeEmpty(newPos))
        {
            GetMark(newPos);
        }

        newPos = new Vector2(transform.position.x, transform.position.y - 2);

        if (IsNodeEmpty(newPos))
            GetMark(newPos);
        }

    

    private void BackMoveControlForNotStartPos()
    {
        newPos = new Vector2(transform.position.x, transform.position.y - 1);

        if (IsNodeEmpty(newPos))
        {
            GetMark(newPos);
        }
    }

    private void BackLeftCrossMoveControl()
    {
        newPos = new Vector2(transform.position.x - 1, transform.position.y - 1);

        if (IsNodeOccupied(newPos, false))
        {
            GetMark(newPos);
        }
    }

    private void BackRightCrossMoveControl()
    {
        newPos = new Vector2(transform.position.x + 1, transform.position.y - 1);

        if (IsNodeOccupied(newPos, false))
        {
            GetMark(newPos);
        }
    }


    private void ForwardMoveControlForStartPos()
    {
        newPos = new Vector2(transform.position.x, transform.position.y + 1);
        

        if (IsNodeEmpty(newPos))
        {
            GetMark(newPos);
        }

        newPos = new Vector2(transform.position.x, transform.position.y + 2);

        if (IsNodeEmpty(newPos))
            GetMark(newPos);
    }

    private void ForwardMoveControlForNotStartPos()
    {
        newPos = new Vector2(transform.position.x, transform.position.y + 1);

        if (IsNodeEmpty(newPos))
        {
            GetMark(newPos);
        }
    }
    

    private void ForwardLeftCrossMoveControl()
    {
        newPos = new Vector2(transform.position.x - 1, transform.position.y + 1);

        if (IsNodeOccupied(newPos, false))
        {
            GetMark(newPos);
        }
    }

    private void ForwardRightCrossMoveControl()
    {
        newPos = new Vector2(transform.position.x + 1, transform.position.y + 1);

        if (IsNodeOccupied(newPos, false))
        {
            GetMark(newPos);
        }
    }

    public override void DetermineAllTheNodesItCanGoTo()
    {
        DetermineNodesItCanGoForWhite();
        DetermineNodesItCanGoForBlack();
    }

    private void DetermineNodesItCanGoForBlack()
    {
        if (rockColor == RockColor.Black)
        {
            newPos = new Vector2(transform.position.x - 1, transform.position.y - 1);
            

            if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x - 1, transform.position.y - 1)))
            {
                AddFakeMarkToList(newPos, GameManager.Instance.allTheNodesListTheOpponentCanGoTo);
            }

            newPos = new Vector2(transform.position.x + 1, transform.position.y - 1);

            if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x + 1, transform.position.y - 1)))
            {
                AddFakeMarkToList(newPos, GameManager.Instance.allTheNodesListTheOpponentCanGoTo);
            }



        }
    }

    private void DetermineNodesItCanGoForWhite()
    {
        if (rockColor == RockColor.White)
        {
            newPos = new Vector2(transform.position.x - 1, transform.position.y + 1);
            

            if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x - 1, transform.position.y + 1)))
            {
                AddFakeMarkToList(newPos, GameManager.Instance.allTheNodesListTheOpponentCanGoTo);
            }

            newPos = new Vector2(transform.position.x + 1, transform.position.y + 1);

            if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x + 1, transform.position.y + 1)))
            {
                AddFakeMarkToList(newPos, GameManager.Instance.allTheNodesListTheOpponentCanGoTo);
            }

        }
    }

    public override void OccupiedMove()
    {
        if (directionInWhichItIsoccupied == DirectionInWhichItIsoccupied.Forward || directionInWhichItIsoccupied == DirectionInWhichItIsoccupied.Back)
        {
            if (rockColor == RockColor.White)
            {
               
                if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x, transform.position.y + 1) && x.isOccupied == true)) return;

                if ((Vector2)transform.position == startPos)
                {
                    ForwardMoveControlForStartPos();
                }

                else
                {
                    ForwardMoveControlForNotStartPos();
                }
            }

            if (rockColor == RockColor.White)
            {

                if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x, transform.position.y - 1) && x.isOccupied == true)) return;

                if ((Vector2)transform.position == startPos)
                {
                    BackMoveControlForStartPos();

                }

                else
                {
                    BackMoveControlForNotStartPos();
                }
            }
        }

        if(directionInWhichItIsoccupied == DirectionInWhichItIsoccupied.ForwardRightCross)
        {
            if (rockColor == RockColor.White)
            {
                ForwardRightCrossMoveControl();
            }
        }

        if (directionInWhichItIsoccupied == DirectionInWhichItIsoccupied.ForwardLeftCross)
        {
            if (rockColor == RockColor.White)
            {
                ForwardLeftCrossMoveControl();
            }
        }

        if (directionInWhichItIsoccupied == DirectionInWhichItIsoccupied.BackRightCross)
        {
            if (rockColor == RockColor.Black)
            {
                BackRightCrossMoveControl();
            }
        }

        if (directionInWhichItIsoccupied == DirectionInWhichItIsoccupied.BackLeftCross)
        {
            if (rockColor == RockColor.Black)
            {
                BackLeftCrossMoveControl();
            }
        }

      

    }

    public override void DetermineShahStateMove()
    {
        if (rockColor == RockColor.White)
        {
            newPos = new Vector2(transform.position.x + 1, transform.position.y + 1);

            if ((Vector2)GameManager.Instance.threateningRock.transform.position == newPos)
            {

                AddFakeMarkToList(newPos, GameManager.Instance.nodesListTheCanGoToShahedState);


            }

            newPos = new Vector2(transform.position.x - 1, transform.position.y + 1);

            if ((Vector2)GameManager.Instance.threateningRock.transform.position == newPos)
            {

                AddFakeMarkToList(newPos, GameManager.Instance.nodesListTheCanGoToShahedState);

            }



            if ((Vector2)transform.position == startPos)
            {
                newPos = new Vector2(transform.position.x, transform.position.y + 1);

                if (GameManager.Instance.nodesListBetweenTheKingAndTheThreatenerRock.Any(x => x == newPos)
                    && (Vector2)GameManager.Instance.threateningRock.transform.position != newPos)
                {


                    AddFakeMarkToList(newPos, GameManager.Instance.nodesListTheCanGoToShahedState);

                }

                newPos = new Vector2(transform.position.x, transform.position.y + 2);

                if (GameManager.Instance.nodesListBetweenTheKingAndTheThreatenerRock.Any(x => x == newPos)

                && (Vector2)GameManager.Instance.threateningRock.transform.position != newPos)
                {


                    AddFakeMarkToList(newPos, GameManager.Instance.nodesListTheCanGoToShahedState);


                }
            }


        }


        if (rockColor == RockColor.Black)
        {

            newPos = new Vector2(transform.position.x + 1, transform.position.y - 1);

            if ((Vector2)GameManager.Instance.threateningRock.transform.position == newPos)
            {

                AddFakeMarkToList(newPos, GameManager.Instance.nodesListTheCanGoToShahedState);


            }

            newPos = new Vector2(transform.position.x - 1, transform.position.y - 1);

            if ((Vector2)GameManager.Instance.threateningRock.transform.position == newPos)
            {

                AddFakeMarkToList(newPos, GameManager.Instance.nodesListTheCanGoToShahedState);

            }



            if ((Vector2)transform.position == startPos)
            {
                newPos = new Vector2(transform.position.x, transform.position.y - 1);

                if (GameManager.Instance.nodesListBetweenTheKingAndTheThreatenerRock.Any(x => x == newPos)
                    && (Vector2)GameManager.Instance.threateningRock.transform.position != newPos)
                {


                    AddFakeMarkToList(newPos, GameManager.Instance.nodesListTheCanGoToShahedState);

                }

                newPos = new Vector2(transform.position.x, transform.position.y - 2);

                if (GameManager.Instance.nodesListBetweenTheKingAndTheThreatenerRock.Any(x => x == newPos)

                && (Vector2)GameManager.Instance.threateningRock.transform.position != newPos)
                {


                    AddFakeMarkToList(newPos, GameManager.Instance.nodesListTheCanGoToShahedState);


                }
            }


        }



    }


    public override void ShahStateMove()
    {
        if (rockColor == RockColor.White)
        {
            newPos = new Vector2(transform.position.x + 1, transform.position.y + 1);

            if ((Vector2)GameManager.Instance.threateningRock.transform.position == newPos)
            {
                
                GetMark(newPos);
                
                
            }

            newPos = new Vector2(transform.position.x - 1, transform.position.y + 1);

            if ((Vector2)GameManager.Instance.threateningRock.transform.position == newPos)
            {

                GetMark(newPos);

            }
           


            if ((Vector2)transform.position == startPos)
            {
                newPos = new Vector2(transform.position.x, transform.position.y + 1);
                
                if (GameManager.Instance.nodesListBetweenTheKingAndTheThreatenerRock.Any(x => x == newPos)
                    && (Vector2)GameManager.Instance.threateningRock.transform.position != newPos)
                {

                    
                    GetMark(newPos);

                }

                newPos = new Vector2(transform.position.x, transform.position.y + 2);

                if (GameManager.Instance.nodesListBetweenTheKingAndTheThreatenerRock.Any(x => x == newPos)
                    
                && (Vector2)GameManager.Instance.threateningRock.transform.position != newPos)
                {
                    
                    
                    GetMark(newPos);


                }
            }


        }


        if (rockColor == RockColor.Black)
        {

            newPos = new Vector2(transform.position.x + 1, transform.position.y - 1);

            if ((Vector2)GameManager.Instance.threateningRock.transform.position == newPos)
            {

                GetMark(newPos);


            }

            newPos = new Vector2(transform.position.x - 1, transform.position.y - 1);

            if ((Vector2)GameManager.Instance.threateningRock.transform.position == newPos)
            {

                GetMark(newPos);

            }



            if ((Vector2)transform.position == startPos)
            {
                newPos = new Vector2(transform.position.x, transform.position.y - 1);

                if (GameManager.Instance.nodesListBetweenTheKingAndTheThreatenerRock.Any(x => x == newPos)
                    && (Vector2)GameManager.Instance.threateningRock.transform.position != newPos)
                {


                    GetMark(newPos);
                    
                }

                newPos = new Vector2(transform.position.x, transform.position.y - 2);

                if (GameManager.Instance.nodesListBetweenTheKingAndTheThreatenerRock.Any(x => x == newPos)

                && (Vector2)GameManager.Instance.threateningRock.transform.position != newPos)
                {


                    GetMark(newPos);


                }
            }


        }



    }

}
