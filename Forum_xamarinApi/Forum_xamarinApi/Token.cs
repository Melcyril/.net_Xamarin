using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum_xamarinApi
{
    public class Token
    {

        // Token à Eric
        //public string Create()
        //{
        //    DateTime dateTime = DateTime.Now;
        //    long graduate = dateTime.Ticks;

        //    string firstTab = graduate.ToString().Substring(0, 4);
        //    string upFirstTab = firstTab + "a" + DateTime.Now.Year;

        //    string secondTab = graduate.ToString().Substring(4, graduate.ToString().Length - 4);
        //    string upSecondTab = secondTab + "yx" + DateTime.Now.Year;
        //    return upFirstTab + upSecondTab;
        //}


        //public bool Verify(string token)
        //{
        //    DateTime dateTime = DateTime.Now;
        //    DateTime dateTime2 = DateTime.Now.AddSeconds(-30);

        //    string firstTab = token.ToString().Substring(0, 4);
        //    string secondTab = token.ToString().Substring(9, token.ToString().Length - 15);

        //    try
        //    {
        //        long getToken = long.Parse(firstTab + secondTab);
        //        DateTime dtTimeToken = new DateTime(getToken);
        //        if (dtTimeToken != null && dateTime2 < dtTimeToken && dateTime > dtTimeToken)
        //            return true;
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }
        //    return false;
        //}


        // Création du token
        public static string Create()
        {
            DateTime time_s = DateTime.Now;
            long time = time_s.Ticks;
            long tok = time * 4 - 120;
            string token = tok.ToString();   
            return token;
        }


        // Decrypt non utilisé
        public static string Decrypt(string token)
        {
            long token1 = long.Parse(token) / 4 + 120;
            string tokenDecrypte = token1.ToString();
            return tokenDecrypte;
        }


        // Vérification du token
        public static bool Verify(string token)
        {
            long decryptLong = long.Parse(token) / 4 + 120;

            DateTime dtNow = DateTime.Now;

            try
            {
                DateTime dtToken = new DateTime(decryptLong);

                if (dtToken <= dtNow)
                {
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
            return false;
        }
    }
}