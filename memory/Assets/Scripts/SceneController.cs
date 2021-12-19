using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneController : MonoBehaviour
{
    public const int gridRows = 2;
    public const int gridCols = 4;
    public const float offsetX = 2.5f;
    public const float offsetY = 3f;
    private int _score;

    [SerializeField] private Sprite[] images;
    [SerializeField] private MemoryCard originCard;
    [SerializeField] TextMesh textLabel;

    private MemoryCard _firstCard;
    private MemoryCard _secondCard;

    public bool CanReveal()
    {
        return _secondCard == null;
    }

    public void CardRevealed(MemoryCard card)
    {
        if(_firstCard == null)
        {
            _firstCard = card;
        }
        else
        {
            _secondCard = card;
            StartCoroutine(CheckMatch());
           
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _score = 0;
        int[] numbers = { 0, 0, 1, 1, 2, 2, 3, 3 };
        numbers = ShaffleArray(numbers);
        Vector3 startPos = originCard.transform.position;
        for (int i = 0; i < gridCols; i++)
        {
            for (int j = 0; j < gridRows; j++)
            {
                MemoryCard card;
                if (i == 0 && j == 0)
                {
                    card = originCard;
                }
                else
                {
                    card = Instantiate(originCard) as MemoryCard;
                }

                int index = j * gridCols + i;
                int id = numbers[index];
                card.SetCard(id, images[id]);
                float posX = (offsetX * i) + startPos.x;
                float posY = -(offsetY * j) + startPos.y;
                card.transform.position = new Vector3(posX, posY, startPos.z);
            }
        }
    }

    private int[] ShaffleArray(int [] array)
    {
        int[] newArray = array.Clone() as int[];
        for (int i = 0; i < newArray.Length; i++)
        {
            int temp = newArray[i];
            int r = Random.Range(i, newArray.Length);
            newArray[i] = newArray[r];
            newArray[r] = temp;
        }

        return newArray;
    }

    private IEnumerator CheckMatch()
    {
        if (_firstCard.id == _secondCard.id)
        {
            _score++;
            textLabel.text = "Score: " + _score;
        }
        else
        {
            yield return new WaitForSeconds(1);
            _firstCard.Unreveal();
            _secondCard.Unreveal();
        }
        _firstCard = null;
        _secondCard = null;
    }

    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
