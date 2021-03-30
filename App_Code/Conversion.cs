using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Conversion
/// </summary>
public class Conversion
{
	public Conversion()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    static sbyte[] unhex_table =
      { -1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1
       ,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1
       ,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1
       , 0, 1, 2, 3, 4, 5, 6, 7, 8, 9,-1,-1,-1,-1,-1,-1
       ,-1,10,11,12,13,14,15,-1,-1,-1,-1,-1,-1,-1,-1,-1
       ,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1
       ,-1,10,11,12,13,14,15,-1,-1,-1,-1,-1,-1,-1,-1,-1
       ,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1
      };

    public static int Convert(string hexNumber)
    {
        int decValue = unhex_table[(byte)hexNumber[0]];
        for (int i = 1; i < hexNumber.Length; i++)
        {
            decValue *= 16;
            decValue += unhex_table[(byte)hexNumber[i]];
        }
        return decValue;
    }
}