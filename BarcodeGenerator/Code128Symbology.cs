using System;
using System.Collections.Generic;
add one one for r2_index 02
using System.Text;


namespace BarcodeGenerator
{
    public class Code128Symbology : BarcodeSymbology
    {
        #region Map Data
        private readonly static SymbolMap<byte> _symbolMap = new SymbolMap<byte>();
        private readonly static Dictionary<char, byte> _charSetB = new Dictionary<char, byte>();

        static Code128Symbology()
        {
            #region SymbolMap

            _symbolMap.Add(0, 1, 1, 0, 1, 1, 0, 0, 1, 1, 0, 0);
            _symbolMap.Add(1, 1, 1, 0, 0, 1, 1, 0, 1, 1, 0, 0);
            _symbolMap.Add(2, 1, 1, 0, 0, 1, 1, 0, 0, 1, 1, 0);
            _symbolMap.Add(3, 1, 0, 0, 1, 0, 0, 1, 1, 0, 0, 0);
            _symbolMap.Add(4, 1, 0, 0, 1, 0, 0, 0, 1, 1, 0, 0);
            _symbolMap.Add(5, 1, 0, 0, 0, 1, 0, 0, 1, 1, 0, 0);
            _symbolMap.Add(6, 1, 0, 0, 1, 1, 0, 0, 1, 0, 0, 0);
            _symbolMap.Add(7, 1, 0, 0, 1, 1, 0, 0, 0, 1, 0, 0);
            _symbolMap.Add(8, 1, 0, 0, 0, 1, 1, 0, 0, 1, 0, 0);
            _symbolMap.Add(9, 1, 1, 0, 0, 1, 0, 0, 1, 0, 0, 0);
            _symbolMap.Add(10, 1, 1, 0, 0, 1, 0, 0, 0, 1, 0, 0);
            _symbolMap.Add(11, 1, 1, 0, 0, 0, 1, 0, 0, 1, 0, 0);
            _symbolMap.Add(12, 1, 0, 1, 1, 0, 0, 1, 1, 1, 0, 0);
            _symbolMap.Add(13, 1, 0, 0, 1, 1, 0, 1, 1, 1, 0, 0);
            _symbolMap.Add(14, 1, 0, 0, 1, 1, 0, 0, 1, 1, 1, 0);
            _symbolMap.Add(15, 1, 0, 1, 1, 1, 0, 0, 1, 1, 0, 0);
            _symbolMap.Add(16, 1, 0, 0, 1, 1, 1, 0, 1, 1, 0, 0);
            _symbolMap.Add(17, 1, 0, 0, 1, 1, 1, 0, 0, 1, 1, 0);
            _symbolMap.Add(18, 1, 1, 0, 0, 1, 1, 1, 0, 0, 1, 0);
            _symbolMap.Add(19, 1, 1, 0, 0, 1, 0, 1, 1, 1, 0, 0);
            _symbolMap.Add(20, 1, 1, 0, 0, 1, 0, 0, 1, 1, 1, 0);
            _symbolMap.Add(21, 1, 1, 0, 1, 1, 1, 0, 0, 1, 0, 0);
            _symbolMap.Add(22, 1, 1, 0, 0, 1, 1, 1, 0, 1, 0, 0);
            _symbolMap.Add(23, 1, 1, 1, 0, 1, 1, 0, 1, 1, 1, 0);
            _symbolMap.Add(24, 1, 1, 1, 0, 1, 0, 0, 1, 1, 0, 0);
            _symbolMap.Add(25, 1, 1, 1, 0, 0, 1, 0, 1, 1, 0, 0);
            _symbolMap.Add(26, 1, 1, 1, 0, 0, 1, 0, 0, 1, 1, 0);
            _symbolMap.Add(27, 1, 1, 1, 0, 1, 1, 0, 0, 1, 0, 0);
            _symbolMap.Add(28, 1, 1, 1, 0, 0, 1, 1, 0, 1, 0, 0);
            _symbolMap.Add(29, 1, 1, 1, 0, 0, 1, 1, 0, 0, 1, 0);
            _symbolMap.Add(30, 1, 1, 0, 1, 1, 0, 1, 1, 0, 0, 0);
            _symbolMap.Add(31, 1, 1, 0, 1, 1, 0, 0, 0, 1, 1, 0);
            _symbolMap.Add(32, 1, 1, 0, 0, 0, 1, 1, 0, 1, 1, 0);
            _symbolMap.Add(33, 1, 0, 1, 0, 0, 0, 1, 1, 0, 0, 0);
            _symbolMap.Add(34, 1, 0, 0, 0, 1, 0, 1, 1, 0, 0, 0);
            _symbolMap.Add(35, 1, 0, 0, 0, 1, 0, 0, 0, 1, 1, 0);
            _symbolMap.Add(36, 1, 0, 1, 1, 0, 0, 0, 1, 0, 0, 0);
            _symbolMap.Add(37, 1, 0, 0, 0, 1, 1, 0, 1, 0, 0, 0);
            _symbolMap.Add(38, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 0);
            _symbolMap.Add(39, 1, 1, 0, 1, 0, 0, 0, 1, 0, 0, 0);
            _symbolMap.Add(40, 1, 1, 0, 0, 0, 1, 0, 1, 0, 0, 0);
            _symbolMap.Add(41, 1, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0);
            _symbolMap.Add(42, 1, 0, 1, 1, 0, 1, 1, 1, 0, 0, 0);
            _symbolMap.Add(43, 1, 0, 1, 1, 0, 0, 0, 1, 1, 1, 0);
            _symbolMap.Add(44, 1, 0, 0, 0, 1, 1, 0, 1, 1, 1, 0);
            _symbolMap.Add(45, 1, 0, 1, 1, 1, 0, 1, 1, 0, 0, 0);
            _symbolMap.Add(46, 1, 0, 1, 1, 1, 0, 0, 0, 1, 1, 0);
            _symbolMap.Add(47, 1, 0, 0, 0, 1, 1, 1, 0, 1, 1, 0);
            _symbolMap.Add(48, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 0);
            _symbolMap.Add(49, 1, 1, 0, 1, 0, 0, 0, 1, 1, 1, 0);
            _symbolMap.Add(50, 1, 1, 0, 0, 0, 1, 0, 1, 1, 1, 0);
            _symbolMap.Add(51, 1, 1, 0, 1, 1, 1, 0, 1, 0, 0, 0);
            _symbolMap.Add(52, 1, 1, 0, 1, 1, 1, 0, 0, 0, 1, 0);
            _symbolMap.Add(53, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0);
            _symbolMap.Add(54, 1, 1, 1, 0, 1, 0, 1, 1, 0, 0, 0);
            _symbolMap.Add(55, 1, 1, 1, 0, 1, 0, 0, 0, 1, 1, 0);
            _symbolMap.Add(56, 1, 1, 1, 0, 0, 0, 1, 0, 1, 1, 0);
            _symbolMap.Add(57, 1, 1, 1, 0, 1, 1, 0, 1, 0, 0, 0);
            _symbolMap.Add(58, 1, 1, 1, 0, 1, 1, 0, 0, 0, 1, 0);
            _symbolMap.Add(59, 1, 1, 1, 0, 0, 0, 1, 1, 0, 1, 0);
            _symbolMap.Add(60, 1, 1, 1, 0, 1, 1, 1, 1, 0, 1, 0);
            _symbolMap.Add(61, 1, 1, 0, 0, 1, 0, 0, 0, 0, 1, 0);
            _symbolMap.Add(62, 1, 1, 1, 1, 0, 0, 0, 1, 0, 1, 0);
            _symbolMap.Add(63, 1, 0, 1, 0, 0, 1, 1, 0, 0, 0, 0);
            _symbolMap.Add(64, 1, 0, 1, 0, 0, 0, 0, 1, 1, 0, 0);
            _symbolMap.Add(65, 1, 0, 0, 1, 0, 1, 1, 0, 0, 0, 0);
            _symbolMap.Add(66, 1, 0, 0, 1, 0, 0, 0, 0, 1, 1, 0);
            _symbolMap.Add(67, 1, 0, 0, 0, 0, 1, 0, 1, 1, 0, 0);
            _symbolMap.Add(68, 1, 0, 0, 0, 0, 1, 0, 0, 1, 1, 0);
            _symbolMap.Add(69, 1, 0, 1, 1, 0, 0, 1, 0, 0, 0, 0);
            _symbolMap.Add(70, 1, 0, 1, 1, 0, 0, 0, 0, 1, 0, 0);
            _symbolMap.Add(71, 1, 0, 0, 1, 1, 0, 1, 0, 0, 0, 0);
            _symbolMap.Add(72, 1, 0, 0, 1, 1, 0, 0, 0, 0, 1, 0);
            _symbolMap.Add(73, 1, 0, 0, 0, 0, 1, 1, 0, 1, 0, 0);
            _symbolMap.Add(74, 1, 0, 0, 0, 0, 1, 1, 0, 0, 1, 0);
            _symbolMap.Add(75, 1, 1, 0, 0, 0, 0, 1, 0, 0, 1, 0);
            _symbolMap.Add(76, 1, 1, 0, 0, 1, 0, 1, 0, 0, 0, 0);
            _symbolMap.Add(77, 1, 1, 1, 1, 0, 1, 1, 1, 0, 1, 0);
            _symbolMap.Add(78, 1, 1, 0, 0, 0, 0, 1, 0, 1, 0, 0);
            _symbolMap.Add(79, 1, 0, 0, 0, 1, 1, 1, 1, 0, 1, 0);
            _symbolMap.Add(80, 1, 0, 1, 0, 0, 1, 1, 1, 1, 0, 0);
            _symbolMap.Add(81, 1, 0, 0, 1, 0, 1, 1, 1, 1, 0, 0);
            _symbolMap.Add(82, 1, 0, 0, 1, 0, 0, 1, 1, 1, 1, 0);
            _symbolMap.Add(83, 1, 0, 1, 1, 1, 1, 0, 0, 1, 0, 0);
            _symbolMap.Add(84, 1, 0, 0, 1, 1, 1, 1, 0, 1, 0, 0);
            _symbolMap.Add(85, 1, 0, 0, 1, 1, 1, 1, 0, 0, 1, 0);
            _symbolMap.Add(86, 1, 1, 1, 1, 0, 1, 0, 0, 1, 0, 0);
            _symbolMap.Add(87, 1, 1, 1, 1, 0, 0, 1, 0, 1, 0, 0);
            _symbolMap.Add(88, 1, 1, 1, 1, 0, 0, 1, 0, 0, 1, 0);
            _symbolMap.Add(89, 1, 1, 0, 1, 1, 0, 1, 1, 1, 1, 0);
            _symbolMap.Add(90, 1, 1, 0, 1, 1, 1, 1, 0, 1, 1, 0);
            _symbolMap.Add(91, 1, 1, 1, 1, 0, 1, 1, 0, 1, 1, 0);
            _symbolMap.Add(92, 1, 0, 1, 0, 1, 1, 1, 1, 0, 0, 0);
            _symbolMap.Add(93, 1, 0, 1, 0, 0, 0, 1, 1, 1, 1, 0);
            _symbolMap.Add(94, 1, 0, 0, 0, 1, 0, 1, 1, 1, 1, 0);
            _symbolMap.Add(95, 1, 0, 1, 1, 1, 1, 0, 1, 0, 0, 0);
            _symbolMap.Add(96, 1, 0, 1, 1, 1, 1, 0, 0, 0, 1, 0);
            _symbolMap.Add(97, 1, 1, 1, 1, 0, 1, 0, 1, 0, 0, 0);
            _symbolMap.Add(98, 1, 1, 1, 1, 0, 1, 0, 0, 0, 1, 0);
            _symbolMap.Add(99, 1, 0, 1, 1, 1, 0, 1, 1, 1, 1, 0);
            _symbolMap.Add(100, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 0);
            _symbolMap.Add(101, 1, 1, 1, 0, 1, 0, 1, 1, 1, 1, 0);
            _symbolMap.Add(102, 1, 1, 1, 1, 0, 1, 0, 1, 1, 1, 0);

            #endregion

            #region Map [B]

            _charSetB.Add(' ', 0);
            _charSetB.Add('!', 1);
            _charSetB.Add('"', 2);
            _charSetB.Add('#', 3);
            _charSetB.Add('$', 4);
            _charSetB.Add('%', 5);
            _charSetB.Add('&', 6);
            _charSetB.Add('\'', 7);
            _charSetB.Add('(', 8);
            _charSetB.Add(')', 9);
            _charSetB.Add('*', 10);
            _charSetB.Add('+', 11);
            _charSetB.Add(',', 12);
            _charSetB.Add('-', 13);
            _charSetB.Add('.', 14);
            _charSetB.Add('/', 15);
            _charSetB.Add('0', 16);
            _charSetB.Add('1', 17);
            _charSetB.Add('2', 18);
            _charSetB.Add('3', 19);
            _charSetB.Add('4', 20);
            _charSetB.Add('5', 21);
            _charSetB.Add('6', 22);
            _charSetB.Add('7', 23);
            _charSetB.Add('8', 24);
            _charSetB.Add('9', 25);
            _charSetB.Add(':', 26);
            _charSetB.Add(';', 27);
            _charSetB.Add('<', 28);
            _charSetB.Add('=', 29);
            _charSetB.Add('>', 30);
            _charSetB.Add('?', 31);
            _charSetB.Add('@', 32);
            _charSetB.Add('A', 33);
            _charSetB.Add('B', 34);
            _charSetB.Add('C', 35);
            _charSetB.Add('D', 36);
            _charSetB.Add('E', 37);
            _charSetB.Add('F', 38);
            _charSetB.Add('G', 39);
            _charSetB.Add('H', 40);
            _charSetB.Add('I', 41);
            _charSetB.Add('J', 42);
            _charSetB.Add('K', 43);
            _charSetB.Add('L', 44);
            _charSetB.Add('M', 45);
            _charSetB.Add('N', 46);
            _charSetB.Add('O', 47);
            _charSetB.Add('P', 48);
            _charSetB.Add('Q', 49);
            _charSetB.Add('R', 50);
            _charSetB.Add('S', 51);
            _charSetB.Add('T', 52);
            _charSetB.Add('U', 53);
            _charSetB.Add('V', 54);
            _charSetB.Add('W', 55);
            _charSetB.Add('X', 56);
            _charSetB.Add('Y', 57);
            _charSetB.Add('Z', 58);
            _charSetB.Add('[', 59);
            _charSetB.Add('\\', 60);
            _charSetB.Add(']', 61);
            _charSetB.Add('^', 62);
            _charSetB.Add('_', 63);
            _charSetB.Add('`', 64);
            _charSetB.Add('a', 65);
            _charSetB.Add('b', 66);
            _charSetB.Add('c', 67);
            _charSetB.Add('d', 68);
            _charSetB.Add('e', 69);
            _charSetB.Add('f', 70);
            _charSetB.Add('g', 71);
            _charSetB.Add('h', 72);
            _charSetB.Add('i', 73);
            _charSetB.Add('j', 74);
            _charSetB.Add('k', 75);
            _charSetB.Add('l', 76);
            _charSetB.Add('m', 77);
            _charSetB.Add('n', 78);
            _charSetB.Add('o', 79);
            _charSetB.Add('p', 80);
            _charSetB.Add('q', 81);
            _charSetB.Add('r', 82);
            _charSetB.Add('s', 83);
            _charSetB.Add('t', 84);
            _charSetB.Add('u', 85);
            _charSetB.Add('v', 86);
            _charSetB.Add('w', 87);
            _charSetB.Add('x', 88);
            _charSetB.Add('y', 89);
            _charSetB.Add('z', 90);
            _charSetB.Add('{', 91);
            _charSetB.Add('|', 92);
            _charSetB.Add('}', 93);
            _charSetB.Add('~', 94);

            #endregion
        }
        #endregion

        private bool _useNumericCompression;
        public Code128Symbology(bool useNumericCompression)
        {
            _useNumericCompression = useNumericCompression;
        }

        public Code128Symbology()
            : this(true)
        {
        }

        protected override int QuietLength
        {
            get { return 10; }
        }

        protected override void ProcessCode(string barcode)
        {
            bool useCodeC = _useNumericCompression;
            if (useCodeC)
            {
                foreach (char c in barcode)
                {
                    if (c < '0' || c > '9')
                    {
                        useCodeC = false;
                        break;
                    }
                }
            }

            int checksum = 0;
            int charIndex = 1;
            if (useCodeC) // Use Code C compression
            {
                checksum += 105; // StartC
                Add(1, 1, 0, 1, 0, 0, 1, 1, 1, 0, 0);
                for (int i = 0; i < barcode.Length; i += 2)
                {
                    string num = new string(barcode[i], 1);
                    if (i < barcode.Length - 1) // not last char
                    {
                        num += barcode[i + 1];
                        byte code = byte.Parse(num);

                        checksum += code * charIndex++;
                        Add(_symbolMap[code]);
                    }
                    else
                    {
                        checksum += 100 * charIndex++;
                        Add(1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 0); // Code B

                        byte code = _charSetB[barcode[i]];
                        checksum += code * charIndex++;
                        Add(_symbolMap[code]);
                    }
                }
            }
            else // Use Code B
            {
                checksum += 104; // StartB
                Add(1, 1, 0, 1, 0, 0, 1, 0, 0, 0, 0);
                foreach (char c in barcode)
                {
                    byte code = _charSetB[c];
                    checksum += code * charIndex++;
                    Add(_symbolMap[code]);
                }
            }

            byte checkBit = (byte)(checksum % 103);
            Add(_symbolMap[checkBit]);

            Add(1, 1, 0, 0, 0, 1, 1, 1, 0, 1, 0);
            Add(1, 1); // Terminator Bar 
        }
    }
}
