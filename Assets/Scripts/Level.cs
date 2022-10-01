using System.Collections;
using UnityEngine;

namespace Match3
{
    public class Level : MonoBehaviour
    {
        public GameGrid gameGrid;
        public Hud hud;

        public int score1Star;
        public int score2Star;
        public int score3Star;    

        protected LevelType type;

        protected int currentScore;

        private bool _didWin;

        private void Start()
        {
            hud.SetScore(currentScore);
        }

        public LevelType Type => type;

        protected virtual void GameWin()
        {
            gameGrid.GameOver();
            _didWin = true;
            StartCoroutine(WaitForGridFill());
        }

        protected virtual void GameLose()
        {        
            gameGrid.GameOver();
            _didWin = false;
            StartCoroutine(WaitForGridFill());
        }
    
        public virtual void OnMove()
        {
        }

        public virtual void OnPieceCleared(GamePiece piece)
        {
            currentScore += piece.score;
            hud.SetScore(currentScore);
        }

        protected virtual IEnumerator WaitForGridFill()
        {
            while (gameGrid.IsFilling)
            {
                yield return null;
            }

            if (_didWin)
            {
                hud.OnGameWin(currentScore);
            }
            else
            {
                hud.OnGameLose();
            }
        }
    }
}
