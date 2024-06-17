//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class bbbb : MonoBehaviour
//{
//    enum ShotType
//    {
//        NONE = 0,
//        AIM,            // �v���C���[��_��
//        THREE_WAY,      // �R����
//    }

//    [System.Serializable]
//    struct ShotData
//    {
//        public int frame;
//        public ShotType type;
//        public BossBullet1 bullet;
//    }

//    // �V���b�g�f�[�^
//    [SerializeField] ShotData shotData = new ShotData { frame = 60, type = ShotType.NONE, bullet = null };

//    GameObject playerObj = null;    // �v���C���[�I�u�W�F�N�g
//    int shotFrame = 0;              // �t���[��

//    void Start()
//    {
//        // �v���C���[�I�u�W�F�N�g���擾����
//        switch (shotData.type)
//        {
//            case ShotType.AIM:
//                playerObj = GameObject.Find("player");
//                break;
//        }
//    }

//    // �V���b�g�����i�����Update�ȂǂŌĂԁj
//    void Shot()
//    {
//        ++shotFrame;
//        if (shotFrame > shotData.frame)
//        {
//            switch (shotData.type)
//            {
//                // �v���C���[��_��
//                case ShotType.AIM:
//                    {
//                        if (playerObj == null) { break; }
//                        BossBullet1 bullet = (BossBullet1)Instantiate(
//                            shotData.bullet,
//                            transform.position,
//                            Quaternion.identity
//                        );
//                        bullet.SetMoveVec(playerObj.transform.position - transform.position);
//                    }
//                    break;

//                // �R����
//                case ShotType.THREE_WAY:
//                    {
//                        BossBullet1 bullet = (BossBullet1)Instantiate(
//                            shotData.bullet,
//                            transform.position,
//                            Quaternion.identity
//                        );
//                        bullet = (BossBullet1)Instantiate(shotData.bullet, transform.position, Quaternion.identity);
//                        bullet.SetMoveVec(Quaternion.AngleAxis(15, new Vector3(0, 0, 1)) * new Vector3(-1, 0, 0));
//                        bullet = (BossBullet1)Instantiate(shotData.bullet, transform.position, Quaternion.identity);
//                        bullet.SetMoveVec(Quaternion.AngleAxis(-15, new Vector3(0, 0, 1)) * new Vector3(-1, 0, 0));
//                    }
//                    break;
//            }

//            shotFrame = 0;
//        }
//    }
//}