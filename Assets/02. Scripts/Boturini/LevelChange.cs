using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class LevelChange : MonoBehaviour
{
    [Header("Bloques finales")]
    [SerializeField] private GameObject[] finalBlocks = new GameObject[7];

    private void Update()
    {
            //Si los todos los bloques ya han sido destruidos
            if (finalBlocks[0].IsDestroyed() && finalBlocks[1].IsDestroyed() && finalBlocks[2].IsDestroyed() &&
            finalBlocks[3].IsDestroyed() && finalBlocks[4].IsDestroyed() && finalBlocks[5].IsDestroyed() &&
            finalBlocks[6].IsDestroyed() && Dialogos.animalesContador == 3)
            {
                SceneManager.LoadScene("E8 B");
            }
    }
}
