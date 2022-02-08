using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] private MemoryCard card;
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private TextMesh score;
    private MemoryCard _firstCard;
    private MemoryCard _secondCard;

    private const int gridRows = 2;
    private const int gridCols = 4;
    private const float offsetX = 4f;
    private const float offsetY = 5f;
    private int _score = 0;



    private void Start()
    {
        Vector3 startPos = card.transform.position;

        int[] number = { 0, 0, 1, 1, 2, 2, 3, 3 };
        number = ShuffleArray(number);


        for (int i = 0; i < gridCols; i++)
        {
            for (int j = 0; j < gridRows; j++)
            {
                MemoryCard tempCard;
                if (i == 0 && j == 0)
                {
                    tempCard = card;
                }
                else
                {
                    tempCard = Instantiate(card) as MemoryCard;
                }

                int index = j * gridCols + i;
                int id = number[index];
                tempCard.SetCard(id, sprites[id]);

                float posX = (offsetX * i) + startPos.x;
                float posY = -(offsetY * j) + startPos.y;

                tempCard.transform.position = new Vector3(posX, posY, startPos.z);
            }
        }
    }


    public bool CanReveal()
    {
        return _secondCard == null;
    }

    public void CardRevealed (MemoryCard card)
    {
        if (_firstCard == null)
        {
            _firstCard = card;
        }
        else
        {
            _secondCard = card;
            StartCoroutine(CheckMatch());
           
        }
    }

    private IEnumerator CheckMatch ()
    {
        if (_firstCard.Id == _secondCard.Id)
        {
            _score++;
            score.text = "Score: " + _score;
        }
        else
        {
            yield return new WaitForSeconds(0.5f);

            _firstCard.Unreveal();
            _secondCard.Unreveal();
        }

        _firstCard = null;
        _secondCard = null;
    }

    private int[] ShuffleArray(int[] number)
    {
        int[] temp = number.Clone() as int[];
        for (int i = 0; i < temp.Length; i++)
        {
            int tmp = temp[i];
            int r = Random.Range(i, temp.Length);
            temp[i] = temp[r];
            temp[r] = tmp;
        }

        return temp;
    }

    public void Restart ()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
