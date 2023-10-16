using System;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Sanomic
{
    public class NumbersTest : MonoBehaviour
    {
        private void Start()
        {
            var eins = 1f;
            var hundert = 100f;
            
            var einsBytes = BitConverter.GetBytes(eins).Reverse().ToArray();
            var hundertBytes = BitConverter.GetBytes(hundert).Reverse().ToArray();

            var bytesEins = BitConverter.ToUInt32(einsBytes.Reverse().ToArray());
            var bytesHundert = BitConverter.ToUInt32(hundertBytes.Reverse().ToArray());

            // var einsExponent = bytesEins << 1;
            // einsExponent = einsExponent >> 24;
            // bytesEins = (einsExponent - 127);
            //
            // var hundertExponent = bytesHundert << 1;
            // hundertExponent = hundertExponent >> 24;
            // bytesHundert = (hundertExponent - 127);
            
            var einsMantissa = bytesEins & 0x007fffff;
            bytesEins = einsMantissa;
            bytesEins = bytesEins | 0x3f800000;
            eins = BitConverter.ToSingle(BitConverter.GetBytes(bytesEins));
            
            var hundertMantissa = bytesHundert & 0x007fffff;
            bytesHundert = hundertMantissa;
            bytesHundert = bytesHundert | 0x3f800000;
            hundert = BitConverter.ToSingle(BitConverter.GetBytes(bytesHundert));
            
            einsBytes = BitConverter.GetBytes(eins).Reverse().ToArray();
            hundertBytes = BitConverter.GetBytes(hundert).Reverse().ToArray();
 
            bytesEins = BitConverter.ToUInt32(einsBytes.Reverse().ToArray());
            bytesHundert = BitConverter.ToUInt32(hundertBytes.Reverse().ToArray());
            
            Debug.Log("Eins" 
                      + $"\n{HexToBits(BitConverter.ToString(einsBytes))}"
                      + $"\n{BitConverter.ToString(einsBytes)}" 
                      + $"\n{bytesEins}"
                );
            
            Debug.Log("Hundert" 
                      + $"\n{HexToBits(BitConverter.ToString(hundertBytes))}"
                      + $"\n{BitConverter.ToString(hundertBytes)}" 
                      + $"\n{bytesHundert}"
                );
        }
        
        private string HexToBits(string hex)
        {
            var sb = new StringBuilder();
            foreach (var c in hex)
            {
                if (c == '-') continue;
                sb.Append(Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0'));
            }
            return sb.ToString();
        }
    }
}
