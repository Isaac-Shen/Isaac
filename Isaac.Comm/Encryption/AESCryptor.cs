using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Isaac.Comm.Encryption
{
    /// <summary>
    /// AES加密
    /// </summary>
    public class AESCryptor
    {
        public const string Ret_Error = "-1";
        private byte[] _IV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF, 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
        private byte[] _Key = { 0x63, 0x7c, 0x77, 0x7b, 0xf2, 0x6b, 0x6f, 0xc5, 0x30, 0x01, 0x67, 0x2b, 0xfe, 0xd7, 0xab, 0x76, 0xca, 0x82, 0xc9, 0x7d, 0xfa, 0x59, 0x47, 0xf0, 0xad, 0xd4, 0xa2, 0xaf, 0x9c, 0xa4, 0x72, 0xc0 };
        private const string CryptMsgExtend = "Isaac";
        private int Crypt_Key_Length = 32;
        private AesCryptoServiceProvider m_aesCryptoServiceProvider;
        private string m_message;
        private bool m_containKey;

        /// <summary>
        /// 标识加密解密过程中错误信息，做log 追踪使用
        /// </summary>
        public string Message
        {
            get { return m_message; }
            set { m_message = value; }
        }

        /// <summary>
        /// True：密文中包含密钥
        /// False：密文中不包含密钥
        /// </summary>
        public bool ContainKey
        {
            get { return m_containKey; }
            set { m_containKey = value; }
        }

        public AESCryptor()
        {
            m_aesCryptoServiceProvider = new AesCryptoServiceProvider();
            m_containKey = true;
            m_message = string.Empty;
        }

        public AESCryptor(bool containKey)
            : this()
        {
            m_containKey = containKey;
        }

        private string Encrypt(string s_crypto, byte[] key)
        {
            string s_encryped = string.Empty;
            byte[] crypto, encrypted;
            ICryptoTransform ct;

            try
            {
                crypto = string2Byte(s_crypto + CryptMsgExtend);
                m_aesCryptoServiceProvider.Key = key;
                m_aesCryptoServiceProvider.IV = _IV;
                ct = m_aesCryptoServiceProvider.CreateEncryptor();
                encrypted = ct.TransformFinalBlock(crypto, 0, crypto.Length);
                if (m_containKey)
                {
                    s_encryped += byte2HexString(key);
                }
                s_encryped += byte2HexString(encrypted);
                return s_encryped;
            }
            catch (Exception ex)
            {
                m_message = ex.ToString();
                return Ret_Error;
            }
        }

        private string Decrypt(string s_encrypted, byte[] key)
        {
            string s_decrypted = string.Empty;
            byte[] encrypted, decrypted;
            ICryptoTransform ct;

            try
            {
                encrypted = hexString2Byte(s_encrypted);
                m_aesCryptoServiceProvider.Key = key;
                m_aesCryptoServiceProvider.IV = _IV;
                ct = m_aesCryptoServiceProvider.CreateDecryptor();
                decrypted = ct.TransformFinalBlock(encrypted, 0, encrypted.Length);
                s_decrypted += byte2String(decrypted);
                return s_decrypted.Substring(0, s_decrypted.LastIndexOf(CryptMsgExtend));
            }
            catch (Exception ex)
            {
                m_message = ex.ToString() + "Decrypt fail.";
                return Ret_Error;
            }
        }

        #region 指定密钥对明文进行AES加密、解密
        /// <summary>
        /// 指定密钥对明文进行AES加密
        /// </summary>
        /// <param name="s_crypto">明文</param>
        /// <param name="s_key">加密密钥</param>
        /// <returns></returns>
        public string Encrypt(string s_crypto, string s_key)
        {
            byte[] key = new byte[Crypt_Key_Length];

            byte[] temp = string2Byte(s_key);
            if (temp.Length > key.Length)
            {
                m_message = "Key too long,need less than 32 Bytes key.";
                return Ret_Error;
            }
            key = string2Byte(s_key.PadRight(key.Length));
            return Encrypt(s_crypto, key);
        }
        /// <summary>
        /// 指定密钥，并对密文进行解密
        /// </summary>
        /// <param name="s_encrypted">密文</param>
        /// <param name="s_key">密钥</param>
        /// <returns></returns>
        public string Decrypt(string s_encrypted, string s_key)
        {
            byte[] key = new byte[Crypt_Key_Length];

            byte[] temp = string2Byte(s_key);
            if (temp.Length > key.Length)
            {
                m_message = "Key invalid.too long,need less than 32 Bytes";
                return Ret_Error;
            }
            key = string2Byte(s_key.PadRight(key.Length));
            if (m_containKey)
            {
                s_encrypted = s_encrypted.Substring(Crypt_Key_Length * 2);
            }
            return Decrypt(s_encrypted, key);
        }
        #endregion

        #region 使用定义密钥，对明文进行AES加密、解密
        /// <summary>
        /// 动态生成密钥，并对明文进行AES加密
        /// </summary>
        /// <param name="s_crypto">明文</param>
        /// <returns></returns>
        public string Encrypt(string s_crypto)
        {
            return Encrypt(s_crypto, _Key);
        }
        /// <summary>
        /// 从密文中解析出密钥，并对密文进行解密
        /// </summary>
        /// <param name="s_encrypted">密文</param>
        /// <returns></returns>
        public string Decrypt(string s_encrypted)
        {

            if (s_encrypted.Length <= Crypt_Key_Length * 2)
            {
                m_message = "Encrypted string invalid.";
                return Ret_Error;
            }
            if (m_containKey)
            {
                s_encrypted = s_encrypted.Substring(Crypt_Key_Length * 2);
            }
            return Decrypt(s_encrypted, _Key);
        }
        #endregion

        #region 私有方法
        private string byte2HexString(byte[] bytes)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in bytes)
            {
                sb.AppendFormat("{0:X2}", b);
            }
            return sb.ToString();
        }
        private byte[] hexString2Byte(string hex)
        {
            int len = hex.Length / 2;
            byte[] bytes = new byte[len];
            for (int i = 0; i < len; i++)
            {
                bytes[i] = (byte)(Convert.ToInt32(hex.Substring(i * 2, 2), 16));
            }
            return bytes;
        }
        private byte[] string2Byte(string str)
        {
            return Encoding.UTF8.GetBytes(str);
        }
        private string byte2String(byte[] bytes)
        {
            return Encoding.UTF8.GetString(bytes);
        }
        #endregion
    }
}
