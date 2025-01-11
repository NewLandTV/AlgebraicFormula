using System.Collections;
using UnityEngine;

public class MultiplicationObject : MonoBehaviour
{
    [SerializeField]
    private GameObject canvas;
    [SerializeField]
    private GameObject[] group;
    private int activeGroupIndex = -1;

    private IEnumerator Start()
    {
        while (true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                canvas.SetActive(!canvas.activeSelf);
            }

            if (canvas.activeSelf)
            {
                if (activeGroupIndex != -1)
                {
                    group[activeGroupIndex].SetActive(false);
                }

                yield return null;
                continue;
            }

            for (int i = 0; i < Mathf.Min(group.Length, 9); i++)
            {
                if (group[i] == null || !Input.GetKeyDown(KeyCode.Alpha1 + i))
                {
                    continue;
                }

                if (activeGroupIndex != -1)
                {
                    group[activeGroupIndex].SetActive(false);
                }

                group[activeGroupIndex = i].SetActive(true);

                break;
            }

            yield return null;
        }
    }
}
