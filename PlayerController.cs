using UnityEngine;

public class PlayerController : MonoBehaviour
{
    GameDirector director;


    // Start is called once before the first execution of Update after the MonoBehaviour is created]
    //�Q�[�����N���������ԍŏ��Ɉ�񂾂��Ă΂�郁�b�\�h
    void Start()
    {
        //�t���[�����[�g��60�ɐݒ�
        Application.targetFrameRate = 60;

        director = GameObject.Find("GameDirector").GetComponent<GameDirector>();
    }

    // Update is called once per frame
    //��b�Ԃɉ���������ŌĂ΂�郁�\�b�h
    void Update()
    {

        //�Q�[�����~�܂��Ă���Ƃ��͉������Ȃ�
        if (director.stopFlag == true)
        {
            return;
        }


        //����󂪉����ꂽ�Ƃ�
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //player�����Ɂu3�v������
            transform.Translate(-3, 0, 0);

        }

        //�E��󂪉����ꂽ�Ƃ�
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //player���E�Ɂu3�v������
            transform.Translate(3, 0, 0);
        }

       
        
    }
}
