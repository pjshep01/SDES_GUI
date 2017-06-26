using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Collections;

namespace WindowsFormsApplication1
{
    class SDES
    {
        //Declare Sboxs 4x4
        BitArray[,] Sbox1 = new BitArray[4, 4];
        BitArray[,] Sbox2 = new BitArray[4, 4];
        //Class Constructor
        public SDES()
        {
            //Make Bitarrays to create sboxes. Default values are false so only assign true
            //condensed to one line for readability
            //ff = (false, false) ft = (false, true) etc
            BitArray ff = new BitArray(2);
            BitArray ft = new BitArray(2); ft[1] = true;
            BitArray tf = new BitArray(2); tf[0] = true;
            BitArray tt = new BitArray(2); tt[0] = tt[1] = true;
            Sbox1[0, 1] = Sbox1[1, 3] = Sbox1[2, 0] = ff;
            Sbox1[0, 0] = Sbox1[1, 2] = Sbox1[2, 2] = Sbox1[3, 1] = ft;
            Sbox1[0, 3] = Sbox1[1, 1] = Sbox1[2, 1] = Sbox1[3, 3] = tf;
            Sbox1[0, 2] = Sbox1[1, 0] = Sbox1[2, 3] = Sbox1[3, 0] = Sbox1[3, 2] = tt;

            Sbox2[0, 0] = Sbox2[1, 1] = Sbox2[2, 1] = Sbox2[2, 3] = Sbox2[3, 2] = ff;
            Sbox2[0, 1] = Sbox2[1, 2] = Sbox2[2, 2] = Sbox2[3, 1] = ft;
            Sbox2[0, 2] = Sbox2[1, 0] = Sbox2[3, 0] = tf;
            Sbox2[0, 3] = Sbox2[1, 3] = Sbox2[2, 0] = Sbox2[3, 3] = tt;
        }
         
        //This is for checking GUI input is only '0' or '1'
        //Only matches strings of '1' and '0' 
        public static Regex alphabet = new Regex(@"^[01]+$");
        //Made a dictionary so that the binary strings can be translated
        //to A-P. Probably will not need first dict since only accepting
        //'1' and '0' input. Would be useful if accepting letters as well.
        //Rev dict is used by GUI to translate input to letters.
        IDictionary<string, string> dict = new Dictionary<string, string>()
            {
                {"A", "0000"},
                {"B", "0001"},
                {"C", "0010"},
                {"D", "0011"},
                {"E", "0100"},
                {"F", "0101"},
                {"G", "0110"},
                {"H", "0111"},
                {"I", "1000"},
                {"J", "1001"},
                {"K", "1010"},
                {"L", "1011"},
                {"M", "1100"},
                {"N", "1101"},
                {"O", "1110"},
                {"P", "1111"}
            };
        IDictionary<string, string> revDict = new Dictionary<string, string>()
            {
                {"0000", "A"},
                {"0001", "B"},
                {"0010", "C"},
                {"0011", "D"},
                {"0100", "E"},
                {"0101", "F"},
                {"0110", "G"},
                {"0111", "H"},
                {"1000", "I"},
                {"1001", "J"},
                {"1010", "K"},
                {"1011", "L"},
                {"1100", "M"},
                {"1101", "N"},
                {"1110", "O"},
                {"1111", "P"}
            };
        //Method to convert input to corresponding char (see dict above)
        public string Input_String_To_Char_GUI(string input)
        {
            string oChar = "";
            for (int i = 0; i < input.Length; i = i + 4)
            {
                string splitString = input.Substring(i, 4);
                string tempChar;
                revDict.TryGetValue(splitString, out tempChar);
                oChar += tempChar;
            }

            return "[" + oChar + "]";
        }
        //Convert an input string of 1 and 0 to corresponding bits
        //Bitarrays reverse the order so tempArray reverses it back
        //array.reverse doesnt work on Bitarrays so easiest way to do it for now
        public BitArray String_To_Bits(string input)
        {
            byte[] byteArray = new byte[1];
            byteArray[0] = Convert.ToByte(input, 2);
            BitArray encryptedBitArray = new BitArray(byteArray);
            BitArray tempArray = new BitArray(8);
            tempArray[0] = encryptedBitArray[7];
            tempArray[1] = encryptedBitArray[6];
            tempArray[2] = encryptedBitArray[5];
            tempArray[3] = encryptedBitArray[4];
            tempArray[4] = encryptedBitArray[3];
            tempArray[5] = encryptedBitArray[2];
            tempArray[6] = encryptedBitArray[1];
            tempArray[7] = encryptedBitArray[0];
            return tempArray;
        }
        //Convert bits to string of 1 and 0 to output to GUI
        public String Bits_To_String(BitArray input)
        {
            byte[] backtoByte = new byte[1];
            input.CopyTo(backtoByte, 0);
            string plainText = Convert.ToString(backtoByte[0], 2).PadLeft(8, '0');
            return plainText;
        }
        //Doing another method to get bits from key
        //When converting using methods above, it added 0 padding and didnt want that
        public BitArray Key_To_Bits(string input)
        {
            BitArray keyBits = new BitArray(10);
            int i = 0;
            foreach(char b in input)
            {
                switch (b)
                {
                    case '0':
                        keyBits[i] = false;
                        break;
                    case '1':
                        keyBits[i] = true;
                        break;
                }
                i++;
            }
            //Console.WriteLine(Debug_BTS(keyBits));
            return keyBits;
        }
        public BitArray P10(BitArray keyBits)
        {
            //Permute key to 2 4 1 6 3 9 0 8 7 5
            BitArray p10 = new BitArray(10);
            p10[0] = keyBits[2];
            p10[1] = keyBits[4];
            p10[2] = keyBits[1];
            p10[3] = keyBits[6];
            p10[4] = keyBits[3];
            p10[5] = keyBits[9];
            p10[6] = keyBits[0];
            p10[7] = keyBits[8];
            p10[8] = keyBits[7];
            p10[9] = keyBits[5];
            //Console.WriteLine(Debug_BTS(p10));
            return p10;
        }
        public BitArray P8(BitArray input)
        {
            //permute key to 5 2 6 3 7 4 9 8
            BitArray p8 = new BitArray(8);
            p8[0] = input[5];
            p8[1] = input[2];
            p8[2] = input[6];
            p8[3] = input[3];
            p8[4] = input[7];
            p8[5] = input[4];
            p8[6] = input[9];
            p8[7] = input[8];
            //Console.WriteLine(Debug_BTS(p8));
            return p8;
        }

        public BitArray Initial_Permutation(BitArray plainText)
        {
            //Permute key to 1 5 2 0 3 7 4 6
            BitArray init_perm = new BitArray(8);
            init_perm[0] = plainText[1];
            init_perm[1] = plainText[5];
            init_perm[2] = plainText[2];
            init_perm[3] = plainText[0];
            init_perm[4] = plainText[3];
            init_perm[5] = plainText[7];
            init_perm[6] = plainText[4];
            init_perm[7] = plainText[6];
            //Console.WriteLine(Debug_BTS(init_perm));
            return init_perm;

        }
        //Left shift. Made one Function for 1 shift and two shifts
        public BitArray LS_1(BitArray input, int shiftCount)
        {
            BitArray left_shift = new BitArray(10);
            switch(shiftCount)
            {
                case 1:
                    left_shift[0] = input[1];
                    left_shift[1] = input[2];
                    left_shift[2] = input[3];
                    left_shift[3] = input[4];
                    left_shift[4] = input[0];
                    left_shift[5] = input[6];
                    left_shift[6] = input[7];
                    left_shift[7] = input[8];
                    left_shift[8] = input[9];
                    left_shift[9] = input[5];
                    break;
                case 2:
                    left_shift[0] = input[2];
                    left_shift[1] = input[3];
                    left_shift[2] = input[4];
                    left_shift[3] = input[0];
                    left_shift[4] = input[1];
                    left_shift[5] = input[7];
                    left_shift[6] = input[8];
                    left_shift[7] = input[9];
                    left_shift[8] = input[5];
                    left_shift[9] = input[6];
                    break;

            }
            //Console.WriteLine(Debug_BTS(left_shift));
            return left_shift;
        }
        public BitArray Expansion_Permutation(BitArray ipText)
        {
            // 3 0 1 2 1 2 3 0
            BitArray exp_perm = new BitArray(8);
            exp_perm[0] = ipText[3];
            exp_perm[1] = ipText[0];
            exp_perm[2] = ipText[1];
            exp_perm[3] = ipText[2];
            exp_perm[4] = ipText[1];
            exp_perm[5] = ipText[2];
            exp_perm[6] = ipText[3];
            exp_perm[7] = ipText[0];
            //Console.WriteLine(Debug_BTS(exp_perm));
            return exp_perm;
        }
        public BitArray SDES_XOR(BitArray epText, BitArray key)
        {/*XOR Function goes here. */
            return key.Xor(epText);
        }

        public BitArray P4(BitArray S0, BitArray S1)
        {/*P4 Function goes here. */
            BitArray p4 = new BitArray(4);
            p4[0] = S0[1];
            p4[1] = S1[1];
            p4[2] = S1[0];
            p4[3] = S0[0];
            //Console.WriteLine(Debug_BTS(p4));
            return p4;
        }

        public BitArray SDES_Swap(BitArray input)
        {/*Swap Function goes here. */
            // 4 5 6 7 0 1 2 3
            BitArray swapS = new BitArray(8);
            swapS[0] = input[4];
            swapS[1] = input[5];
            swapS[2] = input[6];
            swapS[3] = input[7];
            swapS[4] = input[0];
            swapS[5] = input[1];
            swapS[6] = input[2];
            swapS[7] = input[3];
            //Console.WriteLine(Debug_BTS(swapS));
            return swapS;
        }
        public BitArray Rev_IP(BitArray input)
        {//Inverse Initial Permutation Function goes here. 
         //Doing reverse order because of structure in c#
         //Could reverse in print out but easier to here
         // 3 0 2 4 6 1 7 5
            BitArray rev_ip = new BitArray(8);
            rev_ip[7] = input[3];
            rev_ip[6] = input[0];
            rev_ip[5] = input[2];
            rev_ip[4] = input[4];
            rev_ip[3] = input[6];
            rev_ip[2] = input[1];
            rev_ip[1] = input[7];
            rev_ip[0] = input[5];
            //Console.WriteLine(Debug_BTS(rev_ip));
            return rev_ip;
        }
        public BitArray Encrypt(BitArray plainText, BitArray key)
        { //Encrypt Function
            Console.WriteLine("Initial = " + Debug_BTS(plainText));
            //Arrays for storing values
            BitArray encrypted = new BitArray(8);
            BitArray temp = new BitArray(8);
            //Firstkey
            BitArray k1 = P8(LS_1(P10(key),1));
            Console.WriteLine("k1 = " + Debug_BTS(k1));
            //Second key
            BitArray k2 = P8(LS_1(LS_1(P10(key),1), 2));
            Console.WriteLine("k2 = " + Debug_BTS(k2));
            //Initial permuation
            temp = Initial_Permutation(plainText);
            Console.WriteLine("IP = " + Debug_BTS(temp));
            //fk function on key 1
            temp = fk(temp, k1);
            Console.WriteLine("fk key 1 = " + Debug_BTS(temp));
            //Swap
            temp = SDES_Swap(temp);
            Console.WriteLine("Swap = " + Debug_BTS(temp));
            //fk with key 2
            temp = fk(temp, k2);
            Console.WriteLine("fk key 2 = " + Debug_BTS(temp));
            //Inverse IP
            encrypted = Rev_IP(temp);
            Console.WriteLine("encrypted = " + Debug_BTS(encrypted));
            return encrypted;

            //return bits2byte(RIP(Fk(Switch(Fk(IP(bits_block), keys[0])), keys[1])));

        }
        //This method will Decrypt a bitarray given a key
        //Reverse of encryption
        public BitArray Decrypt(BitArray cipher, BitArray key)
        {
            BitArray decrypted = new BitArray(8);
            BitArray temp = new BitArray(8);
            BitArray k1 = P8(LS_1(P10(key), 1));
            BitArray k2 = P8(LS_1(LS_1(P10(key), 1), 2));
            Console.WriteLine("k1 = " + Debug_BTS(k1));
            Console.WriteLine("k2 = " + Debug_BTS(k2));
            temp = Initial_Permutation(cipher);
            Console.WriteLine("IP = " + Debug_BTS(temp));
            temp = fk(temp, k2);
            Console.WriteLine("fk key 1 = " + Debug_BTS(temp));
            temp = SDES_Swap(temp);
            Console.WriteLine("Swap = " + Debug_BTS(temp));
            temp = fk(temp, k1);
            Console.WriteLine("fk key 2 = " + Debug_BTS(temp));
            decrypted = Rev_IP(temp);
            Console.WriteLine("decrypted = " + Debug_BTS(decrypted));
            return decrypted;
        }
       
        public BitArray fk(BitArray input, BitArray key)
        {//fk function
            BitArray temp = new BitArray(8);
            BitArray[] split = Split_BA(input);
            BitArray leftNibble = SDES_XOR(split[0], SDES_F(split[1], key));
            int index = 0;
            for (int i = 0; i < 4; i++)
            {
                temp[index++] = leftNibble[i];
            }
            for (int i = 0; i < 4; i++)
            {
                temp[index++] = split[1][i];
            }
            return temp;
            
        }
        //Function to split Bitarrays into two equal length Bitarrays
        public BitArray[] Split_BA(BitArray input)
        {
            BitArray[] split = new BitArray[2];
            split[0] = new BitArray(input.Length / 2);
            split[1] = new BitArray(input.Length / 2);
            int j = 0;
            for(int i = 0; i < input.Length / 2; i++)
            {
                split[0][i] = input[j];
                j++;
            }
            for (int i = 0; i < input.Length / 2; i++)
            {
                split[1][i] = input[j];
                j++;
            }
            return split;
        }
        //F function to get sbox data for fk function
        public BitArray SDES_F(BitArray input, BitArray key)
        {
            BitArray temp = new BitArray(8);
            temp = SDES_XOR(Expansion_Permutation(input), key);

            BitArray[] split = Split_BA(temp);

            return P4(Sbox1[BA_To_Int(split[0][0], split[0][3]), BA_To_Int(split[0][1], split[0][2])], Sbox2[BA_To_Int(split[1][0], split[1][3]), BA_To_Int(split[1][1], split[1][2])]);
        }
        //Function to return an int value in order to access the sboxes
        public int BA_To_Int(bool input, bool input2)
        {
            if(input && input2)
            {
                return 3;
            }
            else if (input && !input2)
            {
                return 2;
            }
            else if (!input && input2)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        //Function to get string in order to  print out BitArrays
        //Used to print out to console for debugging
        public string Debug_BTS(BitArray input)
        {
            string outString = "";
            foreach(bool bit in input)
            {
                if (bit)
                {
                    outString += "1";
                }
                else
                {
                    outString += "0";
                }
            }
            return outString;

        }
    }
}
