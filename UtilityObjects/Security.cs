﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendWebUMG.UtilityObjects
{
    public class Security
    {
            public static string key = "ad@54654d@66";
            public static string Encrypt(string password)
            {
                if (string.IsNullOrEmpty(password)) return "";
                password += key;
                var passwordBytes = Encoding.UTF8.GetBytes(password);
                return Convert.ToBase64String(passwordBytes);
            }

            public static string Decrypt(string base64EncodeData)
            {
                if (string.IsNullOrEmpty(base64EncodeData)) return "";
                var base64EncodeBytes = Convert.FromBase64String(base64EncodeData);
                var result = Encoding.UTF8.GetString(base64EncodeBytes);
                result = result.Substring(0, result.Length - key.Length);
                return result;
            }
    }
}
