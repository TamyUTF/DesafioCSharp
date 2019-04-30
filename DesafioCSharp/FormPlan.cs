using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesafioCSharp
{
    public partial class FormPlan : Form
    {
        internal static int index;
        PlanDAO planDao = new PlanDAO();
        internal List<Plan> planList = new List<Plan>();
        internal List<Plan> resultList = new List<Plan>();
        internal bool edit;
        public FormPlan()
        {
            InitializeComponent();
            if (!planList.Any())
            {
                planDao.SelectAll();
                planDao.ListAll();
                planList = planDao.GetList();
            }
            index = 0;
        }

        private void BSave_Click(object sender, EventArgs e)
        {
            if (tName.ReadOnly)
            {
                MessageBox.Show("Crie um novo plano.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else {
                if (edit == true)
                {
                    if (tName.Text == "")
                    {
                        MessageBox.Show("Selecione um plano para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        bool returnDao = planDao.UpdatePlan(new Plan(planList[index].Id,tName.Text, tStartDate.Value, tEndDate.Value));
                        if (returnDao == true)
                        {
                            MessageBox.Show("Plano atualizado com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            planDao.ListAll();
                        }
                        else if (returnDao == false)
                        {
                            MessageBox.Show("Ocorreu um erro :(", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    edit = false;
                }
                else
                {
                    if (tName.Text == "")
                    {
                        MessageBox.Show("Forneça um nome para o plano.");
                    }
                    else
                    {
                        bool returnDao = planDao.InsertPlan(new Plan(tName.Text, tStartDate.Value, tEndDate.Value));
                        if (returnDao == true)
                        {
                            MessageBox.Show("Plano criado com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            planDao.ListAll();
                        }
                        else if (returnDao == false)
                        {
                            MessageBox.Show("Ocorreu um erro :(", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }

            edit = false;
        }

        private void TSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if((Keys)e.KeyCode == Keys.Enter)
            {
                planList = planDao.SearchPlan(tSearch.Text);
                if (!planList.Any()) //se estiver vazio
                {
                    MessageBox.Show("Não há planos com este nome","Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    planList.Clear();
                    planDao.ListAll();
                }
                else
                {
                    index = 0;
                    tName.ReadOnly = true;
                    tStartDate.Enabled = false;
                    tEndDate.Enabled = false;
                    tName.Text = planList[index].Name;
                    tStartDate.Value = planList[index].StartDate;
                    tEndDate.Value = planList[index].EndDate;
                }
            }
        }

        private void BNext_Click(object sender, EventArgs e)
        {
            try
            {
                if (!planList.Any())//verifica se está vazio
                {
                    MessageBox.Show("Não há planos para mostrar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if(!tName.ReadOnly && index == 0)
                {
                    tName.ReadOnly = true;
                    tStartDate.Enabled = false;
                    tEndDate.Enabled = false;
                    tName.Text = planList[0].Name;
                    tStartDate.Value = planList[0].StartDate;
                    tStartDate.Value = planList[0].EndDate;
                }
                else
                if (index < planList.Count())
                {
                    index++;
                    if (index >= planList.Count())
                    {
                        MessageBox.Show("Não há mais usuários para mostrar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        index--;
                    }
                    else
                    {
                        tName.ReadOnly = true;
                        tStartDate.Enabled = false;
                        tEndDate.Enabled = false;
                        tName.Text = planList[index].Name;
                        tStartDate.Value = planList[index].StartDate;
                        tStartDate.Value = planList[index].EndDate;
                    }
                }

            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("Ocorreu um erro:" + ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro: " + ex);
            }
        }

        private void BDelete_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Deseja excluir o usuário?", "Aviso", MessageBoxButtons.YesNo);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                if (tName.Text == "" || tStartDate.Value.ToString() == "" || tEndDate.Value.ToString() == "")
                {
                    MessageBox.Show("Selecione um plano para deletar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    bool returnDao = planDao.DeletePlan(planList[index], index);
                    if (returnDao == true)
                    {
                        MessageBox.Show("Plano deletado com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        planDao.ListAll();
                        if (index == 0 ) //deletou o primeiro
                        {
                            tName.Text = "";
                        }else if(index > 0)
                        {
                            index--;
                            tName.Text = planList[index].Name;
                            tStartDate.Value = planList[index].StartDate;
                            tEndDate.Value = planList[index].EndDate;
                        }
                    }
                    else if (returnDao == false)
                    {
                        MessageBox.Show("Ocorreu um erro :(", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void BPrevious_Click(object sender, EventArgs e)
        {
            try
            {
                if (!planList.Any())//verifica se está vazio
                {
                    MessageBox.Show("Não há planos para mostrar","Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                if(!tName.ReadOnly && index == 0)//Se for o primeiro percorrimento da lista
                {
                    tName.ReadOnly = true;
                    tStartDate.Enabled = false;
                    tEndDate.Enabled = false;
                    tName.Text = planList[0].Name;
                    tStartDate.Value = planList[0].StartDate;
                    tStartDate.Value = planList[0].EndDate;
                }
                else
                {
                    index--;
                    if (index < 0)
                    {
                        MessageBox.Show("Não há mais planos para mostrar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        index++;
                    }
                    else
                    {
                        tName.ReadOnly = true;
                        tStartDate.Enabled = false;
                        tEndDate.Enabled = false;
                        tName.Text = planList[index].Name;
                        tStartDate.Value = planList[index].StartDate;
                        tStartDate.Value = planList[index].EndDate;
                    }
                }

            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("Ocorreu um erro: " + ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro: " + ex);
            }
        }

        private void BNew_Click(object sender, EventArgs e)
        {
            index = 0;
            tName.ReadOnly = false;
            tStartDate.Enabled = true;
            tEndDate.Enabled = true;
            tName.Text = "";
            tStartDate.Value = DateTime.Now;
            tEndDate.Value = DateTime.Now;
            edit = false;
        }

        private void BEdit_Click(object sender, EventArgs e)
        {
            tName.ReadOnly = false;
            tStartDate.Enabled = true;
            tEndDate.Enabled = true;
            edit = true;
        }

        private void BBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BSearch_Click(object sender, EventArgs e)
        {
            planList = planDao.SearchPlan(tSearch.Text);
            if (!planList.Any()) //se estiver vazio
            {
                MessageBox.Show("Não há planos com este nome", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                planList.Clear();
                planDao.ListAll();
            }
            else
            {
                index = 0;
                tName.ReadOnly = true;
                tStartDate.Enabled = false;
                tEndDate.Enabled = false;
                tName.Text = planList[index].Name;
                tStartDate.Value = planList[index].StartDate;
                tEndDate.Value = planList[index].EndDate;
            }
        }

        private void BListAll_Click(object sender, EventArgs e)
        {
            planDao.ListAll();
            planList = planDao.GetList();
            if (!planList.Any())
            {
                MessageBox.Show("Não há mais planos a serem listados", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                index = 0;
                tName.ReadOnly = true;
                tStartDate.Enabled = false;
                tEndDate.Enabled = false;
                tName.Text = planList[index].Name;
                tStartDate.Value = planList[index].StartDate;
                tEndDate.Value = planList[index].EndDate;
            }
        }
    }
}
