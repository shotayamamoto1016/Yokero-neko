using UnityEngine;

public class ArrowController : MonoBehaviour
{
    //player�Ƃ����ϐ����v���C���[�L�������Q��
    GameObject player;

    GameDirector director;

    //�_���[�W��0.1�ɐݒ�
    public float damege = 0.1f;

    
    void Start()
    {
        //player�ɃV�[������"player_0"�Ƃ������O�̕ϐ��ɑ��
        this.player = GameObject.Find("player_0");

        director = GameObject.Find("GameDirector").GetComponent<GameDirector>();
    }

    
    void Update()
    {
        //�Q�[�����~�܂��Ă���Ƃ��͉������Ȃ�
        if (director.stopFlag == true)
        {
            return;
        }

        //�t���[�����Ƃɓ����ŗ���������
        transform.Translate(0, -0.1f, 0);

        //��ʊO�ɏo����I�u�W�F�N�g��j�󂷂�
        if(transform.position.y < -5.0f)
        {
            Destroy(gameObject);
        }

        //�����蔻��
        //��̒��S���W
        Vector2 p1 = transform.position;
        //�v���C���̒��S���W
        Vector2 p2 = this.player.transform.position;
        //�������v�Z
        Vector2 dir = p1 - p2;
        //kk
        float d = dir.magnitude;
        //��̔��a
        float r1 = 0.5f;
        //�v���C���̔��a
        float r2 = 1.0f;

        if(d <r1 + r2)
        {
            //�ēX�N���v�g�Ƀv���C���ƏՓ˂������Ƃ�`����
            GameObject director = GameObject.Find("GameDirector");
            director.GetComponent<GameDirector>().DecreaseHp(damege);

            //�Փ˂����ꍇ�͖������
            Destroy(gameObject);
        }

       

    }
}
