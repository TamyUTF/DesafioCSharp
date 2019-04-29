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
            planDao.ListAll();
            planList = planDao.GetList();
            Console.WriteLine(planList.Count());
            cPlan.DataSource = planList;
            cPlan.DisplayMember = "Name";
            cPlan.ValueMember = "Id";
            index = 0;
        }

        private void BNew_Click(object sender, EventArgs e)
        {
            index = 0;
            tFirstName.Enabled = true;
            tLastName.Enabled = true;
            cPlan.Enabled = true;
            tBirth.Enabled = true;
            tFirstName.Text = "";
            tLastName.Text = "";
            cPlan.SelectedValue = 1;
        }

        private void BSave_Click(object sender, EventArgs e)
        {
            if (edit == true)
            {
                if (tFirstName.Text == "" || tLastName.Text == "" )
                {
                    MessageBox.Show("Selecione um usuário para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    bool returnDao = userDao.UpdateUser();
                }
            }
            User user = new User(tFirstName.Text, tLastName.Text, tBirth.Value, (int)cPlan.SelectedValue);
            bool userDao = new UserDAO().InsertUser(user);
            if (userDao == true)
            {
                MessageBox.Show("Usuário criado com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Ocorreu um erro :(", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BAdd_Click(object sender, EventArgs e)
        {
            FormPlan planF = new FormPlan();
            planF.Show();
        }

        private void BFirst_Click(object sender, EventArgs e)
        {
            if (!userList.Any())
            {
                userDao.ListAll();
                userList = userDao.GetList();
            }
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
                userDao.ListAll();
                userList = userDao.GetList();
            }
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

        private void BPrevious_Click(object sender, EventArgs e)
        {
            try
            {
                if (!userList.Any()) //se n houver inicializado a lista de usuários
                {
                    userDao.ListAll();
                    userList = userDao.GetList();
                    tFirstName.ReadOnly = true;
                    tLastName.ReadOnly = true;
                    cPlan.Enabled = false;
                    tBirth.Enabled = false;
                    tFirstName.Text = userList[0].FirstName;
                    tLastName.Text = userList[0].LastName;
                    cPlan.SelectedValue = userList[0].PlanId;
                    index = 0;
                }else
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
                    userDao.ListAll();
                    userList = userDao.GetList();
                    tFirstName.ReadOnly = true;
                    tLastName.ReadOnly = true;
                    cPlan.Enabled = false;
                    tBirth.Enabled = false;
                    tFirstName.Text = userList[0].FirstName;
                    tLastName.Text = userList[0].LastName;
                    cPlan.SelectedValue = userList[0].PlanId;
                    index = 0;
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

        }

        private void BTrash_Click(object sender, EventArgs e)
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

                }
                else if (returnDao == false)
                {
                    MessageBox.Show("Ocorreu um erro :(", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
