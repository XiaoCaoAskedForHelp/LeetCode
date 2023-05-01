namespace LeetCode.分治法;

public class Soluton190颠倒二进制位
{
    public uint reverseBits(uint n)
    {
        uint res = 0;
        for (int i = 0; i < 32 && n!= 0; i++)
        {
            res |= (uint)(n & 1) << (31 - i);
            n >>= 1;
        }

        return res;
    }
    
    //位运算分治
    //若要翻转一个二进制串，可以将其均分成左右两部分，对每部分递归执行翻转操作，然后将左半部分拼在右半部分的后面，即完成了翻转。
    private readonly int M1 = 0x55555555; // 01010101010101010101010101010101
    private readonly int M2 = 0x33333333; // 00110011001100110011001100110011
    private readonly int M4 = 0x0f0f0f0f; // 00001111000011110000111100001111
    private readonly int M8 = 0x00ff00ff; // 00000000111111110000000011111111

    public uint reverseBits1(uint n) {
        n = (uint)(n >> 1 & M1 | (n & M1) << 1);
        n = (uint)(n >> 2 & M2 | (n & M2) << 2);
        n = (uint)(n >> 4 & M4 | (n & M4) << 4);
        n = (uint)(n >> 8 & M8 | (n & M8) << 8);
        return (uint)(n >> 16 | n << 16);
    }
}