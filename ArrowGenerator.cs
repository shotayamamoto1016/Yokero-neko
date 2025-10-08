using UnityEngine;

public class ArrowGenerator : MonoBehaviour
{
    //arrowprefab��錾
    public GameObject arrowprefab;
    public GameObject Rarrowprefab;
    //�Ԋu��錾
    float span = 1.0f;
    //��𐶐��������Ԃ�錾
    float delta = 0;

    //�Ԃ���𐶐����A���Ԃ��Ǘ����邽�߂̕ϐ���錾
    float Rdelta = 0;

    GameDirector director;

    private void Start()
    {
        director = GameObject.Find("GameDirector").GetComponent<GameDirector>();
    }


    
    void Update()
    {
        //�Q�[�����~�܂��Ă���Ƃ��͉������Ȃ�
        if(director.stopFlag == true)
        {
            return;
        }

        //�t���[�����Ƃ̎��ԍ���this.delta�ɑ��
        //Time.deltaTime�͑O�t���[������̎��ԍ���\��
        this.delta += Time.deltaTime;

        this.Rdelta += Time.deltaTime;

        if(this.delta > this.span)
        {
            this.delta = 0;
            //instantiate���\�b�h�͈�����prefab��n���ƁA�Ԃ�l�Ƃ���prefab�̃C���X�^���X��Ԃ��Ă����
            GameObject go = Instantiate(arrowprefab);
            //��̈ʒu�������_���ɐݒ�
            int px = Random.Range(-6, 7);
            //��̈ʒu��ݒ�
            go.transform.position = new Vector3(px, 7, 0);


        }

        //30�b�o�߂ŐԂ���~��
        if (this.Rdelta > 31)
        {
            this.Rdelta = 30;
            GameObject go2 = Instantiate(Rarrowprefab);
            //�Ԃ���̈ʒu�������_���ɐݒ�
            int px = Random.Range(-6, 7);
            //�Ԃ���̈ʒu��ݒ�
            go2.transform.position = new Vector3(px, 7, 0);
        }
       
    }
}
