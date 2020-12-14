using System;
using UnityEngine;

namespace AssemblyCSharp.Assets.Scripts
{
    public class BinaryParameterStorage
    {
        private uint value = 0;
        private int length, left, right;

        public BinaryParameterStorage(int length, int left, int right)
        {
            if ((left > length) || (right > length))
            {
                throw new Exception("Length must be bigger that left and right");
            }

            this.left = left;
            this.right = right;
            this.length = length;

            int middle = length - (length - right) - (length - left);


            for (int i = 0; i < middle; i+=2) {
                value <<= 2;
                value |= 1;
                Debug.Log("=>" + Convert.ToString(value, 2));
            }

            uint tmp = 1;
            for(int i = 0; i < (this.length - this.right - 1); ++i)
            {
                tmp <<= 1;
                tmp |= 1;
            }
            tmp <<= this.right;

            Debug.Log("TMP=" + Convert.ToString(tmp, 2));

            value <<= (length - left);
            value |= tmp;
        }

        public int GetLeft()
        {
            int ret = 0;
            var val = this.value >> (this.length - this.left);
            for (int i = 0; i < left; ++i)
            {
                if ((val & 1) == 0) ret += 1;
                val >>= 1;
            }
            return ret;
        }

        public int GetRight()
        {
            int ret = 0;
            var val = this.value;
            for (int i = 0; i < right; ++i)
            {
                if ((val & 1) == 1) ret += 1;
                val >>= 1;
            }
            return ret;
        }

        public uint GetValue()
        {
            return this.value;
        }
    }
}
