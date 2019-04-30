using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DesafioCSharp
{
    public partial class CRUD : Form
    {
        UserDAO userDao = new UserDAO();
        PlanDAO planDao = new PlanDAO();
        List<Plan> planList = new List<Plan>();
        List<User> userList = new List<User>();
        static int index = 0;
        internal bool edit;

        public CRUD()
        {

            InitializeComponent();
            if (!planList.Any())
            {
                planDao.SelectAll();
                planDao.ListAll();
                planList = planDao.GetList();
            }
            if (!userList.Any())
            {
                userDao.SelectAll();
                userDao.ListAll();
                userList = userDao.GetList();

            }

            cPlan.DataSource = planList;
            cPlan.DisplayMember = "Name";
            cPlan.ValueMember = "Id";
            index = 0;
        }

        public void UpdatePlanList() //atualiza a lista de plano após fechar 'FormPlan'
        {
            planList = planDao.GetList();
        }

        private void BNew_Click(object sender, EventArgs e)
        {
            index = 0;
            tFirstName.ReadOnly = false;
            tLastName.ReadOnly = false;
            cPlan.Enabled = true;
            tBirth.Enabled = true;
            tFirstName.Text = "";
            tLastName.Text = "";
            tBirth.Value = DateTime.Now;
            cPlan.SelectedValue = 1;
            edit = false;
        }

        private void BSave_Click(object sender, EventArgs e)
        {
            if (tFirstName.ReadOnly)
            {
                MessageBox.Show("Crie um novo usuário para salvar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (edit == true)
                {
                    if (tFirstName.Text == "" || tLastName.Text == "" )
                    {
                        MessageBox.Show("Selecione um usuário para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        bool returnDao = userDao.UpdateUser(new User(userList[index].Id,tFirstName.Text, tLastName.Text, tBirth.Value, (int)cPlan.SelectedValue), index);
                        if (returnDao == true)
                        {
                            MessageBox.Show("Usuário editado com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            userDao.ListAll();
                        }
                        else if (returnDao == false)
                        {
                            MessageBox.Show("Ocorreu um erro :(", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    if (tFirstName.Text == "" || tLastName.Text == "")
                    {
                        MessageBox.Show("Preencha os campos necessários.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        bool returnDao = userDao.InsertUser(new User(tFirstName.Text, tLastName.Text, tBirth.Value, (int)cPlan.SelectedValue));
                        if (returnDao == true)
                        {
                            MessageBox.Show("Usuário criado com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            userDao.ListAll();
                        }
                        else
                        {
                            MessageBox.Show("Ocorreu um erro :(", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void BAdd_Click(object sender, EventArgs e)
        {
            FormPlan planF = new FormPlan();
            planF.Show();
        }

        private void BFirst_Click(object sender, EventArgs e)
        {
            bNext.Enabled = true;
            bPrevious.Enabled = false;
            tFirstName.ReadOnly = true;
            tLastName.ReadOnly = true;
            cPlan.Enabled = false;
            tBirth.Enabled = false;
            tFirstName.Text = userList[0].FirstName;
            tLastName.Text = userList[0].LastName;
            cPlan.SelectedValue = userList[0].PlanId;
            index = 0;
        }

        private void BLast_Click(object sender, EventArgs e)
        {
            if (!userList.Any())
            {
                MessageBox.Show("Não há usuários para mostrar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                bPrevious.Enabled = true;
                bNext.Enabled = false;
                tFirstName.ReadOnly = true;
                tLastName.ReadOnly = true;
                cPlan.Enabled = false;
                tBirth.Enabled = false;
                tFirstName.Text = userList[userList.Count()-1].FirstName;
                tLastName.Text = userList[userList.Count() - 1].LastName;
                cPlan.SelectedValue = userList[userList.Count() - 1].PlanId;
                index = userList.Count() - 1;
            }
        }

        private void BPrevious_Click(object sender, EventArgs e)
        {
            try
            {
                if (!userList.Any()) //se n houver inicializado a lista de usuários
                {
                    MessageBox.Show("Não há usuários para mostrar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if(!tFirstName.ReadOnly && index == 0){ //Se for o primeiro percorrimento da lista
                    tFirstName.ReadOnly = true;
                    tLastName.ReadOnly = true;
                    cPlan.Enabled = false;
                    tBirth.Enabled = false;
                    tFirstName.Text = userList[0].FirstName;
                    tLastName.Text = userList[0].LastName;
                    cPlan.SelectedValue = userList[0].PlanId;
                    index = 0;
                }
               if (index < userList.Count())
                {
                    index--;
                    if (index < 0)
                    {
                        MessageBox.Show("Não há usuários para mostrar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        index++;
                    }
                    else
                    {
                        bNext.Enabled = true;
                        tFirstName.ReadOnly = true;
                        tLastName.ReadOnly = true;
                        cPlan.Enabled = false;
                        tBirth.Enabled = false;
                        tFirstName.Text = userList[index].FirstName;
                        tLastName.Text = userList[index].LastName;
                        cPlan.SelectedValue = userList[index].PlanId;
                        tBirth.Value = userList[index].Birth;
                    }
                }
            }catch(NullReferenceException ex)
            {
                Console.WriteLine("Ocorreu um erro:" + ex);
            }catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void BNext_Click(object sender, EventArgs e)
        {
            try
            {
                if (!userList.Any()) //se n houver inicializado a lista de usuários
                {
                    MessageBox.Show("Não há usuários para mostrar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }else 
                if (!tFirstName.ReadOnly && index == 0)
                {
                    tFirstName.ReadOnly = true;
                    tLastName.ReadOnly = true;
                    cPlan.Enabled = false;
                    tBirth.Enabled = false;
                    tFirstName.Text = userList[0].FirstName;
                    tLastName.Text = userList[0].LastName;
                    cPlan.SelectedValue = userList[0].PlanId;
                }else
                if (index < userList.Count())
                {
                    index++;
                    if (index >= userList.Count())
                    {
                        MessageBox.Show("Não há mais usuários para mostrar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        index--;                
                    }
                    else
                    {
                        bPrevious.Enabled = true;
                        tFirstName.ReadOnly = true;
                        tLastName.ReadOnly = true;
                        cPlan.Enabled = false;
                        tBirth.Enabled = false;
                        tFirstName.Text = userList[index].FirstName;
                        tLastName.Text = userList[index].LastName;
                        cPlan.SelectedValue = userList[index].PlanId;
                        tBirth.Value = userList[index].Birth;
                    }
                }
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("Ocorreu um erro:" + ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

        private void BEdit_Click(object sender, EventArgs e)
        {
            edit = true;
            tFirstName.ReadOnly = false;
            tLastName.ReadOnly = false;
            tBirth.Enabled = true;
            cPlan.Enabled = true;
        }

        private void BTrash_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Deseja excluir o usuário?", "Aviso", MessageBoxButtons.YesNo);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                if(tFirstName.Text == ""|| tLastName.Text == "" || tBirth.Value.ToString() == "")
                {
                    MessageBox.Show("Selecione um usuário para deletar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }else
                {
                    bool returnDao = userDao.DeletetUser(userList[index]);
                    if (returnDao == true)
                    {
                        MessageBox.Show("Usuário deletado com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        userDao.ListAll();
                        if (index == 0) //deletou o primeiro
                        {
                            MessageBox.Show("Não há mais usuários. Cadastre um.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            tFirstName.ReadOnly = false;
                            tLastName.ReadOnly = false;
                            tBirth.Enabled = true;
                            cPlan.Enabled = true;
                            tFirstName.Text = "";
                            tLastName.Text = "";
                            tBirth.Value = DateTime.Now;
                            cPlan.SelectedValue = 1;
                        }
                        else if (index > 0)
                        {
                            index--;
                            tFirstName.Text = userList[index].FirstName;
                            tLastName.Text = userList[index].LastName;
                            cPlan.SelectedValue = userList[index].PlanId;
                            tBirth.Value = userList[index].Birth;
                        }
                    }
                    else if (returnDao == false)
                    {
                        MessageBox.Show("Ocorreu um erro :(", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void BSearch_Click(object sender, EventArgs e)
        {
            userList = userDao.Search(tSearch.Text);
            if (!userList.Any())
            {
                MessageBox.Show("Não há usuários com este nome", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                userList.Clear();
                userDao.ListAll();
            }
            else
            {
                index = 0;
                tFirstName.ReadOnly = true;
                tLastName.ReadOnly = true;
                tBirth.Enabled = false;
                cPlan.Enabled = false;
                tFirstName.Text = userList[index].FirstName;
                tLastName.Text = userList[index].LastName;
                tBirth.Value = userList[index].Birth;
                cPlan.SelectedValue = userList[index].PlanId;
            }

        }

        private void TSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if ((Keys)e.KeyCode == Keys.Enter)
            {
                userList = userDao.Search(tSearch.Text);
                if (!userList.Any())
                {
                    MessageBox.Show("Não há usuários com este nome", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    userList.Clear();
                    userDao.ListAll();
                }
                else
                {
                    index = 0;
                    tFirstName.ReadOnly = true;
                    tLastName.ReadOnly = true;
                    tBirth.Enabled = false;
                    cPlan.Enabled = false;
                    tFirstName.Text = userList[index].FirstName;
                    tLastName.Text = userList[index].LastName;
                    tBirth.Value = userList[index].Birth;
                    cPlan.SelectedValue = userList[index].PlanId;
                }
            }
        }

        private void BListAll_Click(object sender, EventArgs e)
        {
            userDao.ListAll();
            userList = userDao.GetList();
            if(!userList.Any()){
                MessageBox.Show("Não há mais usuários a serem listados", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                index = 0;
                tFirstName.ReadOnly = true;
                tLastName.ReadOnly = true;
                tBirth.Enabled = false;
                cPlan.Enabled = false;
                tFirstName.Text = userList[index].FirstName;
                tLastName.Text = userList[index].LastName;
                tBirth.Value = userList[index].Birth;
                cPlan.SelectedValue = userList[index].PlanId;
            }
        }
    }
}
