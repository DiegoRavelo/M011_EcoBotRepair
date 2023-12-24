using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabPickUps : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]

    AudioPlay _audioPlay;


    void Start()
    {
        _audioPlay = FindObjectOfType<AudioPlay>();


    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Tuerca"))
        {
            GameManager.Instance.SumarPuntosTuerca(1);
            Destroy(other.gameObject);

            _audioPlay.PlaySound(1);
        }
        else if (other.CompareTag("Muelle"))
        {
            GameManager.Instance.SumarPuntosMuelle(1);
            Destroy(other.gameObject);

            _audioPlay.PlaySound(1);

        }
        else if (other.CompareTag("Metal"))
        {
            GameManager.Instance.SumarPuntosMetal(1);
            Destroy(other.gameObject);

            _audioPlay.PlaySound(1);

        }
    }
}
