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
        internal bool edit;
        public FormPlan()
        {
            InitializeComponent();
            index = 0;

        }

        private void BSave_Click(object sender, EventArgs e)
        {
            if (edit == true)
            {
                if (tName.Text == "")
                {
                    MessageBox.Show("Selecione um plano para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    bool returnDao = planDao.UpdatePlan(new Plan(tName.Text, tStartDate.Value, tEndDate.Value), planList[index].Id, index);
                    if (returnDao == true)
                    {
                        MessageBox.Show("Plano atualizado com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    }
                    else if(returnDao == false)
                    {
                        MessageBox.Show("Ocorreu um erro :(", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
                
        }

        private void TSearch_KeyUp(object sender, KeyEventArgs e)
        {
            /*if((Keys)e.KeyCode == Keys.Enter)
            {
                var plan = tSearch.Text 
            }*/
        }

        private void BNext_Click(object sender, EventArgs e)
        {
            try
            {
            if (!planList.Any())
            { 
                planList = planDao.GetList();
                tName.ReadOnly = true;
                tStartDate.Enabled = false;
                tEndDate.Enabled = false;
                tName.Text = planList[0].Name;
                tStartDate.Value = planList[0].StartDate;
                tStartDate.Value = planList[0].EndDate;
            }else
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
            }catch(Exception ex)
            {
                Console.WriteLine("Ocorreu um erro: " + ex);
            }
        }

        private void BDelete_Click(object sender, EventArgs e)
        {
            if (tName.Text == ""|| tStartDate.Value.ToString() == "" || tEndDate.Value.ToString() == "")
            {
                MessageBox.Show("Selecione um plano para deletar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                bool returnDao = planDao.DeletePlan(planList[index]);
                if (returnDao == true)
                {
                    MessageBox.Show("Plano deletado com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else if (returnDao == false)
                {
                    MessageBox.Show("Ocorreu um erro :(", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void BPrevious_Click(object sender, EventArgs e)
        {
            try
            {
                if (!planList.Any())
                {
                    planList = planDao.GetList();
                    tName.ReadOnly = true;
                    tStartDate.Enabled = false;
                    tEndDate.Enabled = false;
                    tName.Text = planList[0].Name;
                    tStartDate.Value = planList[0].StartDate;
                    tStartDate.Value = planList[0].EndDate;
                    index = 0;
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
            tName.Text = "";
            tStartDate.Value = DateTime.Now;
            tEndDate.Value = DateTime.Now;
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
            this.Close();
        }
    }
}
