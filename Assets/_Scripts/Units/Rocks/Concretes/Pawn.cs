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

        var pos = new Vector2(transform.position.x, transform.position.y - 1);
        var pos2 = new Vector2(transform.position.x, transform.position.y - 2);

        if (IsNodeEmpty(pos))
        {
            GetMarkNode(pos);
        }
        
        if(IsNodeEmpty(pos2))
            GetMarkNode(pos2);
        }

    

    private void BackMoveControlForNotStartPos()
    {
        var pos = new Vector2(transform.position.x, transform.position.y - 1);

        if (IsNodeEmpty(pos))
        {
            GetMarkNode(pos);
        }
    }

    private void BackLeftCrossMoveControl()
    {
        var pos = new Vector2(transform.position.x - 1, transform.position.y - 1);

        if (IsNodeOccupied(pos, false))
        {
            GetMarkNode(pos);
        }
    }

    private void BackRightCrossMoveControl()
    {
        var pos = new Vector2(transform.position.x + 1, transform.position.y - 1);

        if (IsNodeOccupied(pos, false))
        {
            GetMarkNode(pos);
        }
    }


    private void ForwardMoveControlForStartPos()
    {
        var pos = new Vector2(transform.position.x, transform.position.y + 1);
        var pos2 = new Vector2(transform.position.x, transform.position.y + 2);

        if (IsNodeEmpty(pos))
        {
            GetMarkNode(pos);
        }

        if (IsNodeEmpty(pos2))
            GetMarkNode(pos2);
    }

    private void ForwardMoveControlForNotStartPos()
    {
        var pos = new Vector2(transform.position.x, transform.position.y + 1);

        if (IsNodeEmpty(pos))
        {
            GetMarkNode(pos);
        }
    }
    

    private void ForwardLeftCrossMoveControl()
    {
        var pos = new Vector2(transform.position.x - 1, transform.position.y + 1);

        if (IsNodeOccupied(pos, false))
        {
            GetMarkNode(pos);
        }
    }

    private void ForwardRightCrossMoveControl()
    {
        var pos = new Vector2(transform.position.x + 1, transform.position.y + 1);

        if (IsNodeOccupied(pos, false))
        {
            GetMarkNode(pos);
        }
    }

    public override void DetermineAllTheNodesItCanGoTo()
    {
        if(rockColor == RockColor.White)
        {
            var pos = new Vector2(transform.position.x - 1, transform.position.y + 1);
            var pos2 = new Vector2(transform.position.x + 1, transform.position.y + 1);

            if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x - 1, transform.position.y + 1)))
            {
                AddFakeMarkToList(pos, GameManager.Instance.allTheNodesListTheOpponentCanGoTo);
            }

            if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x + 1, transform.position.y + 1)))
            {
                AddFakeMarkToList(pos2, GameManager.Instance.allTheNodesListTheOpponentCanGoTo);
            }

        }

        if (rockColor == RockColor.Black)
        {
            var pos = new Vector2(transform.position.x - 1, transform.position.y - 1);
            var pos2 = new Vector2(transform.position.x + 1, transform.position.y - 1);

            if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x - 1, transform.position.y - 1)))
            {
                AddFakeMarkToList(pos2, GameManager.Instance.allTheNodesListTheOpponentCanGoTo);
            }

            if (GameManager.Instance.nodesList.Any(x => x.pos == new Vector2(transform.position.x + 1, transform.position.y - 1)))
            {
                AddFakeMarkToList(pos, GameManager.Instance.allTheNodesListTheOpponentCanGoTo);
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
            var pos = new Vector2(transform.position.x + 1, transform.position.y + 1);

            if ((Vector2)GameManager.Instance.threateningRock.transform.position == pos)
            {

                AddFakeMarkToList(pos,GameManager.Instance.nodesListTheCanGoToShahedState);


            }

            var pos2 = new Vector2(transform.position.x - 1, transform.position.y + 1);

            if ((Vector2)GameManager.Instance.threateningRock.transform.position == pos2)
            {

                AddFakeMarkToList(pos2, GameManager.Instance.nodesListTheCanGoToShahedState);

            }



            if ((Vector2)transform.position == startPos)
            {
                var pos3 = new Vector2(transform.position.x, transform.position.y + 1);

                if (GameManager.Instance.nodesListBetweenTheKingAndTheThreatenerRock.Any(x => x == pos3)
                    && (Vector2)GameManager.Instance.threateningRock.transform.position != pos3)
                {


                    AddFakeMarkToList(pos3, GameManager.Instance.nodesListTheCanGoToShahedState);

                }

                var pos4 = new Vector2(transform.position.x, transform.position.y + 2);

                if (GameManager.Instance.nodesListBetweenTheKingAndTheThreatenerRock.Any(x => x == pos4)

                && (Vector2)GameManager.Instance.threateningRock.transform.position != pos4)
                {


                    AddFakeMarkToList(pos4, GameManager.Instance.nodesListTheCanGoToShahedState);


                }
            }


        }


        if (rockColor == RockColor.Black)
        {

            var pos = new Vector2(transform.position.x + 1, transform.position.y - 1);

            if ((Vector2)GameManager.Instance.threateningRock.transform.position == pos)
            {

                AddFakeMarkToList(pos, GameManager.Instance.nodesListTheCanGoToShahedState);


            }

            var pos2 = new Vector2(transform.position.x - 1, transform.position.y - 1);

            if ((Vector2)GameManager.Instance.threateningRock.transform.position == pos2)
            {

                AddFakeMarkToList(pos2, GameManager.Instance.nodesListTheCanGoToShahedState);

            }



            if ((Vector2)transform.position == startPos)
            {
                var pos3 = new Vector2(transform.position.x, transform.position.y - 1);

                if (GameManager.Instance.nodesListBetweenTheKingAndTheThreatenerRock.Any(x => x == pos3)
                    && (Vector2)GameManager.Instance.threateningRock.transform.position != pos3)
                {


                    AddFakeMarkToList(pos3, GameManager.Instance.nodesListTheCanGoToShahedState);

                }

                var pos4 = new Vector2(transform.position.x, transform.position.y - 2);

                if (GameManager.Instance.nodesListBetweenTheKingAndTheThreatenerRock.Any(x => x == pos4)

                && (Vector2)GameManager.Instance.threateningRock.transform.position != pos4)
                {


                    AddFakeMarkToList(pos4, GameManager.Instance.nodesListTheCanGoToShahedState);


                }
            }


        }



    }


    public override void ShahStateMove()
    {
        if (rockColor == RockColor.White)
        {
            var pos = new Vector2(transform.position.x + 1, transform.position.y + 1);

            if ((Vector2)GameManager.Instance.threateningRock.transform.position == pos)
            {
                
                GetMarkNode(pos);
                
                
            }
            
            pos = new Vector2(transform.position.x - 1, transform.position.y + 1);

            if ((Vector2)GameManager.Instance.threateningRock.transform.position == pos)
            {

                GetMarkNode(pos);

            }
           


            if ((Vector2)transform.position == startPos)
            {
                pos = new Vector2(transform.position.x, transform.position.y + 1);
                
                if (GameManager.Instance.nodesListBetweenTheKingAndTheThreatenerRock.Any(x => x == pos)
                    && (Vector2)GameManager.Instance.threateningRock.transform.position != pos)
                {

                    
                    GetMarkNode(pos);

                }

                pos = new Vector2(transform.position.x, transform.position.y + 2);

                if (GameManager.Instance.nodesListBetweenTheKingAndTheThreatenerRock.Any(x => x == pos)
                    
                && (Vector2)GameManager.Instance.threateningRock.transform.position != pos)
                {
                    
                    
                    GetMarkNode(pos);


                }
            }


        }


        if (rockColor == RockColor.Black)
        {

            var pos = new Vector2(transform.position.x + 1, transform.position.y - 1);

            if ((Vector2)GameManager.Instance.threateningRock.transform.position == pos)
            {

                GetMarkNode(pos);


            }

            pos = new Vector2(transform.position.x - 1, transform.position.y - 1);

            if ((Vector2)GameManager.Instance.threateningRock.transform.position == pos)
            {

                GetMarkNode(pos);

            }



            if ((Vector2)transform.position == startPos)
            {
                pos = new Vector2(transform.position.x, transform.position.y - 1);

                if (GameManager.Instance.nodesListBetweenTheKingAndTheThreatenerRock.Any(x => x == pos)
                    && (Vector2)GameManager.Instance.threateningRock.transform.position != pos)
                {


                    GetMarkNode(pos);
                    
                }

                pos = new Vector2(transform.position.x, transform.position.y - 2);

                if (GameManager.Instance.nodesListBetweenTheKingAndTheThreatenerRock.Any(x => x == pos)

                && (Vector2)GameManager.Instance.threateningRock.transform.position != pos)
                {


                    GetMarkNode(pos);


                }
            }


        }



    }

}
