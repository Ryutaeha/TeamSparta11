using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TeamSparta11;

internal class Json
{
    internal static void JsonSave(int userSelect)
    {
        SaveData saveData = new SaveData
        {
            Player = PlayerInfo.player
        };
        string saveDatas = JsonConvert.SerializeObject(saveData, Formatting.Indented);
        // 키 생성 어따보관하지? DB 연동하기엔 C#은 어캐하는지 몰라유
        byte[] key = Encoding.UTF8.GetBytes("0123456789ABCDEF");

        // 초기화 벡터 생성 (암호화된 데이터를 시작하는 지점을 지정) 애도 DB에서 가져와야하는디유 시간이 모질라네유
        byte[] iv = Encoding.UTF8.GetBytes("ABCDEFGHABCDEFGH");

        // 문자열을 바이트 배열로 변환
        byte[] originalBytes = Encoding.UTF8.GetBytes(saveDatas);

        // 암호화
        byte[] encryptedBytes = Encrypt(originalBytes, key, iv);


        string directoryPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\dates");
        string filePath = Path.Combine(directoryPath, "Save"+userSelect+".json");
        // 폴더가 없으면 생성
        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }

        // 파일에 쓰기
        File.WriteAllBytes(filePath, encryptedBytes);
    }

    private static byte[] Encrypt(byte[] originalBytes, byte[] key, byte[] iv)
    {

        using (AesCryptoServiceProvider aesAlg = new ())
        {
            //대칭 키 암호화 생성
            aesAlg.Key = key;
            aesAlg.IV = iv;

            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

            //대칭 암호화키를 이용하면 메모리 암호화
            using (MemoryStream msEncrypt = new MemoryStream())
            {
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    csEncrypt.Write(originalBytes, 0, originalBytes.Length);
                    csEncrypt.FlushFinalBlock();
                }
                return msEncrypt.ToArray();
            }
        }
    }

    internal static SaveData JsonLoad(int userSelect)
    {
        string directoryPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\dates");
        string filePath = Path.Combine(directoryPath, "Save" + userSelect + ".json");
        SaveData saveData = null;
        // 파일이 존재하는지 확인
        if (File.Exists(filePath))
        {
            byte[] key = Encoding.UTF8.GetBytes("0123456789ABCDEF");

            // 초기화 벡터 생성 (암호화 시 사용된 초기화 벡터와 동일해야 함)
            byte[] iv = Encoding.UTF8.GetBytes("ABCDEFGHABCDEFGH");

            // 파일 내용을 바이트 배열로 읽기
            byte[] encryptedBytes = File.ReadAllBytes(filePath);

            // 복호화
            byte[] decryptedBytes = Decrypt(encryptedBytes, key, iv);

            // 복호화된 데이터를 문자열로 변환
            string decryptedData = Encoding.UTF8.GetString(decryptedBytes);

            saveData = JsonConvert.DeserializeObject<SaveData>(decryptedData);


        }
        return saveData;

    }

    private static byte[] Decrypt(byte[] encryptedBytes, byte[] key, byte[] iv)
    {
        using (AesCryptoServiceProvider aesAlg = new ())
        {
            //대칭 키 암호화 생성
            aesAlg.Key = key;
            aesAlg.IV = iv;

            ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

            //대칭 암호화키를 참조하여 암호화된 메모리 복호화
            using (MemoryStream msDecrypt = new MemoryStream())
            {
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Write))
                {
                    csDecrypt.Write(encryptedBytes, 0, encryptedBytes.Length);
                    csDecrypt.FlushFinalBlock();
                }
                return msDecrypt.ToArray();
            }
        }
    }

}

