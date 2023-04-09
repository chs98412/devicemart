using UnityEngine;
using UnityEngine.SceneManagement;
using Amazon;
using Amazon.CognitoIdentity;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using System.Threading;

public class director : MonoBehaviour
{


  
    int count;
    public int [] arr = { -1, -1, -1, -1 };
    int[] arranswer = { 0, 1, 2, 3 };
    DynamoDBContext context;
    AmazonDynamoDBClient DBclient;
    CognitoAWSCredentials credentials;
    Character c;
    public Camera a;
    private void Start()
    {
        UnityInitializer.AttachToGameObject(this.gameObject);
        credentials = new CognitoAWSCredentials("ap-northeast-2:ceafc145-14a2-4c03-b397-22368bc8ab4f", RegionEndpoint.APNortheast2);
        DBclient = new AmazonDynamoDBClient(credentials, RegionEndpoint.APNortheast2);
        context = new DynamoDBContext(DBclient);
       
       
    }

    [DynamoDBTable("character_info")]
    public class Character
    {
        [DynamoDBHashKey] // Hash key.
        public string id { get; set; }
        [DynamoDBProperty]
        public int item { get; set; }
    }

    private void CreateCharacter() //캐릭터 정보를 DB에 올리기
    {
        Character c1 = new Character
        {
            id = "leapmotion",
            item = 1234,
        };
        context.SaveAsync(c1, (result) =>
        {
            if (result.Exception == null)
                Debug.Log("Success!");
            else
                Debug.Log(result.Exception);
        });
    }

   

    void Update() //써클을 통과한 원이 지정된 패턴과 일치하는지 확인 후, 일치하면 서버에 정보를 보냄
    {

        for(int i = 0; i <= 3; i++)
        {
            if (arr[i] == arranswer[i])
            {
                count += 1;
            }
            else if (arr[i] != arranswer[i])
                break;
        }

        if (count== 4)
        {
            CreateCharacter();
            Debug.Log("카운트!!!!!!!!!!!!!!!!!111");
        }







       
    }




}