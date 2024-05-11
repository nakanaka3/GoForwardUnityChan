using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; //�i�ǉ��j�����X�N���v�g�ŃV�[���Ɋւ���N���X���g�����߂ɁAusing UnityEngine.SceneManagement;���L�q���Ă��܂��B

public class UIController : MonoBehaviour
{

    // �Q�[���I�[�o�[�e�L�X�g
    private GameObject gameOverText;

    // ���s�����e�L�X�g
    private GameObject runLengthText;

    // ����������
    private float len = 0;

    // ���鑬�x
    private float speed = 5f;

    // �Q�[���I�[�o�[�̔���
    private bool isGameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        // �V�[���r���[����I�u�W�F�N�g�̎��̂���������
        //�����쐬����2��UI(GameOver��RunLength)�ɕ\�����镶������X�V���邽�߁AStart�֐��̂Ȃ���Find�֐����g���ăV�[�������炱���̃I�u�W�F�N�g��T���AgameOverText�ϐ���runLengthText�ϐ��ɂ��ꂼ�������Ă���
        this.gameOverText = GameObject.Find("GameOver");
        this.runLengthText = GameObject.Find("RunLength");
    }

    // Update is called once per frame
    void Update()
    {
        if (this.isGameOver == false)
        {
            // �������������X�V���遜��len�ϐ���speed�ϐ������Z���đ��s�������Z�o���Ă���B�t���[�����[�g�ɂ���č����o���Ȃ����߂�Time.deltaTime���|���Ă���
            this.len += this.speed * Time.deltaTime;

            // ������������\�����遜��runLengthText�ϐ���text�ɑ������Ƃ���len.ToString ("F2")�Ƃ���len�ϐ���ToString�֐����g���ĕ�����ɕϊ����Ă��܂�
            //�����uToString()�v�͐��l�𕶎���ɕϊ�����֐��B�����ɂ͕�����ɕϊ�����ۂ̏������w��ł��A�����ł͕��������_�̒l�𕶎���ɕϊ��B������"F2"�Ƃ��邱�ƂŁA��������2���܂ŕ\������悤�ɏ����w�肵�Ă��܂�
            this.runLengthText.GetComponent<Text>().text = "Distance:  " + len.ToString("F2") + "m";
        }

        // �Q�[���I�[�o�[�ɂȂ����ꍇ�i�ǉ��j
        if (this.isGameOver == true)
        {
            // �N���b�N���ꂽ��V�[�������[�h����i�ǉ��j�����Q�[���I�[�o�[���ɉ�ʂ��^�b�v���ꂽ���AGameScene��ǂݍ��ރX�N���v�g
            if (Input.GetMouseButtonDown(0))
            {
                //SampleScene��ǂݍ��ށi�ǉ��j����SceneManager�N���X��LoadScene�֐����g���ƃV�[����ǂݍ��ނ��Ƃ��ł��܂��B�����ɂ͓ǂݍ��ރV�[������n���܂��B
                //���������ł�"SampleScene"��n���ē����V�[�����ēǂݍ��݂��邱�ƂŁA�Q�[���I�[�o�[�ƂȂ������Ƀ����^�b�`�ōĂуQ�[�����J�n���Ă��܂��B
                SceneManager.LoadScene("SampleScene");
            }
        }
    }

    //����GameOver�֐��́A��قǍ쐬����GameOver��text�ɁuGame Over�v�̕�����������ĉ�ʂɕ\�����܂��B�Q�[���I�[�o�[�ɂȂ�ƁAUnityChanController�����̊֐����ĂԂ��ƂɂȂ�܂��B
    public void GameOver()
    {
        // �Q�[���I�[�o�[�ɂȂ����Ƃ��ɁA��ʏ�ɃQ�[���I�[�o��\������
        this.gameOverText.GetComponent<Text>().text = "Game Over";
        this.isGameOver = true;
    }
}