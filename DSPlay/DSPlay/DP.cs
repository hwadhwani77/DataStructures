using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSPlay
{
    public class DP
    {
        int[] lookup { get; set; }
        public DP()
        {
            lookup = new int[100];
        }
        public int MemoFibo(int n)
        {
            if (lookup[n] <= 0)
            {
                if (n <= 1)
                    lookup[n] = n;
                else
                    lookup[n] = MemoFibo(n - 1) + MemoFibo(n - 2);
            }
            return lookup[n];
        }

        public int TabFibo(int n)
        {
            int[] f = new int[n + 1];
            f[0] = 0;
            f[1] = 1;

            for (int i = 2; i <= n; i++)
                f[i] = f[i - 1] + f[i - 2];

            return f[n];
        }

        public int MemoFacto(int n)
        {
            if (lookup[n] <= 0)
            {
                if (n <= 0)
                    return 1;
                else
                {
                    lookup[n] = MemoFacto(n - 1) * n;
                }
            }
            return lookup[n];
        }

        public int TabFacto(int n)
        {
            int[] f = new int[n + 1];
            f[0] = 1;            

            for (int i = 1; i <= n; i++)
                f[i] = i * f[i - 1];

            return f[n];
        }
    }
}
