﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    /*
    public const int gridRows = 2;
    public const int gridCols = 4;
    public const float offsetX = 2f;
    public const float offsetZ = 2f;

    [SerializeField] private RotarCarta originalCard;
    [SerializeField] private Material[] images;

    // Buscar el hijo usando el nombre
    Transform childTransform;

    private void Start()
    {
        Vector3 startPos = originalCard.transform.position; //The position of the first card. All other cards are offset from here.

        int[] numbers = { 0, 0, 1, 1, 2, 2, 3, 3 };
        numbers = ShuffleArray(numbers); //This is a function we will create in a minute!

        for (int i = 0; i < gridCols; i++)
        {
            for (int j = 0; j < gridRows; j++)
            {
                RotarCarta card;
                if (i == 0 && j == 0)
                {
                    card = originalCard;
                }
                else
                {
                    card = Instantiate(originalCard) as RotarCarta;
                }

                int index = j * gridCols + i;
                int id = numbers[index];
                card.CambiarSprite(id, images[id]);

                float posX = (offsetX * i) + startPos.x;
                float posZ = (offsetZ * j) + startPos.y;
                card.transform.position = new Vector3(posX, startPos.y, posZ);
            }
        }
    }

    private int[] ShuffleArray(int[] numbers)
    {
        int[] newArray = numbers.Clone() as int[];
        for (int i = 0; i < newArray.Length; i++)
        {
            int tmp = newArray[i];
            int r = Random.Range(i, newArray.Length);
            newArray[i] = newArray[r];
            newArray[r] = tmp;
        }
        return newArray;
    }

    //-------------------------------------------------------------------------------------------------------------------------------------------

    private RotarCarta _firstRevealed;
    private RotarCarta _secondRevealed;

    private int _score = 0;
    [SerializeField] private TextMesh scoreLabel;

    public bool canReveal
    {
        get { return _secondRevealed == null; }
    }

    public void CardRevealed(RotarCarta card)
    {
        if (_firstRevealed == null)
        {
            _firstRevealed = card;
        }
        else
        {
            _secondRevealed = card;
            StartCoroutine(CheckMatch());
        }
    }

    private IEnumerator CheckMatch()
    {
        if (_firstRevealed.id == _secondRevealed.id)
        {
            Debug.Log("SonIguales");
            _score++;
            scoreLabel.text = "Score: " + _score;
        }
        else
        {
            Debug.Log(" no SonIguales");
            yield return new WaitForSeconds(0.5f);

            _firstRevealed.Unreveal();
            _secondRevealed.Unreveal();
        }

        _firstRevealed = null;
        _secondRevealed = null;

    }
    /*
        public void Restart()
        {
            SceneManager.LoadScene("Scene_001");
        }
    */
}