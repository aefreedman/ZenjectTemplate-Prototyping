using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace SpaceGameTwo
{
    public class ScoreHandler : MonoBehaviour
    {
        [Inject(Id = "ScoreText")] private Text _text;
        [Inject] private Signals.ScorePoints _scorePoints;
        private int _score;

        public void Start()
        {
            _scorePoints += Score;
            _score = 0;
        }


        private void Score(int points)
        {
            _score += points;
            _text.text = _score.ToString();
        }
    }
}