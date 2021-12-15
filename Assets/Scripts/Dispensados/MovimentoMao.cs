using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Windows.Kinect;
//using AudioSource = UnityEngine.AudioSource;

public class MovimentoMao : MonoBehaviour
{
    public Windows.Kinect.JointType _jointType;
    public GameObject _bodySourceManager;
    private BodySourceManager _bodyManager;
    public GameObject Aberta;
    public GameObject Fechada;
    public string colidiu;

    // Use this for initialization
    void Start()
    {
        Aberta.SetActive(true);
        Fechada.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (_bodySourceManager == null)
        {
            return;
        }

        _bodyManager = _bodySourceManager.GetComponent<BodySourceManager>();
        if (_bodyManager == null)
        {
            return;
        }

        Body[] data = _bodyManager.GetData();
        if (data == null)
        {
            return;
        }

        // get the first tracked body...
        foreach (var body in data)
        {
            if (body == null)
            {
                continue;
            }

            if (body.IsTracked)
            {
                var pos = body.Joints[_jointType].Position;
                this.gameObject.transform.position = new Vector3(pos.X * 40, pos.Y * 40, pos.Z * 0);

                switch (body.HandLeftState)
                {
                    case HandState.Open:
                        Aberta.SetActive(true);
                        Fechada.SetActive(false);

                        break;
                    case HandState.Closed:
                        UnityEngine.SceneManagement.SceneManager.LoadScene("CenaResgate");
                        Aberta.SetActive(false);
                        Fechada.SetActive(true);
                        break;
                }
                break;
            }
        }
    }
}
