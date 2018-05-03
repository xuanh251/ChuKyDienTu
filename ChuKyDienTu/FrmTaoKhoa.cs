using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace ChuKyDienTu
{
    public partial class FrmTaoKhoa : DevExpress.XtraEditors.XtraForm
    {
        public FrmTaoKhoa()
        {
            InitializeComponent();
            TaoSNT();
        }
        private long sntngaunhien()
        {
            Random random = new Random();
            long k = 2L;
            while (((k < 5L) || (k > 0x270fL)) || !ktnt(k))
            {
                k = random.Next(5, 0x270f);
            }
            return k;
        }
        public bool ktnt(long k)
        {
            if (k < 2L)
            {
                return false;
            }
            for (long i = 2L; i <= (k / 2L); i += 1L)
            {
                if ((k % i) == 0L)
                {
                    return false;
                }
            }
            return true;
        }
        public long max(long a, long b)
        {
            if (a >= b)
            {
                return a;
            }
            return b;
        }
        public long nd(long a, long b)
        {
            long num2 = 1L;
            while ((((num2 * b) + 1L) % a) != 0L)
            {
                num2 += 1L;
            }
            return (((num2 * b) + 1L) / a);
        }
        public long ucln(long a, long b)
        {
            while (b != 0L)
            {
                long num2 = a % b;
                a = b;
                b = num2;
            }
            return a;
        }
        private void btnTaoSNT_Click(object sender, EventArgs e)
        {
            TaoSNT();
        }
        private void TaoSNT()
        {
            long num = sntngaunhien();
            long num2 = sntngaunhien();
            while (num == num2)
            {
                num2 = sntngaunhien();
            }
            txtSNT1.Text = Convert.ToString(num);
            txtSNT2.Text = Convert.ToString(num2);
        }
        long N = 0L;
        long E = 0L;
        long D = 0L;
        private void BtnTaoKhoa_Click(object sender, EventArgs e)
        {
            long snt1 = Convert.ToInt64(txtSNT1.Text);
            long snt2 = Convert.ToInt64(txtSNT2.Text);
            N = snt1 * snt2;
            txtNBM.Text = txtNCK.Text = N.ToString();
            long num3 = (snt2 - 1L) * (snt1 - 1L);
            long num4 = this.max(snt1, snt2);
            E = num4 + 1L;
            do
            {
                E += 1L;
            }
            while (ucln(E, num3) != 1L);
            D = nd(E, num3);
            txtE.Text = E.ToString();
            txtD.Text = D.ToString();
            Program.bienD = this.D.ToString();
            Program.bienE = this.E.ToString();
            Program.bienN = this.N.ToString();
        }

        private void txtSNT1_EditValueChanged(object sender, EventArgs e)
        {
            Program.bienq = txtSNT1.Text;
        }

        private void txtSNT2_EditValueChanged(object sender, EventArgs e)
        {
            Program.bienp = txtSNT2.Text;
        }
    }
    
}