using Unity.VisualScripting;
using UnityEngine;
//UI���g�p����̂Œǉ�
using UnityEngine.UI;
//TextMeshPro���g�p
using TMPro;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    //hpGauge��錾
    GameObject hpGauge;

    GameObject GameOverText;

    GameObject timerText;
    //�J�E���g�_�E����ݒ�
    float countTime = 60;

    //�Q�[�����~�߂�t���O
    public bool stopFlag;

    public Button ReturnButton;

    public GameObject GameClearText;
    
    
    void Start()
    {
        this.timerText = GameObject.Find("TimeText");
        //�V�[������hpGauge�I�u�W�F�N�g��T����hpgauge�ɑ��
        this.hpGauge = GameObject.Find("hpGauge");

        GameOverText = GameObject.Find("GameOverText");

        //�Q�[���J�n���͔�\���ɂ���
        GameOverText.SetActive(false);

        ReturnButton.gameObject.SetActive(false);

        GameClearText.SetActive(false);

     
    }
    private void Update()
    {
        //�X�g�b�v�t���O��true�ɂȂ����炷�ׂẴI�u�W�F�N�g���~����
        if (stopFlag == true)
        {
            countTime = 0;
            this.timerText.GetComponent<TextMeshProUGUI>().text = this.countTime.ToString("F2");
            return;
        }
        this.countTime -= Time.deltaTime;
        this.timerText.GetComponent<TextMeshProUGUI>().text = this.countTime.ToString("F2");

        //�J�E���g�_�E�����O�ɂȂ�����Q�[���N���A�[
        if (countTime <= 0)
        {
            //�Q�[���N���A��\������
            Debug.Log("�Q�[���N���A");

            stopFlag = true;

            //ReturnButton��\��
            ReturnButton.gameObject.SetActive(true);

            //GameClear��\��
            GameClearText.SetActive(true);
        }
    }

    
    //hpGauge�̏���������
   �@public void DecreaseHp(float damege)
    {
       

        //hpGauge�ɃA�b�^�`����Ă���Image�R���|�[�l���g���擾
        //GetComponent��inspector�E�B���h�E�ɂ���image�Ƃ������i���擾����
        this.hpGauge.GetComponent<Image>().fillAmount -= damege;

        //hp���O�ɂȂ����Ƃ��Q�[���I�[�o�[��\������
        if (hpGauge.GetComponent <Image >().fillAmount <= 0)
        {
            //GameOver��\��
            GameOverText.SetActive(true);

            //�Q�[�����~�߂�t���O�𗧂Ă�
            stopFlag = true;

            //ReturnButton��\��
            ReturnButton.gameObject.SetActive(true);
        }

       
 
    }

    //�^�C�g���V�[���֑J��
    public void ReturnGame()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
