using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Gce_Model;
using Model;
using Gce_Bll;

namespace Gce.pop_upWindows
{
    public partial class WorkScheduleForm : Office2007Form
    {
        //对象
        ProductionTypeBll ptb = new ProductionTypeBll();
        PWorkScheduleBll pwsb = new PWorkScheduleBll();

        //集合
        List<ProductionType> listproductiontype = new List<ProductionType>();
        List<PWorkSchedule> listPWorkSchedule = new List<PWorkSchedule>();
        List<string> liststrcbox_CompanyName = new List<string>();

        //状态
        //string state = "browse";
        public WorkScheduleForm()
        {
            InitializeComponent();
        }

        private void WorkScheduleForm_Load(object sender, EventArgs e)
        {
            getProductionType();
            SetControls();
            this.SetControls1();
        }

        private void getProductionType()
        {
            listproductiontype = ptb.selectProductionTypeBll("selectProductionType");
            listPWorkSchedule = pwsb.selectPWorkScheduleBll("selectPWorkSchedule");

            foreach (PWorkSchedule item in listPWorkSchedule)
            {
                liststrcbox_CompanyName.Add(item.CompanyName);
            }
            cbox_CompanyName.DataSource = liststrcbox_CompanyName;
        }
        /// <summary>
        /// 动态添加控件
        /// </summary>
        private void SetControls()
        {
            CheckBox cb1 = new CheckBox();
            cb1.Text = "全选";
            cb1.Name = "cb_All";
            cb1.Location = new Point(69, 6);//确定控件的位置

            cb1.CheckedChanged += new System.EventHandler(cb_All_CheckedChanged);//添加事件
            panelEx2.Controls.Add(cb1);//向pannel中添加控件
            if (listproductiontype.Count > 0)
            {
                int point = 6;
                for (int i = 0; i < listproductiontype.Count; i++)
                {
                    point += 36;
                    CheckBox cb = new CheckBox();
                    cb.Text = listproductiontype[i].ProductType;
                    cb.Name = "cb"+i.ToString();
                    cb.Checked = false;
                    cb.Location = new Point(20, point);

                    panelEx2.Controls.Add(cb);

                }
            }
        }
        /// <summary>
        /// cb_All_CheckedChanged事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cb_All_CheckedChanged(object sender,System.EventArgs e)
        { 
            CheckBox cb = (CheckBox)sender;//强转控件类型
            if(cb.Checked)
            {
                if(panelEx2.Controls.Count!=0)
                {
                    for (int i = 0; i < panelEx2.Controls.Count; i++)//遍历panel控件中的所有子控件
                    {
                        CheckBox cb1= (CheckBox)panelEx2.Controls[i];
                        cb1.Checked=true;
                    }
                }
            }
            else
            {
                if(panelEx2.Controls.Count!=0)
                {
                    for (int i = 0; i < panelEx2.Controls.Count; i++)
                    {
                        CheckBox cb1= (CheckBox)panelEx2.Controls[i];
                        cb1.Checked=false;
                    }
                }
            }
        }
        /// <summary>
        /// 新建
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_new_Click(object sender, EventArgs e)
        {
            this.ClearControls();
        }
        /// <summary>
        /// 情况控件值
        /// </summary>
        private void ClearControls()
        {
            if (panelEx2.Controls.Count != 0)
            {
                for (int i = 0; i < panelEx2.Controls.Count; i++)
                {
                    CheckBox cb1 = (CheckBox)panelEx2.Controls[i];
                    cb1.Checked = false;
                }
            }
            cbox_CompanyName.Text = "";
            dti_MorningOnWorkTime.Text = "";
            dti_MorningUnderWorkTime.Text = "";
            dti_AfternoonOnWorkTime.Text = "";
            dti_AfternoonUnderWorkTime.Text = "";
            dti_NightOnWorkTime.Text = "";
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (this.Message1())
            {
                return;
            }
            bool bl;
            bl = pwsb.insertPWorkScheduleBll(GetPWorkScheduleList(cbox_CompanyName.Text, Convert.ToString(dti_MorningOnWorkTime.Value), Convert.ToString(dti_MorningUnderWorkTime.Value), Convert.ToString(dti_AfternoonOnWorkTime.Value), Convert.ToString(dti_AfternoonUnderWorkTime.Value), Convert.ToString(dti_NightOnWorkTime.Value), this.cb_night.Checked), "insertPWorkSchedule");

            for (int i = 0; i < listproductiontype.Count; i++)
            {
                for (int j = 0; j < panelEx2.Controls.Count; j++)
                {
                    if (listproductiontype[i].ProductType == panelEx2.Controls[j].Text)
                    { 
                        CheckBox cb= (CheckBox)panelEx2.Controls[j];
                        if (cb_night.Checked)
                        {
                            if (cb.Checked)
                            {
                                ptb.updateProductionTypeOnWorkTimeTypeBll(cbox_CompanyName.Text, cb.Text.Trim(), "updateProductionTypeOnWorkTimeTypeNight");
                            }
                        }
                        else
                        {
                            if (cb.Checked)
                            {
                                ptb.updateProductionTypeOnWorkTimeTypeBll(cbox_CompanyName.Text, cb.Text.Trim(), "updateProductionTypeOnWorkTimeType");
                            }
                        }
                    }
                }
            }

            if (bl)
            {
                MessageBox.Show("保存成功!");
            }
            else
            {
                MessageBox.Show("是否已存在该公司名称，保存失败！");
            }
        }
        private bool Message1()
        {
            for (int i = 0; i < panelEx2.Controls.Count; i++)
            {
                List<CheckBox> list = new List<CheckBox>();
                CheckBox cb = panelEx2.Controls[i] as CheckBox;
                if (cb.Text != "全选")
                {
                    if (cb.Checked)
                    {
                        list.Add(cb);
                    }
                }
            }
            if (cbox_CompanyName.Text == "")
            {
                MessageBox.Show("公司名称不能为空！");
                return true;
            }
            else if (dti_MorningOnWorkTime.Text == "")
            {
                MessageBox.Show("上午上班时间不能为空！");
                return true;
            }
            else if (dti_MorningUnderWorkTime.Text == "")
            {
                MessageBox.Show("上午下班班时间不能为空！");
                return true;
            }
            else if (dti_AfternoonOnWorkTime.Text == "")
            {
                MessageBox.Show("下午上班时间不能为空！");
                return true;
            }
            else if (dti_MorningUnderWorkTime.Text == "")
            {
                MessageBox.Show("下午下班时间不能为空！");
                return true;
            }
            else if (dti_NightOnWorkTime.Text == "")
            {
                MessageBox.Show("晚上加班上班时间不能为空！");
                return true;
            }
            else if (listproductiontype.Count == 0)
            {
                MessageBox.Show("至少选择一个工位！");
                return true;
            }
            else
            {
                return false;
            }

        }

        private List<PWorkSchedule> GetPWorkScheduleList(string companyname, string morningonworktime, string morningUnderworktime, string afternoononworktime, string afternoonUnderworktime, string nighonworktime,bool flag)
        {
            List<PWorkSchedule> list = new List<PWorkSchedule>();

            list.Add(new PWorkSchedule()
            {
                CompanyName=companyname,
                MorningOnWorkTime=morningonworktime,
                MorningUnderWorkTime=morningUnderworktime,
                AfternoonOnWorkTime=afternoononworktime,
                AfternoonUnderWorkTime=afternoonUnderworktime,
                NightOnWorkTime=nighonworktime,
                Flag = flag
            });

            return list;
        }

        private void btn_Modify_Click(object sender, EventArgs e)
        {
            if (this.Message1())
            {
                return;
            }
            bool bl;
            bl = pwsb.insertPWorkScheduleBll(GetPWorkScheduleList(cbox_CompanyName.Text, Convert.ToString(dti_MorningOnWorkTime.Value), Convert.ToString(dti_MorningUnderWorkTime.Value), Convert.ToString(dti_AfternoonOnWorkTime.Value), Convert.ToString(dti_AfternoonUnderWorkTime.Value), Convert.ToString(dti_NightOnWorkTime.Value), this.cb_night.Checked), "updatePWorkSchedule");

            for (int i = 0; i < listproductiontype.Count; i++)
            {
                for (int j = 0; j < panelEx2.Controls.Count; j++)
                {
                    if (listproductiontype[i].ProductType == panelEx2.Controls[j].Text)
                    {
                        CheckBox cb = (CheckBox)panelEx2.Controls[j];
                        if (cb_night.Checked)
                        {
                            if (cb.Checked)
                            {
                                ptb.updateProductionTypeOnWorkTimeTypeBll(cbox_CompanyName.Text, cb.Text.Trim(), "updateProductionTypeOnWorkTimeTypeNight");
                            }
                        }
                        else
                        {
                            if (cb.Checked)
                            {
                                ptb.updateProductionTypeOnWorkTimeTypeBll(cbox_CompanyName.Text, cb.Text.Trim(), "updateProductionTypeOnWorkTimeType");
                            }
                        }
                    }
                }
            }
            if (bl)
            {
                MessageBox.Show("修改成功!");
            }
            else
            {
                MessageBox.Show("修改失败！");
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (cbox_CompanyName.Text == "")
            {
                MessageBox.Show("公司名称不能为空！");
                return;
            }

            if (pwsb.deletePWorkScheduleBll(cbox_CompanyName.Text.Trim(), "deletePWorkSchedule"))
            {
                MessageBox.Show("删除成功！");
                this.ClearControls();
                liststrcbox_CompanyName.Remove(cbox_CompanyName.Text);
                cbox_CompanyName.DataSource = liststrcbox_CompanyName;               
            }
            else
            {
                MessageBox.Show("该记录可能不存在,删除失败！");
            }
        }

        private void cbox_CompanyName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.SetControls1();
        }

        void SetControls1()
        {
            foreach (PWorkSchedule item in listPWorkSchedule)
            {
                if (item.CompanyName ==cbox_CompanyName.SelectedItem.ToString())
                {
                    dti_MorningOnWorkTime.Text = item.MorningOnWorkTime;
                    dti_MorningUnderWorkTime.Text = item.MorningUnderWorkTime;
                    dti_AfternoonOnWorkTime.Text = item.AfternoonOnWorkTime;
                    dti_AfternoonUnderWorkTime.Text = item.AfternoonUnderWorkTime;
                    dti_NightOnWorkTime.Text = item.NightOnWorkTime;
                    cb_night.Checked = item.Flag;
                }
            }
            List<string> liststr = new List<string>();
            liststr = ptb.selectProductionTypeProductTypeBll(cbox_CompanyName.SelectedItem.ToString(), "selectProductionTypeProductType");
            for (int i = 0; i < panelEx2.Controls.Count; i++)
            {
                CheckBox cb = panelEx2.Controls[i] as CheckBox;
                cb.Checked = false;
                for (int j = 0; j < liststr.Count; j++)
                {
                    if (cb.Text.Trim() == liststr[j].Trim())
                    {
                        cb.Checked = true;
                    }
                }
            }
        }

        private void cb_night_CheckedChanged(object sender, CheckBoxChangeEventArgs e)
        {
            cb_nightChanged(cb_night.Checked);
        }

        void cb_nightChanged(bool bl)
        {
            if (bl)
            {
                labelX2.Text = "一次上班时间(夜)";
                labelX3.Text = "一次下班时间(夜)";
                labelX4.Text = "二次上班时间(夜)";
                labelX5.Text = "二次下班时间(夜)";
                labelX6.Text = "早上加班上班时间(夜)";
            }
            else
            {
                labelX2.Text = "上午上班时间(白)";
                labelX3.Text = "上午下班时间(白)";
                labelX4.Text = "下午上班时间(白)";
                labelX5.Text = "下午下班时间(白)";
                labelX6.Text = "晚上加班上班时间(白)";
            }
        }
    }
}
