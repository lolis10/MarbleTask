using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Windows.Kinect;
using AudioSource = UnityEngine.AudioSource;
using System;

public class TreinoJoint : MonoBehaviour
{
    public Windows.Kinect.JointType _jointType;
    public Windows.Kinect.JointType _jointTypeE;
    public GameObject _bodySourceManager;
    public string Estado;
    private BodySourceManager _bodyManager;
    public GameObject Aberta;
    public GameObject Fechada;
    public GameObject Grab;
    public string pegou;


    private bool repouso;

    private float txAmostragem = 0.25f;


    // Use this for initialization
    void Start()
    {
        _jointType = JointType.HandRight;
        _jointTypeE = JointType.HandLeft;
        Aberta.SetActive(false);
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

                var pos = body.Joints[_jointTypeE].Position;

                if (Parametros.mDireita) pos = body.Joints[_jointType].Position;

                this.gameObject.transform.position = new Vector3(pos.X * 40, pos.Y * 40, pos.Z * 0);

                if (Grab.gameObject.GetComponent<Rigidbody2D>().velocity == new Vector2(0.0f, 0.0f))
                {
                    repouso = true;
                }
                else
                {
                    repouso = false;
                }

                if (Parametros.mDireita)
                {
                    switch (body.HandRightState)
                    {
                        case HandState.Open:
                            Estado = "ABERTA";

                            if (repouso == true)
                            {
                                Aberta.SetActive(true);
                                Fechada.SetActive(false);
                            }
                            else
                            {
                                Aberta.SetActive(false);
                                Fechada.SetActive(false);
                            }
                            break;

                        case HandState.Closed:
                            Estado = "FECHADA";
                            Aberta.SetActive(false);
                            if (repouso) Fechada.SetActive(true);
                            break;
                    }
                    break;
                }
                else
                {
                    switch (body.HandLeftState)
                    {
                        case HandState.Open:
                            Estado = "ABERTA";

                            if (repouso == true)
                            {
                                Aberta.SetActive(true);
                                Fechada.SetActive(false);
                            }
                            else
                            {
                                Aberta.SetActive(false);
                                Fechada.SetActive(false);
                            }
                            break;

                        case HandState.Closed:
                            Estado = "FECHADA";
                            Aberta.SetActive(false);
                            if (repouso) Fechada.SetActive(true);
                            break;
                    }
                    break;
                }

            }
        }
    }
}
