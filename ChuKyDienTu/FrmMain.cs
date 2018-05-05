using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;

namespace ChuKyDienTu
{
    public partial class FrmMain : DevExpress.XtraEditors.XtraForm
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        public void XtraTabbedMdiManager_Add_Or_Select_ChildForm(Form pForm, System.Drawing.Image pImage = null, bool pAllowReplaceForm = false)
        {
            try
            {
                //Cho phép đè lên Form cũ
                if ((pAllowReplaceForm))
                {
                    Form _Form = default(Form);

                    foreach (DevExpress.XtraTabbedMdi.XtraMdiTabPage _Page in this.xtraTabbedMdiManagerMain.Pages)
                    {
                        if ((_Page.MdiChild.Name == pForm.Name))
                        {
                            this.xtraTabbedMdiManagerMain.Pages.Remove(_Page);
                            _Form = pForm;
                            _Form.Text = _Form.Text.ToUpper();
                            _Form.MdiParent = xtraTabbedMdiManagerMain.MdiParent;
                            if ((pImage != null))
                            {
                                xtraTabbedMdiManagerMain.Pages[_Form].Image = pImage;
                            }
                            _Form.Show();
                            return;
                        }
                    }

                    _Form = pForm;
                    _Form.Text = _Form.Text.ToUpper();
                    _Form.MdiParent = xtraTabbedMdiManagerMain.MdiParent;
                    if ((pImage != null))
                    {
                        xtraTabbedMdiManagerMain.Pages[_Form].Image = pImage;
                    }
                    _Form.Show();
                    //Không cho phép đè lên Form cũ, mà chỉ hiển thị lại
                }
                else
                {
                    foreach (DevExpress.XtraTabbedMdi.XtraMdiTabPage _Page in this.xtraTabbedMdiManagerMain.Pages)
                    {
                        if ((_Page.MdiChild.Name == pForm.Name))
                        {
                            if ((pImage != null))
                            {
                                _Page.Image = pImage;
                            }

                            _Page.MdiChild.Activate();
                            return;
                        }
                    }
                    Form _Form = pForm;
                    _Form.Text = _Form.Text.ToUpper();
                    _Form.MdiParent = xtraTabbedMdiManagerMain.MdiParent;
                    if ((pImage != null))
                    {
                        xtraTabbedMdiManagerMain.Pages[_Form].Image = pImage;
                    }
                    _Form.Show();
                }
            }
            catch (System.Exception _Ex)
            {
                XtraMessageBox.Show(_Ex.Message, "XtraTabbedMdiManager_Add_Or_Select_ChildForm", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnTaoCapKhoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmTaoKhoa f = new FrmTaoKhoa();
            f.ShowDialog();
        }

        private void BtnKyVanBan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraTabbedMdiManager_Add_Or_Select_ChildForm(new FrmKyVanBan());
        }

        private void BtnXacNhanChuKy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraTabbedMdiManager_Add_Or_Select_ChildForm(new FrmXacNhan());
        }

        private void BtnNhomThucHien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraMessageBox.Show("PHẦN MỀM TẠO VÀ KIỂM TRA CHỮ KÝ ĐIỆN TỬ CHO VĂN BẢN." + Environment.NewLine + "Nhóm thực hiện: Nhóm 6 - DT15CTT01" + Environment.NewLine + "-Lê Xuân Hoàng (nhóm trưởng)" + Environment.NewLine + "-Phạm Thanh Thịnh" + Environment.NewLine + "-Hà Quốc Dũng" + Environment.NewLine + "-Nguyễn Hiếu Nghĩa" + Environment.NewLine + "-Nguyễn Quỳnh" + Environment.NewLine + "Tháng 5/2018", "Giới thiệu", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}