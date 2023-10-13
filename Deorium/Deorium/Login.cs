using System.Windows.Forms;
using static Deorium.Variables;

namespace Deorium
{
    public partial class Login : Form
    {

        Form1 form = new Form1();
        public Login()
        {
            InitializeComponent();
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            userID = txtboxUserID.Text;
            tknBot = txtboxBotToken.Text;

            this.Hide();
            form.Show();
        }
    }
}
